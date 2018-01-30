#include <fstream>
#include <vector>
#include <iomanip>
#include <limits>
#include <memory>
#include <iostream>
#include <cmath>
#include <string>
#include <sstream>

#include "Leveling.h"

using namespace std;

namespace wj{
    
/********************************************************
Leveling
********************************************************/

    Leveling::Leveling()
        : data_head(make_shared<LevelingData>())
        // , data_prev(make_shared<LevelingData>())
        , data_next(make_shared<LevelingData>())
        , wptr_data(make_shared<LevelingData>())
        , station_count(0)
        , temp_accumulation_sight_distance_difference(0)
        , temp_observation_elevation_difference(0)
        , station_segment(0)
        // , station(std::vector<int>())
        // , correction_of_subsegment(0.0)
        // , distance_of_subsegment(std::vector<double>())
        // , observation_elevation_difference_of_subsegment(std::vector<double>())
        // , corrected_observation_elevation_difference_of_subsegment(std::vector<double>())
        , accumulation_of_observation_elevation_difference(0.0)
        , distance(0.0)
        , closure(0.0)
        // , weight(std::vector<double>())
        , unit_weight(0.0)
        , Pvv(0)
        , uncertain_station_point(0)
        // , each_elevation_error(vector<double>())
        , correction(0.0)
        , start_height(0.0)
        , end_height(0.0)
        , accumulation_of_correction(0.0)
        // , height(std::vector<double>())
		, status(0)
        {
            station.reserve(20);
            correction_of_subsegment.reserve(20);
			distance_of_subsegment.reserve(20);
            observation_elevation_difference_of_subsegment.reserve(20);
            corrected_observation_elevation_difference_of_subsegment.reserve(20);
            weight.reserve(20);
            each_elevation_error.reserve(20);
            height.reserve(20);
			data_prev = data_head;
        }
    
    Leveling::~Leveling(){
        data_prev.reset();
        data_next.reset();

        // 这是一切链表的起点
        // 根据智能指针的特性，他们会从第一个node开始调用析构函数
        // 一直链式调用下去
        // 但是最后一个（尾结点）指向了head
        // 从而head有两个引用
        // data_head.reset()，是不会链式destruct下去
        // 这里是断开最后一个结点与head的链接
        // 万一没有输入数据，也就是没有数据指向data_head
        if(data_head->prev)
            data_head->prev->next.reset();
        data_head.reset();
    }

	bool Leveling::CSharpDealData(
		int back_above
		, int back_below
		, int front_above
		, int front_below
		, int back_blackface
	    , int front_blackface
	    , int back_redface
	    , int front_redface) {
		data_next = make_shared<LevelingData>();
		// 输入顺序：
		// 1.后视尺：上丝， 2。后视尺：下丝，3.前视尺：上丝，4.前视尺：下丝，
		// 5.后视尺：黑面中丝，6：前视尺:黑面中丝，7：后视尺：红面中丝，8->前视尺：红面中丝
		data_next->back_above = back_above;
		data_next->back_below = back_below;
		data_next->front_above = front_above;
		data_next->front_below = front_below;
		data_next->back_blackface = back_blackface;
		data_next->front_blackface = front_blackface;
		data_next->back_redface = back_redface;
		data_next->front_redface = front_redface;
		// overflow
		if (!Range(data_next->back_above))
		{
			return false;
		}
		if (!Range(data_next->back_below))
		{
			return false;
		}
		if (!Range(data_next->front_above))
		{
			return false;
		}
		if (!Range(data_next->front_below))
		{
			return false;
		}
		if (!Range(data_next->back_blackface))
		{
			return false;
		}
		if (!Range(data_next->front_blackface))
		{
			return false;
		}
		if (!Range(data_next->back_redface))
		{
			return false;
		}
		if (!Range(data_next->front_redface))
		{
			return false;
		}
		ComputeData(data_next);
		// 在最后结束的时候，
		// 最后的一个结点需要返回到哨兵
		data_next->prev = data_prev;
		data_prev->next = data_next;
		data_prev = data_next;
		data_next.reset();
		++station_count;
		return true;
	}

    bool Leveling::CSharpUpdateData(int station_no
            , int back_above
			, int back_below
			, int front_above
			, int front_below
			, int back_blackface
			, int front_blackface
			, int back_redface
			, int front_redface) 
	{
		if (station_no > station_count)
		{
			return false;
		}
        auto sp = data_head;
        for(int i = 0; i < station_count; ++i) {
            sp = sp->next;
        if(i == station_no - 1) {
            sp->back_above = back_above;
            sp->back_below = back_below;
            sp->front_above = front_above;
            sp->front_below = front_below;
            sp->back_blackface = back_blackface;
            sp->front_blackface = front_blackface;
            sp->back_redface = back_redface;
            sp->front_redface = front_redface;
            // 重置temp累计视距差
            temp_accumulation_sight_distance_difference
                = sp->accumulation_sight_distance_difference
                - sp->sight_distance_difference;
            ComputeData(sp);
			data_prev = sp;
            }
		if (i >= station_no)
		{
			ComputeData(sp);
		}
        }
        return true;
    }

