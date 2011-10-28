//code from: 
// http://www.codeproject.com/KB/shell/ManageProcessShellAPI.aspx?fid=275098&df=90&mpp=25&noise=3&sort=Position&view=Quick&select=2638740#xx2638740xx
//
using System;
using System.Diagnostics;
using System.Globalization;
using System.Management;

namespace check_pst
{
        public static class ProcessesKiller
        {
                public static void FindAndKillProcess(int id)
                {
                        killProcess(id);
                }

                public static void FindAndKillProcess(string name)
                {
                        foreach (Process clsProcess in Process.GetProcesses())
                        {
                                //查找类似的程式名，并结束之
                                //if ((clsProcess.ProcessName.StartsWith(name, StringComparison.CurrentCulture)) || (clsProcess.MainWindowTitle.StartsWith(name, StringComparison.CurrentCulture)))
                                //        killProcess(clsProcess.Id);
                                //查找一样的程式名，并结束之
                                if ((clsProcess.ProcessName.ToString() == name))
                                        killProcess(clsProcess.Id);
                        }
                }

                private static bool killProcess(int pid)
                {
                        Process[] procs = Process.GetProcesses();
                        for (int i = 0; i < procs.Length; i++)
                        {
                                if (getParentProcess(procs[i].Id) == pid)
                                        killProcess(procs[i].Id);
                        }

                        try
                        {
                                Process myProc = Process.GetProcessById(pid);
                                myProc.Kill();
                        }
                        // process already quited
                        catch (ArgumentException)
                        {
                                ;
                        }

                        return true;
                }

                private static int getParentProcess(int Id)
                {
                        int parentPid = 0;
                        using (ManagementObject mo = new ManagementObject("win32_process.handle='" + Id.ToString(CultureInfo.InvariantCulture) + "'"))
                        {
                                try
                                {
                                        mo.Get();
                                }
                                catch (ManagementException)
                                {
                                        return -1;
                                }
                                parentPid = Convert.ToInt32(mo["ParentProcessId"], CultureInfo.InvariantCulture);
                        }
                        return parentPid;
                }
        }
}
