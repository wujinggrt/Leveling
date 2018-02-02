#ifndef DLL_LEVELING_H
#define DLL_LEVELING_H

#ifndef DLL_API
#define DLL_API extern "C" __declspec(dllexport)
#else
#define DLL_API extern "C" __declspec(dllimport)
#endif

namespace wj{

/********************************************************
class:DllLeveling
********************************************************/

    // 创建一个Leveling对象
    DLL_API Leveling* __stdcall CreateLeveling();

    // 输入数据,data_prev指向这个数据
    DLL_API bool __stdcall DealData(Leveling* leveling_ptr
		, int back_above
		, int back_below
		, int front_above
		, int front_below
		, int back_blackface
		, int front_blackface
		, int back_redface
		, int front_redface);
    // 修改数据
    DLL_API bool __stdcall UpdateData(Leveling* leveling_ptr
	    , int station_no
	    , int back_above
	    , int back_below
	    , int front_above
	    , int front_below
	    , int back_blackface
	    , int front_blackface
	    , int back_redface
	    , int front_redface);
    // 删除数据
    DLL_API bool __stdcall DeleteData(Leveling* leveling_ptr, int stationNo);
	DLL_API bool __stdcall DeleteAll(Leveling* &pl);
    // 在输入测站之前插入数据
    DLL_API bool __stdcall InsertData(Leveling* leveling_ptr
	    , int station_no
	    , int back_above
	    , int back_below
	    , int front_above
	    , int front_below
	    , int back_blackface
	    , int front_blackface
	    , int back_redface
	    , int front_redface);
	DLL_API bool __stdcall DealTxtData(Leveling* pl, const char* fileName);
	DLL_API bool __stdcall SaveTxt(Leveling* pl, const char* fileName);
	DLL_API bool __stdcall ProcessInner(
		Leveling* pl
		, double beginHeight
		, double endHeight
		, int stationCount
		, const char* stationNo);
	// 如果存在下一个，data_prev指向它
	DLL_API bool __stdcall Traverse(Leveling* pl);

	// 数据获取
	// 获取测站数
	DLL_API int __stdcall GetStationCount(Leveling* leveling_ptr);
    // 之后get与data_prev有关
    // get 后视尺上丝
	DLL_API int __stdcall GetBackAbove(Leveling* leveling_ptr);
	//get 后视尺下丝
	DLL_API int __stdcall GetBackBelow(Leveling* leveling_ptr);
	//get 后视尺黑面中丝
	DLL_API int __stdcall GetBackBlackface(Leveling* leveling_ptr);
	//get 后视尺红面中丝
	DLL_API int __stdcall GetBackRedface(Leveling* leveling_ptr);
	//get 前视尺上丝
	DLL_API int __stdcall GetFrontAbove(Leveling* leveling_ptr);
	//get 前视尺下丝
	DLL_API int __stdcall GetFrontBelow(Leveling* leveling_ptr);
	//get 前视尺黑面中丝
	DLL_API int __stdcall GetFrontBlackface(Leveling* leveling_ptr);
	//get 前视尺红面中丝
	DLL_API int __stdcall GetFrontRedface(Leveling* leveling_ptr);
	//get 后视距
	DLL_API int __stdcall GetBackDistance(Leveling* leveling_ptr);
	//get 前视距
	DLL_API int __stdcall GetFrontDistance(Leveling* leveling_ptr);
	//get 视距差
	DLL_API int __stdcall GetSightDistanceDifference(Leveling* leveling_ptr);
	//get 累计视距差
	DLL_API int __stdcall GetAccumulationSightDistanceDifference(Leveling* leveling_ptr);
	//get 后：K+黑 - 红
	DLL_API int __stdcall GetBackKBlackRed(Leveling* leveling_ptr);
	//get 前：K+黑-红
	DLL_API int __stdcall GetFrontKBlackRed(Leveling* leveling_ptr);
	//get 黑面中丝：后视尺中丝-前视尺中丝
	DLL_API int __stdcall GetBlackfaceBackFront(Leveling* leveling_ptr);
	//get 红面中丝：后视尺中丝-前视尺中丝
	DLL_API int __stdcall GetRedfaceBackFront(Leveling* leveling_ptr);
	//get 红黑面差
	DLL_API int __stdcall GetBackFront(Leveling* leveling_ptr);
	//get 高差中数
	DLL_API double __stdcall GetMean(Leveling* leveling_ptr);
	DLL_API bool __stdcall GetInnerData(Leveling* pl, char* &data);


	// 停止输入数据时，需要调用。
	DLL_API bool __stdcall StopData(Leveling* leveling_ptr);
	DLL_API void __stdcall DataPrevReset(Leveling* pl);
	DLL_API void __stdcall DataPrevResetToHead(Leveling* pl);

#ifndef NDEBUG

	// for test
	DLL_API bool __stdcall TestOutputInner(Leveling* pl, char* &data);
	DLL_API bool __stdcall TestGetStation(Leveling* pl, char* &data);
	DLL_API bool __stdcall TestGetDistance(Leveling* pl, char* &data);
	DLL_API bool __stdcall TestGetRealElevation(Leveling* pl, char* &data);
	DLL_API bool __stdcall TestGetCorrection(Leveling* pl, char* &data);
	DLL_API bool __stdcall TestGetCorrectedHeight(Leveling* pl, char* &data);
	DLL_API bool __stdcall TestGetHeight(Leveling* pl, char* &data);

#endif
}

#endif