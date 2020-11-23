using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Net;
using System.Security.AccessControl;

namespace WinPurify_Giant
{
    class Core
    {
        // Window move defs
        private const int wM_NCLBUTTONDOWN = 0xA1;
        private const int hT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /* @void DO_TOAST
         * @description Send a toast notification to Windows 10
         * @author mirkobrombin
         * @params NotifyIcon(element), string(title), string(message)
        */
        public void DO_TOAST(NotifyIcon element, string title, string message)
        {
            element.ShowBalloonTip(1000, title, message, ToolTipIcon.Info);
        }

        /* @void POWERSHELL
         * @description Execute a command or method in Windows 10 PowerShell
         * @author mirkobrombin
         * @params string(command)
        */
        public void POWERSHELL(string command)
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    PowerShellInstance.AddScript(command);
                    PowerShellInstance.Invoke();
                }
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void CMD
         * @description Execute a command or method in Windows 10 Cmd
         * @author mirkobrombin
         * @params string(command)
        */
        public void CMD(string command)
        {
            try
            {
                System.Diagnostics.Process.Start("CMD.exe", command);
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void SIZE_BEAUTIFY
         * @description Convert a size to human readable string
         * @author mirkobrombin
         * @params string(filesize)
        */
        public string SIZE_BEAUTIFY(string filesize)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int s = 0;
            long size = filesize.Length;

            while (size >= 1024)
            {
                s++;
                size /= 1024;
            }

            return String.Format("{0} {1}", size, suffixes[s]);
        }

        /* @void DEL_DIR_FILES
         * @description Delete all files in a directory
         * @author mirkobrombin
         * @params string(target_dir)
        */
        public void DEL_DIR_FILES(string target_dir)
        {
            try
            {
                foreach (string file in Directory.GetFiles(target_dir).Where(name => !name.EndsWith(".m4e")))
                {
                    File.Delete(file);
                }
                foreach (string subDir in Directory.GetDirectories(target_dir))
                {
                    DEL_DIR_FILES(subDir);
                }
            }
            catch (Exception)
            {
                // Skip fail
            }
            Thread.Sleep(1);
            try
            {
                Directory.Delete(target_dir);
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void GET_DIR_SIZE
         * @description Get size of a directory
         * @author mirkobrombin
         * @params DirectoryInfo(d)
        */
        public static long GET_DIR_SIZE(DirectoryInfo d)
        {
            long size = 0;
            try
            {
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += GET_DIR_SIZE(di);
                }
            }
            catch (Exception)
            {
                // Skip fail
            }
            return size;
        }

        /* @void GET_FIRST_DRIVE
         * @description Get the primary drive of PC
         * @author mirkobrombin
         * @params DirectoryInfo(d)
        */
        public string GET_FIRST_DRIVE()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            return drives[0].ToString();
        }

        /* @void REGISTRY_WRITE
         * @description Write values to Windows 10 registry
         * @author mirkobrombin
         * @params string(path), string(key), string(value)
        */
        public void REGISTRY_WRITE(string path, string key, string value, string dword = "false")
        {
            string user = Environment.UserDomainName + "\\" + Environment.UserName;

            RegistrySecurity rs = new RegistrySecurity();

            rs.AddAccessRule(new RegistryAccessRule(user,
                RegistryRights.WriteKey | RegistryRights.ChangePermissions,
                InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny));

            RegistryKey rk = null;
            rk = Registry.LocalMachine.CreateSubKey(path, RegistryKeyPermissionCheck.Default, rs);
            if (dword == "false")
            {
                rk.SetValue(key, value, RegistryValueKind.String);
            }
            else
            {
                rk.SetValue(key, value, RegistryValueKind.DWord);
            }
            rk.Close();
        }


        /* @void REGISTRY_USER_WRITE
         * @description Write values to Windows 10 CurrentUser registry
         * @author mirkobrombin
         * @params string(path), string(key), string(value)
        */
        public void REGISTRY_USER_WRITE(string path, string key, string value, string dword = "false")
        {
            try
            {
                RegistryKey t_key = Registry.CurrentUser.OpenSubKey(path, true);
                if (dword == "false")
                {
                    t_key.SetValue(key, value, RegistryValueKind.String);
                }
                else
                {
                    t_key.SetValue(key, value, RegistryValueKind.DWord);
                }
                t_key.Close();
            }
            catch (Exception)
            {
                // Skip fail
            }
        }


        /* @void REGISTRY_READ
         * @description Get key value from registry
         * @author mirkobrombin
         * @params string(path), string(key)
        */
        public string REGISTRY_READ(string path, string key)
        {
            try
            {
                RegistryKey t_key = Registry.CurrentUser.OpenSubKey(path, true);
                return t_key.GetValue(key).ToString();
            }
            catch (Exception)
            {
                // Skip fail
                return "None";
            }
        }


        /* @void REGISTRY_SUBKEY
         * @description Create a new subkey to Windows 10 registry
         * @author mirkobrombin
         * @params string(path), string(key), string(value)
        */
        public void REGISTRY_SUBKEY(string path, string key, string value, string dword = "false")
        {
            try
            {
                RegistryKey t;
                t = Registry.CurrentUser.CreateSubKey(path);
                if (dword == "false")
                {
                    t.SetValue(key, value, RegistryValueKind.String);
                }
                else
                {
                    t.SetValue(key, value, RegistryValueKind.DWord);
                }
                t.Close();
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void FILE_WRITE_ALL
         * @description Write all content of a file
         * @author mirkobrombin
         * @params string(dir), string(text)
        */
        public void FILE_WRITE_ALL(string dir, string text)
        {
            try
            {
                File.WriteAllText(dir, text);
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void WRITE_TO_HOST
         * @description Add a line to a file
         * @author mirkobrombin
         * @params string(dir), string(text)
        */
        public void WRITE_TO_HOST(string text)
        {
            try
            {
                using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts")))
                {
                    w.AutoFlush = true;
                    w.WriteLine("\n\n" + text + "\n\n");
                    w.Close();
                }
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void GET_ENV
         * @description Get an environment path
         * @author mirkobrombin
         * @params string(name)
        */
        public string GET_ENV(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }

        /* @void RUN_PROCESS
         * @description Run a process in Windows 10
         * @author mirkobrombin
         * @params string(process)
        */
        public void RUN_PROCESS(string process)
        {
            try
            {
                Process.Start(process);
                Thread.Sleep(1);
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void KILL_PROCESS
         * @description Kill a process in Windows 10
         * @author mirkobrombin
         * @params string(process)
        */
        public void KILL_PROCESS(string process)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName(process))
                {
                    proc.Kill();
                    Thread.Sleep(1);
                }
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void RUN_EXPLORER_TASKBAR
         * @description Run Windows 10 explorer.exe with taskbar
         * @author mirkobrombin
        */
        public void RUN_EXPLORER_TASKBAR()
        {
            try
            {
                Process.Start(Path.Combine(GET_ENV("windir"), "explorer.exe"));
                Thread.Sleep(1);
            }
            catch (Exception)
            {
                // Skip fail
            }
        }

        /* @void CHECK_CONNECTION
         * @description Check for internet connection and return a boolean value
         * @author mirkobrombin
        */
        public static bool CHECK_CONNECTION()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.amazon.com/"))
                    {
                        // internet connection ready
                        return true;
                    }
                }
            }
            catch
            {
                // no internet connection
                return false;
            }
        }

        /* @void NO_ACTION
         * @description Make no action
         * @author mirkobrombin
        */
        public void NO_ACTION()
        {
            // no action
        }

        /* @void DOWNLOAD_DATA
         * @description Download a file and make action at DownloadFileCompleted
         * @params ProgressBar(progressbar), string(url), string(name), Action(function)
         * @author mirkobrombin
        */
        public void DOWNLOAD_DATA(ProgressBar progressbar, string url, string name, Action function)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += (s, e) =>
            {
                progressbar.Value = e.ProgressPercentage;
            };
            webClient.DownloadFileCompleted += (s, e) =>
            {
                function();
            };
            webClient.DownloadFileAsync(new Uri(url), name);
        }

    }
}