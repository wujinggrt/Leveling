#include <iostream>
#include <fstream>
#include <vector>
#include <iomanip>
#include <limits>
#include <memory>
#include <cmath>
#include <string>

#include "Leveling.h"
#include "DllLeveling.h"

namespace wj{

/********************************************************
class:DllLeveling
********************************************************/

	Leveling * __stdcall CreateLeveling() {
		return new Leveling();
	}

	bool __stdcall DealData(Leveling* leveling_ptr
		, int back_above
		, int back_below
		, int front_above
		, int front_below
		, int back_blackface
		, int front_blackface
		, int back_redface
		, int front_redface) {
		return leveling_ptr->CSharpDealData(back_above
			, back_below
			, front_above
			, front_below
			, back_blackface
			, front_blackface
			, back_redface
			, front_redface);
	}

    bool __stdcall UpdateData(Leveling* leveling_ptr
	    , int station_no
	    , int back_above
	    , int back_below
	    , int front_above
	    , int front_below
	    , int back_blackface
	    , int front_blackface
	    , int back_redface
	    , int front_redface) {
		return leveling_ptr->CSharpUpdateData(station_no
			, back_above
			, back_below
			, front_above
			, front_below
			, back_blackface
			, front_blackface
			, back_redface
			, front_redface);
	}

	bool __stdcall DeleteData(Leveling* leveling_ptr, int station_no) {
		return leveling_ptr->CSharpDeleteData(station_no);
	}

	bool __stdcall InsertData(Leveling* leveling_ptr
	    , int station_no
	    , int back_above
	    , int back_below
	    , int front_above
	    , int front_below
	    , int back_blackface
	    , int front_blackface
	    , int back_redface
	    , int front_redface) {
		return leveling_ptr->CSharpInsertData(station_no
			, back_above
			, back_below
			, front_above
			, front_below
			, back_blackface
			, front_blackface
			, back_redface
			, front_redface);
	}

	bool __stdcall DealTxtData(Leveling * pl, char * fileName)
	{
		return pl->CSharpDealTxtData(fileName);
	}

	bool __stdcall SaveTxt(Leveling * pl, char * fileName)
	{
		return pl->CSharpSaveTxt(fileName);
	}

	bool __stdcall Traverse(Leveling * pl)
	{
		return pl->CSharpTraverse();
	}

	int __stdcall GetStationCount(Leveling * leveling_ptr)
	{
		return leveling_ptr->CSharpGetStationCount();
	}

	int __stdcall GetBackAbove(Leveling* leveling_ptr) {
		return leveling_ptr->CSharpGetBackAbove();
	}

	int __stdcall GetBackBelow(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetBackBelow();
	}

	int __stdcall GetBackBlackface(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetBackBlackFace();
	}
	
	int __stdcall GetBackRedface(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetBackRedFace();
	}

	int __stdcall GetFrontAbove(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetFrontAbove();
	}

	int __stdcall GetFrontBelow(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetFrontBelow();
	}

	int __stdcall GetFrontBlackface(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetFrontBlackFace();
	}

	int __stdcall GetFrontRedface(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetFrontRedFace();
	}

	int __stdcall GetBackDistance(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetBackDistance();
	}

	int __stdcall GetFrontDistance(Leveling * leveling_ptr){
		return leveling_ptr->CSharpGetFrontDistance();
	}

	int __stdcall GetSightDistanceDifference(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetSightDistanceDifference();
	}

	int __stdcall GetAccumulationSightDistanceDifference(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetAccumulationSightDistanceDifference();
	}

	int __stdcall GetBackKBlackRed(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetBackKBlackRed();
	}

	int __stdcall GetFrontKBlackRed(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetFrontKBlackRed();
	}

	int __stdcall GetBlackfaceBackFront(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetBlackfaceBackFront();
	}

	int __stdcall GetRedfaceBackFront(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetRedfaceBackFront();
	}

	int __stdcall GetBackFront(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetBackFront();
	}

	double __stdcall GetMean(Leveling * leveling_ptr) {
		return leveling_ptr->CSharpGetMean();
	}

	bool __stdcall StopData(Leveling * leveling_ptr)
	{
		return leveling_ptr->CSharpStopData();
	}

	void __stdcall DataPrevReset(Leveling * pl)
	{
		return pl->CSharpDataPrevReset();
	}

	void __stdcall DataPrevResetToHead(Leveling * pl)
	{
		return pl->CSharpDataPrevResetToHead();
	}
}