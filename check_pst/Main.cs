using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
//using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;
using System.IO;
using AMS.Profile;

namespace check_pst
{
        public partial class Main : Form
        {

                Process[] myProcesses = Process.GetProcesses();

                string FileName = null;
                static string IniName = "setting.ini";


                static string Curdir = System.Environment.CurrentDirectory;

                public static string IniFullName = Curdir + "\\" + IniName;
                Ini ini = new Ini(IniFullName);
                Dictionary<string, Dictionary<string, string>> node = new Dictionary<string, Dictionary<string, string>>();
                //TimerDo[] ProcList = new TimerDo[5];
                List<TimerDo> ProcList = new List<TimerDo>();

                public Main()
                {

                        InitializeComponent();
                        int process_num = myProcesses.Length;
                        //myProcesses.ToArray();
                        ProcessCountTextBox.Text = process_num.ToString();

                }

                private void Form1_Load(object sender, EventArgs e)
                {
                        //SetTimer();
                        //SetTimer_1();
                        DoIni();
                }

                private void button1_Click(object sender, EventArgs e)
                {
                        dataGridView1.Visible = true;
                        Process[] myProcesses = Process.GetProcesses();
                        ArrayList ProcList = new ArrayList();
                        DataTable d = new DataTable();
                        string[] s = new string[2];
                        d.Columns.Add("进程ID");
                        d.Columns.Add("进程名称");
                        
                       //foreach (Process vProcess in myProcesses.OrderBy(g => g.Id))
                        ProcessListTextBox.Text = null;
                        //.net 4.0 才有的排序功能
                        //foreach (Process vProcess in myProcesses.OrderBy(a => a.ProcessName))
                        foreach (Process vProcess in myProcesses)
                        {
                                //Console.WriteLine("进程:{0}", vProcess.ProcessName);
                                //ProcessListTextBox.Text += vProcess.Id + " " + vProcess.ProcessName + "\r\n";
                                ProcList.Add(vProcess.ProcessName + "\t" + vProcess.Id.ToString());

                        }
                        ProcList.Sort();
                        foreach(string p in ProcList)
                        //foreach (KeyValuePair<string, int> item in Proc)
                        {
                                
                                //ProcessListTextBox.Text += p + "\r\n";
                                s = p.Split('\t');
                                d.Rows.Add(s[0], s[1]);
                        }
                        dataGridView1.DataSource = d;
                        ProcessCountTextBox.Text = myProcesses.Length.ToString();
                }


