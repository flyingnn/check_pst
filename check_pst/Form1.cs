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
                        SetTimer_1();
                }

                private void button1_Click(object sender, EventArgs e)
                {
                        Process[] myProcesses = Process.GetProcesses();
                        //foreach (Process vProcess in myProcesses.OrderBy(g => g.Id))
                        textBox1.Text = null;
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
                        string program_2 = "python";
                        string program_3 = "aoclbf 1.75";
                        int f = 0;
                        int c = 0;
                        int d = 0;
                        int e = 0;
                        string app1 = "D:\\old-disk\\D\\install_2\\ming\\c00w-bitHopper\\c00w-bitHopper-55ae622\\run-bithopper.bat";
                        string app2 = "D:\\old-disk\\D\\install_2\\ming\\phoenix\\aoclbf 1.75.exe";
                        string app1_evn = System.IO.Path.GetDirectoryName(app1);
                        string app2_evn = System.IO.Path.GetDirectoryName(app2);
                        //foreach (Process vProcess in CheProcesses)
                        foreach (Process vProcess in CheProcesses)
                        {


                                if (vProcess.ProcessName == program)
                                        c++;
                                if (vProcess.ProcessName == program_1)
                                        d++;
                                if (vProcess.ProcessName == program_2)
                                        e++;
                                if (vProcess.ProcessName == program_3)
                                        f++;
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

                        if (e < 1)
                        {
                                RunApp(app1,app1_evn);
                        }
                        if (f < 1)
                        {
                                RunApp(app2,app2_evn);
                        }


                }

                //直接使用.Net提供的Process类来实现外部程序的启动
                private void RunApp(string app, string dir_name = "", string run_args = "")
                {
                        Process proc = new Process();
                        //执行的文件名
                        proc.StartInfo.FileName = app;
                        //执行的起始位置
                        proc.StartInfo.WorkingDirectory = @dir_name;
                        //执行参数
                        proc.StartInfo.Arguments = @run_args;

                        // 关闭Shell的使用
                        //proc.StartInfo.UseShellExecute = false;
                        // 重定向标准输入
                        //proc.StartInfo.RedirectStandardInput = true;
                        // 重定向标准输出
                        //proc.StartInfo.RedirectStandardOutput = true;
                        //重定向错误输出
                        //proc.StartInfo.RedirectStandardError = true;
                        // 设置不显示窗口
                        //proc.StartInfo.CreateNoWindow = true;
                        //运行
                        proc.Start(); 
                        
                        
                       // myprocessID = myProcess.Id;  // 获得该外部进程ID
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
                private void notifyIcon1_Click(object sender, EventArgs e)
                {
                        this.Visible = true;
                        this.WindowState = FormWindowState.Normal;
                        this.notifyIcon1.Visible = false;
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

                public void SetTimer_1()
                {
                        System.Timers.Timer aTimer = new System.Timers.Timer();
                        aTimer.Elapsed += new ElapsedEventHandler(TimeDo);
                        //// 设置引发时间的时间间隔　此处设置为1秒(1000毫秒)
                        aTimer.Interval = 1000 * 60 *60 * 3 ;
                        aTimer.Enabled = true;

                }

                private void TimeDo(object source, ElapsedEventArgs e)
                {
                        ProcessesKiller.FindAndKillProcess("aoclbf 1.75");
                        //MessageBox.Show("ttt");
                       
                        
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
                                //MessageBox.Show("每秒钟的开始执行一次!");
                        }
                        // 设置　每个小时的30分钟开始执行
                        if (intMinute == iMinute && intSecond == iSecond)
                        {
                                //MessageBox.Show("每个小时的30分钟开始执行一次!");
                        }

                        // 设置　每天的10:30:00开始执行程序
                        if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
                        {
                                //MessageBox.Show("在每天10点30分开始执行!");
                        }

                }







        }


}
