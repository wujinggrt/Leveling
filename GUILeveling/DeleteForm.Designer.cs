namespace GUILeveling
{
    partial class DeleteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.stationNOBox = new System.Windows.Forms.TextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.deleteAllBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入你需要删除的测站序号";
            // 
            // stationNOBox
            // 
            this.stationNOBox.Location = new System.Drawing.Point(119, 154);
            this.stationNOBox.Name = "stationNOBox";
            this.stationNOBox.Size = new System.Drawing.Size(100, 25);
            this.stationNOBox.TabIndex = 3;
            this.stationNOBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stationNOBox_KeyPress);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(179, 227);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(100, 44);
            this.QuitButton.TabIndex = 11;
            this.QuitButton.Text = "退出";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(48, 227);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(100, 44);
            this.delBtn.TabIndex = 12;
            this.delBtn.Text = "删除";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // deleteAllBox
            // 
            this.deleteAllBox.Location = new System.Drawing.Point(303, 227);
            this.deleteAllBox.Name = "deleteAllBox";
            this.deleteAllBox.Size = new System.Drawing.Size(100, 44);
            this.deleteAllBox.TabIndex = 13;
            this.deleteAllBox.Text = "删除所有";
            this.deleteAllBox.UseVisualStyleBackColor = true;
            this.deleteAllBox.Click += new System.EventHandler(this.deleteAllBox_Click);
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 335);
            this.Controls.Add(this.deleteAllBox);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.stationNOBox);
            this.Controls.Add(this.label1);
            this.Name = "DeleteForm";
            this.Text = "删除数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stationNOBox;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button deleteAllBox;
    }
}