    bool Leveling::CSharpDeleteData(int station_no) 
	{
		if (station_no == 0 || station_no > station_count)
		{
			return false;
		}
        auto sp = data_head;
        for(int i = 0; i < station_count; ++i) 
		{
            sp = sp->next;
            if(i == station_no - 1) 
			{
                // 在这个临时存储的累计视距差中，
                // 减去将要删除的这一测站的视距差
                temp_accumulation_sight_distance_difference 
                    = sp->accumulation_sight_distance_difference
                    - sp->sight_distance_difference;
                // 因为接下来需要在这个node上，
                // 取消prev/next对前后node的以来，
                // 避免在以后的析构函数造成影响
                auto temp = sp;
                // 下一个结点的接口
                sp->next->prev = sp->prev;
                // 上一个结点的接口
                sp->prev->next = sp->next;
                temp->prev.reset();
                temp->next.reset();
                ComputeData(sp);
            }
			if (i >= station_no)
			{
				ComputeData(sp);
			}
        }
		--station_count;
        return true;
    }

    bool Leveling::CSharpInsertData(int station_no
            , int back_above
			, int back_below
			, int front_above
			, int front_below
			, int back_blackface
			, int front_blackface
			, int back_redface
			, int front_redface) {
		if (station_no == 0 || station_no > station_count + 1)
		{
			return false;
		}
        auto sp = data_head;
        for(int i = 0; i < station_count; ++i) 
		{
			// 现在sp是第i + 1站的前一个
			// if 完成的任务是：
			// 在插入的测站之前，即是： data_prev data_insert data_this
			// sp代表data_prev
			// 在if末尾，sp赋值为data_insert
            if(i == station_no - 1)
			{
                auto data = make_shared<LevelingData>();
                data->back_above = back_above;
                data->back_below = back_below;
                data->front_above = front_above;
                data->front_below = front_below;
                data->back_blackface = back_blackface;
                data->front_blackface = front_blackface;
                data->back_redface = back_redface;
                data->front_redface = front_redface;
                temp_accumulation_sight_distance_difference 
                    = sp->accumulation_sight_distance_difference;
                data->prev = sp;
                data->next = sp->next;
                sp->next = data;
                data->next->prev = data;
                ComputeData(data);
                sp = data;
				data_prev = sp;
            }
			if (i >= station_no)
			{
				ComputeData(sp->next);
			}
            sp = sp->next;
        }
		++station_count;
        return true;
    }

	bool Leveling::CSharpDealTxtData(char * fileName)
	{
		if (fileName == nullptr)
		{
			return false;
		}

		fstream data_file;
		data_file.open(fileName, ios::in);
		if (data_file.fail())
		{
			return false;
		}
		while (data_file)
		{
			data_next = make_shared<LevelingData>();
			// 用来保存读取的序号，1、2、3 ...
			string temp;
			if (data_file)
			{
				data_file >> temp;
			}
			data_file >> data_next->back_above
				>> data_next->back_below
				>> data_next->front_above
				>> data_next->front_below
				>> data_next->back_blackface
				>> data_next->front_blackface
				>> data_next->back_redface
				>> data_next->front_redface;

			if (!Range(data_next->back_above))
			{
				return false;
			}
			if (!Range(data_next->back_below))
			{
				return false;
			}
			if (!Range(data_next->front_above)) 
			{
				return false;
			}
			if (!Range(data_next->front_below))
			{
				return false;
			}
			if (!Range(data_next->back_blackface))
			{
				return false;
			}
			if (!Range(data_next->front_blackface))
			{
				return false;
			}
			if (!Range(data_next->back_redface))
			{
				return false;
			}
			if (!Range(data_next->front_redface))
			{
				return false;
			}
			ComputeData(data_next);
			data_next->prev = data_prev;
			data_prev->next = data_next;
			data_prev = data_next;
			station_count++;
		}
		// 删除最后一站，因为读入了空数据
		// reset temp...
		temp_accumulation_sight_distance_difference
			= data_prev->prev->accumulation_sight_distance_difference;
		data_prev->prev->next = data_head;
		data_head->prev = data_prev->prev;
		data_prev.reset();
		data_next.reset();
		--station_count;
		return true;
	}

