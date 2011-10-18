namespace check_pst
{
        partial class Form1
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
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                    this.button1 = new System.Windows.Forms.Button();
                    this.textBox1 = new System.Windows.Forms.TextBox();
                    this.button2 = new System.Windows.Forms.Button();
                    this.textBox2 = new System.Windows.Forms.TextBox();
                    this.label1 = new System.Windows.Forms.Label();
                    this.textBox3 = new System.Windows.Forms.TextBox();
                    this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
                    this.SuspendLayout();
                    // 
                    // button1
                    // 
                    this.button1.Location = new System.Drawing.Point(113, 351);
                    this.button1.Name = "button1";
                    this.button1.Size = new System.Drawing.Size(77, 26);
                    this.button1.TabIndex = 0;
                    this.button1.Text = "GetProcess";
                    this.button1.UseVisualStyleBackColor = true;
                    this.button1.Click += new System.EventHandler(this.button1_Click);
                    // 
                    // textBox1
                    // 
                    this.textBox1.Location = new System.Drawing.Point(32, 13);
                    this.textBox1.Multiline = true;
                    this.textBox1.Name = "textBox1";
                    this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                    this.textBox1.Size = new System.Drawing.Size(195, 320);
                    this.textBox1.TabIndex = 1;
                    // 
                    // button2
                    // 
                    this.button2.Location = new System.Drawing.Point(32, 351);
                    this.button2.Name = "button2";
                    this.button2.Size = new System.Drawing.Size(59, 26);
                    this.button2.TabIndex = 2;
                    this.button2.Text = "Clean";
                    this.button2.UseVisualStyleBackColor = true;
                    this.button2.Click += new System.EventHandler(this.button2_Click);
                    // 
                    // textBox2
                    // 
                    this.textBox2.Location = new System.Drawing.Point(259, 254);
                    this.textBox2.Name = "textBox2";
                    this.textBox2.Size = new System.Drawing.Size(117, 21);
                    this.textBox2.TabIndex = 3;
                    // 
                    // label1
                    // 
                    this.label1.AutoSize = true;
                    this.label1.Location = new System.Drawing.Point(262, 225);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(41, 12);
                    this.label1.TabIndex = 4;
                    this.label1.Text = "label1";
                    // 
                    // textBox3
                    // 
                    this.textBox3.Location = new System.Drawing.Point(257, 187);
                    this.textBox3.Name = "textBox3";
                    this.textBox3.Size = new System.Drawing.Size(118, 21);
                    this.textBox3.TabIndex = 5;
                    // 
                    // notifyIcon1
                    // 
                    this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
                    this.notifyIcon1.Text = "check";
                    this.notifyIcon1.Visible = true;
                    this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
                    // 
                    // Form1
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.ClientSize = new System.Drawing.Size(391, 389);
                    this.Controls.Add(this.textBox3);
                    this.Controls.Add(this.label1);
                    this.Controls.Add(this.textBox2);
                    this.Controls.Add(this.button2);
                    this.Controls.Add(this.textBox1);
                    this.Controls.Add(this.button1);
                    this.Name = "Form1";
                    this.ShowInTaskbar = false;
                    this.Text = "Form1";
                    this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                    this.Load += new System.EventHandler(this.Form1_Load);
                    this.SizeChanged += new System.EventHandler(this.form1_sizechanged);
                    this.ResumeLayout(false);
                    this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Button button1;
                private System.Windows.Forms.TextBox textBox1;
                private System.Windows.Forms.Button button2;
                private System.Windows.Forms.TextBox textBox2;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.TextBox textBox3;
                private System.Windows.Forms.NotifyIcon notifyIcon1;
        }
}

