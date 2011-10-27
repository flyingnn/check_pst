namespace check_pst
{
        partial class Main
        {
                /// <summary>
                /// 必需的设计器变量。
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// 清理所有正在使用的资源。
                /// </summary>
                /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null))
                        {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Windows 窗体设计器生成的代码

                /// <summary>
                /// 设计器支持所需的方法 - 不要
                /// 使用代码编辑器修改此方法的内容。
                /// </summary>
                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
                        this.GetProcessButton = new System.Windows.Forms.Button();
                        this.ProcessListTextBox = new System.Windows.Forms.TextBox();
                        this.CleanButton = new System.Windows.Forms.Button();
                        this.ProcessCountTextBox = new System.Windows.Forms.TextBox();
                        this.running = new System.Windows.Forms.Label();
                        this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
                        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                        this.groupBox1 = new System.Windows.Forms.GroupBox();
                        this.label4 = new System.Windows.Forms.Label();
                        this.TimerRadio = new System.Windows.Forms.RadioButton();
                        this.CheckRadio = new System.Windows.Forms.RadioButton();
                        this.SaveButton = new System.Windows.Forms.Button();
                        this.TimeTextBox = new System.Windows.Forms.TextBox();
                        this.label3 = new System.Windows.Forms.Label();
                        this.ViewButton = new System.Windows.Forms.Button();
                        this.label2 = new System.Windows.Forms.Label();
                        this.OpenButton = new System.Windows.Forms.Button();
                        this.FilePathTextBox = new System.Windows.Forms.TextBox();
                        this.groupBox2 = new System.Windows.Forms.GroupBox();
                        this.label5 = new System.Windows.Forms.Label();
                        this.CheckPairTextBox1 = new System.Windows.Forms.TextBox();
                        this.CheckPairTextBox2 = new System.Windows.Forms.TextBox();
                        this.label6 = new System.Windows.Forms.Label();
                        this.CheckPairButton = new System.Windows.Forms.Button();
                        this.CheckPairTimerTextBox = new System.Windows.Forms.TextBox();
                        this.label1 = new System.Windows.Forms.Label();
                        this.panel1 = new System.Windows.Forms.Panel();
                        this.groupBox1.SuspendLayout();
                        this.groupBox2.SuspendLayout();
                        this.panel1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // GetProcessButton
                        // 
                        this.GetProcessButton.Location = new System.Drawing.Point(107, 13);
                        this.GetProcessButton.Name = "GetProcessButton";
                        this.GetProcessButton.Size = new System.Drawing.Size(77, 26);
                        this.GetProcessButton.TabIndex = 0;
                        this.GetProcessButton.Text = "GetProcess";
                        this.GetProcessButton.UseVisualStyleBackColor = true;
                        this.GetProcessButton.Click += new System.EventHandler(this.button1_Click);
                        // 
                        // ProcessListTextBox
                        // 
                        this.ProcessListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.ProcessListTextBox.Location = new System.Drawing.Point(32, 13);
                        this.ProcessListTextBox.Multiline = true;
                        this.ProcessListTextBox.Name = "ProcessListTextBox";
                        this.ProcessListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                        this.ProcessListTextBox.Size = new System.Drawing.Size(195, 320);
                        this.ProcessListTextBox.TabIndex = 1;
                        // 
                        // CleanButton
                        // 
                        this.CleanButton.Location = new System.Drawing.Point(20, 12);
                        this.CleanButton.Name = "CleanButton";
                        this.CleanButton.Size = new System.Drawing.Size(43, 25);
                        this.CleanButton.TabIndex = 2;
                        this.CleanButton.Text = "Clean";
                        this.CleanButton.UseVisualStyleBackColor = true;
                        this.CleanButton.Click += new System.EventHandler(this.button2_Click);
                        // 
                        // ProcessCountTextBox
                        // 
                        this.ProcessCountTextBox.Location = new System.Drawing.Point(361, 18);
                        this.ProcessCountTextBox.Name = "ProcessCountTextBox";
                        this.ProcessCountTextBox.Size = new System.Drawing.Size(44, 21);
                        this.ProcessCountTextBox.TabIndex = 3;
                        // 
                        // running
                        // 
                        this.running.AutoSize = true;
                        this.running.Location = new System.Drawing.Point(242, 21);
                        this.running.Name = "running";
                        this.running.Size = new System.Drawing.Size(113, 12);
                        this.running.TabIndex = 4;
                        this.running.Text = "正在运行的线程数：";
                        // 
                        // notifyIcon1
                        // 
                        this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
                        this.notifyIcon1.Text = "check";
                        this.notifyIcon1.Visible = true;
                        this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
                        // 
                        // openFileDialog1
                        // 
                        this.openFileDialog1.FileName = "openFileDialog1";
                        // 
                        // groupBox1
                        // 
                        this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.groupBox1.Controls.Add(this.label4);
                        this.groupBox1.Controls.Add(this.TimerRadio);
                        this.groupBox1.Controls.Add(this.CheckRadio);
                        this.groupBox1.Controls.Add(this.SaveButton);
                        this.groupBox1.Controls.Add(this.TimeTextBox);
                        this.groupBox1.Controls.Add(this.label3);
                        this.groupBox1.Controls.Add(this.label2);
                        this.groupBox1.Controls.Add(this.OpenButton);
                        this.groupBox1.Controls.Add(this.FilePathTextBox);
                        this.groupBox1.Location = new System.Drawing.Point(244, 21);
                        this.groupBox1.Name = "groupBox1";
                        this.groupBox1.Size = new System.Drawing.Size(295, 135);
                        this.groupBox1.TabIndex = 6;
                        this.groupBox1.TabStop = false;
                        this.groupBox1.Text = "定时检查或重启程序";
                        // 
                        // label4
                        // 
                        this.label4.AutoSize = true;
                        this.label4.Location = new System.Drawing.Point(10, 108);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(65, 12);
                        this.label4.TabIndex = 9;
                        this.label4.Text = "检查类型：";
                        // 
                        // TimerRadio
                        // 
                        this.TimerRadio.AutoSize = true;
                        this.TimerRadio.Location = new System.Drawing.Point(190, 105);
                        this.TimerRadio.Name = "TimerRadio";
                        this.TimerRadio.Size = new System.Drawing.Size(71, 16);
                        this.TimerRadio.TabIndex = 8;
                        this.TimerRadio.TabStop = true;
                        this.TimerRadio.Text = "定时重启";
                        this.TimerRadio.UseVisualStyleBackColor = true;
                        // 
                        // CheckRadio
                        // 
                        this.CheckRadio.AutoSize = true;
                        this.CheckRadio.Location = new System.Drawing.Point(80, 105);
                        this.CheckRadio.Name = "CheckRadio";
                        this.CheckRadio.Size = new System.Drawing.Size(95, 16);
                        this.CheckRadio.TabIndex = 7;
                        this.CheckRadio.TabStop = true;
                        this.CheckRadio.Text = "检查是否运行";
                        this.CheckRadio.UseVisualStyleBackColor = true;
                        // 
                        // SaveButton
                        // 
                        this.SaveButton.Location = new System.Drawing.Point(235, 60);
                        this.SaveButton.Name = "SaveButton";
                        this.SaveButton.Size = new System.Drawing.Size(43, 25);
                        this.SaveButton.TabIndex = 6;
                        this.SaveButton.Text = "Save";
                        this.SaveButton.UseVisualStyleBackColor = true;
                        this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
                        // 
                        // TimeTextBox
                        // 
                        this.TimeTextBox.Location = new System.Drawing.Point(89, 62);
                        this.TimeTextBox.Name = "TimeTextBox";
                        this.TimeTextBox.Size = new System.Drawing.Size(50, 21);
                        this.TimeTextBox.TabIndex = 5;
                        this.TimeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimeTextBox_KeyPress);
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(10, 67);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(78, 15);
                        this.label3.TabIndex = 4;
                        this.label3.Text = "间隔时间(秒)";
                        // 
                        // ViewButton
                        // 
                        this.ViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.ViewButton.Location = new System.Drawing.Point(479, 312);
                        this.ViewButton.Name = "ViewButton";
                        this.ViewButton.Size = new System.Drawing.Size(43, 25);
                        this.ViewButton.TabIndex = 3;
                        this.ViewButton.Text = "查看";
                        this.ViewButton.UseVisualStyleBackColor = true;
                        this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
                        // 
                        // label2
                        // 
                        this.label2.AutoSize = true;
                        this.label2.Location = new System.Drawing.Point(10, 24);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(53, 12);
                        this.label2.TabIndex = 2;
                        this.label2.Text = "程序路径";
                        // 
                        // OpenButton
                        // 
                        this.OpenButton.Location = new System.Drawing.Point(235, 18);
                        this.OpenButton.Name = "OpenButton";
                        this.OpenButton.Size = new System.Drawing.Size(43, 25);
                        this.OpenButton.TabIndex = 1;
                        this.OpenButton.Text = "Open";
                        this.OpenButton.UseVisualStyleBackColor = true;
                        this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
                        // 
                        // FilePathTextBox
                        // 
                        this.FilePathTextBox.Location = new System.Drawing.Point(89, 20);
                        this.FilePathTextBox.Name = "FilePathTextBox";
                        this.FilePathTextBox.ReadOnly = true;
                        this.FilePathTextBox.Size = new System.Drawing.Size(126, 21);
                        this.FilePathTextBox.TabIndex = 0;
                        // 
                        // groupBox2
                        // 
                        this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.groupBox2.Controls.Add(this.CheckPairTimerTextBox);
                        this.groupBox2.Controls.Add(this.label1);
                        this.groupBox2.Controls.Add(this.CheckPairButton);
                        this.groupBox2.Controls.Add(this.CheckPairTextBox2);
                        this.groupBox2.Controls.Add(this.label6);
                        this.groupBox2.Controls.Add(this.CheckPairTextBox1);
                        this.groupBox2.Controls.Add(this.label5);
                        this.groupBox2.Location = new System.Drawing.Point(244, 173);
                        this.groupBox2.Name = "groupBox2";
                        this.groupBox2.Size = new System.Drawing.Size(295, 123);
                        this.groupBox2.TabIndex = 7;
                        this.groupBox2.TabStop = false;
                        this.groupBox2.Text = "定时检查无赖子程序是否运行";
                        // 
                        // label5
                        // 
                        this.label5.AutoSize = true;
                        this.label5.Location = new System.Drawing.Point(10, 26);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(65, 12);
                        this.label5.TabIndex = 0;
                        this.label5.Text = "主程序名字";
                        // 
                        // CheckPairTextBox1
                        // 
                        this.CheckPairTextBox1.Location = new System.Drawing.Point(89, 23);
                        this.CheckPairTextBox1.Name = "CheckPairTextBox1";
                        this.CheckPairTextBox1.Size = new System.Drawing.Size(126, 21);
                        this.CheckPairTextBox1.TabIndex = 1;
                        // 
                        // CheckPairTextBox2
                        // 
                        this.CheckPairTextBox2.Location = new System.Drawing.Point(89, 57);
                        this.CheckPairTextBox2.Name = "CheckPairTextBox2";
                        this.CheckPairTextBox2.Size = new System.Drawing.Size(126, 21);
                        this.CheckPairTextBox2.TabIndex = 3;
                        // 
                        // label6
                        // 
                        this.label6.AutoSize = true;
                        this.label6.Location = new System.Drawing.Point(10, 60);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(65, 12);
                        this.label6.TabIndex = 2;
                        this.label6.Text = "子程序名字";
                        // 
                        // CheckPairButton
                        // 
                        this.CheckPairButton.Location = new System.Drawing.Point(235, 56);
                        this.CheckPairButton.Name = "CheckPairButton";
                        this.CheckPairButton.Size = new System.Drawing.Size(43, 25);
                        this.CheckPairButton.TabIndex = 7;
                        this.CheckPairButton.Text = "Save";
                        this.CheckPairButton.UseVisualStyleBackColor = true;
                        this.CheckPairButton.Click += new System.EventHandler(this.CheckPairButton_Click);
                        // 
                        // CheckPairTimerTextBox
                        // 
                        this.CheckPairTimerTextBox.Location = new System.Drawing.Point(89, 90);
                        this.CheckPairTimerTextBox.Name = "CheckPairTimerTextBox";
                        this.CheckPairTimerTextBox.Size = new System.Drawing.Size(50, 21);
                        this.CheckPairTimerTextBox.TabIndex = 9;
                        this.CheckPairTimerTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckPairTimerTextBox_KeyPress);
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(10, 94);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(78, 15);
                        this.label1.TabIndex = 8;
                        this.label1.Text = "间隔时间(秒)";
                        // 
                        // panel1
                        // 
                        this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.panel1.Controls.Add(this.CleanButton);
                        this.panel1.Controls.Add(this.GetProcessButton);
                        this.panel1.Controls.Add(this.ProcessCountTextBox);
                        this.panel1.Controls.Add(this.running);
                        this.panel1.Location = new System.Drawing.Point(12, 343);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(527, 46);
                        this.panel1.TabIndex = 8;
                        // 
                        // Main
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(551, 394);
                        this.Controls.Add(this.groupBox2);
                        this.Controls.Add(this.groupBox1);
                        this.Controls.Add(this.ViewButton);
                        this.Controls.Add(this.ProcessListTextBox);
                        this.Controls.Add(this.panel1);
                        this.Name = "Main";
                        this.ShowInTaskbar = false;
                        this.Text = "Main";
                        this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                        this.Load += new System.EventHandler(this.Form1_Load);
                        this.SizeChanged += new System.EventHandler(this.form1_sizechanged);
                        this.groupBox1.ResumeLayout(false);
                        this.groupBox1.PerformLayout();
                        this.groupBox2.ResumeLayout(false);
                        this.groupBox2.PerformLayout();
                        this.panel1.ResumeLayout(false);
                        this.panel1.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Button GetProcessButton;
                private System.Windows.Forms.TextBox ProcessListTextBox;
                private System.Windows.Forms.Button CleanButton;
                private System.Windows.Forms.TextBox ProcessCountTextBox;
                private System.Windows.Forms.Label running;
                private System.Windows.Forms.NotifyIcon notifyIcon1;
                private System.Windows.Forms.OpenFileDialog openFileDialog1;
                private System.Windows.Forms.GroupBox groupBox1;
                private System.Windows.Forms.GroupBox groupBox2;
                private System.Windows.Forms.Button OpenButton;
                private System.Windows.Forms.TextBox FilePathTextBox;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Button SaveButton;
                private System.Windows.Forms.TextBox TimeTextBox;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Button ViewButton;
                private System.Windows.Forms.RadioButton TimerRadio;
                private System.Windows.Forms.RadioButton CheckRadio;
                private System.Windows.Forms.Label label4;
                private System.Windows.Forms.TextBox CheckPairTextBox2;
                private System.Windows.Forms.Label label6;
                private System.Windows.Forms.TextBox CheckPairTextBox1;
                private System.Windows.Forms.Label label5;
                private System.Windows.Forms.Button CheckPairButton;
                private System.Windows.Forms.TextBox CheckPairTimerTextBox;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Panel panel1;
        }
}

