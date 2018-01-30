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

// the tab stop is limited in avilabel textBox and btn
// the textbox is limited in under 4 characters and I try to make it input numbers only,
// so that the filted action only process in textBox instead of click btn.


namespace GUILeveling
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
            stationCountLabel.Text = "第"
                + (MainForm.stationCount + 1).ToString()
                + "站";
            // note this is important
            MainForm.DataPrevReset(MainForm.pl);
        }

        // 窗口出现位置
        public InputForm(System.Windows.Forms.Form ParentForm)
            : this()
        {
            StartPosition = FormStartPosition.Manual;
            Location = ParentForm.Location;
        }

       private void StorageButton_Click(object sender, EventArgs e)
        {
            //如果点击保存时，数据为空，报错
            //循环进行判断
            //判断是否文本框为数字
            if (
                textBox1.Text == string.Empty ||
                textBox2.Text == string.Empty ||
                textBox3.Text == string.Empty ||
                textBox4.Text == string.Empty ||
                textBox5.Text == string.Empty ||
                textBox6.Text == string.Empty ||
                textBox7.Text == string.Empty ||
                textBox8.Text == string.Empty
                )
            {
                MessageBox.Show("保存的数据不能存在空项！");
                return;
            }
            //判断能否转化为int型，即是这个输入是不是数字
            /*
             * 以前的代码，已经用keypress事件代替
            int intTemp = 0;
            if (!int.TryParse(textBox1.Text, out intTemp) ||
                !int.TryParse(textBox2.Text, out intTemp) ||
                !int.TryParse(textBox3.Text, out intTemp) ||
                !int.TryParse(textBox4.Text, out intTemp) ||
                !int.TryParse(textBox5.Text, out intTemp) ||
                !int.TryParse(textBox6.Text, out intTemp) ||
                !int.TryParse(textBox7.Text, out intTemp) ||
                !int.TryParse(textBox8.Text, out intTemp)
                )
            {
                MessageBox.Show("应该输入为数字!");
                return;
            }
            */
            MainForm.ld.backAbove = int.Parse(textBox1.Text);
            MainForm.ld.backBelow = int.Parse(textBox2.Text);
            MainForm.ld.forwardAbove = int.Parse(textBox3.Text);
            MainForm.ld.forwardBelow = int.Parse(textBox4.Text);
            MainForm.ld.backBlackface = int.Parse(textBox5.Text);
            MainForm.ld.forwardBlackface = int.Parse(textBox6.Text);
            MainForm.ld.backRedface = int.Parse(textBox7.Text);
            MainForm.ld.forwardRedface = int.Parse(textBox8.Text);
            bool temp = MainForm.DealData(
                MainForm.pl
                , MainForm.ld.backAbove
                , MainForm.ld.backBelow
                , MainForm.ld.forwardAbove
                , MainForm.ld.forwardBelow
                , MainForm.ld.backBlackface
                , MainForm.ld.forwardBlackface
                , MainForm.ld.backRedface
                , MainForm.ld.forwardRedface
                );
            if (temp == true)
            {
                //改变正在输入的测站数
                MainForm.stationCount = MainForm.GetStationCount(MainForm.pl);
                storageStatusLabel.Text = "第" + MainForm.stationCount.ToString() + "站：保存成功";
                stationCountLabel.Text = "第" + (MainForm.stationCount + 1).ToString() + "站";
            }
            else
            {
                storageStatusLabel.Text = "保存失败";
                return;
            }
            //显示处理后的数据
            //后视距离
            MainForm.ld.backDistance = MainForm.GetBackDistance(MainForm.pl);
            backDistanceBox.Text = MainForm.ld.backDistance.ToString();
            //前视距离
            MainForm.ld.forwardDistance = MainForm.GetForwardDistance(MainForm.pl);
            forwardDistanceBox.Text = MainForm.ld.forwardDistance.ToString();
            //前后视距差
            MainForm.ld.disparityDifference = MainForm.GetDisparityDifference(MainForm.pl);
                disparityDifferenceBox.Text = MainForm.ld.disparityDifference.ToString();
            //累计视距差
            MainForm.ld.accumulatedDifference = MainForm.GetAccumulatedDisparityDifference(MainForm.pl);
            accumulatedDisparityDistanceBox.Text = MainForm.ld.accumulatedDifference.ToString();
            //黑面中丝：后 - 前
            MainForm.ld.blackfaceBackForward = MainForm.GetBlackfaceBackForward(MainForm.pl);
            blackBackForwardBox.Text = System.Environment.NewLine + MainForm.ld.blackfaceBackForward.ToString();
            //红面中丝：后 - 前
            MainForm.ld.redfaceBackForward = MainForm.GetRedfaceBackForward(MainForm.pl);
            redBackForwardBox.Text = "\r\n" + MainForm.ld.redfaceBackForward.ToString();
            //后：黑 + K - 红， 红黑面差
            MainForm.ld.backKBlackRed = MainForm.GetBackKBlackRed(MainForm.pl);
            backBlackRedBox.Text = MainForm.ld.backKBlackRed.ToString();
            //前：黑 + K - 红， 红黑面差
            MainForm.ld.forwardKBlackRed = MainForm.GetForwardKBlackRed(MainForm.pl);
            forwardBlackRedBox.Text = MainForm.ld.forwardKBlackRed.ToString();
            //红黑面之差
            MainForm.ld.backForward = MainForm.GetBackForward(MainForm.pl);
            backFrontBox.Text = "\r\n" + MainForm.ld.backForward.ToString();
            //平均高差
            MainForm.ld.mean = MainForm.GetMean(MainForm.pl);
            meanBox.Text = System.Environment.NewLine + "\r\n" + MainForm.ld.mean.ToString("f1");
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            MainForm.StopData(MainForm.pl);
            this.Close();
        }

        private void ClearTextBoxButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
        }

        // 限制只能输入数字，Backspace
        #region keyPress
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // 非以上键则禁止输入
                // i guess that the event send only if e.Handled equals true.
                // 表示这个事件已经处理过了，不用再处理了（send）
                e.Handled = true;  
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
