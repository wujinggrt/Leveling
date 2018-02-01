namespace GUILeveling
{
    partial class ProcessInnerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processBtn = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.stationNoBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.countBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.endBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.beginBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(297, 265);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(100, 44);
            this.processBtn.TabIndex = 14;
            this.processBtn.Text = "处理";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(430, 265);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(100, 44);
            this.QuitButton.TabIndex = 15;
            this.QuitButton.Text = "退出";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "输入每测站段最后一个测站序号，并且用空格分割：";
            // 
            // stationNoBox
            // 
            this.stationNoBox.Location = new System.Drawing.Point(90, 218);
            this.stationNoBox.Name = "stationNoBox";
            this.stationNoBox.Size = new System.Drawing.Size(370, 25);
            this.stationNoBox.TabIndex = 12;
            this.stationNoBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stationNoBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "测站段数：";
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(214, 140);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(73, 25);
            this.countBox.TabIndex = 11;
            this.countBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "终点高程(m)：";
            // 
            // endBox
            // 
            this.endBox.Location = new System.Drawing.Point(214, 98);
            this.endBox.Name = "endBox";
            this.endBox.Size = new System.Drawing.Size(73, 25);
            this.endBox.TabIndex = 9;
            this.endBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.endBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "起始高程(m)：";
            // 
            // beginBox
            // 
            this.beginBox.Location = new System.Drawing.Point(214, 57);
            this.beginBox.Name = "beginBox";
            this.beginBox.Size = new System.Drawing.Size(73, 25);
            this.beginBox.TabIndex = 8;
            this.beginBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.beginBox_KeyPress);
            // 
            // ProcessInnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 381);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stationNoBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.beginBox);
            this.Name = "ProcessInnerForm";
            this.Text = "内业数据处理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stationNoBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox endBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox beginBox;
    }
}