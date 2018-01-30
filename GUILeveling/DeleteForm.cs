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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
            label1.Font = new Font("宋体", 10, FontStyle.Bold);
        }

        public DeleteForm(System.Windows.Forms.Form ParentForm)
            : this()
        {
            StartPosition = FormStartPosition.Manual;
            Location = ParentForm.Location;
        }

        private int stationNO = 0;
        private void delBtn_Click(object sender, EventArgs e)
        {
            if(stationNOBox.Text == string.Empty)
            {
                MessageBox.Show("数据不能为空！", "ERRO", MessageBoxButtons.OK);
                return;
            }
            stationNO = int.Parse(stationNOBox.Text);
            if(stationNO > MainForm.stationCount || stationNO < 1)
            {
                MessageBox.Show("不存在这样的测站", "ERRO", MessageBoxButtons.OK);
                return;
            }
            DialogResult dr = MessageBox.Show("是否删除第" + stationNO.ToString() + "站？"
                , "提示"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                bool temp = MainForm.DeleteData(MainForm.pl, stationNO);
                if (temp)
                {
                    MessageBox.Show("删除完成");
                    MainForm.stationCount = MainForm.GetStationCount(MainForm.pl);
                    return;
                }
                else
                {
                    MessageBox.Show("无该测站数据");
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stationNOBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void deleteAllBox_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删除所有测站？"
               , "提示"
               , MessageBoxButtons.OKCancel
               , MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                if(MainForm.stationCount == 0)
                {
                    MessageBox.Show("无测站数据");
                    return;
                }
                for(stationNO = 1; MainForm.stationCount > 0; )
                {
                    bool temp = MainForm.DeleteData(MainForm.pl, stationNO);
                    if (temp)
                    {
                        MessageBox.Show("删除完成");
                        MainForm.stationCount = MainForm.GetStationCount(MainForm.pl);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("无该测站数据");
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
