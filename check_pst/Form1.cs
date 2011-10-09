using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace check_pst
{
        public partial class Form1 : Form
        {

                Process[] myProcesses = Process.GetProcesses();


                public Form1()
                {

                        InitializeComponent();
                        int process_num = myProcesses.Length;
                        myProcesses.ToArray();
                        textBox2.Text = process_num.ToString();
                        textBox3.Text = myProcesses.GetType().ToString();


                }

                private void Form1_Load(object sender, EventArgs e)
                {
                        SetTimer();
                }

                private void button1_Click(object sender, EventArgs e)
                {
                        //foreach (Process vProcess in myProcesses.OrderBy(g => g.Id))
                        foreach (Process vProcess in myProcesses.OrderBy(a => a.ProcessName))
                        {
                                //Console.WriteLine("进程:{0}", vProcess.ProcessName);
                                textBox1.Text += vProcess.Id + " " + vProcess.ProcessName + "\r\n";
                        }
                }
                private void che()
                {
                        Process[] CheProcesses = Process.GetProcesses();
                        string program = "PPSAP";
                        string program_1 = "PPStream";
                        int c = 0;
                        int d = 0;
                        //foreach (Process vProcess in CheProcesses)
                        foreach (Process vProcess in CheProcesses)
                        {


                                if (vProcess.ProcessName == program)
                                        c++;
                                if (vProcess.ProcessName == program_1)
                                        d++;

                        }
                        //if (c > 0 & d > 0)
                        //        MessageBox.Show("PPSAP and PPStream is running...." + c.ToString());
                        //else if(c > 0 )
                        //        MessageBox.Show("PPSAP or PPStream is running...." + c.ToString());
                        if (c > 0 & d < 1)
                        {
                                Process[] k = Process.GetProcessesByName(program);
                                foreach (Process kk in k)
                                {
                                        kk.Kill();
                                }

                        }


                }

                private void button2_Click(object sender, EventArgs e)
                {
                        textBox1.Text = null;
                }

                //最小化窗口，只在任务栏显示图标
                private void form1_sizechanged(object sender, EventArgs e)
                {
                        if (this.WindowState == FormWindowState.Minimized)
                        {
                                this.Hide();
                                this.notifyIcon1.Visible = true;
                        }

                }

                //添加点击图标事件(首先需要添加事件引用)： 

                private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
                {
                        if (e.Button == MouseButtons.Left)  //单击鼠标左键也弹出菜单
                        {
                                this.Visible = true;
                                this.WindowState = FormWindowState.Normal;
                                this.notifyIcon1.Visible = false;
                        }
                }

                private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
                {
                        this.Visible = true;
                        this.WindowState = FormWindowState.Normal;
                        this.notifyIcon1.Visible = false;
                }

                public void SetTimer()
                {
                        System.Timers.Timer aTimer = new System.Timers.Timer();
                        aTimer.Elapsed += new ElapsedEventHandler(TimeEvent);
                        //// 设置引发时间的时间间隔　此处设置为1秒(1000毫秒)
                        aTimer.Interval = 5000;
                        aTimer.Enabled = true;

                }

                private void TimeEvent(object source, ElapsedEventArgs e)
                {
                        che();
                        // 得到 hour minute second  如果等于某个值就开始执行某个程序。
                        int intHour = e.SignalTime.Hour;
                        int intMinute = e.SignalTime.Minute;
                        int intSecond = e.SignalTime.Second;
                        //MessageBox.Show(intSecond.ToString());
                        // 定制时间； 比如 在10：30 ：00 的时候执行某个函数
                        int iHour = 10;
                        int iMinute = 30;
                        int iSecond = 00;

                        // 设置　 每秒钟的开始执行一次
                        if (intSecond == iSecond)
                        {
                                MessageBox.Show("每秒钟的开始执行一次!");


                        }
                        // 设置　每个小时的30分钟开始执行
                        if (intMinute == iMinute && intSecond == iSecond)
                        {
                                MessageBox.Show("每个小时的30分钟开始执行一次!");
                        }

                        // 设置　每天的10:30:00开始执行程序
                        if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
                        {
                                MessageBox.Show("在每天10点30分开始执行!");
                        }

                }



                //c#杀死系统进程的方法：

                //System.Diagnostics.Process[] myp = System.Diagnostics.Process.GetProcessesByName("输入进程名称");
                //foreach ( System.Diagnostics.Process xxx in myp)
                //{
                //    xxx.Kill();
                //}





        }


}