                private void button2_Click(object sender, EventArgs e)
                {
                        ProcessListTextBox.Text = null;
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
                //任务栏图标双击
                private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
                {
                        this.Visible = true;
                        this.WindowState = FormWindowState.Normal;
                        this.notifyIcon1.Visible = false;
                }


                //指定程序路径
                private void OpenButton_Click(object sender, EventArgs e)
                {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.InitialDirectory = "c://";
                        openFileDialog.Filter = "exe文件|*.exe|bat文件|*.bat|所有文件|*.*";
                        openFileDialog.RestoreDirectory = true;
                        openFileDialog.FilterIndex = 1;
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                                FileName = openFileDialog.FileName;
                                FilePathTextBox.Text = FileName;


                        }
                }
                //只能输入数字，和用退格键
                private void TimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                        {
                                e.Handled = true;
                        }
                }
                //保存到ini 文件
                private void SaveButton_Click(object sender, EventArgs e)
                {
                        string run_type = null;
                        if (this.FilePathTextBox.Text == "" || this.TimeTextBox.Text == "")
                        {
                                MessageBox.Show("还没有设定程序路径和时间！");
                                return;
                        }
                        else if (CheckRadio.Checked)
                        {
                                DoSave("CheckRunning");
                                run_type = "CheckRunning";
                        }
                        else if (TimerRadio.Checked)
                        {
                                DoSave("Kill");
                                run_type = "Kill";
                        }
                        else
                        {
                                MessageBox.Show("请先选择检查类型！");
                                return;
                        }
                        DoList(Convert.ToInt32(TimeTextBox.Text), run_type, FilePathTextBox.Text);
                        //DoIni();

                }
                //保存动作
                private void DoSave(string section)
                {

                        string key = null;
                        string[] values = new string[2];

                        if (section == "checkpair")
                        {

                                key = CheckPairTextBox1.Text;
                                string pair_name2 = CheckPairTextBox2.Text;
                                string value_time = CheckPairTimerTextBox.Text;
                                values = new string[2] { pair_name2, value_time };
                        }
                        else
                        {
                                key = System.IO.Path.GetFileNameWithoutExtension(FileName);
                                string value_time = this.TimeTextBox.Text;
                                values = new string[2] { FileName, value_time };
                        }
                        string v = String.Join(",", values);



                        Dictionary<string, string> kv = new Dictionary<string, string>();


                        kv.Add(key, v);

                        SaveIni(section, kv);
                        //MessageBox.Show(section + kv);






                }
                //一次保存一个节和一对键值
                private void SaveIni(string section, string key, string value)
                {

                        ini.SetValue(section, key, value);

                }
                //一次保存一个节和多对键值
                private void SaveIni(string section, Dictionary<string, string> Entry)
                {

                        foreach (KeyValuePair<string, string> kv in Entry)
                        {
                                ini.SetValue(section, kv.Key, kv.Value);
                        }



                }
                //一次保存多个节和多对键值
                private void SaveIni(Dictionary<string, Dictionary<string, string>> sections)
                {

                        //Dictionary<string, Dictionary<string, string>> sections = new Dictionary<string, Dictionary<string, string>>();
                        foreach (KeyValuePair<string, Dictionary<string, string>> kv in sections)
                        {
                                foreach (KeyValuePair<string, string> vv in kv.Value)
                                {
                                        ini.SetValue(kv.Key, vv.Key, vv.Value);
                                }
                        }


                }
                // read ini file
                private Dictionary<string, Dictionary<string, string>> ReadIni()
                {
                        string[] sections = ini.GetSectionNames();
                        Dictionary<string, string> keys = new Dictionary<string, string>();
                        Dictionary<string, string> keys_tmp = new Dictionary<string, string>();
                        Dictionary<string, Dictionary<string, string>> node = new Dictionary<string, Dictionary<string, string>>();
                        foreach (string section in sections)
                        {

                                foreach (string key in ini.GetEntryNames(section))
                                {
                                        keys.Add(key, ini.GetValue(section, key).ToString());

                                }
                                keys_tmp = CloneDictionaryCloningValues(keys);
                                node.Add(section, keys_tmp);

                                keys.Clear();
                                //values.Add(section);

                        }
                        return node;

                }

                // deepcopy Dictionary
                public static Dictionary<TKey, TValue> CloneDictionaryCloningValues<TKey, TValue>
                 (Dictionary<TKey, TValue> original) where TValue : ICloneable
                {
                        Dictionary<TKey, TValue> ret = new Dictionary<TKey, TValue>(original.Count, original.Comparer);
                        foreach (KeyValuePair<TKey, TValue> entry in original)
                        {
                                ret.Add(entry.Key, (TValue)entry.Value.Clone());
                        }
                        return ret;
                }



                //show ini content
                private string ShowIni(string type = "")
                {
                        node = ReadIni();
                        string content = "";

                        foreach (KeyValuePair<string, Dictionary<string, string>> section in node)
                        {
                                if (type != "" && type != section.Key)
                                        continue;
                                content += "[" + section.Key + "]\r\n";
                                foreach (KeyValuePair<string, string> key in section.Value)
                                {
                                        content += key.Key + "=" + key.Value + "\r\n";
                                }
                                //values.Add(section);

                        }

                        return content;
                }
                // show ini file content at textbox
                private void ViewButton_Click(object sender, EventArgs e)
                {
                        ProcessListTextBox.Text = ShowIni();
                        dataGridView1.Visible = false;
                }

