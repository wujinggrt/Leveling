namespace GUILeveling
{
    partial class TestForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.stationLabel = new System.Windows.Forms.Label();
            this.distanceLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.realValueLabel = new System.Windows.Forms.Label();
            this.correctionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.correctedValueLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.getDistanceBtn = new System.Windows.Forms.Button();
            this.segmentLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "station:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "distance:";
            // 
            // quitBtn
            // 
            this.quitBtn.Location = new System.Drawing.Point(516, 520);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(166, 87);
            this.quitBtn.TabIndex = 2;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // stationLabel
            // 
            this.stationLabel.AutoSize = true;
            this.stationLabel.Location = new System.Drawing.Point(28, 54);
            this.stationLabel.Name = "stationLabel";
            this.stationLabel.Size = new System.Drawing.Size(55, 15);
            this.stationLabel.TabIndex = 3;
            this.stationLabel.Text = "label3";
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Location = new System.Drawing.Point(28, 117);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(55, 15);
            this.distanceLabel.TabIndex = 4;
            this.distanceLabel.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "real:";
            // 
            // realValueLabel
            // 
            this.realValueLabel.AutoSize = true;
            this.realValueLabel.Location = new System.Drawing.Point(28, 175);
            this.realValueLabel.Name = "realValueLabel";
            this.realValueLabel.Size = new System.Drawing.Size(119, 15);
            this.realValueLabel.TabIndex = 6;
            this.realValueLabel.Text = "realElevation:";
            // 
            // correctionLabel
            // 
            this.correctionLabel.AutoSize = true;
            this.correctionLabel.Location = new System.Drawing.Point(28, 234);
            this.correctionLabel.Name = "correctionLabel";
            this.correctionLabel.Size = new System.Drawing.Size(47, 15);
            this.correctionLabel.TabIndex = 7;
            this.correctionLabel.Text = "real:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Correction:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "corrected:";
            // 
            // correctedValueLabel
            // 
            this.correctedValueLabel.AutoSize = true;
            this.correctedValueLabel.Location = new System.Drawing.Point(28, 308);
            this.correctedValueLabel.Name = "correctedValueLabel";
            this.correctedValueLabel.Size = new System.Drawing.Size(47, 15);
            this.correctedValueLabel.TabIndex = 10;
            this.correctedValueLabel.Text = "real:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "height:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(28, 373);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(87, 15);
            this.heightLabel.TabIndex = 12;
            this.heightLabel.Text = "corrected:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "status";
            // 
            // getDistanceBtn
            // 
            this.getDistanceBtn.Location = new System.Drawing.Point(303, 520);
            this.getDistanceBtn.Name = "getDistanceBtn";
            this.getDistanceBtn.Size = new System.Drawing.Size(170, 82);
            this.getDistanceBtn.TabIndex = 14;
            this.getDistanceBtn.Text = "GetNext";
            this.getDistanceBtn.UseVisualStyleBackColor = true;
            this.getDistanceBtn.Click += new System.EventHandler(this.getDistanceBtn_Click);
            // 
            // segmentLabel
            // 
            this.segmentLabel.AutoSize = true;
            this.segmentLabel.Location = new System.Drawing.Point(237, 73);
            this.segmentLabel.Name = "segmentLabel";
            this.segmentLabel.Size = new System.Drawing.Size(63, 15);
            this.segmentLabel.TabIndex = 15;
            this.segmentLabel.Text = "segment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "segment NO：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Status：";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 645);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.segmentLabel);
            this.Controls.Add(this.getDistanceBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.correctedValueLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.correctionLabel);
            this.Controls.Add(this.realValueLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.distanceLabel);
            this.Controls.Add(this.stationLabel);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label stationLabel;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label realValueLabel;
        private System.Windows.Forms.Label correctionLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label correctedValueLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button getDistanceBtn;
        private System.Windows.Forms.Label segmentLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}