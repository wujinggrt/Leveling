using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUILeveling
{
    public partial class PrintInnerForm : Form
    {

        // 每段最后一站序号
        private int stationNo;
        // 每段距离
        private double distance;
        // 每段观测高差
        private double realElevation;
        // 每段改正数
        private double correction;
        // 每段改正高差
        private double correctedElevation;
        // 高程
        private double height;

        public PrintInnerForm()
        {
            InitializeComponent();
            SetDGVFormat();
            PrintDGVFirstRow();
            PrintDGVBody();
            PrintResult();
        }

        public PrintInnerForm(System.Windows.Forms.Form prtFrm)
            : this()
        {
            StartPosition = FormStartPosition.Manual;
            Location = prtFrm.Location;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 格式设置：
        // 第一（段号）、二（测站号）列宽自动调整
        // 行头隐藏
        // 不允许用户添加新行
        private void SetDGVFormat()
        {
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        // 第一行信息
        private void PrintDGVFirstRow()
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[1].Value = "1";
            dataGridView1.Rows[0].Cells[6].Value = MainForm.beginHeight.ToString("f3");
        }

        private void GetData()
        {
            stationNo = MainForm.GetStationNo(MainForm.pl);
            distance = MainForm.GetDistance(MainForm.pl);
            realElevation = MainForm.GetObservedElevation(MainForm.pl);
            correction = MainForm.GetCorrection(MainForm.pl);
            correctedElevation = MainForm.GetCorrectedHeight(MainForm.pl);
            height = MainForm.GetHeight(MainForm.pl);

            MainForm.UpdateIndex(MainForm.pl);
        }

        // 把数据写入dgv，传入一个段号参数
        private void PrintDataToDGV(int segmentNo)
        {
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = segmentNo.ToString();
            dataGridView1.Rows[index].Cells[2].Value = distance.ToString("f3");
            dataGridView1.Rows[index].Cells[3].Value = realElevation.ToString("f3");
            dataGridView1.Rows[index].Cells[4].Value = correction.ToString("f3");
            dataGridView1.Rows[index].Cells[5].Value = correctedElevation.ToString("f3");

            index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[1].Value = stationNo.ToString();
            dataGridView1.Rows[index].Cells[6].Value = height.ToString("f3");
        }

        // 打印内容
        private void PrintDGVBody()
        {
            for (int segmentNo = 1; segmentNo <= MainForm.segment; ++segmentNo)
            {
                GetData();
                PrintDataToDGV(segmentNo);
            }
        }

        // 打印结果
        private void PrintResult()
        {
            string innerData = "";
            bool status = MainForm.GetInnerResult(MainForm.pl, ref innerData);
            string[] innerDataSet = innerData.Split();
            // 结果：闭合差部分
            string closureData = "f = ";
            // 高差之和
            closureData += double.Parse(innerDataSet[0]).ToString("f3");
            closureData += " + ";
            // 起始高程
            closureData += double.Parse(innerDataSet[1]).ToString("f3");
            closureData += " - ";
            // 终点高程
            closureData += double.Parse(innerDataSet[2]).ToString("f3");
            closureData += " = ";
            // 闭合差的值
            closureData += double.Parse(innerDataSet[3]).ToString("f3");
            closureData += " (mm) ";
            closureLabel.Text = closureData;

            // 结果：限差部分
            string tolerance = "f限 = ±20√";
            // 总距离
            tolerance += double.Parse(innerDataSet[4]).ToString("f3");
            tolerance += " = ";
            // 限差的值
            tolerance += double.Parse(innerDataSet[5]).ToString("f3");
            toleranceLabel.Text = tolerance;

            // 闭合差和限差的关系:  < or >
            string relation = "f闭 ";
            relation += innerDataSet[6];
            relation += " f限";
            relationLabel.Text = relation;
        }

    }
}