	bool Leveling::CSharpSaveTxt(char * fileName)
	{
		if (fileName == nullptr || fileName == NULL || fileName == "")
		{
			return false;
		}
		fstream dataFile;
		dataFile.open(fileName, ios::out);
		if (dataFile.fail())
		{
			return false;
		}
		auto sp = data_head->next;
		if (!sp)
		{
			return false;
		}
		int count = 1;
		while (sp != data_head)
		{
			dataFile.setf(ios::left);
			dataFile << "\n\n  ";
			dataFile << " 第  ";
			dataFile << count;
			dataFile << "  站\n";
			OutputData(sp, dataFile);
			//强行写入，不关闭文件
			dataFile.flush();
			sp = sp->next;
			count++;
		}
		dataFile.close();
		return true;
	}

	bool Leveling::CSharpTraverse()
	{
		if (data_prev->next == data_head)
		{
			return false;
		}
		data_prev = data_prev->next;
		return true;
	}
	
	int Leveling::CSharpGetStationCount() const 
	{
		return station_count;
	}

    int Leveling::CSharpGetBackAbove() const 
	{
		return data_prev->back_above;
	}

	int Leveling::CSharpGetBackBelow() const 
	{
		return data_prev->back_below;
	}

	int Leveling::CSharpGetBackBlackFace() const 
	{
		return data_prev->back_blackface;
	}
    
	int Leveling::CSharpGetBackRedFace() const 
	{
		return data_prev->back_redface;
	}
    
	int Leveling::CSharpGetFrontAbove() const 
	{
		return data_prev->front_above;
	}
    
	int Leveling::CSharpGetFrontBelow() const 
	{
		return data_prev->front_below;
	}
    
	int Leveling::CSharpGetFrontBlackFace() const 
	{
		return data_prev->front_blackface;
	}
    
	int Leveling::CSharpGetFrontRedFace() const 
	{
		return data_prev->front_redface;
	}
    
	int Leveling::CSharpGetBackDistance() const 
	{
		return data_prev->back_distance;
	}

	int Leveling::CSharpGetFrontDistance() const 
	{
		return data_prev->front_distance;
	}

	int Leveling::CSharpGetSightDistanceDifference() const 
	{
		return data_prev->sight_distance_difference;
	}

	int Leveling::CSharpGetAccumulationSightDistanceDifference() const 
	{
		return data_prev->accumulation_sight_distance_difference;
	}

	int Leveling::CSharpGetBackKBlackRed() const 
	{
		return data_prev->back_subtraction_of_K_plus_blackface_and_redface;
	}

	int Leveling::CSharpGetFrontKBlackRed() const 
	{
		return data_prev->front_subtraction_of_K_plus_blackface_and_redface;
	}

	int Leveling::CSharpGetBlackfaceBackFront() const 
	{
		return data_prev->subtraction_of_blackface_of_back_and_front;
	}

	int Leveling::CSharpGetRedfaceBackFront() const 
	{
		return data_prev->subtraction_of_redface_of_back_and_front;
	}

	int Leveling::CSharpGetBackFront() const 
	{
		return data_prev->subtraction_of_back_and_front;
	}

	double Leveling::CSharpGetMean() const 
	{
		return data_prev->mean;
	}

	bool Leveling::CSharpStopData()
	{
		data_prev->next = data_head;
		data_head->prev = data_prev;
		data_prev = data_head;
		return true;
	}

	void Leveling::CSharpDataPrevReset()
	{
		if (data_prev != data_head->prev && data_head->prev != nullptr)
		{
			data_prev = data_head->prev;
		}
	}

	void Leveling::CSharpDataPrevResetToHead()
	{
		if (data_prev != data_head)
		{
			data_prev = data_head;
		}
	}
	
