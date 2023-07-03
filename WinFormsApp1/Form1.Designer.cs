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
            groupBox2 = new GroupBox();
            label6 = new Label();
            groupBox3 = new GroupBox();
            label7 = new Label();
            groupBox4 = new GroupBox();
            button3 = new Button();
            label9 = new Label();
            label8 = new Label();
            groupBox5 = new GroupBox();
            button5 = new Button();
            button4 = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            button6 = new Button();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(6, 166);
            button1.Name = "button1";
            button1.Size = new Size(181, 29);
            button1.TabIndex = 0;
            button1.Text = "Yimmenu注入测试";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(6, 111);
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
            label1.ForeColor = Color.Coral;
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
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 143);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 6;
            label5.Text = "label5";
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 262);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(357, 281);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Yim日志分析";
            // 
            // groupBox2
            // 
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
            groupBox2.Size = new Size(357, 244);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "文件检查";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 198);
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
            groupBox5.Controls.Add(button6);
            groupBox5.Controls.Add(button5);
            groupBox5.Controls.Add(button4);
            groupBox5.Location = new Point(404, 275);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(250, 125);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "groupBox5";
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
            button4.Location = new Point(6, 90);
            button4.Name = "button4";
            button4.Size = new Size(194, 29);
            button4.TabIndex = 0;
            button4.Text = "清空Yim配置目录";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 500;
            timer2.Tick += timer2_Tick;
            // 
            // button6
            // 
            button6.Location = new Point(6, 55);
            button6.Name = "button6";
            button6.Size = new Size(194, 29);
            button6.TabIndex = 2;
            button6.Text = "清空Yim语言文件";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 601);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Yimmenu兼容性检查程序 ";
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}