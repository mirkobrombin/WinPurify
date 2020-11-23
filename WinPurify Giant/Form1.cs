using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPurify_Giant
{
    public partial class Form1 : Form
    {

        // Window move
        private const int wM_NCLBUTTONDOWN = 0xA1;
        private const int hT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void window_bar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public static int WM_NCLBUTTONDOWN
        {
            get
            {
                return wM_NCLBUTTONDOWN;
            }
        }

        public static int HT_CAPTION
        {
            get
            {
                return hT_CAPTION;
            }
        }

        // Load form
        public Form1()
        {
            InitializeComponent();
        }

        // Welcome toast and load configs
        private void Form1_Load(object sender, EventArgs e)
        {
            winpurify_progressbar.BackColor = Color.LimeGreen;
            winpurify_progressbar.ForeColor = Color.DarkGray;

            var core = new Core();
            var f = new Functions();

            core.DO_TOAST(notifications, "Welcome to WinPurify!", "Improves your PC's performance with WinPurify!");

            // load config
            if (f.LOAD("winpurify_telemetry") == "1")
            {
                t_disable_telemetry.Checked = true;
            }
            else
            {
                t_disable_telemetry.Checked = false;
            }
            if (f.LOAD("winpurify_analytics") == "1")
            {
                t_disable_webanalytics.Checked = true;
            }
            else
            {
                t_disable_webanalytics.Checked = false;
            }
            if (f.LOAD("winpurify_pishing") == "1")
            {
                t_disable_webpishing.Checked = true;
            }
            else
            {
                t_disable_webpishing.Checked = false;
            }
            if (f.LOAD("winpurify_feedback") == "1")
            {
                t_disable_crashlog.Checked = true;
            }
            else
            {
                t_disable_crashlog.Checked = false;
            }
            if (f.LOAD("winpurify_defender") == "1")
            {
                t_disable_windowsdefender.Checked = true;
            }
            else
            {
                t_disable_windowsdefender.Checked = false;
            }
            if (f.LOAD("winpurify_remote") == "1")
            {
                t_make_restorepoint.Checked = true;
            }
            else
            {
                t_make_restorepoint.Checked = false;
            }
            if (f.LOAD("winpurify_ads") == "1")
            {
                t_disable_remote.Checked = true;
            }
            else
            {
                t_disable_remote.Checked = false;
            }
            if (f.LOAD("winpurify_tracking") == "1")
            {
                t_disable_advertisingid.Checked = true;
            }
            else
            {
                t_disable_advertisingid.Checked = false;
            }
            if (f.LOAD("winpurify_logging") == "1")
            {
                t_disable_trackinginfo.Checked = true;
            }
            else
            {
                t_disable_trackinginfo.Checked = false;
            }
            if (f.LOAD("winpurify_wifisense") == "1")
            {
                t_disable_loggingservices.Checked = true;
            }
            else
            {
                t_disable_loggingservices.Checked = false;
            }
            if (f.LOAD("winpurify_winupdate") == "1")
            {
                t_disable_wifisense.Checked = true;
            }
            else
            {
                t_disable_wifisense.Checked = false;
            }
            if (f.LOAD("winpurify_wineffects") == "1")
            {
                t_disable_winupdates.Checked = true;
            }
            else
            {
                t_disable_winupdates.Checked = false;
            }
            if (f.LOAD("winpurify_winmove") == "1")
            {
                t_disable_windowseffects.Checked = true;
            }
            else
            {
                t_disable_windowseffects.Checked = false;
            }
            if (f.LOAD("winpurify_help") == "1")
            {
                t_disable_windowmoving.Checked = true;
            }
            else
            {
                t_disable_windowmoving.Checked = false;
            }
            if (f.LOAD("winpurify_temp") == "1")
            {
                t_remove_helpfiles.Checked = true;
            }
            else
            {
                t_remove_helpfiles.Checked = false;
            }
            if (f.LOAD("winpurify_winupcache") == "1")
            {
                t_prune_tempfolder.Checked = true;
            }
            else
            {
                t_prune_tempfolder.Checked = false;
            }
            if (f.LOAD("winpurify_notificationscenter") == "1")
            {
                t_prune_windowsupdatecache.Checked = true;
            }
            else
            {
                t_prune_windowsupdatecache.Checked = false;
            }
            if (f.LOAD("winpurify_multidesktop") == "1")
            {
                t_disable_notificationcenter.Checked = true;
            }
            else
            {
                t_disable_notificationcenter.Checked = false;
            }
            if (f.LOAD("winpurify_replacecalendar") == "1")
            {
                t_disable_multidesktop.Checked = true;
            }
            else
            {
                t_disable_multidesktop.Checked = false;
            }
            if (f.LOAD("winpurify_replacecmd") == "1")
            {
                t_replace_calendar.Checked = true;
            }
            else
            {
                t_replace_calendar.Checked = false;
            }
            if (f.LOAD("winpurify_aeroshake") == "1")
            {
                t_replace_cmd.Checked = true;
            }
            else
            {
                t_replace_cmd.Checked = false;
            }
            if (f.LOAD("winpurify_startdelay") == "1")
            {
                t_disable_aeroshake.Checked = true;
            }
            else
            {
                t_disable_aeroshake.Checked = false;
            }
            if (f.LOAD("winpurify_showext") == "1")
            {
                t_disable_startupdelay.Checked = true;
            }
            else
            {
                t_disable_startupdelay.Checked = false;
            }
            if (f.LOAD("winpurify_pagefiles") == "1")
            {
                t_show_ext.Checked = true;
            }
            else
            {
                t_show_ext.Checked = false;
            }
            if (f.LOAD("winpurify_legacynotifications") == "1")
            {
                t_enable_legacynotifications.Checked = true;
            }
            else
            {
                t_enable_legacynotifications.Checked = false;
            }
            if (f.LOAD("winpurify_updaterestart") == "1")
            {
                t_enable_legacynotifications.Checked = true;
            }
            else
            {
                t_enable_legacynotifications.Checked = false;
            }
            if (f.LOAD("winpurify_xptaskbar") == "1")
            {
                t_show_xptaskbar.Checked = true;
            }
            else
            {
                t_show_xptaskbar.Checked = false;
            }
            if (f.LOAD("winpurify_uwpsupport") == "1")
            {
                t_remove_uwpsupport.Checked = true;
            }
            else
            {
                t_remove_uwpsupport.Checked = false;
            }
            if (f.LOAD("winpurify_preinstalled") == "1")
            {
                t_remove_allpreinstalled.Checked = true;
            }
            else
            {
                t_remove_allpreinstalled.Checked = false;
            }
            if (f.LOAD("winpurify_cortana") == "1")
            {
                t_disable_cortana.Checked = true;
            }
            else
            {
                t_disable_cortana.Checked = false;
            }
            if (f.LOAD("winpurify_store") == "1")
            {
                t_disable_store.Checked = true;
            }
            else
            {
                t_disable_store.Checked = false;
            }
            if (f.LOAD("winpurify_edge") == "1")
            {
                t_disable_edge.Checked = true;
            }
            else
            {
                t_disable_edge.Checked = false;
            }
            if (f.LOAD("winpurify_groove") == "1")
            {
                t_remove_groove.Checked = true;
            }
            else
            {
                t_remove_groove.Checked = false;
            }
            if (f.LOAD("winpurify_outlook") == "1")
            {
                t_remove_outlook.Checked = true;
            }
            else
            {
                t_remove_outlook.Checked = false;
            }
            if (f.LOAD("winpurify_filmstv") == "1")
            {
                t_remove_filmstv.Checked = true;
            }
            else
            {
                t_remove_filmstv.Checked = false;
            }
            if (f.LOAD("winpurify_photolegacy") == "1")
            {
                t_replace_photolegacy.Checked = true;
            }
            else
            {
                t_replace_photolegacy.Checked = false;
            }
            if (f.LOAD("winpurify_getoffice") == "1")
            {
                t_remove_getoffice.Checked = true;
            }
            else
            {
                t_remove_getoffice.Checked = false;
            }
            if (f.LOAD("winpurify_weather") == "1")
            {
                t_remove_weather.Checked = true;
            }
            else
            {
                t_remove_weather.Checked = false;
            }
            if (f.LOAD("winpurify_news") == "1")
            {
                t_remove_news.Checked = true;
            }
            else
            {
                t_remove_news.Checked = false;
            }
            if (f.LOAD("winpurify_contacts") == "1")
            {
                t_remove_contacts.Checked = true;
            }
            else
            {
                t_remove_contacts.Checked = false;
            }
            if (f.LOAD("winpurify_skypeprev") == "1")
            {
                t_remove_skypepreview.Checked = true;
            }
            else
            {
                t_remove_skypepreview.Checked = false;
            }
            if (f.LOAD("winpurify_xbox") == "1")
            {
                t_remove_xbox.Checked = true;
            }
            else
            {
                t_remove_xbox.Checked = false;
            }
            if (f.LOAD("winpurify_onedrive") == "1")
            {
                t_remove_onedrive.Checked = true;
            }
            else
            {
                t_remove_onedrive.Checked = false;
            }
        }

        private void metroTabPage1_Click(object sender, EventArgs e) { }

        // Close button
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Switch tiles
        private void tilePrivacy_Click(object sender, EventArgs e)
        {
            wintabs.SelectTab(tabPrivacy);
        }

        private void tilePerformance_Click(object sender, EventArgs e)
        {
            wintabs.SelectTab(tabPerformance);
        }

        private void tileApps_Click(object sender, EventArgs e)
        {
            wintabs.SelectTab(tabApps);
        }

        private void tileGaming_Click(object sender, EventArgs e)
        {
            wintabs.SelectTab(tabGaming);
        }

        private void metroLabel38_Click(object sender, EventArgs e) { }

        private void metroLabel42_Click(object sender, EventArgs e) { }

        // Select all voices
        private void selectall_privacy_CheckedChanged(object sender, EventArgs e)
        {
            if (selectall_privacy.Checked == true)
            {
                t_disable_telemetry.Checked = true;
                t_disable_webanalytics.Checked = true;
                t_disable_webpishing.Checked = true;
                t_disable_crashlog.Checked = true;
                t_disable_windowsdefender.Checked = true;
                // t_make_restorepoint.Checked = true;
                // t_scan_hdd.Checked = true;
                t_disable_advertisingid.Checked = true;
                t_disable_trackinginfo.Checked = true;
                t_disable_loggingservices.Checked = true;
                t_disable_wifisense.Checked = true;
            }
            else
            {
                t_disable_telemetry.Checked = false;
                t_disable_webanalytics.Checked = false;
                t_disable_webpishing.Checked = false;
                t_disable_crashlog.Checked = false;
                t_disable_windowsdefender.Checked = false;
                // t_make_restorepoint.Checked = false;
                // t_scan_hdd.Checked = false;
                t_disable_advertisingid.Checked = false;
                t_disable_trackinginfo.Checked = false;
                t_disable_loggingservices.Checked = false;
                t_disable_wifisense.Checked = false;
            }
        }

        private void selectall_performance_CheckedChanged(object sender, EventArgs e)
        {
            if (selectall_performance.Checked == true)
            {
                t_disable_winupdates.Checked = true;
                t_disable_windowseffects.Checked = true;
                t_disable_windowmoving.Checked = true;
                t_remove_helpfiles.Checked = true;
                t_prune_tempfolder.Checked = true;
                t_prune_windowsupdatecache.Checked = true;
                t_disable_notificationcenter.Checked = true;
                t_disable_multidesktop.Checked = true;
                t_replace_calendar.Checked = true;
                t_replace_cmd.Checked = true;
                t_disable_aeroshake.Checked = true;
                t_disable_startupdelay.Checked = true;
                t_show_ext.Checked = true;
                t_delete_pagefiles.Checked = true;
                t_enable_legacynotifications.Checked = true;
                t_prevent_updateshutdown.Checked = true;
                t_show_xptaskbar.Checked = true;
            }
            else
            {
                t_disable_winupdates.Checked = false;
                t_disable_windowseffects.Checked = false;
                t_disable_windowmoving.Checked = false;
                t_remove_helpfiles.Checked = false;
                t_prune_tempfolder.Checked = false;
                t_prune_windowsupdatecache.Checked = false;
                t_disable_notificationcenter.Checked = false;
                t_disable_multidesktop.Checked = false;
                t_replace_calendar.Checked = false;
                t_replace_cmd.Checked = false;
                t_disable_aeroshake.Checked = false;
                t_disable_startupdelay.Checked = false;
                t_show_ext.Checked = false;
                t_delete_pagefiles.Checked = false;
                t_enable_legacynotifications.Checked = false;
                t_prevent_updateshutdown.Checked = false;
                t_show_xptaskbar.Checked = false;
            }
        }

        private void selectall_apps_CheckedChanged(object sender, EventArgs e)
        {
            if (selectall_apps.Checked == true)
            {
                t_disable_cortana.Checked = true;
                t_disable_store.Checked = true;
                t_disable_edge.Checked = true;
                t_remove_groove.Checked = true;
                t_remove_outlook.Checked = true;
                t_remove_filmstv.Checked = true;
                t_replace_photolegacy.Checked = true;
                t_remove_getoffice.Checked = true;
                t_remove_weather.Checked = true;
                t_remove_news.Checked = true;
                t_remove_contacts.Checked = true;
                t_remove_skypepreview.Checked = true;
                t_remove_xbox.Checked = true;
                t_remove_onedrive.Checked = true;
                t_remove_allpreinstalled.Checked = true;
                t_remove_uwpsupport.Checked = true;
            }
            else
            {
                t_disable_cortana.Checked = false;
                t_disable_store.Checked = false;
                t_disable_edge.Checked = false;
                t_remove_groove.Checked = false;
                t_remove_outlook.Checked = false;
                t_remove_filmstv.Checked = false;
                t_replace_photolegacy.Checked = false;
                t_remove_getoffice.Checked = false;
                t_remove_weather.Checked = false;
                t_remove_news.Checked = false;
                t_remove_contacts.Checked = false;
                t_remove_skypepreview.Checked = false;
                t_remove_xbox.Checked = false;
                t_remove_onedrive.Checked = false;
                t_remove_allpreinstalled.Checked = false;
                t_remove_uwpsupport.Checked = false;
            }
        }

        // Show start button on tab switch
        void wintabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (wintabs.SelectedTab != tabHome)
            {
                btn_start.Visible = true;
            }
            else
            {
                btn_start.Visible = false;
            }
        }

        // Visit winpurify website
        private void www_winpurify_Click(object sender, EventArgs e)
        {
            var core = new Core();
            core.RUN_PROCESS("http://winpurify.xyz/");
        }

        // Start purify
        private void btn_start_Click(object sender, EventArgs e)
        {
            // Start progressbar
            winpurify_progressbar.Invoke(new Action(() =>
            {
                winpurify_progressbar.Style = ProgressBarStyle.Marquee;
            }));

            var f = new Functions();

            // Kill explorer process
            f.KILL_EXPLORER();

            // Privacy actions
            if (t_disable_telemetry.Checked)
            {
                try
                {
                    f.DISABLE_TELEMETRY();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_TELEMETRY("restore");
                }
                catch { }
            }
            if (t_disable_webanalytics.Checked)
            {
                try
                {
                    f.DISABLE_ANALYTICS();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_ANALYTICS("restore");
                }
                catch { }
            }
            if (t_disable_webpishing.Checked)
            {
                try
                {
                    f.DISABLE_WEBPISHING();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_WEBPISHING("restore");
                }
                catch { }
            }
            if (t_disable_crashlog.Checked)
            {
                try
                {
                    f.DISABLE_CRASHLOGFEEDBACK();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_CRASHLOGFEEDBACK("restore");
                }
                catch { }
            }
            if (t_disable_windowsdefender.Checked)
            {
                try
                {
                    f.DISABLE_WINDOWSDEFENDER();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_WINDOWSDEFENDER("restore");
                }
                catch { }
            }
            if (t_make_restorepoint.Checked)
            {
                try
                {
                    f.MAKE_RESTOREPOINT();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.MAKE_RESTOREPOINT("restore");
                }
                catch { }
            }
            if (t_disable_remote.Checked)
            {
                try
                {
                    f.DISABLE_REMOTE();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_REMOTE("restore");
                }
                catch { }
            }
            if (t_disable_advertisingid.Checked)
            {
                try
                {
                    f.DISABLE_ADVERTISINGID();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_ADVERTISINGID("restore");
                }
                catch { }
            }
            if (t_disable_trackinginfo.Checked)
            {
                try
                {
                    f.DISABLE_TRACKINGINFO();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_TRACKINGINFO("restore");
                }
                catch { }
            }
            if (t_disable_loggingservices.Checked)
            {
                try
                {
                    f.DISABLE_TRACKINGINFO();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_TRACKINGINFO("restore");
                }
                catch { }
            }
            if (t_disable_wifisense.Checked)
            {
                try
                {
                    f.DISABLE_WIFISENSE();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_WIFISENSE("restore");
                }
                catch { }
            }

            // Performance actions
            if (t_disable_winupdates.Checked)
            {
                try
                {
                    f.DISABLE_WINUPDATES();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_WINUPDATES("restore");
                }
                catch { }
            }
            if (t_disable_windowseffects.Checked)
            {
                try
                {
                    f.DISABLE_WINDOWSEFFECTS();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_WINDOWSEFFECTS("restore");
                }
                catch { }
            }
            if (t_disable_windowmoving.Checked)
            {
                try
                {
                    f.DISABLE_WINDOWMOVING();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_WINDOWMOVING("restore");
                }
                catch { }
            }
            if (t_remove_helpfiles.Checked)
            {
                try
                {
                    f.REMOVE_HELPFILES();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.REMOVE_HELPFILES("restore");
                }
                catch { }
            }
            if (t_prune_tempfolder.Checked)
            {
                try
                {
                    f.PRUNE_TEMPFOLDER();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.PRUNE_TEMPFOLDER("restore");
                }
                catch { }
            }
            if (t_prune_windowsupdatecache.Checked)
            {
                try
                {
                    f.PRUNE_WINDOWSUPDATECACHE();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.PRUNE_WINDOWSUPDATECACHE("restore");
                }
                catch { }
            }
            if (t_disable_notificationcenter.Checked)
            {
                try
                {
                    f.DISABLE_NOTIFICATIONCENTER();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_NOTIFICATIONCENTER("restore");
                }
                catch { }
            }
            if (t_disable_multidesktop.Checked)
            {
                try
                {
                    f.DISABLE_MULTIDESKTOP();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_MULTIDESKTOP("restore");
                }
                catch { }
            }
            if (t_replace_calendar.Checked)
            {
                try
                {
                    f.REPLACE_CALENDAR();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.REPLACE_CALENDAR("restore");
                }
                catch { }
            }
            if (t_replace_cmd.Checked)
            {
                try
                {
                    f.REPLACE_CMD();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.REPLACE_CMD("restore");
                }
                catch { }
            }
            if (t_disable_aeroshake.Checked)
            {
                try
                {
                    f.DISABLE_AEROSHAKE();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_AEROSHAKE("restore");
                }
                catch { }
            }
            if (t_disable_startupdelay.Checked)
            {
                try
                {
                    f.DISABLE_STARTUPDELAY();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DISABLE_STARTUPDELAY("restore");
                }
                catch { }
            }
            if (t_show_ext.Checked)
            {
                try
                {
                    f.SHOW_EXT();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.SHOW_EXT("restore");
                }
                catch { }
            }
            if (t_delete_pagefiles.Checked)
            {
                try
                {
                    f.DELETE_PAGEFILES();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.DELETE_PAGEFILES("restore");
                }
                catch { }
            }
            if (t_enable_legacynotifications.Checked)
            {
                try
                {
                    f.ENABLE_LEGACYNOTIFICATIONS();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.ENABLE_LEGACYNOTIFICATIONS("restore");
                }
                catch { }
            }
            if (t_prevent_updateshutdown.Checked)
            {
                try
                {
                    f.PREVENT_UPDATESHUTDOWN();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.PREVENT_UPDATESHUTDOWN("restore");
                }
                catch { }
            }
            if (t_show_xptaskbar.Checked)
            {
                try
                {
                    f.SHOW_XPTASKBAR();
                }
                catch { }
            }
            else
            {
                try
                {
                    f.SHOW_XPTASKBAR("restore");
                }
                catch { }
            }

            // Apps actions
            if (t_remove_uwpsupport.Checked)
            {
                try
                {
                    f.REMOVE_UWPSUPPORT();
                }
                catch { }
            }
            else if (t_remove_allpreinstalled.Checked)
            {
                try
                {
                    f.REMOVE_UWPSUPPORT();
                }
                catch { }
            }
            else
            {
                if (t_disable_cortana.Checked)
                {
                    try
                    {
                        f.DISABLE_CORTANA();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_CORTANA("restore");
                    }
                    catch { }
                }
                if (t_disable_store.Checked)
                {
                    try
                    {
                        f.DISABLE_STORE();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_STORE("restore");
                    }
                    catch { }
                }
                if (t_disable_edge.Checked)
                {
                    try
                    {
                        f.DISABLE_EDGE();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_EDGE("restore");
                    }
                    catch { }
                }
                if (t_remove_groove.Checked)
                {
                    try
                    {
                        f.DISABLE_GROOVE();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_GROOVE("restore");
                    }
                    catch { }
                }
                if (t_remove_outlook.Checked)
                {
                    try
                    {
                        f.DISABLE_OUTLOOK();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_OUTLOOK("restore");
                    }
                    catch { }
                }
                if (t_remove_filmstv.Checked)
                {
                    try
                    {
                        f.DISABLE_FILMSTV();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_FILMSTV("restore");
                    }
                    catch { }
                }
                if (t_replace_photolegacy.Checked)
                {
                    try
                    {
                        f.REPLACE_PHOTOLEGACY();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.REPLACE_PHOTOLEGACY("restore");
                    }
                    catch { }
                }
                if (t_remove_getoffice.Checked)
                {
                    try
                    {
                        f.DISABLE_GETOFFICE();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_GETOFFICE("restore");
                    }
                    catch { }
                }
                if (t_remove_weather.Checked)
                {
                    try
                    {
                        f.DISABLE_WEATHER();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_WEATHER("restore");
                    }
                    catch { }
                }
                if (t_remove_news.Checked)
                {
                    try
                    {
                        f.DISABLE_NEWS();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_NEWS("restore");
                    }
                    catch { }
                }
                if (t_remove_contacts.Checked)
                {
                    try
                    {
                        f.DISABLE_CONTACTS();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_CONTACTS("restore");
                    }
                    catch { }
                }
                if (t_remove_skypepreview.Checked)
                {
                    try
                    {
                        f.DISABLE_SKYPEPREVIEW();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_SKYPEPREVIEW("restore");
                    }
                    catch { }
                }
                if (t_remove_xbox.Checked)
                {
                    try
                    {
                        f.DISABLE_XBOX();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_XBOX("restore");
                    }
                    catch { }
                }
                if (t_remove_onedrive.Checked)
                {
                    try
                    {
                        f.DISABLE_ONEDRIVE();
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        f.DISABLE_ONEDRIVE("restore");
                    }
                    catch { }
                }
            }

            // Kill explorer process
            f.KILL_EXPLORER();

            // Show finish notification
            var core = new Core();
            core.DO_TOAST(notifications, "WinPurify", "Your PC is now purified!");

            // Stop progressbar
            winpurify_progressbar.MarqueeAnimationSpeed = 0;

        }
    }
}
