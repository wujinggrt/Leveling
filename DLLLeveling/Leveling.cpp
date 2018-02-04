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
        , segment_count(0)
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
		, index(0)
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
	    , int front_redface) 
	{
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
        for(int i = 0; i < station_count; ++i) 
		{
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

	bool Leveling::CSharpDealTxtData(const char * fileName)
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

	bool Leveling::CSharpSaveTxt(const char * fileName)
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

	bool Leveling::CSharpProcessInner(
		double beginHeight
		, double endHeight
		, int stationCount
		, const char* stationNo)
	{
		bool b_temp = CSharpProcessHeight(beginHeight, endHeight);
		if (!b_temp)
		{
			return false;
		}
		// return true
		b_temp = CSharpProcessSegment(stationCount, stationNo);
		if (!b_temp)
		{
			return false;
		}
		// return true
		//b_temp = CSharpComputeWeight(3);
		//if (!b_temp)
		//{
		//	return false;
		//}
		return true;
	}

	void Leveling::CSharpClearInner()
	{
		segment_count = 0;
		station.clear();
		correction_of_subsegment.clear();
		distance_of_subsegment.clear();
		observation_elevation_difference_of_subsegment.clear();
		corrected_observation_elevation_difference_of_subsegment.clear();
		accumulation_of_observation_elevation_difference = 0;
		distance = 0;
		closure = 0;
		start_height = 0;
		end_height = 0;
		height.clear();
		accumulation_of_correction = 0;
		index = 0;
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

	int Leveling::CSharpGetStationNo() const
	{
		return station[index];
	}

	double Leveling::CSharpGetDistance() const
	{
		return distance_of_subsegment[index];
	}

	double Leveling::CSharpGetObservedElevation() const
	{
		return observation_elevation_difference_of_subsegment[index];
	}

	double Leveling::CSharpGetCorrection() const
	{
		return correction_of_subsegment[index];
	}

	double Leveling::CSharpGetCorrectedHeight() const
	{
		return corrected_observation_elevation_difference_of_subsegment[index];
	}

	double Leveling::CSharpGetHeight() const
	{
		return height[index + 1];
	}

	int Leveling::CSharpUpdateIndex()
	{
		++index;
		if (index < segment_count)
		{
			return index;
		}
		else
		{
			index = 0;
			return index;
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

	double Leveling::ReserveDecimal(double num, int count) const
	{
		int powerNum = pow(10.0, count + 1) * num;
		int temp = powerNum % 10;
		double ret;
		if (temp < 5)
		{
			ret = powerNum / 10;
			ret /= pow(10.0, count);
		} else if (temp == 5)
		{
			int value = static_cast<int>(powerNum) % 100;
			if (value % 2 == 0)
			{
				ret = powerNum / 10;
				ret /= pow(10.0, count);
			} else
			{
				ret = powerNum / 10 + 1;
				ret /= pow(10.0, count);
			}
		} else
		{
			ret = powerNum / 10 + 1;
			ret /= pow(10.0, count);
		}
		return ret;
	}
	
	bool Leveling::Range(int input)
	{
		if (input < 0 || input > 9999)
			return false;
		return true;
	}

	bool Leveling::CSharpProcessHeight(const double beginHeight
		, const double endHeight)
	{
		// 输入起始高程
		start_height = beginHeight;
		end_height = endHeight;
		auto sp = data_head->next;
		// empty data
		if (!sp)
		{
			return false;
		}
		// 初始化临时高差（mm)
		double temp_observation_elevation_difference = 0.0;
		// 遍历所有node，计算高差
		for (int i = 0; i < station_count; i++)
		{
			temp_observation_elevation_difference
				+= sp->mean;
			distance
				+= (static_cast<double>(sp->front_distance)
					+ static_cast<double>(sp->back_distance))
				/ 10.0;
			sp = sp->next;
		}
		double tempValue = (start_height - end_height) * 1000;
		//高程闭合差(mm)
		closure =
			temp_observation_elevation_difference
			+ tempValue;
		//改正数(mm)
		correction = -closure;
		/*accumulation_of_observation_elevation_difference =
			temp_observation_elevation_difference;*/
		return true;
	}

	bool Leveling::CSharpProcessSegment(const int segmentCount, const char* stationNo)
	{
		// 测段数
		segment_count = segmentCount;
		// 输入每一测段的最后站序号, 用空格将每一组数据隔开
		// 一共有segment + 1 个站点,但是除掉第1个初始站点，也就只剩下segmentNumber个站点
		string s(stationNo);
		istringstream is(s);
		for (int i = 0; i < segment_count; i++)
		{
			int station_num;
			is >> station_num;
			station.push_back(station_num);
		}
		auto sp = data_head->next;
		if (!sp)
		{
			// 需要先输入数据
			return false;
		}
		// 记录每一段的，最后存入到subDistance中
		double temp_distance = 0.0;
		// 记录每一段的高差，存入subObserveElevationDifference中;
		double temp_for_elevation = 0.0;
		// 写入每段距离、每段高差的数据，存入数组
		for (int i = 0, j = 0; i < station_count; i++)
		{
			temp_distance
				+= (static_cast<double>(sp->front_distance)
					+ static_cast<double>(sp->back_distance));
			temp_for_elevation
				+= sp->mean;
			if (i == station[j] - 1)
			{
				// 存储这一的测段距离(m)
				distance_of_subsegment.push_back(temp_distance / 10);
				// 存储这一段的高差
				observation_elevation_difference_of_subsegment.push_back(temp_for_elevation / 1000.0);
				// 重置测段距离
				temp_distance = 0.0;
				// 重置测段高差
				temp_for_elevation = 0.0;
				++j;
			}
			sp = sp->next;
		}
		// 写入每段高差改正数、每段改正后高差，存入数组
		for (int i = 0; i < segment_count; i++)
		{
			// vi
			correction_of_subsegment
				.push_back(ReserveDecimal(
					correction * distance_of_subsegment[i]
					/ distance
					, 3));
			// hi = hi + vi
			corrected_observation_elevation_difference_of_subsegment
				.push_back(ReserveDecimal((
					correction_of_subsegment[i]
					/ 1000)
					// hi,观测,由mean得来
					+ observation_elevation_difference_of_subsegment[i]
					, 3)
				);
		}
		for (int i = 0; i <= segment_count; i++)
		{
			if (i == 0)
			{
				height.push_back(start_height);
				continue;
			}
			// if (i == segment_count)
			// {
			//     height.push_back(end_height);
			//     continue;
			// }
			height.push_back(
				corrected_observation_elevation_difference_of_subsegment[i - 1]
				+ height[i - 1]);
		}
		for (auto &t : correction_of_subsegment)
		{
			accumulation_of_correction += t;
		}
		accumulation_of_observation_elevation_difference = 0.0;
		for (int i = 0; i < segment_count; ++i)
		{
			//高差值和（m）
			accumulation_of_observation_elevation_difference +=
				observation_elevation_difference_of_subsegment[i];
		}
		return true;
	}

	// weight:type(vector<double>)存在问题
	//bool Leveling::CSharpComputeWeight(int count)
	//{
	//	uncertain_station_point = count;
	//	if (distance_of_subsegment.empty())
	//	{
	//		return false;
	//	}
	//	// 赋值权
	//	for (int i = 0; i < segment_count && i < distance_of_subsegment.size(); i++)
	//	{
	//		weight.push_back(1 / distance_of_subsegment[i]);
	//	}
	//	// 计算单位权中差
	//	for (int i = 0, Pvv = 0;
	//		i < segment_count && i < weight.size() && i < correction_of_subsegment.size()
	//		; i++)
	//	{
	//		Pvv = weight[i]
	//			* correction_of_subsegment[i]
	//			* correction_of_subsegment[i];
	//	}
	//	unit_weight
	//		= ReserveDecimal(
	//			static_cast<double>(
	//				sqrt(Pvv
	//					/ (segment_count
	//						- count)))
	//			, 1);
	//	for (int i = 0; i < count && i < weight.size(); i++)
	//	{
	//		each_elevation_error.push_back(
	//			ReserveDecimal(
	//				static_cast<double>(
	//					unit_weight
	//					/ sqrt(weight[i]))
	//				, 1));
	//	}
	//	return true;
	//}

	bool Leveling::CSharpGetInnerResult(char* &data)  const
	{
		string s;
		// s += " 闭合差: f闭 = ";
		s += to_string(
			accumulation_of_observation_elevation_difference);
		s += " ";
		s += to_string(start_height);
		s += " ";
		s += to_string(end_height);
		s += " ";
		s += to_string(closure);
		s += " ";
		s += to_string(distance);
		s += " ";
		double value = sqrt(distance / 1000);
		value *= 20;
		double num_temp = ReserveDecimal(value, 5);
		s += to_string(num_temp);
		if (closure <= num_temp)
		{
			s += " < ";
		} else
		{
			s += " > ";
		}
		/*s += " 单位权中差： μ =  ±√ ";
		s += to_string(Pvv);
		s += " / ";
		s += to_string(segment_count);
		s += " - ";
		s += to_string(uncertain_station_point);
		s += " = ";
		s += to_string(unit_weight);*/
		strcpy_s(data, s.size() + 1, s.c_str());
		return true;
	}
	double Leveling::CSharpGetAccumulationValue() const
	{
		return accumulation_of_observation_elevation_difference;
	}
	double Leveling::CSharpGetClosure() const
	{
		return closure;
	}
	double Leveling::CSharpGetTotalDistance() const
	{
		return distance;
	}
	double Leveling::CSharpGetTolerance() const
	{
		double value = sqrt(distance) / 1000;
		value *= 20;
		double ret = ReserveDecimal(value, 5);
		return ret;
	}
	int Leveling::CSharpGetClosureRelation() const
	{
		if (closure < CSharpGetTolerance())
		{
			return 1;
		}
		else
		{
			return 0;
		}
	}
}