                private void DoIni()
                {
                        node = ReadIni();
                        int time = 10;

                        foreach (KeyValuePair<string, Dictionary<string, string>> section in node)
                        {
                                string run_type = section.Key.ToLower();
                                foreach (KeyValuePair<string, string> key in section.Value)
                                {

                                        if (run_type == "checkpair")
                                        {
                                                try
                                                {
                                                        time = Convert.ToInt32(key.Value.Split(',')[1]);
                                                }
                                                catch (Exception e)
                                                {
                                                        MessageBox.Show(e.Message);
                                                }
                                                string pair_name1 = key.Key;
                                                string pair_name2 = key.Value.Split(',')[0];
                                                DoList(time, run_type, null, pair_name1, pair_name2);
                                                DoList(time, run_type, null, "PPStream", "PPSAP");     //check pps
                                        }
                                        else
                                        {
                                                try
                                                {
                                                        time = Convert.ToInt32(key.Value.Split(',')[1]);
                                                }
                                                catch (Exception e)
                                                {
                                                        MessageBox.Show(e.Message);
                                                }
                                                string process = key.Value.Split(',')[0];
                                                DoList(time, run_type, process);
                                        }
                                }
                                //values.Add(section);

                        }
                }


                private void DoList(int time, string run_type, string process = null, string pair_name1 = null, string pair_name2 = null)
                {
                        TimerDo do_list = new TimerDo();

                        //do_list.Time = time;
                        //do_list.ProcessName = process;
                        //do_list.PairName1 = pair_name1;
                        //do_list.PairName2 = pair_name2;
                        //do_list.DoType = run_type;
                        //do_list.SetTimer();

                        ProcList.Add(do_list);
                        ProcList[ProcList.Count - 1].Time = time;
                        ProcList[ProcList.Count - 1].ProcessName = process;
                        ProcList[ProcList.Count - 1].PairName1 = pair_name1;
                        ProcList[ProcList.Count - 1].PairName2 = pair_name2;
                        ProcList[ProcList.Count - 1].DoType = run_type;
                        ProcList[ProcList.Count - 1].SetTimer();

                        //MessageBox.Show(time.ToString() + process + run_type + pair_name1 + pair_name2);
                        //MessageBox.Show(ProcList.Count.ToString());
                }

                private void CheckPairButton_Click(object sender, EventArgs e)
                {
                        if (CheckPairTextBox1.Text.Length == 0 || CheckPairTextBox2.Text.Length == 0 || CheckPairTimerTextBox.Text.Length == 0)
                        {
                                MessageBox.Show("请先填完参数！");
                                return;
                        }
                        else
                                DoSave("checkpair");
                        DoList(Convert.ToInt32(CheckPairTimerTextBox.Text), "checkpair", null, CheckPairTextBox1.Text, CheckPairTextBox2.Text);
                        //DoIni();

                }

                //只可以输入数字
                private void CheckPairTimerTextBox_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                        {
                                e.Handled = true;
                        }
                }
                //用记事本打开配置文件
                private void OpenFileButton_Click(object sender, EventArgs e)
                {
                        TimerDo app = new TimerDo();
                        app.RunApp("notepad.exe", null, IniFullName);

                }

                private void StopButton_Click(object sender, EventArgs e)
                {
                        StopProc();
                        RestartButton.Enabled = true;
                        StopButton.Enabled = false;
                                
                }
                //停止所有的检查功能
                private void StopProc()
                {
                        for (int i = 0; i < ProcList.Count; i++)
                        {
                                ProcList[i].aTimer.Stop();
                                ProcList[i].aTimer.Enabled = false;
                                ProcList[i].aTimer.Dispose();
                                
                        }
                        ProcList.Clear();
                }
                //重新启动所有的检查功能
                private void RestartButton_Click(object sender, EventArgs e)
                {
                        RestartProc();
                        StopButton.Enabled = true;
                }
                private void RestartProc()
                {
                        StopProc();
                        DoIni();
                }








        }


}
