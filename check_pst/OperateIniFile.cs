//code refer http://www.cnblogs.com/scgw/archive/2009/04/08/1431343.html

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace check_pst
{
        class OperateIniFile
        {
                #region API函数声明

                [DllImport("kernel32")]//返回0表示失败，非0为成功
                private static extern long WritePrivateProfileString(string section, string key,
                    string val, string filePath);

                [DllImport("kernel32")]//返回取得字符串缓冲区的长度
                private static extern long GetPrivateProfileString(string section, string key,
                    string def, StringBuilder retVal, int size, string filePath);


                #endregion

                #region 读Ini文件

                public static string ReadIniData(string Section, string Key, string NoText, string iniFilePath)
                {
                        if (File.Exists(iniFilePath))
                        {
                                StringBuilder temp = new StringBuilder(1024);
                                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                                return temp.ToString();
                        }
                        else
                        {
                                return String.Empty;
                        }
                }

                #endregion

                #region 写Ini文件

                public static bool WriteIniData(string Section, string Key, string Value, string iniFilePath)
                {
                        if (!File.Exists(iniFilePath))
                        {

                                StreamWriter sw = File.CreateText(iniFilePath);
                                sw.Close();
                                sw.Dispose();
                             
                        }


                        long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
                        if (OpStation == 0)
                        {
                                return false;
                        }
                        else
                        {
                                return true;
                        }


                }

                #endregion
        }
}

/*
 other way 
 from : http://jachman.wordpress.com/2006/09/11/how-to-access-ini-files-in-c-net/
 * */

#region 第二种方法

namespace IniFiles
{
        class Program
        {
                [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW",
                                SetLastError = true,
                                CharSet = CharSet.Unicode, ExactSpelling = true,
                                CallingConvention = CallingConvention.StdCall)]
                private static extern int GetPrivateProfileString(
                        string lpAppName,
                        string lpKeyName,
                        string lpDefault,
                        string lpReturnString,
                        int nSize,
                        string lpFilename);

                [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW",
                        SetLastError = true,
                        CharSet = CharSet.Unicode, ExactSpelling = true,
                        CallingConvention = CallingConvention.StdCall)]
                private static extern int WritePrivateProfileString(
                        string lpAppName,
                        string lpKeyName,
                        string lpString,
                        string lpFilename);

                /// <summary>
                /// Main program
                /// </summary>
                static void Main_tmp()
                {
                        string defaultValue = "???";
                        string iniFile = @"c:\windows\odbc.ini";

                        /*
                         * Try to read the content of a simle INI file
                         */
                        List<string> categories = GetCategories(iniFile);
                        foreach (string category in categories)
                        {
                                Console.WriteLine(category);

                                /*
                                 * Get the keys
                                 */
                                List<string> keys = GetKeys(iniFile, category);
                                foreach (string key in keys)
                                {
                                        /*
                                         * Now output the content
                                         */
                                        string content = GetIniFileString(iniFile, category, key, defaultValue);
                                        Console.WriteLine(string.Concat("  ", key, "\t", content));
                                }
                        }

                        /*
                         * Last but not least, write your own INI File
                         * If you do not specify a directory, the INI File will be created within the Windows Directory.
                         * C:\Windows\MyIniFile.ini
                         */
                        WritePrivateProfileString("GLOBAL", "Stuff", "The content of that stuff", "MyIniFile.ini");

                        Console.ReadKey();
                }

                /// <summary>
                /// Gets the content.
                /// </summary>
                /// <param name="iniFile">The ini file.</param>
                /// <param name="category">The category.</param>
                /// <param name="key">The key.</param>
                /// <param name="defaultValue">The default value.</param>
                /// <returns></returns>
                private static string GetIniFileString(string iniFile, string category, string key, string defaultValue)
                {
                        string returnString = new string(' ', 1024);
                        GetPrivateProfileString(category, key, defaultValue, returnString, 1024, iniFile);
                        return returnString.Split('\0')[0];
                }

                /// <summary>
                /// Gets the keys.
                /// </summary>
                /// <param name="iniFile">The ini file.</param>
                /// <param name="category">The category.</param>
                private static List<string> GetKeys(string iniFile, string category)
                {
                        string returnString = new string(' ', 32768);
                        GetPrivateProfileString(category, null, null, returnString, 32768, iniFile);
                        List<string> result = new List<string>(returnString.Split('\0'));
                        result.RemoveRange(result.Count - 2, 2);
                        return result;
                }

                /// <summary>
                /// Gets the categories.
                /// </summary>
                /// <param name="iniFile">The ini file.</param>
                /// <returns></returns>
                private static List<string> GetCategories(string iniFile)
                {
                        string returnString = new string(' ', 65536);
                        GetPrivateProfileString(null, null, null, returnString, 65536, iniFile);
                        List<string> result = new List<string>(returnString.Split('\0'));
                        result.RemoveRange(result.Count - 2, 2);
                        return result;
                }
        }
}

#endregion

/*
 * other way, code from http://www.codeproject.com/KB/cs/cs_ini.aspx
 * using INI;
 * INIFile ini = new INIFile("C:\\test.ini");
 * Use IniWriteValue to write a new value to a specific key in a section or use IniReadValue to read a value FROM a key in a specific Section.
 * 
 * */

#region 第三种方法
/*
namespace Ini
{
        /// <summary>

        /// Create a New INI file to store or load data

        /// </summary>

        public class IniFile
        {
                public string path;

                [DllImport("kernel32")]
                private static extern long WritePrivateProfileString(string section,
                    string key, string val, string filePath);
                [DllImport("kernel32")]
                private static extern int GetPrivateProfileString(string section,
                         string key, string def, StringBuilder retVal,
                    int size, string filePath);

                /// <summary>

                /// INIFile Constructor.

                /// </summary>

                /// <PARAM name="INIPath"></PARAM>

                public IniFile(string INIPath)
                {
                        path = INIPath;
                }
                /// <summary>

                /// Write Data to the INI File

                /// </summary>

                /// <PARAM name="Section"></PARAM>

                /// Section name

                /// <PARAM name="Key"></PARAM>

                /// Key Name

                /// <PARAM name="Value"></PARAM>

                /// Value Name

                public void IniWriteValue(string Section, string Key, string Value)
                {
                        WritePrivateProfileString(Section, Key, Value, this.path);
                }

                /// <summary>

                /// Read Data Value From the Ini File

                /// </summary>

                /// <PARAM name="Section"></PARAM>

                /// <PARAM name="Key"></PARAM>

                /// <PARAM name="Path"></PARAM>

                /// <returns></returns>

                public string IniReadValue(string Section, string Key)
                {
                        StringBuilder temp = new StringBuilder(255);
                        int i = GetPrivateProfileString(Section, Key, "", temp,
                                                        255, this.path);
                        return temp.ToString();

                }
        }
}
 * */
#endregion

