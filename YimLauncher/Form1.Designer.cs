namespace YimLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            groupBox1 = new GroupBox();
            label11 = new Label();
            label10 = new Label();
            button8 = new Button();
            groupBox2 = new GroupBox();
            button16 = new Button();
            button12 = new Button();
            label6 = new Label();
            groupBox3 = new GroupBox();
            label7 = new Label();
            groupBox4 = new GroupBox();
            button3 = new Button();
            label9 = new Label();
            label8 = new Label();
            groupBox5 = new GroupBox();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            groupBox6 = new GroupBox();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button15 = new Button();
            button14 = new Button();
            timer3 = new System.Windows.Forms.Timer(components);
            label12 = new Label();
            label13 = new Label();
            button13 = new Button();
            label14 = new Label();
            groupBox7 = new GroupBox();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(6, 197);
            button1.Name = "button1";
            button1.Size = new Size(146, 29);
            button1.TabIndex = 0;
            button1.Text = "注入测试(汉化版)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(6, 119);
            button2.Name = "button2";
            button2.Size = new Size(181, 29);
            button2.TabIndex = 1;
            button2.Text = "下载并更新所有文件";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 2;
            label1.Text = "Yimmenu dll";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Coral;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 3;
            label2.Text = "语言索引";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Coral;
            label3.Location = new Point(6, 83);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 4;
            label3.Text = "中文语言文件";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 23);
            label4.Name = "label4";
            label4.Size = new Size(188, 20);
            label4.TabIndex = 5;
            label4.Text = "文件完整性检查:(即将检查)";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 155);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 6;
            label5.Text = "label5";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(button8);
            groupBox1.Location = new Point(12, 288);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(357, 301);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Yim日志分析-开发中";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 91);
            label11.Name = "label11";
            label11.Size = new Size(62, 20);
            label11.TabIndex = 14;
            label11.Text = "label11";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 59);
            label10.Name = "label10";
            label10.Size = new Size(62, 20);
            label10.TabIndex = 13;
            label10.Text = "label10";
            // 
            // button8
            // 
            button8.Location = new Point(6, 26);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 12;
            button8.Text = "开始检查";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button16);
            groupBox2.Controls.Add(button12);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(357, 270);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "文件检查";
            // 
            // button16
            // 
            button16.Location = new Point(158, 197);
            button16.Name = "button16";
            button16.Size = new Size(153, 29);
            button16.TabIndex = 9;
            button16.Text = "注入测试(官方版)";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button12
            // 
            button12.Location = new Point(224, 232);
            button12.Name = "button12";
            button12.Size = new Size(127, 29);
            button12.TabIndex = 8;
            button12.Text = "强制退出GTA";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 236);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 7;
            label6.Text = "GTA5未运行";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(402, 14);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(353, 101);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "干扰项检查";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 30);
            label7.Name = "label7";
            label7.Size = new Size(53, 20);
            label7.TabIndex = 11;
            label7.Text = "label7";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button3);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label8);
            groupBox4.Location = new Point(404, 123);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(351, 133);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "游戏和SC版本检查";
            // 
            // button3
            // 
            button3.ForeColor = Color.Red;
            button3.Location = new Point(6, 96);
            button3.Name = "button3";
            button3.Size = new Size(146, 31);
            button3.TabIndex = 2;
            button3.Text = "卸载GTA5启动器";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 44);
            label9.Name = "label9";
            label9.Size = new Size(59, 20);
            label9.TabIndex = 1;
            label9.Text = "无网络!";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 23);
            label8.Name = "label8";
            label8.Size = new Size(53, 20);
            label8.TabIndex = 0;
            label8.Text = "label8";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button7);
            groupBox5.Controls.Add(button6);
            groupBox5.Controls.Add(button5);
            groupBox5.Controls.Add(button4);
            groupBox5.Location = new Point(404, 262);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(351, 183);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "配置清除";
            // 
            // button7
            // 
            button7.Location = new Point(6, 87);
            button7.Name = "button7";
            button7.Size = new Size(194, 29);
            button7.TabIndex = 3;
            button7.Text = "清空Yim脚本";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(6, 59);
            button6.Name = "button6";
            button6.Size = new Size(194, 29);
            button6.TabIndex = 2;
            button6.Text = "清空Yim语言文件";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(6, 26);
            button5.Name = "button5";
            button5.Size = new Size(194, 29);
            button5.TabIndex = 1;
            button5.Text = "清空Yim缓存";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.ForeColor = Color.Red;
            button4.Location = new Point(6, 138);
            button4.Name = "button4";
            button4.Size = new Size(194, 29);
            button4.TabIndex = 0;
            button4.Text = "清空整个配置目录";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 500;
            timer2.Tick += timer2_Tick;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(button11);
            groupBox6.Controls.Add(button10);
            groupBox6.Controls.Add(button9);
            groupBox6.Location = new Point(407, 461);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(348, 132);
            groupBox6.TabIndex = 12;
            groupBox6.TabStop = false;
            groupBox6.Text = "lua脚本管理";
            // 
            // button11
            // 
            button11.Location = new Point(169, 26);
            button11.Name = "button11";
            button11.Size = new Size(155, 27);
            button11.TabIndex = 2;
            button11.Text = "下载Yim-Heist lua";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.Location = new Point(8, 59);
            button10.Name = "button10";
            button10.Size = new Size(155, 27);
            button10.TabIndex = 1;
            button10.Text = "下载SCH lua";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Location = new Point(8, 26);
            button9.Name = "button9";
            button9.Size = new Size(155, 27);
            button9.TabIndex = 0;
            button9.Text = "下载Alice lua";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button15
            // 
            button15.BackColor = Color.White;
            button15.Location = new Point(545, 595);
            button15.Name = "button15";
            button15.Size = new Size(94, 29);
            button15.TabIndex = 24;
            button15.Text = "jsdelivr";
            button15.UseVisualStyleBackColor = false;
            button15.Click += button15_Click;
            // 
            // button14
            // 
            button14.BackColor = Color.White;
            button14.Location = new Point(445, 595);
            button14.Name = "button14";
            button14.Size = new Size(94, 29);
            button14.TabIndex = 23;
            button14.Text = "ghproxy";
            button14.UseVisualStyleBackColor = false;
            button14.Click += button14_Click;
            // 
            // timer3
            // 
            timer3.Enabled = true;
            timer3.Interval = 2000;
            timer3.Tick += timer3_Tick;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 597);
            label12.Name = "label12";
            label12.Size = new Size(54, 20);
            label12.TabIndex = 13;
            label12.Text = "下载源";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(266, 601);
            label13.Name = "label13";
            label13.Size = new Size(73, 20);
            label13.TabIndex = 18;
            label13.Text = "手动换源:";
            // 
            // button13
            // 
            button13.BackColor = Color.White;
            button13.Location = new Point(345, 595);
            button13.Name = "button13";
            button13.Size = new Size(94, 29);
            button13.TabIndex = 22;
            button13.Text = "Github";
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click_1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 627);
            label14.Name = "label14";
            label14.Size = new Size(805, 20);
            label14.TabIndex = 25;
            label14.Text = "除了Github,其他源下载到的文件可能都不是最新的,存在约24h的延迟。但是在中国大陆访问GitHub需要合适的网络环境";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label21);
            groupBox7.Controls.Add(label20);
            groupBox7.Controls.Add(label19);
            groupBox7.Controls.Add(label18);
            groupBox7.Controls.Add(label17);
            groupBox7.Controls.Add(label16);
            groupBox7.Controls.Add(label15);
            groupBox7.Location = new Point(770, 20);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(260, 266);
            groupBox7.TabIndex = 26;
            groupBox7.TabStop = false;
            groupBox7.Text = "信息";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 155);
            label21.Name = "label21";
            label21.Size = new Size(69, 20);
            label21.TabIndex = 6;
            label21.Text = "更新日期";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 135);
            label20.Name = "label20";
            label20.Size = new Size(39, 20);
            label20.TabIndex = 5;
            label20.Text = "版别";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 115);
            label19.Name = "label19";
            label19.Size = new Size(69, 20);
            label19.TabIndex = 4;
            label19.Text = "上次注入";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 23);
            label18.Name = "label18";
            label18.Size = new Size(69, 20);
            label18.TabIndex = 3;
            label18.Text = "操作系统";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 85);
            label17.Name = "label17";
            label17.Size = new Size(62, 20);
            label17.TabIndex = 2;
            label17.Text = "label17";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 65);
            label16.Name = "label16";
            label16.Size = new Size(62, 20);
            label16.TabIndex = 1;
            label16.Text = "label16";
            label16.Click += label16_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 45);
            label15.Name = "label15";
            label15.Size = new Size(62, 20);
            label15.TabIndex = 0;
            label15.Text = "label15";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 650);
            Controls.Add(groupBox7);
            Controls.Add(label14);
            Controls.Add(button15);
            Controls.Add(button13);
            Controls.Add(button14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Yimmenu兼容性检查程序v1.4.0-网络版 ";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer timer1;
        private Label label5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label6;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label7;
        private GroupBox groupBox5;
        private Label label8;
        private Label label9;
        private System.Windows.Forms.Timer timer2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label label10;
        private Label label11;
        private GroupBox groupBox6;
        private Button button10;
        private Button button9;
        private Button button11;
        private Button button12;
        private System.Windows.Forms.Timer timer3;
        private Label label12;
        private Label label13;
        private Button button15;
        private Button button14;
        private Button button13;
        private Label label14;
        private GroupBox groupBox7;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label20;
        private Label label19;
        private Label label21;
        private Button button16;
    }
}