	void Leveling::ComputeData(shared_ptr<LevelingData> &spld)
	{
		// 用来辅助计算累计视距差
		double temp = 0;

		// 后距
		spld->back_distance
			= spld->back_above
			- spld->back_below;
		// 前距
		spld->front_distance
			= spld->front_above
			- spld->front_below;
		// 视距差
		spld->sight_distance_difference
			= spld->back_distance
			- spld->front_distance;
		// 后视尺：K +黑中丝 - 红中丝
		spld->back_subtraction_of_K_plus_blackface_and_redface
			= spld->back_blackface
			- spld->back_redface + 4787;
		// 调整，是否要取值为4687，以是否大于50来计算
		if (spld->back_subtraction_of_K_plus_blackface_and_redface
			> 50)
			spld->back_subtraction_of_K_plus_blackface_and_redface
			-= 100;
		// 前视尺的K相关计算
		spld->front_subtraction_of_K_plus_blackface_and_redface
			= spld->front_blackface
			- spld->front_redface + 4787;
		if (spld->front_subtraction_of_K_plus_blackface_and_redface
			> 50)
			spld->front_subtraction_of_K_plus_blackface_and_redface
			-= 100;
		// 前后黑/红面中丝之差       
		spld->subtraction_of_blackface_of_back_and_front
			= spld->back_blackface
			- spld->front_blackface;
		spld->subtraction_of_redface_of_back_and_front
			= spld->back_redface
			- spld->front_redface;
		// back_subtraction_of_K_plus_blackface_and_redface
		// -
		// front_subtraction_of_K_plus_blackface_and_redface;
		spld->subtraction_of_back_and_front
			= spld->back_subtraction_of_K_plus_blackface_and_redface
			- spld->front_subtraction_of_K_plus_blackface_and_redface;
		// 计算累计视距差
		temp = static_cast<double>(spld->subtraction_of_back_and_front) / 2;
		spld->mean = static_cast<double>(
			spld->subtraction_of_blackface_of_back_and_front)
			- temp;
		// 这里的累计视距差应该注意，他并非LevelingData中的数据
		// 而是存在这个Leveling对象里面的一个临时数据
		// 因为是需要保存一个累积的类似静态的变量（但是用不着静态变量），所以结构体中的数据达不到这个要求
		// 也就是说，以后每次的累计视距差，会保存在以下的数据里面，然后再来提取
		temp_accumulation_sight_distance_difference
			+= spld->sight_distance_difference;
		// 现在才是计算的结构体中的累计视距差
		spld->accumulation_sight_distance_difference
			= temp_accumulation_sight_distance_difference;
	}

	void Leveling::OutputData(shared_ptr<LevelingData> &spld, ostream &os) const
	{

		// 和iomanip头文件相关操作
		os.setf(ios::left);
		for (int i = 0; i < 82; i++)
			os << '*';
		os << '\n';
		os << setw(81) << " ";
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(12) << spld->back_above;
		os << setw(12) << spld->front_above;
		os << setw(12) << "后 ";
		os << setw(12) << spld->back_blackface;
		os << setw(12) << spld->back_redface;
		os << setw(12) << spld->back_subtraction_of_K_plus_blackface_and_redface;
		os << setw(8) << " ";
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(80) << " ";
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(12) << spld->back_below;
		os << setw(12) << spld->front_below;
		os << setw(12) << "前 ";
		os << setw(12) << spld->front_blackface;
		os << setw(12) << spld->front_redface;
		os << setw(12) << spld->front_subtraction_of_K_plus_blackface_and_redface;
		os << setw(8) << " ";
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(80) << " ";
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(12) << spld->back_distance;
		os << setw(12) << spld->front_distance;
		os << setw(12) << "后 - 前 ";
		os << setw(12) << spld->subtraction_of_blackface_of_back_and_front;
		os << setw(12) << spld->subtraction_of_redface_of_back_and_front;
		os << setw(12) << spld->subtraction_of_back_and_front;
		os.precision(1);
		os.setf(ios::fixed | ios::showpoint);
		os << setw(8) << spld->mean;
		os.unsetf(ios::fixed | ios::showpoint);
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(80) << " ";
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(12) << spld->sight_distance_difference;
		os << setw(12) << spld->accumulation_sight_distance_difference;
		os << setw(48) << " ";
		os << setw(8) << " ";
		os << '*';
		os << endl;
		os << setw(1) << " ";
		os << setw(80) << " ";
		os << '*';
		os << endl;
		for (int i = 0; i < 82; i++)
			os << '*';
		os << endl;
		os.unsetf(ios::left);
	}

	double Leveling::ReserveDecimal(double num, int count)
	{
		// to do
		int numTemp;
		double numPower;
		float numPowerTemp;

		numPower = pow(static_cast<double>(10), count + 1);
		numPowerTemp = static_cast<float>(numPower);
		numTemp = static_cast<int>(num * numPowerTemp) % 10;
		if (numTemp < 4)
		{
			// 类型转化，去掉小数点之后的数
			num = static_cast<int>(num * numPower / 10);
			num = static_cast<float>(static_cast<float>(num) / (numPowerTemp / 10));
		} 		
		else if (numTemp == 5)
		{
			numTemp = static_cast<int>(num * numPowerTemp) % 100;
			if (numTemp % 2 == 0)
			{
				num = static_cast<int>(num * numPower / 10);
				num = static_cast<float>(static_cast<float>(num) / (numPowerTemp / 10));
			} 		
			else
			{
				num = static_cast<int>(num * numPower / 10) + 1;
				num = static_cast<float>(static_cast<float>(num) / (numPowerTemp / 10));
			}
		} 		
		else if (numTemp > 6)
		{
			num = static_cast<int>(num * numPower / 10) + 1;
			num = static_cast<float>(static_cast<float>(num) / (numPowerTemp / 10));
		}

		return num;
	}
	
	bool Leveling::Range(int input)
	{
		if (input < 0 || input > 9999)
			return false;
		return true;
	}
	
}