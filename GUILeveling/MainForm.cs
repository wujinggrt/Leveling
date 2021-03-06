﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUILeveling
{

    public partial class MainForm : Form
    {

        #region DllImport
        // 创建一个Leveling对象(非托管)
        [DllImport(@"DllLeveling.dll", EntryPoint = "CreateLeveling", CharSet = CharSet.Ansi)]
        public static extern IntPtr CreateLeveling();

        [DllImport(@"DllLeveling.dll", EntryPoint = "DealData", CharSet = CharSet.Ansi)]
        public static extern bool DealData(
            IntPtr pl
            , int backAbove
            , int backBelow
            , int forwardAbove
            , int forwardBelow
            , int backBlackFace
            , int forwardBlackFace
            , int backRedFace
            , int forwardRedFace
            );
        // after stop input action
        // 与PrevReset成对出现
        [DllImport(@"DllLeveling.dll", EntryPoint = "StopData", CharSet = CharSet.Ansi)]
        public static extern bool StopData(IntPtr pl);
        // 
        [DllImport(@"DllLeveling.dll", EntryPoint = "UpdateData", CharSet = CharSet.Ansi)]
        public static extern bool UpdateData(
            IntPtr pl
            , int stationNO
            , int backAbove
            , int backBelow
            , int forwardAbove
            , int forwardBelow
            , int backBlackface
            , int forwardBlackface
            , int backRedface
            , int forwardRedface
            );
        [DllImport(@"DllLeveling.dll", EntryPoint = "DeleteData", CharSet = CharSet.Ansi)]
        public static extern bool DeleteData(IntPtr pl, int stationNO);
        [DllImport(@"DllLeveling.dll", EntryPoint = "DeleteAll", CharSet = CharSet.Ansi)]
        public static extern bool DeleteAll(ref IntPtr pl);
        // 在stationNO之前插入data   
        [DllImport(@"DllLeveling.dll", EntryPoint = "InsertData", CharSet = CharSet.Ansi)]
        public static extern bool InsertData(
            IntPtr pl
            , int stationNO
            , int backAbove
            , int backBelow
            , int forwardAbove
            , int forwardBelow
            , int backBlackface
            , int forwardBlackface
            , int backRedface
            , int forwardRedface
            );
        // save txt
        [DllImport(@"DllLeveling.dll", EntryPoint = "SaveTxt", CharSet = CharSet.Ansi)]
        public static extern bool SaveTxt(IntPtr pl, string fileName);
        // process inner
        [DllImport(@"DllLeveling.dll", EntryPoint = "ProcessInner", CharSet = CharSet.Ansi)]
        public static extern bool ProcessInner(
            IntPtr pl
            , double beginHeight
            , double endHeight
            , int stationCount
            , string stationNo);
        [DllImport(@"DllLeveling.dll", EntryPoint = "ClearInner", CharSet = CharSet.Ansi)]
        public static extern void ClearInner(IntPtr pl);
        // trverse
        [DllImport(@"DllLeveling.dll", EntryPoint = "Traverse", CharSet = CharSet.Ansi)]
        public static extern bool Traverse(IntPtr pl);
        // get 后视尺上丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBackAbove", CharSet = CharSet.Ansi)]
        public static extern int GetBackAbove(IntPtr pl);
        //get 后视尺下丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBackBelow", CharSet = CharSet.Ansi)]
        public static extern int GetBackBelow(IntPtr pl);
        //get 后视尺黑面中丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBackBlackface", CharSet = CharSet.Ansi)]
        public static extern int GetBackBlackface(IntPtr pl);
        //get 后视尺红面中丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBackRedFace", CharSet = CharSet.Ansi)]
        public static extern int GetBackRedFace(IntPtr pl);
        //get 前视尺上丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetFrontAbove", CharSet = CharSet.Ansi)]
        public static extern int GetForwardAbove(IntPtr pl);
        //get 前视尺下丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetFrontBelow", CharSet = CharSet.Ansi)]
        public static extern int GetForwardBelow(IntPtr pl);
        //get 前视尺黑面中丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetFrontBlackface", CharSet = CharSet.Ansi)]
        public static extern int GetForwardBlackface(IntPtr pl);
        //get 前视尺红面中丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetFrontRedface", CharSet = CharSet.Ansi)]
        public static extern int GetForwardRedface(IntPtr pl);
        //get 后视距
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBackDistance", CharSet = CharSet.Ansi)]
        public static extern int GetBackDistance(IntPtr pl);
        //get 前视距
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetFrontDistance", CharSet = CharSet.Ansi)]
        public static extern int GetForwardDistance(IntPtr pl);
        //get 视距差
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetSightDistanceDifference", CharSet = CharSet.Ansi)]
        public static extern int GetDisparityDifference(IntPtr pl);
        //get 累计视距差
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetAccumulationSightDistanceDifference", CharSet = CharSet.Ansi)]
        public static extern int GetAccumulatedDisparityDifference(IntPtr pl);
        //get 后：K+黑 - 红
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBackKBlackRed", CharSet = CharSet.Ansi)]
        public static extern int GetBackKBlackRed(IntPtr pl);
        //get 前：K+黑-红
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetFrontKBlackRed", CharSet = CharSet.Ansi)]
        public static extern int GetForwardKBlackRed(IntPtr pl);
        //get 黑面中丝：后视尺中丝-前视尺中丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBlackfaceBackFront", CharSet = CharSet.Ansi)]
        public static extern int GetBlackfaceBackForward(IntPtr pl);
        //get 红面中丝：后视尺中丝-前视尺中丝
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetRedfaceBackFront", CharSet = CharSet.Ansi)]
        public static extern int GetRedfaceBackForward(IntPtr pl);
        //get 红黑面差
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetBackFront", CharSet = CharSet.Ansi)]
        public static extern int GetBackForward(IntPtr pl);
        // get 高差中数
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetMean", CharSet = CharSet.Ansi)]
        public static extern double GetMean(IntPtr pl);
        // 避免以后输入出现的链表结构混乱
        [DllImport(@"DllLeveling.dll", EntryPoint = "DataPrevReset", CharSet = CharSet.Ansi)]
        public static extern void DataPrevReset(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "DataPrevResetToHead", CharSet = CharSet.Ansi)]
        public static extern void DataPrevResetToHead(IntPtr pl);
        //获取测站数
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetStationCount", CharSet = CharSet.Ansi)]
        public static extern int GetStationCount(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "DealTxtData", CharSet = CharSet.Ansi)]
        public static extern bool DealTxtData(IntPtr pl, string fileName);

        // 获取内业数据，index索引的数据
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetStationNo", CharSet = CharSet.Ansi)]
        public static extern int GetStationNo(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetDistance", CharSet = CharSet.Ansi)]
        public static extern double GetDistance(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetObservedElevation", CharSet = CharSet.Ansi)]
        public static extern double GetObservedElevation(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetCorrection", CharSet = CharSet.Ansi)]
        public static extern double GetCorrection(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetCorrectedHeight", CharSet = CharSet.Ansi)]
        public static extern double GetCorrectedHeight(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetHeight", CharSet = CharSet.Ansi)]
        public static extern double GetHeight(IntPtr pl);
	    // index指向下一个，到尾部重新返回首部
        [DllImport(@"DllLeveling.dll", EntryPoint = "UpdateIndex", CharSet = CharSet.Ansi)]
        public static extern int UpdateIndex(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetInnerResult", CharSet = CharSet.Ansi)]
        public static extern bool GetInnerResult(IntPtr pl, ref string data);

        // 获得内业结果
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetAccumulationValue", CharSet = CharSet.Ansi)]
        public static extern double GetAccumulationValue(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetClosure", CharSet = CharSet.Ansi)]
        public static extern double GetClosure(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetTotalDistance", CharSet = CharSet.Ansi)]
        public static extern double GetTotalDistance(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetTolerance", CharSet = CharSet.Ansi)]
        public static extern double GetTolerance(IntPtr pl);
        [DllImport(@"DllLeveling.dll", EntryPoint = "GetClosureRelation", CharSet = CharSet.Ansi)]
        public static extern int GetClosureRelation(IntPtr pl);
        #endregion

        // use this to return the main form
        // it will be assigned in contructor
        public static MainForm mainForm = null;

        // declarate a IntPtr for Leveling object
        public static IntPtr pl;

        public static LevelingData ld;

        public static int stationCount;

        public static double beginHeight;

        public static double endHeight;

        // 测段数
        public static int segment;

        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
            pl = CreateLeveling();
            ld = new LevelingData();
            stationCount = 0;
            beginHeight = 0.0d;
            endHeight = 0.0;
            segment = 0;
        }

        private void DataInputButton_Click(object sender, EventArgs e)
        {
            var dataInputForm1 = new InputForm(this);
            dataInputForm1.Show();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataUpdataButton_Click(object sender, EventArgs e)
        {
            var updateForm = new UpdateForm(this);
            updateForm.Show();
        }

        private void DataDeleteButton_Click(object sender, EventArgs e)
        {
            var deleteForm = new DeleteForm(this);
            deleteForm.Show();
        }

        private void PrintOuterFormButton_Click(object sender, EventArgs e)
        {
            var printOuterForm = new PrintOuterForm(this);
            printOuterForm.Show();
        }

        private void DataInsertButton_Click(object sender, EventArgs e)
        {
            var insertForm = new InsertForm(this);
            insertForm.Show();
        }

        // 先清空当前数据，然后在添加
        private void readTxTBtn_Click(object sender, EventArgs e)
        {
            MainForm.DeleteAll(ref MainForm.pl);
            stationCount = 0;

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "txt文件(*.txt)|*.txt|dat文件(*.dat)|*.dat"; // 提示1|类型1
            string strPath;//文件完整的路径名
            if (fd.ShowDialog() == DialogResult.OK)
            {
                strPath = fd.FileName;
                bool temp = DealTxtData(pl, strPath);
                if (temp)
                {
                    MessageBox.Show("数据读取并处理完成", "提示", MessageBoxButtons.OK);
                    DataPrevResetToHead(pl);
                    stationCount = GetStationCount(pl);
                    return;
                }
                else
                {
                    MessageBox.Show("读取失败", "ERRO", MessageBoxButtons.OK);
                    DataPrevResetToHead(pl);
                    return;
                }
            }
        }

        // 输出到txt
        private void DataOuterOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter =@"txt文件(*.txt)|*.txt|dat文件(*.dat)|*.dat"; // 提示1|类型1
            string strPath;//文件完整的路径名
            string saveFileName = "蛙蛙";
            sfd.FileName = saveFileName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                strPath = sfd.FileName;
                bool temp = SaveTxt(pl, strPath);
                if (temp)
                {
                    MessageBox.Show("数据输出并存储完成", "提示", MessageBoxButtons.OK);
                    DataPrevResetToHead(pl);
                    stationCount = GetStationCount(pl);
                    return;
                }
                else
                {
                    MessageBox.Show("存取失败", "ERRO", MessageBoxButtons.OK);
                    DataPrevResetToHead(pl);
                    return;
                }
            }
        }

        public static bool innerProcessStatus = false;

        private void ProcessInnerBtn_Click(object sender, EventArgs e)
        {
            ProcessInnerForm processForm = new ProcessInnerForm(this);
            processForm.Show();
        }

        private void DataInnerPrintButton_Click(object sender, EventArgs e)
        {
            PrintInnerForm printInner = new PrintInnerForm(this);
            if (printInner != null)
            {
                printInner.Show();
            }
        }
    }

    public class LevelingData
    {

        // 读取的数据
        // 第二行注释的数据为《数字地形测量学》P.258的表的序号
        // 但其中是上丝 - 下丝
        // 后视尺： 下丝
        // 1
        public int backBelow;
        // 后视尺： 上丝
        // 2
        public int backAbove;
        // 前视尺: 下丝
        // 5
        public int forwardBelow;
        // 前视尺: 上丝
        // 6
        public int forwardAbove;
        // 后视尺黑面中丝
        // 3
        public int backBlackface;
        // 后视尺： 红面中丝
        // 8
        public int backRedface;
        // 前视尺： 黑面中丝
        // 4
        public int forwardBlackface;
        // 前视尺： 红面中丝
        // 7
        public int forwardRedface;

        // 计算得出的数据
        // 后距
        // 12
        // back_above - backBelow
        public int backDistance;
        // 前距
        // 13
        // forward _above - forward Below
        public int forwardDistance;
        // 视距差
        // 14
        // backDistance - forward Distance
        public int disparityDifference;
        // 累积视距差,
        // 15
        // 视距差之和 += sightDistanceDifference
        public int accumulatedDifference;
        // 后： K+黑-红
        // 10
        // K(4687/6787)
        // K + backBlackface - backRedface
        public int backKBlackRed;
        // 前： K+黑-红
        // 9
        // K(4687/4787)
        // K + forward Blackface - forward Redface
        public int forwardKBlackRed;
        // 黑面：后视尺中丝 - 前视尺中丝
        // 16 = 3 - 4
        // backBlackface - forward Blackface
        public int blackfaceBackForward ;
        // 红面： 后视尺中丝 - 前视尺中丝
        // 17 = 8 - 7
        // backRedface - forward Redface;
        public int redfaceBackForward ;
        // 后K+黑-红 - 前K+黑-红
        // 11 = 10 - 9
        // back_subtraction_of_K_plusBlackface_andRedface
        // -
        // forward _subtraction_of_K_plusBlackface_andRedface;
        public int backForward ;
        // 高差中数
        public double mean;
    }
}
