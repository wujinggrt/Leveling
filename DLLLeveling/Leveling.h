#ifndef LEVELING_H
#define LEVELING_H

namespace wj{
        
/********************************************************
LevelingData 
********************************************************/

    // 将会用在双向链表
    // 这个结构体里面，包含了需要计算的测绘的各种信息
    // 以下的所有数据为观测手薄的表上
	struct LevelingData{

        LevelingData()
            : back_below(0)
            , back_above(0)
            , front_below(0)
            , front_above(0)
            , back_blackface(0) 
            , back_redface(0)
            , front_blackface(0)
            , front_redface(0)
            , back_distance(0)
            , front_distance(0)
            , sight_distance_difference(0)
            , accumulation_sight_distance_difference(0)
            , back_subtraction_of_K_plus_blackface_and_redface(0)
            , front_subtraction_of_K_plus_blackface_and_redface(0)
            , subtraction_of_blackface_of_back_and_front(0)
            , subtraction_of_redface_of_back_and_front(0)
            , subtraction_of_back_and_front(0)
            , mean(0)
            // , prev(nullptr)
            // , next(nullptr)
            {}

        // 读取的数据
        // 第二行注释的数据为《数字地形测量学》P.258的表的序号
        // 但其中是上丝 - 下丝
        // 后视尺： 下丝
        // 1
        int back_below;
        // 后视尺： 上丝
        // 2
        int back_above;
        // 前视尺: 下丝
        // 5
        int front_below;
        // 前视尺: 上丝
        // 6
        int front_above;
        // 后视尺黑面中丝
        // 3
        int back_blackface;
        // 后视尺： 红面中丝
        // 8
        int back_redface;
        // 前视尺： 黑面中丝
        // 4
        int front_blackface;
        // 前视尺： 红面中丝
        // 7
        int	front_redface;

        // 计算得出的数据
        // 后距
        // 12
        // back_above - back_below
        int back_distance;
        // 前距
        // 13
        // front_above - front_below
        int front_distance;
        // 视距差
        // 14
        // back_distance - front_distance
        int sight_distance_difference;
        // 累积视距差,
        // 15
        // 视距差之和 += sight_distance_difference
        int accumulation_sight_distance_difference;
        // 后： K+黑-红
        // 10
        // K(4687/6787)
        // K + back_blackface - back_redface
        int back_subtraction_of_K_plus_blackface_and_redface;
        // 前： K+黑-红
        // 9
        // K(4687/4787)
        // K + front_blackface - front_redface
        int front_subtraction_of_K_plus_blackface_and_redface;
        // 黑面：后视尺中丝 - 前视尺中丝
        // 16 = 3 - 4
        // back_blackface - front_blackface
        int subtraction_of_blackface_of_back_and_front;
        // 红面： 后视尺中丝 - 前视尺中丝
        // 17 = 8 - 7
        // back_redface - front_redface;
        int subtraction_of_redface_of_back_and_front;
        // 后K+黑-红 - 前K+黑-红
        // 11 = 10 - 9
        // back_subtraction_of_K_plus_blackface_and_redface
        // -
        // front_subtraction_of_K_plus_blackface_and_redface;
        int subtraction_of_back_and_front;
        // 高差中数
        double mean;

        // 指针部分
        std::shared_ptr<LevelingData> prev;
        std::shared_ptr<LevelingData> next;
    };

/********************************************************
Leveling
********************************************************/

	class Leveling{

    public:
        Leveling();
        ~Leveling();

		// 外业部分
		// 顺序：
		// 1.后视尺：上丝， 2。后视尺：下丝，3.前视尺：上丝，4.前视尺：下丝，
		// 5.后视尺：黑面中丝，6：前视尺:黑面中丝，7：后视尺：红面中丝，8.前视尺：红面中丝
		bool CSharpDealData(int back_above
			, int back_below
			, int front_above
			, int front_below
			, int back_blackface
			, int front_blackface
			, int back_redface
			, int front_redface);
        bool CSharpUpdateData(int station_no
            , int back_above
			, int back_below
			, int front_above
			, int front_below
			, int back_blackface
			, int front_blackface
			, int back_redface
			, int front_redface);
        bool CSharpDeleteData(int station_no);
        // 在指定测站之前插入
        bool CSharpInsertData(int station_no
            , int back_above
			, int back_below
			, int front_above
			, int front_below
			, int back_blackface
			, int front_blackface
			, int back_redface
			, int front_redface);
		// filename应该是全地址/当前的文件
		bool CSharpDealTxtData(const char* fileName);
		bool CSharpSaveTxt(const char* fileName);
		// 如果data_prev不是最后一个只，设置为下一个
		bool CSharpTraverse();
		
