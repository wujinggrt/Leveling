namespace GUILeveling
{
    partial class InsertForm
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
            this.stationNOBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearTextBoxButton = new System.Windows.Forms.Button();
            this.insertStatusLabel = new System.Windows.Forms.Label();
            this.stationCountLabel = new System.Windows.Forms.Label();
            this.stationLabel = new System.Windows.Forms.Label();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.meanBox = new System.Windows.Forms.TextBox();
            this.backForwardBox = new System.Windows.Forms.TextBox();
            this.forwardBlackRedBox = new System.Windows.Forms.TextBox();
            this.backBlackRedBox = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.redBackForwardBox = new System.Windows.Forms.TextBox();
            this.blackBackForwardBox = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.accumulatedDisparityDistanceBox = new System.Windows.Forms.TextBox();
            this.forwardDistanceBox = new System.Windows.Forms.TextBox();
            this.disparityDifferenceBox = new System.Windows.Forms.TextBox();
            this.backDistanceBox = new System.Windows.Forms.TextBox();
            this.StorageLabel = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stationNOBox
            // 
            this.stationNOBox.Location = new System.Drawing.Point(277, 54);
            this.stationNOBox.MaxLength = 4;
            this.stationNOBox.Name = "stationNOBox";
            this.stationNOBox.Size = new System.Drawing.Size(100, 25);
            this.stationNOBox.TabIndex = 0;
            this.stationNOBox.TextChanged += new System.EventHandler(this.stationNOBox_TextChanged);
            this.stationNOBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stationNOBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 186;
            this.label3.Text = "站";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 185;
            this.label2.Text = "第";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 184;
            this.label1.Text = "需要在第几站之前插入？";
            // 
            // ClearTextBoxButton
            // 
            this.ClearTextBoxButton.Location = new System.Drawing.Point(639, 337);
            this.ClearTextBoxButton.Name = "ClearTextBoxButton";
            this.ClearTextBoxButton.Size = new System.Drawing.Size(100, 44);
            this.ClearTextBoxButton.TabIndex = 11;
            this.ClearTextBoxButton.Text = "清空文本框";
            this.ClearTextBoxButton.UseVisualStyleBackColor = true;
            this.ClearTextBoxButton.Click += new System.EventHandler(this.ClearTextBoxButton_Click);
            // 
            // insertStatusLabel
            // 
            this.insertStatusLabel.AutoSize = true;
            this.insertStatusLabel.Location = new System.Drawing.Point(204, 366);
            this.insertStatusLabel.Name = "insertStatusLabel";
            this.insertStatusLabel.Size = new System.Drawing.Size(97, 15);
            this.insertStatusLabel.TabIndex = 183;
            this.insertStatusLabel.Text = "未进行插入！";
            // 
            // stationCountLabel
            // 
            this.stationCountLabel.AutoSize = true;
            this.stationCountLabel.Location = new System.Drawing.Point(204, 324);
            this.stationCountLabel.Name = "stationCountLabel";
            this.stationCountLabel.Size = new System.Drawing.Size(52, 15);
            this.stationCountLabel.TabIndex = 182;
            this.stationCountLabel.Text = "未选择";
            // 
            // stationLabel
            // 
            this.stationLabel.AutoSize = true;
            this.stationLabel.Location = new System.Drawing.Point(107, 324);
            this.stationLabel.Name = "stationLabel";
            this.stationLabel.Size = new System.Drawing.Size(82, 15);
            this.stationLabel.TabIndex = 181;
            this.stationLabel.Text = "正在插入：";
            // 
            // textBox31
            // 
            this.textBox31.BackColor = System.Drawing.SystemColors.Control;
            this.textBox31.Location = new System.Drawing.Point(405, 98);
            this.textBox31.Multiline = true;
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(199, 50);
            this.textBox31.TabIndex = 180;
            this.textBox31.TabStop = false;
            this.textBox31.Text = "\r\n水准尺中丝读数";
            this.textBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(662, 98);
            this.textBox28.MaxLength = 4;
            this.textBox28.Multiline = true;
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(60, 95);
            this.textBox28.TabIndex = 179;
            this.textBox28.TabStop = false;
            this.textBox28.Text = "\r\n平均\r\n\r\n高差\r\n";
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(603, 98);
            this.textBox29.MaxLength = 4;
            this.textBox29.Multiline = true;
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(60, 95);
            this.textBox29.TabIndex = 178;
            this.textBox29.TabStop = false;
            this.textBox29.Text = "\r\n\r\n红黑\r\n面差";
            this.textBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // meanBox
            // 
            this.meanBox.BackColor = System.Drawing.SystemColors.Control;
            this.meanBox.Location = new System.Drawing.Point(662, 192);
            this.meanBox.Multiline = true;
            this.meanBox.Name = "meanBox";
            this.meanBox.ReadOnly = true;
            this.meanBox.Size = new System.Drawing.Size(60, 95);
            this.meanBox.TabIndex = 177;
            this.meanBox.TabStop = false;
            this.meanBox.Text = "\r\n";
            this.meanBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backForwardBox
            // 
            this.backForwardBox.BackColor = System.Drawing.SystemColors.Control;
            this.backForwardBox.Location = new System.Drawing.Point(603, 238);
            this.backForwardBox.Multiline = true;
            this.backForwardBox.Name = "backForwardBox";
            this.backForwardBox.ReadOnly = true;
            this.backForwardBox.Size = new System.Drawing.Size(60, 49);
            this.backForwardBox.TabIndex = 176;
            this.backForwardBox.TabStop = false;
            this.backForwardBox.Text = "\r\n";
            this.backForwardBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // forwardBlackRedBox
            // 
            this.forwardBlackRedBox.Location = new System.Drawing.Point(603, 214);
            this.forwardBlackRedBox.MaxLength = 4;
            this.forwardBlackRedBox.Name = "forwardBlackRedBox";
            this.forwardBlackRedBox.ReadOnly = true;
            this.forwardBlackRedBox.Size = new System.Drawing.Size(60, 25);
            this.forwardBlackRedBox.TabIndex = 175;
            this.forwardBlackRedBox.TabStop = false;
            this.forwardBlackRedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backBlackRedBox
            // 
            this.backBlackRedBox.Location = new System.Drawing.Point(603, 192);
            this.backBlackRedBox.MaxLength = 4;
            this.backBlackRedBox.Name = "backBlackRedBox";
            this.backBlackRedBox.ReadOnly = true;
            this.backBlackRedBox.Size = new System.Drawing.Size(60, 25);
            this.backBlackRedBox.TabIndex = 174;
            this.backBlackRedBox.TabStop = false;
            this.backBlackRedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(306, 98);
            this.textBox30.Multiline = true;
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(100, 95);
            this.textBox30.TabIndex = 173;
            this.textBox30.TabStop = false;
            this.textBox30.Text = "\r\n方\r\n\r\n\r\n向";
            this.textBox30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // redBackForwardBox
            // 
            this.redBackForwardBox.BackColor = System.Drawing.SystemColors.Control;
            this.redBackForwardBox.Location = new System.Drawing.Point(504, 238);
            this.redBackForwardBox.Multiline = true;
            this.redBackForwardBox.Name = "redBackForwardBox";
            this.redBackForwardBox.ReadOnly = true;
            this.redBackForwardBox.Size = new System.Drawing.Size(100, 49);
            this.redBackForwardBox.TabIndex = 172;
            this.redBackForwardBox.TabStop = false;
            this.redBackForwardBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // blackBackForwardBox
            // 
            this.blackBackForwardBox.BackColor = System.Drawing.SystemColors.Control;
            this.blackBackForwardBox.Location = new System.Drawing.Point(405, 238);
            this.blackBackForwardBox.Multiline = true;
            this.blackBackForwardBox.Name = "blackBackForwardBox";
            this.blackBackForwardBox.ReadOnly = true;
            this.blackBackForwardBox.Size = new System.Drawing.Size(100, 49);
            this.blackBackForwardBox.TabIndex = 171;
            this.blackBackForwardBox.TabStop = false;
            this.blackBackForwardBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox27
            // 
            this.textBox27.BackColor = System.Drawing.SystemColors.Control;
            this.textBox27.Location = new System.Drawing.Point(306, 238);
            this.textBox27.Multiline = true;
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(100, 49);
            this.textBox27.TabIndex = 170;
            this.textBox27.TabStop = false;
            this.textBox27.Text = "\r\n后 - 前";
            this.textBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // accumulatedDisparityDistanceBox
            // 
            this.accumulatedDisparityDistanceBox.BackColor = System.Drawing.SystemColors.Control;
            this.accumulatedDisparityDistanceBox.Location = new System.Drawing.Point(207, 262);
            this.accumulatedDisparityDistanceBox.Name = "accumulatedDisparityDistanceBox";
            this.accumulatedDisparityDistanceBox.ReadOnly = true;
            this.accumulatedDisparityDistanceBox.Size = new System.Drawing.Size(100, 25);
            this.accumulatedDisparityDistanceBox.TabIndex = 169;
            this.accumulatedDisparityDistanceBox.TabStop = false;
            this.accumulatedDisparityDistanceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // forwardDistanceBox
            // 
            this.forwardDistanceBox.BackColor = System.Drawing.SystemColors.Control;
            this.forwardDistanceBox.Location = new System.Drawing.Point(207, 238);
            this.forwardDistanceBox.Name = "forwardDistanceBox";
            this.forwardDistanceBox.ReadOnly = true;
            this.forwardDistanceBox.Size = new System.Drawing.Size(100, 25);
            this.forwardDistanceBox.TabIndex = 168;
            this.forwardDistanceBox.TabStop = false;
            this.forwardDistanceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // disparityDifferenceBox
            // 
            this.disparityDifferenceBox.BackColor = System.Drawing.SystemColors.Control;
            this.disparityDifferenceBox.Location = new System.Drawing.Point(110, 262);
            this.disparityDifferenceBox.Name = "disparityDifferenceBox";
            this.disparityDifferenceBox.ReadOnly = true;
            this.disparityDifferenceBox.Size = new System.Drawing.Size(100, 25);
            this.disparityDifferenceBox.TabIndex = 167;
            this.disparityDifferenceBox.TabStop = false;
            this.disparityDifferenceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backDistanceBox
            // 
            this.backDistanceBox.BackColor = System.Drawing.SystemColors.Control;
            this.backDistanceBox.Location = new System.Drawing.Point(110, 238);
            this.backDistanceBox.Name = "backDistanceBox";
            this.backDistanceBox.ReadOnly = true;
            this.backDistanceBox.Size = new System.Drawing.Size(100, 25);
            this.backDistanceBox.TabIndex = 166;
            this.backDistanceBox.TabStop = false;
            this.backDistanceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StorageLabel
            // 
            this.StorageLabel.AutoSize = true;
            this.StorageLabel.Location = new System.Drawing.Point(107, 366);
            this.StorageLabel.Name = "StorageLabel";
            this.StorageLabel.Size = new System.Drawing.Size(82, 15);
            this.StorageLabel.TabIndex = 165;
            this.StorageLabel.Text = "插入状态：";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(504, 146);
            this.textBox21.Multiline = true;
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(100, 47);
            this.textBox21.TabIndex = 164;
            this.textBox21.TabStop = false;
            this.textBox21.Text = "\r\n红面";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(405, 146);
            this.textBox22.Multiline = true;
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(100, 47);
            this.textBox22.TabIndex = 163;
            this.textBox22.TabStop = false;
            this.textBox22.Text = "\r\n黑面";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.SystemColors.Control;
            this.textBox19.Location = new System.Drawing.Point(306, 214);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(100, 25);
            this.textBox19.TabIndex = 153;
            this.textBox19.TabStop = false;
            this.textBox19.Text = "前";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.SystemColors.Control;
            this.textBox20.Location = new System.Drawing.Point(306, 192);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(100, 25);
            this.textBox20.TabIndex = 151;
            this.textBox20.TabStop = false;
            this.textBox20.Text = "后";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.SystemColors.Control;
            this.textBox15.Location = new System.Drawing.Point(207, 168);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(100, 25);
            this.textBox15.TabIndex = 162;
            this.textBox15.TabStop = false;
            this.textBox15.Text = "累计视距差";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.SystemColors.Control;
            this.textBox16.Location = new System.Drawing.Point(207, 146);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(100, 25);
            this.textBox16.TabIndex = 161;
            this.textBox16.TabStop = false;
            this.textBox16.Text = "前视距离";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.SystemColors.Control;
            this.textBox17.Location = new System.Drawing.Point(110, 168);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(100, 25);
            this.textBox17.TabIndex = 160;
            this.textBox17.TabStop = false;
            this.textBox17.Text = "视距差";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.SystemColors.Control;
            this.textBox18.Location = new System.Drawing.Point(110, 146);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(100, 25);
            this.textBox18.TabIndex = 159;
            this.textBox18.TabStop = false;
            this.textBox18.Text = "后视距离";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Location = new System.Drawing.Point(241, 122);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(66, 25);
            this.textBox9.TabIndex = 158;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "下\r\n丝";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Control;
            this.textBox13.Location = new System.Drawing.Point(241, 98);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(66, 25);
            this.textBox13.TabIndex = 157;
            this.textBox13.TabStop = false;
            this.textBox13.Text = "上\r\n丝";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.SystemColors.Control;
            this.textBox14.Location = new System.Drawing.Point(207, 98);
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(37, 50);
            this.textBox14.TabIndex = 156;
            this.textBox14.TabStop = false;
            this.textBox14.Text = "前\r\n尺";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(521, 337);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(100, 44);
            this.QuitButton.TabIndex = 10;
            this.QuitButton.Text = "退出";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(400, 337);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(100, 44);
            this.insertBtn.TabIndex = 9;
            this.insertBtn.Text = "插入";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Control;
            this.textBox10.Location = new System.Drawing.Point(144, 122);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(66, 25);
            this.textBox10.TabIndex = 155;
            this.textBox10.TabStop = false;
            this.textBox10.Text = "下丝";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Location = new System.Drawing.Point(144, 98);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(66, 25);
            this.textBox11.TabIndex = 154;
            this.textBox11.TabStop = false;
            this.textBox11.Text = "上丝";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Control;
            this.textBox12.Location = new System.Drawing.Point(110, 98);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(37, 50);
            this.textBox12.TabIndex = 152;
            this.textBox12.TabStop = false;
            this.textBox12.Text = "后\r\n尺";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(504, 214);
            this.textBox8.MaxLength = 4;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 25);
            this.textBox8.TabIndex = 8;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(504, 192);
            this.textBox7.MaxLength = 4;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 25);
            this.textBox7.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(405, 214);
            this.textBox6.MaxLength = 4;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 25);
            this.textBox6.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(405, 192);
            this.textBox5.MaxLength = 4;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 25);
            this.textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(207, 214);
            this.textBox4.MaxLength = 4;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(207, 192);
            this.textBox3.MaxLength = 4;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(110, 214);
            this.textBox2.MaxLength = 4;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 192);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 1;
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 463);
            this.Controls.Add(this.stationNOBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearTextBoxButton);
            this.Controls.Add(this.insertStatusLabel);
            this.Controls.Add(this.stationCountLabel);
            this.Controls.Add(this.stationLabel);
            this.Controls.Add(this.textBox31);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.textBox29);
            this.Controls.Add(this.meanBox);
            this.Controls.Add(this.backForwardBox);
            this.Controls.Add(this.forwardBlackRedBox);
            this.Controls.Add(this.backBlackRedBox);
            this.Controls.Add(this.textBox30);
            this.Controls.Add(this.redBackForwardBox);
            this.Controls.Add(this.blackBackForwardBox);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.accumulatedDisparityDistanceBox);
            this.Controls.Add(this.forwardDistanceBox);
            this.Controls.Add(this.disparityDifferenceBox);
            this.Controls.Add(this.backDistanceBox);
            this.Controls.Add(this.StorageLabel);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "InsertForm";
            this.Text = "数据插入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox stationNOBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearTextBoxButton;
        private System.Windows.Forms.Label insertStatusLabel;
        private System.Windows.Forms.Label stationCountLabel;
        private System.Windows.Forms.Label stationLabel;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.TextBox meanBox;
        private System.Windows.Forms.TextBox backForwardBox;
        private System.Windows.Forms.TextBox forwardBlackRedBox;
        private System.Windows.Forms.TextBox backBlackRedBox;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox redBackForwardBox;
        private System.Windows.Forms.TextBox blackBackForwardBox;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.TextBox accumulatedDisparityDistanceBox;
        private System.Windows.Forms.TextBox forwardDistanceBox;
        private System.Windows.Forms.TextBox disparityDifferenceBox;
        private System.Windows.Forms.TextBox backDistanceBox;
        private System.Windows.Forms.Label StorageLabel;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}