using System;
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
    // 这个窗口仅仅用来检测ProcessInner数据正确与否
    // 在release后就会在MainForm丢弃对这个窗口的调用
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            Print();
        }

        public TestForm(System.Windows.Forms.Form p)
            : this()
        {
            StartPosition = FormStartPosition.Manual;
            Location = p.Location;
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "TestOutputInner", CharSet = CharSet.Ansi)]
        public static extern bool TestOutputInner(IntPtr pl, ref string data);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "TestGetStation", CharSet = CharSet.Ansi)]
        public static extern bool TestGetStation(IntPtr pl, ref string data);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "TestGetDistance", CharSet = CharSet.Ansi)]
        public static extern bool TestGetDistance(IntPtr pl, ref string data);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "TestGetRealElevation", CharSet = CharSet.Ansi)]
        public static extern bool TestGetRealElevation(IntPtr pl, ref string data);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "TestGetCorrection", CharSet = CharSet.Ansi)]
        public static extern bool TestGetCorrection(IntPtr pl, ref string data);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "TestGetCorrectedHeight", CharSet = CharSet.Ansi)]
        public static extern bool TestGetCorretedHeight(IntPtr pl, ref string data);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "TestGetHeight", CharSet = CharSet.Ansi)]
        public static extern bool TestGetHeight(IntPtr pl, ref string data);

        private void PrintStation()
        {
            string data = "";
            bool status = TestGetStation(MainForm.pl, ref data);
            if(!status)
            {
                return;
            }
            String[] dataSet = data.Split();
            int index = 0;
            int stationCount = int.Parse(dataSet[index++]);
            string text = "";
            for(int i = 0; i < stationCount; ++i)
            {
                text += dataSet[index++] + " ";
            }
            // closure
            text += dataSet[index++] + " ";
            stationLabel.Text = text;
        }

        private void PrintDistance()
        {
            string data = "";
            bool status = TestGetDistance(MainForm.pl, ref data);
            if(!status)
            {
                return;
            }
            String[] dataSet = data.Split();
            int index = 0;
            int distanceCount = int.Parse(dataSet[index++]);
            string distanceText = "";
            for (int i = 0; i < distanceCount; ++i)
            {
                distanceText += dataSet[index++] + " ";
            }
            distanceLabel.Text = distanceText;
        }

        private void PrintRealElevation()
        {
            string data = "";
            bool status = TestGetRealElevation(MainForm.pl, ref data);
            if(!status)
            {
                return;
            }
            String[] dataSet = data.Split();
            int index = 0;
            int realCount = int.Parse(dataSet[index++]);
            string realText = null;
            for (int i = 0; i < realCount; ++i)
            {
                realText += dataSet[index++] + " ";
            }
            realValueLabel.Text = realText;
        }

        private void PrintCorrection()
        {
            string data = "";
            bool status = TestGetCorrection(MainForm.pl, ref data);
            if(!status)
            {
                return;
            }
            String[] dataSet = data.Split();
            int index = 0;
            int correctionCount = int.Parse(dataSet[index++]);
            string correctionText = null;
            for (int i = 0; i < correctionCount; ++i)
            {
                correctionText += dataSet[index++] + " ";
            }
            correctionLabel.Text = correctionText;
        }

        private void PrintCorrectedHeight()
        {
            string data = "";
            bool status = TestGetCorretedHeight(MainForm.pl, ref data);
            if(!status)
            {
                return;
            }
            string[] dataSet = data.Split();
            int index = 0;
            int correctedValueCount = int.Parse(dataSet[index++]);
            string correctedValueText = null;
            for (int i = 0; i < correctedValueCount; ++i)
            {
                correctedValueText += dataSet[index++] + " ";
            }
            correctedValueLabel.Text = correctedValueText;
        }

        private void PrintHeight()
        {
            string data = "";
            bool status = TestGetHeight(MainForm.pl, ref data);
            if(!status)
            {
                return;
            }
            string[] dataSet = data.Split();
            int index = 0;
            int heightCount = int.Parse(dataSet[index++]);
            string heightText = null;
            for (int i = 0; i < heightCount; ++i)
            {
                heightText += dataSet[index++] + " ";
            }
            heightLabel.Text = heightText;
        }

       public void Print()
       {
            PrintStation();
            PrintDistance();
            PrintRealElevation();
            //PrintCorrection();
            //PrintCorrectedHeight();
            //PrintHeight();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }
    }
}
