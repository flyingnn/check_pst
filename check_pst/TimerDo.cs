using System;
using System.Timers;
using System.Diagnostics;
using System.Windows.Forms;
namespace check_pst
{
        class TimerDo
        {
                private string process_name = null;
                private int time = 5;
                private string do_type = null;
                private string pair_name1 = null;
                private string pair_name2 = null;
                private string app;
                private string app_evn;
                public System.Timers.Timer aTimer = new System.Timers.Timer();


                public TimerDo()
                {
                        
                }

                public int Time
                {
                        set
                        {
                                time = value;
                        }

                }
                public string ProcessName
                {
                        set
                        {
                                process_name = value;
                        }
                }
                public string DoType
                {
                        set
                        {
                                do_type = value;
                        }
                }
                public string PairName1
                {
                        set
                        {
                                pair_name1 = value;
                        }
                }
                public string PairName2
                {
                        set
                        {
                                pair_name2 = value;
                        }
                }
                
            
                //定时器
                public void SetTimer()
                {
                        int second = time;
                        //System.Timers.Timer aTimer = new System.Timers.Timer();

                        //// 设置引发时间的时间间隔　此处设置为1秒(1000毫秒)
                        aTimer.Interval = 1000 * second;
                        aTimer.Enabled = true;
                        switch (do_type)
                        {
                                case "checkrunning":
                                        aTimer.Elapsed += new ElapsedEventHandler(CheckRunning);
                                        break;
                                case "kill":
                                        aTimer.Elapsed += new ElapsedEventHandler(KillTree);
                                        break;
                                case "checkpair":
                                        aTimer.Elapsed += new ElapsedEventHandler(CheckPair);
                                        break;
                                default:

                                        break;
                        }


                }
                //到时执行结束进程树,并启动新程序
                private void KillTree(object source, ElapsedEventArgs e)
                {
                        this.app_evn = System.IO.Path.GetDirectoryName(process_name);
                        this.app = System.IO.Path.GetFileNameWithoutExtension(process_name);
                        
                        ProcessesKiller.FindAndKillProcess(app);

                        CheckRunning();
                        //MessageBox.Show("ttt");
                }

                // timer check running
                private void CheckRunning(object source, ElapsedEventArgs e)
                {
                        Process[] CheProcesses = Process.GetProcesses();
                        int n = 0;
                        this.app_evn = System.IO.Path.GetDirectoryName(process_name);
                        this.app = System.IO.Path.GetFileNameWithoutExtension(process_name);


                        foreach (Process vProcess in CheProcesses)
                        {

                                if (vProcess.ProcessName == app)
                                        n++;
                        }

                        if (n < 1)
                        {
                                RunApp(process_name, app_evn);
                        }


                }

                //no timer check running
                private void CheckRunning()
                {
                        Process[] CheProcesses = Process.GetProcesses();
                        int n = 0;
                        this.app_evn = System.IO.Path.GetDirectoryName(process_name);
                        this.app = System.IO.Path.GetFileNameWithoutExtension(process_name);


                        foreach (Process vProcess in CheProcesses)
                        {

                                if (vProcess.ProcessName == app)
                                        n++;
                        }

                        if (n < 1)
                        {
                                RunApp(process_name, app_evn);
                        }


                }

                private void CheckPair(object source, ElapsedEventArgs e)
                {

                        if (pair_name1 != null && pair_name2 != null)
                        {
                                int n = 0;
                                int m = 0;
                                Process[] CheProcesses = Process.GetProcesses();

                                foreach (Process vProcess in CheProcesses)
                                {

                                        if (vProcess.ProcessName == pair_name1)
                                                n++;
                                        if (vProcess.ProcessName == pair_name2)
                                                m++;
                                }
                                if (m > 0 & n < 1)
                                {
                                        Process[] k = Process.GetProcessesByName(pair_name2);
                                        foreach (Process kk in k)
                                        {
                                                kk.Kill();
                                        }

                                }


                        }
                }

                //直接使用.Net提供的Process类来实现外部程序的启动
                public void RunApp(string app, string dir_name = "", string run_args = "")
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
                        try
                        {
                                proc.Start();
                        }
                        catch(Exception e)
                        {
                                MessageBox.Show("" + e.Message);
                        }
                        

                        // myprocessID = myProcess.Id;  // 获得该外部进程ID
                }
        }
}
