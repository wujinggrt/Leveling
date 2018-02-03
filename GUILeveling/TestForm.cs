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

        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "GetStationNo", CharSet = CharSet.Ansi)]
        public static extern int GetStationNo(IntPtr pl);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "GetDistance", CharSet = CharSet.Ansi)]
        public static extern double GetDistance(IntPtr pl);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "GetObservedElevation", CharSet = CharSet.Ansi)]
        public static extern double GetObservedElevation(IntPtr pl);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "GetCorrection", CharSet = CharSet.Ansi)]
        public static extern double GetCorrection(IntPtr pl);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "GetCorrectedHeight", CharSet = CharSet.Ansi)]
        public static extern double GetCorrectedHeight(IntPtr pl);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "GetHeight", CharSet = CharSet.Ansi)]
        public static extern double GetHeight(IntPtr pl);
        [DllImport(@"F:\Workspace\Leveling\nowWork\Leveling\Debug\DllLeveling.dll", EntryPoint = "UpdateIndex", CharSet = CharSet.Ansi)]
        public static extern int UpdateIndex(IntPtr pl);

        private void getDistanceBtn_Click(object sender, EventArgs e)
        {
            stationLabel.Text = GetStationNo(MainForm.pl).ToString();
            distanceLabel.Text = GetDistance(MainForm.pl).ToString("f3");
            realValueLabel.Text = GetObservedElevation(MainForm.pl).ToString("f3");
            correctionLabel.Text = GetCorrection(MainForm.pl).ToString("f3");
            correctedValueLabel.Text = GetCorrectedHeight(MainForm.pl).ToString("f3");
            heightLabel.Text = GetHeight(MainForm.pl).ToString("f3");
            int segment = UpdateIndex(MainForm.pl);
            if (segment != 0)
            {
                segmentLabel.Text = segment.ToString();
            }
            else
            {
                segmentLabel.Text = MainForm.segment.ToString();
            }
        }
    }
}
