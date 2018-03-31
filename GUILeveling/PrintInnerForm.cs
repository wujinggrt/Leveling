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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
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
            // 结果：闭合差部分
            string closureData = "f = ";
            // 高差之和
            closureData += MainForm.GetAccumulationValue(MainForm.pl).ToString("f5");
            closureData += " + ";
            // 起始高程
            closureData += MainForm.beginHeight.ToString("f3");
            closureData += " - ";
            // 终点高程
            closureData += MainForm.endHeight.ToString("f3");
            closureData += " = ";
            // 闭合差的值
            closureData += MainForm.GetClosure(MainForm.pl).ToString("f5");
            closureData += " (mm) ";
            closureLabel.Text = closureData;

            // 结果：限差部分
            string tolerance = "f限 = ±20√";
            // 总距离
            tolerance += MainForm.GetTotalDistance(MainForm.pl).ToString("f3");
            tolerance += " = ";
            // 限差的值
            tolerance += MainForm.GetTolerance(MainForm.pl).ToString("f3") + "(mm)";
            toleranceLabel.Text = tolerance;

            // 闭合差和限差的关系:  < or >
            string relation = "f闭 ";
            int relationStatus = MainForm.GetClosureRelation(MainForm.pl);
            if (relationStatus == 1)
            {
                relation += " < ";
            }
            else
            {
                relation += " > ";
            }
            relation += " f限";
            relationLabel.Text = relation;
        }

        private void outputExcelBtn_Click(object sender, EventArgs e)
        {
            ProgressForm pg = new ProgressForm(this
                , dataGridView1.RowCount * dataGridView1.ColumnCount);
            // 默认fileName
            string fileName = "蛤";
            string saveFileName = "蛙蛙";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            // 这里就传入到了文本框上
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
            //写入标题      
            /*
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            */
            //写入数值
            pg.Show();
            for (int r = 0; r < dataGridView1.Rows.Count; r++)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;
                    pg.Increase(1);
                }
                // DoEvent() 相当于多线程，使得在写入xlsw的时候，这个窗口也能够进行
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);  //fileSaved = true;     
                }
                catch (Exception ex)
                {//fileSaved = false;                      
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);
            xlApp.Quit();
            GC.Collect();//强行销毁   
        }

    }
}
