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
    public delegate bool PrintProgress(int value);

    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
        }

        public ProgressForm(System.Windows.Forms.Form prtFrm, int max)
            : this()
        {
            // StartPosition = FormStartPosition.Manual;
            // Location = prtFrm.Location;
            progressBar1.Maximum = max;
        }

        private DataGridView dgv;

        private int percent = 0;

        public bool Increase(int nValue)
        {
            if (nValue > 0)
            {
                if (progressBar1.Value + nValue < progressBar1.Maximum)
                {
                    progressBar1.Value += nValue;
                    percent = progressBar1.Value;
                    label2.Text = percent.ToString();
                    label2.Update();
                    return true;
                }
                else
                {
                    progressBar1.Value = progressBar1.Maximum;
                    this.Close();
                    return false;
                }
            }
            return false;
        }
    }
}
