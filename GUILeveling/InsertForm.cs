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
    public partial class InsertForm : Form
    {
        public InsertForm()
        {
            InitializeComponent();
        }

        public InsertForm(System.Windows.Forms.Form pf)
            : this()
        {
            StartPosition = FormStartPosition.Manual;
            Location = pf.Location;
        }

        private int stationNO = 0;
        private void insertBtn_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("数据不能存在空项！");
                return;
            }
            MainForm.ld.backAbove = int.Parse(textBox1.Text);
            MainForm.ld.backBelow = int.Parse(textBox2.Text);
            MainForm.ld.forwardAbove = int.Parse(textBox3.Text);
            MainForm.ld.forwardBelow = int.Parse(textBox4.Text);
            MainForm.ld.backBlackface = int.Parse(textBox5.Text);
            MainForm.ld.forwardBlackface = int.Parse(textBox6.Text);
            MainForm.ld.backRedface = int.Parse(textBox7.Text);
            MainForm.ld.forwardRedface = int.Parse(textBox8.Text);
            stationNO = int.Parse(stationNOBox.Text);
            if (stationNO < 1 || stationNO > MainForm.stationCount)
            {
                MessageBox.Show("不存在这样的测站！", "ERRO", MessageBoxButtons.OK);
                return;
            }
            bool temp = MainForm.InsertData(
                MainForm.pl
                , stationNO
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
                insertStatusLabel.Text = "第" + stationNO + "站之前：插入成功";
                MainForm.stationCount = MainForm.GetStationCount(MainForm.pl);
            }
            else
            {
                insertStatusLabel.Text = "修改失败";
                MainForm.DataPrevResetToHead(MainForm.pl);
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
            backForwardBox.Text = "\r\n" + MainForm.ld.backForward.ToString();
            //平均高差 
            MainForm.ld.mean = MainForm.GetMean(MainForm.pl);
            meanBox.Text = System.Environment.NewLine + "\r\n" + MainForm.ld.mean.ToString();

            // 这一步很有影响
            MainForm.DataPrevResetToHead(MainForm.pl);
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stationNOBox_TextChanged(object sender, EventArgs e)
        {
            if (stationNOBox.Text == string.Empty)
            {
                stationCountLabel.Text = "未选择";
                return;
            }
            else
            {
                stationCountLabel.Text = "正在插入第" + stationNOBox.Text + "站之前";
            }
        }

        private void stationNOBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void ClearTextBoxButton_Click(object sender, EventArgs e)
        {
            stationNOBox.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            stationCountLabel.Text = "未选择";
        }
    }
}