		// 以下为内业部分		
		// data_prev一直去下一个node，until哨兵
		// 用来Output traverse
		// so that Get* method could get entire data from the linked list
		bool CSharpProcessInner(
			double beginHeight
			, int endHeight
			, int stationCount
			, const char* stationNo);
		// 通过改变data完成字符串的数据传递
		bool CSharpGetInnerData(char* &data);

		// 测量数据参数的获取，值为data_prev指向的值
		int CSharpGetStationCount() const;
		// get 后视尺上丝
		int CSharpGetBackAbove() const;	
		//CSharpGet 后视尺下丝
		int CSharpGetBackBelow() const;
		//CSharpGet 后视尺黑面中丝
		int CSharpGetBackBlackFace() const;
		//CSharpGet 后视尺红面中丝
		int CSharpGetBackRedFace() const;
		//CSharpGet 前视尺上丝
		int CSharpGetFrontAbove() const;
		//CSharpGet 前视尺下丝
		int CSharpGetFrontBelow() const;
		//CSharpGet 前视尺黑面中丝
		int CSharpGetFrontBlackFace() const;
		//CSharpGet 前视尺红面中丝
		int CSharpGetFrontRedFace() const;
		//CSharpGet 后视距
		int CSharpGetBackDistance() const;
		//CSharpGet 前视距
		int CSharpGetFrontDistance() const;
		//CSharpGet 视距差
		int CSharpGetSightDistanceDifference() const;
		//CSharpGet 累计视距差
		int CSharpGetAccumulationSightDistanceDifference() const;
		//CSharpGet 后：K+黑 - 红
		int CSharpGetBackKBlackRed() const;
		//CSharpGet 前：K+黑-红
		int CSharpGetFrontKBlackRed() const;
		//CSharpGet 黑面中丝：后视尺中丝-前视尺中丝
		int CSharpGetBlackfaceBackFront() const;
		//CSharpGet 红面中丝：后视尺中丝-前视尺中丝
		int CSharpGetRedfaceBackFront() const;
		//CSharpGet 红黑面差
		int CSharpGetBackFront() const;
		//CSharpGet 高差中数
		double CSharpGetMean() const;
		
		// data_prev赋值data_head
		bool CSharpStopData();
		// data_prev设置为最后一个结点
		void CSharpDataPrevReset();
		// data_prev设置为data_head
		void CSharpDataPrevResetToHead();

    private:

		// 数据处理
		void ComputeData(std::shared_ptr<LevelingData> &spld);
        // 输出数据到流。
        void OutputData(std::shared_ptr<LevelingData> &spld, std::ostream &os = std::cout) const;
        // 保留小数精度运算，四舍六入五取偶，第二个参数为保留的小数位数
        double ReserveDecimal(double num, int count = 3);
        // 辅助检查数据输入范围
        bool Range(int input);

		// 为CSharp输出而辅助的
		bool CSharpProcessInner(double beginHeight, int endHeight);
		bool CSharpProcessCorrection(int stationCount, const char* stationNo);
		// 一般用count = 3
		bool CSharpComputeWeight(int count);
		bool CSharpSaveBodyInnerInfoToString(std::string &s);
		// 添加末尾达到信息
		bool CSharpSaveEndInnerInfoToString(std::string &s);

    private:
    
        // 指针部分
        std::shared_ptr<LevelingData> data_head;
        std::shared_ptr<LevelingData> data_prev;
        std::shared_ptr<LevelingData> data_next;
        std::weak_ptr<LevelingData> wptr_data;

        // 辅助数据部分
        // 测站数
        int station_count;
        // 临时存储累计视距差，用来对LevelingData中的累计视距差进行赋值
        int temp_accumulation_sight_distance_difference;
        // 临时存储高差，用来计算
        int temp_observation_elevation_difference;
        

        // 内业部分
        // 测段数
        int station_segment;
		// 每一测段的最后一站序号
        std::vector<int> station;
        // 每段改正数/mm
        std::vector<double> correction_of_subsegment;
        // 每个测段距离/m
        std::vector<double> distance_of_subsegment;
        // 每段实测高差
        std::vector<double> 
            observation_elevation_difference_of_subsegment;
        // 每段改正后的高差
        std::vector<double> 
            corrected_observation_elevation_difference_of_subsegment;
        // 观测高差之和
        double accumulation_of_observation_elevation_difference;
        // 总距离/m
        double distance;
        // 闭合差/mm
        double closure;
        // 权
        std::vector<double> weight;
        // 单位权中茶
        double unit_weight;
        // 临时存储权中差的计算
        double Pvv;
        // 待定测水准点个数
        int uncertain_station_point;
        // 任一点高程中误差
        std::vector<double> each_elevation_error;
        // 改正数/mm
        double correction;
        // 起点的高程/m，小数点后三位
        double start_height;
        // 终点的高程/m
        double end_height;
        // 高程/m
        std::vector<double> height;
		// 累计改正数
        double accumulation_of_correction;
		// 输出内业数据的辅助判断
		int status;

    };

}
#endif