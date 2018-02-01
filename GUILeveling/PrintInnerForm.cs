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
        public PrintInnerForm()
        {
            InitializeComponent();
            SetDGVFormat();
            PrintDGVFirstRow();
            try
            {
                PrintToDGV();
            }
            catch (Exception)
            {
                MessageBox.Show("程序出现异常", "ERRO", MessageBoxButtons.OK);
                this.Close();
            }
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

        private void SetDGVFormat()
        {
            // format
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
        }

        private void PrintDGVFirstRow()
        {
            dataGridView1.AllowUserToAddRows = false;
            // first rows
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[1].Value = "1";
            dataGridView1.Rows[0].Cells[6].Value = MainForm.beginHeight.ToString("f3");
        }

        private void PrintDGVBody(string innerData)
        {
            if (innerData == null || innerData == string.Empty)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows.Add();
                return;
            }
            string[] innerDataSet = innerData.Split();
            int segmentNo = int.Parse(innerDataSet[0]);
            double distance = double.Parse(innerDataSet[1]);
            double realElevation = double.Parse(innerDataSet[2]);
            double correction = double.Parse(innerDataSet[3]);
            double correctedElevation = double.Parse(innerDataSet[4]);
            int stationNo = int.Parse(innerDataSet[5]);
            double height = double.Parse(innerDataSet[6]);

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

        // to do
        private void PrintResult(string innerData)
        {
            string[] innerDataSet = innerData.Split();
            // 结果：闭合差部分
            string closureData = "f = ";
            // 高差之和
            closureData += innerDataSet[0];
            closureData += " + ";
            // 起始高程
            closureData += innerDataSet[1];
            closureData += " - ";
            // 终点高程
            closureData += innerDataSet[2];
            closureData += " = ";
            // 闭合差的值
            closureData += innerDataSet[3];
            closureData += " (mm) ";
            closureLabel.Text = closureData;

            // 结果：限差部分
            string tolerance = "f限 = ±20√";
            // 总距离
            tolerance += innerDataSet[4];
            tolerance += " = ";
            // 限差的值
            tolerance += innerDataSet[5];
            toleranceLabel.Text = tolerance;

            // 闭合差和限差的关系:  < or >
            string relation = "f闭 ";
            relation += innerDataSet[6];
            relation += " f限";
            relationLabel.Text = relation;
        }

        // 每测段数据占两行
        private void PrintToDGV()
        {
            for (int segment = 1; segment <= MainForm.segment; ++segment)
            {
                string innerData = "蛤蛤";
                bool temp = MainForm.GetInnerData(MainForm.pl, ref innerData);
                if (temp)
                {
                    PrintDGVBody(innerData);
                }
                else // data traverse at end
                {
                    if (segment != MainForm.segment)
                    {
                        statusLabel.Text = "false";
                        return;
                    }
                    PrintResult(innerData);
                    return;
                }
            }
        }
    }
}
