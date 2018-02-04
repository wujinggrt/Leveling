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
    public partial class ProcessInnerForm : Form
    {
        public ProcessInnerForm()
        {
            InitializeComponent();
        }

        public ProcessInnerForm(System.Windows.Forms.Form prtfrm)
            : this()
        {
            StartPosition = FormStartPosition.Manual;
            Location = prtfrm.Location;
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            if(MainForm.innerProcessStatus == true)
            {
                DialogResult dr = MessageBox.Show("此次行为将会清空上次数据，是否继续？"
                   , "提示"
                   , MessageBoxButtons.OKCancel
                   , MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    MainForm.ClearInner(MainForm.pl);
                }
                else
                {
                    return;
                }
            }
            if (
                beginBox.Text == null
                || beginBox.Text == string.Empty
                || endBox.Text == null
                || endBox.Text == string.Empty
                || countBox.Text == null
                || countBox.Text == string.Empty
                || stationNoBox.Text == null
                || stationNoBox.Text == string.Empty
                )
            {
                MessageBox.Show("数据存在空项", "ERRO", MessageBoxButtons.OK);
                return;
            }
            // 起始高程
            MainForm.beginHeight = double.Parse(beginBox.Text);
            // 终点高程
            MainForm.endHeight = double.Parse(endBox.Text);
            // 总的测段数
            MainForm.segment = int.Parse(countBox.Text);
            if (MainForm.segment > MainForm.stationCount)
            {
                MessageBox.Show("超出总测站数量！", "ERRO", MessageBoxButtons.OK);
                MainForm.innerProcessStatus = false;
                return;
            }
            // 每测段最后一站
            string stationNo = stationNoBox.Text;
            bool temp = MainForm.ProcessInner(
                MainForm.pl
                , MainForm.beginHeight
                , MainForm.endHeight
                , MainForm.segment
                , stationNo);
            if (temp)
            {
                MessageBox.Show("内业数据处理完成！", "提示", MessageBoxButtons.OK);
                this.Close();
                MainForm.innerProcessStatus = true;
                return;
            }
            else
            {
                MessageBox.Show("失败！", "ERRO", MessageBoxButtons.OK);
                MainForm.innerProcessStatus = false;
                return;
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region keypress

        private void beginBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void endBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void countBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void stationNoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 需要空格\32
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
