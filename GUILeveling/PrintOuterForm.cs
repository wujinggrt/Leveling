using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace GUILeveling
{
    public partial class PrintOuterForm : Form
    {
        public PrintOuterForm()
        {
            InitializeComponent();
            PrintToDataGridView();
        }

        public PrintOuterForm(System.Windows.Forms.Form ParentForm)
            : this()
        {
            StartPosition = FormStartPosition.Manual;
            Location = ParentForm.Location;
        }

        private void PrintToDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;

            MainForm.DataPrevResetToHead(MainForm.pl);
            // format
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            for (int stationNO = 1; MainForm.Traverse(MainForm.pl) && stationNO <= MainForm.stationCount; ++stationNO)
            {
                MainForm.ld.backAbove = MainForm.GetBackAbove(MainForm.pl);
                MainForm.ld.backBelow = MainForm.GetBackBelow(MainForm.pl);
                MainForm.ld.forwardAbove = MainForm.GetForwardAbove(MainForm.pl);
                MainForm.ld.forwardBelow = MainForm.GetForwardBelow(MainForm.pl);
                MainForm.ld.backBlackface = MainForm.GetBackBlackface(MainForm.pl);
                MainForm.ld.backRedface = MainForm.GetForwardRedface(MainForm.pl);
                MainForm.ld.forwardBlackface = MainForm.GetForwardBlackface(MainForm.pl);
                MainForm.ld.forwardRedface = MainForm.GetForwardRedface(MainForm.pl);
                //后视距离
                MainForm.ld.backDistance = MainForm.GetBackDistance(MainForm.pl);
                //前视距离
                MainForm.ld.forwardDistance = MainForm.GetForwardDistance(MainForm.pl);
                //前后视距差
                MainForm.ld.disparityDifference = MainForm.GetDisparityDifference(MainForm.pl);
                //累计视距差
                MainForm.ld.accumulatedDifference = MainForm.GetAccumulatedDisparityDifference(MainForm.pl);
                //黑面中丝：后 - 前
                MainForm.ld.blackfaceBackForward = MainForm.GetBlackfaceBackForward(MainForm.pl);
                //红面中丝：后 - 前
                MainForm.ld.redfaceBackForward = MainForm.GetRedfaceBackForward(MainForm.pl);
                //后：黑 + K - 红， 红黑面差
                MainForm.ld.backKBlackRed = MainForm.GetBackKBlackRed(MainForm.pl);
                //前：黑 + K - 红， 红黑面差
                MainForm.ld.forwardKBlackRed = MainForm.GetForwardKBlackRed(MainForm.pl);
                //红黑面之差
                MainForm.ld.backForward = MainForm.GetBackForward(MainForm.pl);
                //平均高差
                MainForm.ld.mean = MainForm.GetMean(MainForm.pl);

                int y = dataGridView1.Rows.Add();
                dataGridView1.Rows[y].Cells[0].Value = stationNO.ToString();
                dataGridView1.Rows[y].Cells[1].Value = MainForm.ld.backAbove.ToString();
                dataGridView1.Rows[y].Cells[2].Value = MainForm.ld.forwardAbove.ToString();
                dataGridView1.Rows[y].Cells[3].Value = "后";
                dataGridView1.Rows[y].Cells[4].Value = MainForm.ld.backBlackface.ToString();
                dataGridView1.Rows[y].Cells[5].Value = MainForm.ld.backRedface.ToString();
                dataGridView1.Rows[y].Cells[6].Value = MainForm.ld.backKBlackRed.ToString();
                dataGridView1.Rows[y].Cells[7].Value = null;

                y = dataGridView1.Rows.Add();
                dataGridView1.Rows[y].Cells[1].Value = MainForm.ld.backBelow.ToString();
                dataGridView1.Rows[y].Cells[2].Value = MainForm.ld.forwardBelow.ToString();
                dataGridView1.Rows[y].Cells[3].Value = "前";
                dataGridView1.Rows[y].Cells[4].Value = MainForm.ld.forwardBlackface.ToString();
                dataGridView1.Rows[y].Cells[5].Value = MainForm.ld.forwardRedface.ToString();
                dataGridView1.Rows[y].Cells[6].Value = MainForm.ld.forwardKBlackRed.ToString();
                dataGridView1.Rows[y].Cells[7].Value = null;

                y = dataGridView1.Rows.Add();
                dataGridView1.Rows[y].Cells[1].Value = MainForm.ld.backDistance.ToString();
                dataGridView1.Rows[y].Cells[2].Value = MainForm.ld.forwardDistance.ToString();
                dataGridView1.Rows[y].Cells[3].Value = "后 - 前";
                dataGridView1.Rows[y].Cells[4].Value = MainForm.ld.blackfaceBackForward.ToString();
                dataGridView1.Rows[y].Cells[5].Value = MainForm.ld.redfaceBackForward.ToString();
                dataGridView1.Rows[y].Cells[6].Value = MainForm.ld.backForward.ToString();
                dataGridView1.Rows[y].Cells[7].Value = MainForm.ld.mean.ToString("f1");

                y = dataGridView1.Rows.Add();
                dataGridView1.Rows[y].Cells[1].Value = MainForm.ld.disparityDifference.ToString();
                dataGridView1.Rows[y].Cells[2].Value = MainForm.ld.accumulatedDifference.ToString();
                dataGridView1.Rows[y].Cells[3].Value = null;
                dataGridView1.Rows[y].Cells[4].Value = null;
                dataGridView1.Rows[y].Cells[5].Value = null;
                dataGridView1.Rows[y].Cells[6].Value = null;
                dataGridView1.Rows[y].Cells[7].Value = null;
            }
            MainForm.DataPrevResetToHead(MainForm.pl);
        }

        // 对于progressBar增长值
       

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void outputExcelBtn_Click(object sender, EventArgs e)
        {
            ProgressForm pg = new ProgressForm(this
                , dataGridView1.RowCount * dataGridView1.ColumnCount);
            // 默认fileName
            string fileName = "蛤蛤";
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

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            PrintToDataGridView();
        }

        // 想办法给printProgress赋值ProgressForm的Increase方法
        // public PrintProgress printProgress;
    }
}
