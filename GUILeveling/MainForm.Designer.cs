namespace GUILeveling
{
    partial class MainForm
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
            this.DataInsertButton = new System.Windows.Forms.Button();
            this.DataDeleteButton = new System.Windows.Forms.Button();
            this.DataUpdataButton = new System.Windows.Forms.Button();
            this.DataInputButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.DataOuterOutputButton = new System.Windows.Forms.Button();
            this.PrintOuterFormButton = new System.Windows.Forms.Button();
            this.readTxTBtn = new System.Windows.Forms.Button();
            this.ProcessInnerBtn = new System.Windows.Forms.Button();
            this.DataInnerPrintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DataInsertButton
            // 
            this.DataInsertButton.Location = new System.Drawing.Point(301, 120);
            this.DataInsertButton.Name = "DataInsertButton";
            this.DataInsertButton.Size = new System.Drawing.Size(186, 55);
            this.DataInsertButton.TabIndex = 13;
            this.DataInsertButton.Text = "插入数据";
            this.DataInsertButton.UseVisualStyleBackColor = true;
            this.DataInsertButton.Click += new System.EventHandler(this.DataInsertButton_Click);
            // 
            // DataDeleteButton
            // 
            this.DataDeleteButton.Location = new System.Drawing.Point(109, 123);
            this.DataDeleteButton.Name = "DataDeleteButton";
            this.DataDeleteButton.Size = new System.Drawing.Size(186, 55);
            this.DataDeleteButton.TabIndex = 12;
            this.DataDeleteButton.Text = "删除数据";
            this.DataDeleteButton.UseVisualStyleBackColor = true;
            this.DataDeleteButton.Click += new System.EventHandler(this.DataDeleteButton_Click);
            // 
            // DataUpdataButton
            // 
            this.DataUpdataButton.Location = new System.Drawing.Point(301, 56);
            this.DataUpdataButton.Name = "DataUpdataButton";
            this.DataUpdataButton.Size = new System.Drawing.Size(186, 55);
            this.DataUpdataButton.TabIndex = 11;
            this.DataUpdataButton.Text = "修改数据";
            this.DataUpdataButton.UseVisualStyleBackColor = true;
            this.DataUpdataButton.Click += new System.EventHandler(this.DataUpdataButton_Click);
            // 
            // DataInputButton
            // 
            this.DataInputButton.Location = new System.Drawing.Point(109, 56);
            this.DataInputButton.Name = "DataInputButton";
            this.DataInputButton.Size = new System.Drawing.Size(186, 55);
            this.DataInputButton.TabIndex = 10;
            this.DataInputButton.Text = "外业数据处理";
            this.DataInputButton.UseVisualStyleBackColor = true;
            this.DataInputButton.Click += new System.EventHandler(this.DataInputButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(301, 306);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(186, 55);
            this.QuitButton.TabIndex = 19;
            this.QuitButton.Text = "退出";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // DataOuterOutputButton
            // 
            this.DataOuterOutputButton.Location = new System.Drawing.Point(301, 184);
            this.DataOuterOutputButton.Name = "DataOuterOutputButton";
            this.DataOuterOutputButton.Size = new System.Drawing.Size(186, 55);
            this.DataOuterOutputButton.TabIndex = 15;
            this.DataOuterOutputButton.Text = "外业数据输出到txt";
            this.DataOuterOutputButton.UseVisualStyleBackColor = true;
            this.DataOuterOutputButton.Click += new System.EventHandler(this.DataOuterOutputButton_Click);
            // 
            // PrintOuterFormButton
            // 
            this.PrintOuterFormButton.Location = new System.Drawing.Point(109, 184);
            this.PrintOuterFormButton.Name = "PrintOuterFormButton";
            this.PrintOuterFormButton.Size = new System.Drawing.Size(186, 55);
            this.PrintOuterFormButton.TabIndex = 14;
            this.PrintOuterFormButton.Text = "显示外业数据";
            this.PrintOuterFormButton.UseVisualStyleBackColor = true;
            this.PrintOuterFormButton.Click += new System.EventHandler(this.PrintOuterFormButton_Click);
            // 
            // readTxTBtn
            // 
            this.readTxTBtn.Location = new System.Drawing.Point(109, 306);
            this.readTxTBtn.Name = "readTxTBtn";
            this.readTxTBtn.Size = new System.Drawing.Size(186, 55);
            this.readTxTBtn.TabIndex = 20;
            this.readTxTBtn.Text = "从txt读取数据";
            this.readTxTBtn.UseVisualStyleBackColor = true;
            this.readTxTBtn.Click += new System.EventHandler(this.readTxTBtn_Click);
            // 
            // ProcessInnerBtn
            // 
            this.ProcessInnerBtn.Location = new System.Drawing.Point(109, 245);
            this.ProcessInnerBtn.Name = "ProcessInnerBtn";
            this.ProcessInnerBtn.Size = new System.Drawing.Size(186, 55);
            this.ProcessInnerBtn.TabIndex = 21;
            this.ProcessInnerBtn.Text = "内业数据处理";
            this.ProcessInnerBtn.UseVisualStyleBackColor = true;
            this.ProcessInnerBtn.Click += new System.EventHandler(this.ProcessInnerBtn_Click);
            // 
            // DataInnerPrintButton
            // 
            this.DataInnerPrintButton.Location = new System.Drawing.Point(301, 245);
            this.DataInnerPrintButton.Name = "DataInnerPrintButton";
            this.DataInnerPrintButton.Size = new System.Drawing.Size(186, 55);
            this.DataInnerPrintButton.TabIndex = 22;
            this.DataInnerPrintButton.Text = "显示内业结果";
            this.DataInnerPrintButton.UseVisualStyleBackColor = true;
            this.DataInnerPrintButton.Click += new System.EventHandler(this.DataInnerPrintButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 481);
            this.Controls.Add(this.DataInnerPrintButton);
            this.Controls.Add(this.ProcessInnerBtn);
            this.Controls.Add(this.readTxTBtn);
            this.Controls.Add(this.DataInsertButton);
            this.Controls.Add(this.DataDeleteButton);
            this.Controls.Add(this.DataUpdataButton);
            this.Controls.Add(this.DataInputButton);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.DataOuterOutputButton);
            this.Controls.Add(this.PrintOuterFormButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水准测量系统";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DataInsertButton;
        private System.Windows.Forms.Button DataDeleteButton;
        private System.Windows.Forms.Button DataUpdataButton;
        private System.Windows.Forms.Button DataInputButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button DataOuterOutputButton;
        private System.Windows.Forms.Button PrintOuterFormButton;
        private System.Windows.Forms.Button readTxTBtn;
        private System.Windows.Forms.Button ProcessInnerBtn;
        private System.Windows.Forms.Button DataInnerPrintButton;
    }
}

