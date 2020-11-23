using Microsoft.Win32;
using System;
using System.Management;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WinPurify_Giant
{
    class Functions
    {
        // Routine functions
        public void KILL_EXPLORER()
        {
            var core = new Core();

            // Kill explorer as first action
            core.KILL_PROCESS("explorer");
        }
        public void START_EXPLORER()
        {
            var core = new Core();

            // Run explorer with Taskbar
            KILL_EXPLORER();
            core.RUN_EXPLORER_TASKBAR();
        }
        public void SAVE(string param, string value)
        {
            var core = new Core();

            core.REGISTRY_USER_WRITE(@"SOFTWARE", param, value, "true");
        }
        public string LOAD(string param)
        {
            var core = new Core();

            return core.REGISTRY_READ(@"SOFTWARE", param);
        }
        // Privacy functions
        public void DISABLE_TELEMETRY(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Step (1) regedit Normal
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", "00000000", "true");
                // Step (2) regedit TIPC
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Input", "TIPC", "0");
                // Step (3) hosts
                string hosts_text = " # Telemetry hosts killer by: mirko.space & winpurify.xyz\n\n # No telemetry in your windows 10 installation\n\n # www.mirko.space for more informations\n\n \n\n 0.0.0.0 vortex.data.microsoft.com \n\n 0.0.0.0 aidps.atdmt.com \n\n 0.0.0.0 apps.skype.com \n\n 0.0.0.0 a.rad.msn.com \n\n 0.0.0.0 a.ads2.msads.net \n\n 0.0.0.0 ac3.msn.com \n\n 0.0.0.0 aka-cdn-ns.adtech.de \n\n 0.0.0.0 b.rad.msn.com \n\n 0.0.0.0 b.ads2.msads.net \n\n 0.0.0.0 b.ads1.msn.com \n\n 0.0.0.0 bs.serving-sys.com \n\n 0.0.0.0 c.msn.com \n\n 0.0.0.0 cdn.atdmt.com \n\n 0.0.0.0 cds26.ams9.msecn.net \n\n 0.0.0.0 c.atdmt.com \n\n 0.0.0.0 db3aqu.atdmt.com \n\n 0.0.0.0 ec.atdmt.com \n\n 0.0.0.0 flex.msn.com \n\n 0.0.0.0 g.msn.com \n\n 0.0.0.0 h2.msn.com \n\n 0.0.0.0 h1.msn.com \n\n 0.0.0.0 live.rads.msn.com \n\n 0.0.0.0 msntest.serving-sys.com \n\n 0.0.0.0 m.adnxs.com \n\n 0.0.0.0 m.hotmail.com \n\n 0.0.0.0 pricelist.skype.com \n\n 0.0.0.0 rad.live.com \n\n 0.0.0.0 secure.flashtalking.com \n\n 0.0.0.0 static.2mdn.net \n\n 0.0.0.0 s.gateway.messenger.live.com \n\n 0.0.0.0 secure.adnxs.com \n\n 0.0.0.0 sO.2mdn.net \n\n 0.0.0.0 ui.skype.com \n\n 0.0.0.0 http://www.msftncsi.com \n\n 0.0.0.0 msftncsi.com \n\n 0.0.0.0 view.atdmt.com \n\n 0.0.0.0 vortex.data.microsoft.com \n\n 0.0.0.0 data.microsoft.com \n\n 0.0.0.0 vortex-win.data.microsoft.com \n\n 0.0.0.0 telecommand.telemetry.microsoft.com \n\n 0.0.0.0 telemetry.microsoft.com \n\n 0.0.0.0 telecommand.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 oca.telemetry.microsoft.com \n\n 0.0.0.0 oca.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 sqm.telemetry.microsoft.com \n\n 0.0.0.0 sqm.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 watson.telemetry.microsoft.com \n\n 0.0.0.0 watson.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 redir.metaservices.microsoft.com \n\n 0.0.0.0 choice.microsoft.com \n\n 0.0.0.0 choice.microsoft.com.nsatc.net \n\n 0.0.0.0 df.telemetry.microsoft.com \n\n 0.0.0.0 reports.wes.df.telemetry.microsoft.com \n\n 0.0.0.0 wes.df.telemetry.microsoft.com \n\n 0.0.0.0 services.wes.df.telemetry.microsoft.com \n\n 0.0.0.0 sqm.df.telemetry.microsoft.com \n\n 0.0.0.0 telemetry.microsoft.com \n\n 0.0.0.0 watson.ppe.telemetry.microsoft.com \n\n 0.0.0.0 telemetry.appex.bing.net \n\n 0.0.0.0 telemetry.urs.microsoft.com \n\n 0.0.0.0 telemetry.appex.bing.net:443 \n\n 0.0.0.0 settings-sandbox.data.microsoft.com \n\n 0.0.0.0 vortex-sandbox.data.microsoft.com \n\n 0.0.0.0 survey.watson.microsoft.com \n\n 0.0.0.0 watson.live.com \n\n 0.0.0.0 watson.microsoft.com \n\n 0.0.0.0 statsfe2.ws.microsoft.com \n\n 0.0.0.0 corpext.msitadfs.glbdns2.microsoft.com \n\n 0.0.0.0 compatexchange.cloudapp.net \n\n 0.0.0.0 cs1.wpc.v0cdn.net \n\n 0.0.0.0 a-0001.a-msedge.net \n\n 0.0.0.0 statsfe2.update.microsoft.com.akadns.net \n\n 0.0.0.0 sls.update.microsoft.com.akadns.net \n\n 0.0.0.0 update.microsoft.com.akadns.net \n\n 0.0.0.0 fe2.update.microsoft.com.akadns.net \n\n 0.0.0.0 diagnostics.support.microsoft.com \n\n 0.0.0.0 support.microsoft.com \n\n 0.0.0.0 corp.sts.microsoft.com \n\n 0.0.0.0 statsfe1.ws.microsoft.com \n\n 0.0.0.0 pre.footprintpredict.com \n\n 0.0.0.0 i1.services.social.microsoft.com \n\n 0.0.0.0 i1.services.social.microsoft.com.nsatc.net \n\n 0.0.0.0 feedback.windows.com \n\n 0.0.0.0 feedback.microsoft-hohm.com \n\n 0.0.0.0 feedback.search.microsoft.com \n\n 0.0.0.0 rad.msn.com \n\n 0.0.0.0 preview.msn.com \n\n 0.0.0.0 ad.doubleclick.net \n\n 0.0.0.0 ads.msn.com \n\n 0.0.0.0 ads1.msads.net \n\n 0.0.0.0 ads1.msn.com \n\n 0.0.0.0 a.ads1.msn.com \n\n 0.0.0.0 a.ads2.msn.com \n\n 0.0.0.0 adnexus.net \n\n 0.0.0.0 adnxs.com \n\n 0.0.0.0 az361816.vo.msecnd.net \n\n 0.0.0.0 az512334.vo.msecnd.net \n\n 0.0.0.0 prod-w.nexus.live.com.akadns.net \n\n 0.0.0.0 view.atdmt.com \n\n 0.0.0.0 msn.com \n\n 0.0.0.0 www.msn.com ";
                core.WRITE_TO_HOST(hosts_text);
                core.POWERSHELL("ipconfig /flushdns");
                core.POWERSHELL(@"cd .\drivers\etc\");
                core.POWERSHELL("nbtstat -R");
                core.POWERSHELL("ipconfig /displaydns | more");
                // Step (4) persistent DiagTrack + Powershell regedit
                core.POWERSHELL("Get-Service DiagTrack | Set-Service -StartupType Disabled");
                core.POWERSHELL("Get-Service dmwappushservice | Set-Service -StartupType Disabled");
                core.POWERSHELL(@"reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection\ /v AllowTelemetry /t REG_DWORD /d 0 /f");

                // save
                SAVE("winpurify_telemetry", "1");
            }
            else
            {
                if (LOAD("winpurify_telemetry") == "1")
                {
                    // Step (1) regedit Normal
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", "AllowTelemetry", "00000001", "true");
                    // Step (2) regedit TIPC
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Input", "TIPC", "1");
                    // Step (3) hosts
                    string hosts_text = " # Telemetry hosts killer by: mirko.space & winpurify.xyz\n\n # No telemetry in your windows 10 installation\n\n # www.mirko.space for more informations\n\n \n\n 0.0.0.0 vortex.data.microsoft.com \n\n 0.0.0.0 aidps.atdmt.com \n\n 0.0.0.0 apps.skype.com \n\n 0.0.0.0 a.rad.msn.com \n\n 0.0.0.0 a.ads2.msads.net \n\n 0.0.0.0 ac3.msn.com \n\n 0.0.0.0 aka-cdn-ns.adtech.de \n\n 0.0.0.0 b.rad.msn.com \n\n 0.0.0.0 b.ads2.msads.net \n\n 0.0.0.0 b.ads1.msn.com \n\n 0.0.0.0 bs.serving-sys.com \n\n 0.0.0.0 c.msn.com \n\n 0.0.0.0 cdn.atdmt.com \n\n 0.0.0.0 cds26.ams9.msecn.net \n\n 0.0.0.0 c.atdmt.com \n\n 0.0.0.0 db3aqu.atdmt.com \n\n 0.0.0.0 ec.atdmt.com \n\n 0.0.0.0 flex.msn.com \n\n 0.0.0.0 g.msn.com \n\n 0.0.0.0 h2.msn.com \n\n 0.0.0.0 h1.msn.com \n\n 0.0.0.0 live.rads.msn.com \n\n 0.0.0.0 msntest.serving-sys.com \n\n 0.0.0.0 m.adnxs.com \n\n 0.0.0.0 m.hotmail.com \n\n 0.0.0.0 pricelist.skype.com \n\n 0.0.0.0 rad.live.com \n\n 0.0.0.0 secure.flashtalking.com \n\n 0.0.0.0 static.2mdn.net \n\n 0.0.0.0 s.gateway.messenger.live.com \n\n 0.0.0.0 secure.adnxs.com \n\n 0.0.0.0 sO.2mdn.net \n\n 0.0.0.0 ui.skype.com \n\n 0.0.0.0 http://www.msftncsi.com \n\n 0.0.0.0 msftncsi.com \n\n 0.0.0.0 view.atdmt.com \n\n 0.0.0.0 vortex.data.microsoft.com \n\n 0.0.0.0 data.microsoft.com \n\n 0.0.0.0 vortex-win.data.microsoft.com \n\n 0.0.0.0 telecommand.telemetry.microsoft.com \n\n 0.0.0.0 telemetry.microsoft.com \n\n 0.0.0.0 telecommand.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 oca.telemetry.microsoft.com \n\n 0.0.0.0 oca.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 sqm.telemetry.microsoft.com \n\n 0.0.0.0 sqm.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 watson.telemetry.microsoft.com \n\n 0.0.0.0 watson.telemetry.microsoft.com.nsatc.net \n\n 0.0.0.0 redir.metaservices.microsoft.com \n\n 0.0.0.0 choice.microsoft.com \n\n 0.0.0.0 choice.microsoft.com.nsatc.net \n\n 0.0.0.0 df.telemetry.microsoft.com \n\n 0.0.0.0 reports.wes.df.telemetry.microsoft.com \n\n 0.0.0.0 wes.df.telemetry.microsoft.com \n\n 0.0.0.0 services.wes.df.telemetry.microsoft.com \n\n 0.0.0.0 sqm.df.telemetry.microsoft.com \n\n 0.0.0.0 telemetry.microsoft.com \n\n 0.0.0.0 watson.ppe.telemetry.microsoft.com \n\n 0.0.0.0 telemetry.appex.bing.net \n\n 0.0.0.0 telemetry.urs.microsoft.com \n\n 0.0.0.0 telemetry.appex.bing.net:443 \n\n 0.0.0.0 settings-sandbox.data.microsoft.com \n\n 0.0.0.0 vortex-sandbox.data.microsoft.com \n\n 0.0.0.0 survey.watson.microsoft.com \n\n 0.0.0.0 watson.live.com \n\n 0.0.0.0 watson.microsoft.com \n\n 0.0.0.0 statsfe2.ws.microsoft.com \n\n 0.0.0.0 corpext.msitadfs.glbdns2.microsoft.com \n\n 0.0.0.0 compatexchange.cloudapp.net \n\n 0.0.0.0 cs1.wpc.v0cdn.net \n\n 0.0.0.0 a-0001.a-msedge.net \n\n 0.0.0.0 statsfe2.update.microsoft.com.akadns.net \n\n 0.0.0.0 sls.update.microsoft.com.akadns.net \n\n 0.0.0.0 update.microsoft.com.akadns.net \n\n 0.0.0.0 fe2.update.microsoft.com.akadns.net \n\n 0.0.0.0 diagnostics.support.microsoft.com \n\n 0.0.0.0 support.microsoft.com \n\n 0.0.0.0 corp.sts.microsoft.com \n\n 0.0.0.0 statsfe1.ws.microsoft.com \n\n 0.0.0.0 pre.footprintpredict.com \n\n 0.0.0.0 i1.services.social.microsoft.com \n\n 0.0.0.0 i1.services.social.microsoft.com.nsatc.net \n\n 0.0.0.0 feedback.windows.com \n\n 0.0.0.0 feedback.microsoft-hohm.com \n\n 0.0.0.0 feedback.search.microsoft.com \n\n 0.0.0.0 rad.msn.com \n\n 0.0.0.0 preview.msn.com \n\n 0.0.0.0 ad.doubleclick.net \n\n 0.0.0.0 ads.msn.com \n\n 0.0.0.0 ads1.msads.net \n\n 0.0.0.0 ads1.msn.com \n\n 0.0.0.0 a.ads1.msn.com \n\n 0.0.0.0 a.ads2.msn.com \n\n 0.0.0.0 adnexus.net \n\n 0.0.0.0 adnxs.com \n\n 0.0.0.0 az361816.vo.msecnd.net \n\n 0.0.0.0 az512334.vo.msecnd.net \n\n 0.0.0.0 prod-w.nexus.live.com.akadns.net \n\n 0.0.0.0 view.atdmt.com \n\n 0.0.0.0 msn.com \n\n 0.0.0.0 www.msn.com ";
                    core.WRITE_TO_HOST(hosts_text);
                    core.POWERSHELL("ipconfig /flushdns");
                    core.POWERSHELL(@"cd .\drivers\etc\");
                    core.POWERSHELL("nbtstat -R");
                    core.POWERSHELL("ipconfig /displaydns | more");
                    // Step (4) persistent DiagTrack + Powershell regedit
                    core.POWERSHELL("Get-Service DiagTrack | Set-Service -StartupType Disabled");
                    core.POWERSHELL("Get-Service dmwappushservice | Set-Service -StartupType Disabled");
                    core.POWERSHELL(@"reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection\ /v AllowTelemetry /t REG_DWORD /d 0 /f");
                }
                // save
                SAVE("winpurify_telemetry", "0");
            }
        }
        public void DISABLE_ANALYTICS(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Step (1) Google
                string hosts_google = "NO \n\n #Block Google telemetry domains \n\n  \n\n 0.0.0.0 mellowads.com \n\n 0.0.0.0 cm.mgid.com \n\n 0.0.0.0 mgid.com \n\n 0.0.0.0 ao-gb.mgid.com \n\n 0.0.0.0 pagead.googlesyndication.com \n\n 0.0.0.0 pagead2.googlesyndication.com \n\n 0.0.0.0 adservices.google.com \n\n 0.0.0.0 ssl.google-analytics.com  \n\n 0.0.0.0 www.google-analytics.com \n\n 0.0.0.0 googleadservices.com  \n\n 0.0.0.0 imageads.googleadservices.com  \n\n 0.0.0.0 imageads1.googleadservices.com \n\n 0.0.0.0 imageads2.googleadservices.com \n\n 0.0.0.0 imageads3.googleadservices.com \n\n 0.0.0.0 imageads4.googleadservices.com \n\n 0.0.0.0 imageads5.googleadservices.com \n\n 0.0.0.0 imageads6.googleadservices.com \n\n 0.0.0.0 imageads7.googleadservices.com \n\n 0.0.0.0 imageads8.googleadservices.com \n\n 0.0.0.0 imageads9.googleadservices.com \n\n 0.0.0.0 partner.googleadservices.com \n\n 0.0.0.0 www.googleadservices.com \n\n 0.0.0.0 googletagservices.com \n\n ";
                core.WRITE_TO_HOST(hosts_google);
                // Step (2) Bing/Microsoft
                string hosts_bingmicrosoft = "0.0.0.0 advertise.bingads.microsoft.com \n\n 0.0.0.0 analytics.bingads.microsoft.com \n\n 0.0.0.0 stats.bingads.microsoft.com \n\n 0.0.0.0 nexus.ensighten.com \n\n 0.0.0.0 dc.ads.linkedin.com \n\n 0.0.0.0 advertiseonbing.azureedge.net \n\n 0.0.0.0 analytics.microsoft.com \n\n 0.0.0.0 analytics.bing.com \n\n 0.0.0.0 choice.microsoft.com \n\n";
                core.WRITE_TO_HOST(hosts_bingmicrosoft);
                // Step (3) Yahoo
                string hosts_yahoo = "0.0.0.0 analytics-cs.yahoo.com \n\n 0.0.0.0 analytics.yahoo.com \n\n";
                core.WRITE_TO_HOST(hosts_yahoo);
                // Step (4) Twitter
                string hosts_twitter = "0.0.0.0 analytics.twitter.com \n\n 0.0.0.0 ads.yahoo.com \n\n";
                core.WRITE_TO_HOST(hosts_twitter);
                // Step (5) Facebook
                string hosts_facebook = "0.0.0.0 analytics.facebook.com \n\n 0.0.0.0 ads.facebook.com \n\n 0.0.0.0 stats.facebook.com \n\n";
                core.WRITE_TO_HOST(hosts_facebook);

                // save
                SAVE("winpurify_analytics", "1");
            }
            else
            {
                if (LOAD("winpurify_analytics") == "1")
                {
                    // save
                    SAVE("winpurify_analytics", "0");
                }
            }
        }
        public void DISABLE_WEBPISHING(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Block know pishing/advertising hosts
                string hosts_pishing = " \n\n#Block Advertising domains\n\n \n\n   0.0.0.0 d2nn3xyicdpsrf.cloudfront.net \n\n   0.0.0.0 *.isanalyze.com \n\n   0.0.0.0 jsc.mgid.com \n\n   0.0.0.0 isanalyze.com \n\n   0.0.0.0 roi.ediscom.it \n\n   0.0.0.0 landing.clickpoint.com \n\n   0.0.0.0 *.acloudimages.com \n\n   0.0.0.0 acloudimages.com \n\n   0.0.0.0 cdn13.acloudimages.com \n\n   0.0.0.0 cdn14.acloudimages.com \n\n   0.0.0.0 cdn15.acloudimages.com \n\n   0.0.0.0 nowvideo.ec/api/toker.php?f= \n\n   0.0.0.0 *.nowvideo.ec/api/toker.php?f= \n\n   0.0.0.0 *.vkoad.com \n\n   0.0.0.0 *.a2pub.com \n\n   0.0.0.0 a2pub.com \n\n   0.0.0.0 vkoad.com \n\n   0.0.0.0 ad.vkoad.com \n\n   0.0.0.0 ads.ad-center.com \n\n   0.0.0.0 *.ad-center.com \n\n   0.0.0.0 ad-center.com \n\n   0.0.0.0 *.clickmngr.com \n\n   0.0.0.0 clickmngr.com \n\n   0.0.0.0 webtrackerplus.com \n\n   0.0.0.0 http://s3-us-west-2.amazonaws.com/amcdn/admvpopunder.swf \n\n   0.0.0.0 s3-us-west-2.amazonaws.com/amcdn/admvpopunder.swf \n\n   0.0.0.0 s3-us-west-2.amazonaws.com \n\n   0.0.0.0 pickytime.com \n\n   0.0.0.0 b.scorecardresearch.com \n\n   0.0.0.0 scorecardresearch.com \n\n   0.0.0.0 steepto.com \n\n   0.0.0.0 *.steepto.com \n\n   0.0.0.0 bcp.crwdcntrl.net \n\n   0.0.0.0 thewhizmarketing.com \n\n   0.0.0.0 vkoad.com \n\n   0.0.0.0 ad.vkoad.com \n\n   0.0.0.0 statcounter.com \n\n   0.0.0.0 c.statcounter.com \n\n   0.0.0.0 s1.histats.com \n\n   0.0.0.0 s2.histats.com \n\n   0.0.0.0 s3.histats.com \n\n   0.0.0.0 s4.histats.com \n\n   0.0.0.0 s5.histats.com \n\n   0.0.0.0 s6.histats.com \n\n   0.0.0.0 s7.histats.com \n\n   0.0.0.0 s8.histats.com \n\n   0.0.0.0 s9.histats.com \n\n   0.0.0.0 s10.histats.com \n\n   0.0.0.0 ir2.beap.gemini.yahoo.com \n\n   0.0.0.0 sbeap.gemini.yahoo.com \n\n   0.0.0.0 s1.adform.net \n\n   0.0.0.0 s2.adform.net \n\n   0.0.0.0 s3.adform.net \n\n   0.0.0.0 s4.adform.net \n\n   0.0.0.0 s5.adform.net \n\n   0.0.0.0 s6.adform.net \n\n   0.0.0.0 s7.adform.net \n\n   0.0.0.0 s8.adform.net \n\n   0.0.0.0 s9.adform.net \n\n   0.0.0.0 s10.adform.net \n\n   0.0.0.0 s11.adform.net \n\n   0.0.0.0 s12.adform.net \n\n   0.0.0.0 cas.criteo.com \n\n   0.0.0.0 optimized-by.rubiconproject.com \n\n   0.0.0.0 ads.rubiconproject.com \n\n   0.0.0.0 tpc.googlesyndication.com \n\n   0.0.0.0 googletagservices.com \n\n   0.0.0.0 ad.ae.doubleclick.net \n\n   0.0.0.0 ad.ar.doubleclick.net \n\n   0.0.0.0 ad.at.doubleclick.net \n\n   0.0.0.0 ad.au.doubleclick.net \n\n   0.0.0.0 ad.be.doubleclick.net \n\n   0.0.0.0 0koryu0.easter.ne.jp \n\n   0.0.0.0 109-204-26-16.netconnexion.managedbroadband.co.uk \n\n   0.0.0.0 11.lamarianella.info \n\n   0.0.0.0 1866809.securefastserver.com \n\n   0.0.0.0 2amsports.com \n\n   0.0.0.0 3.bluepointmortgage.com \n\n   0.0.0.0 3.coolerpillow.com \n\n   0.0.0.0 4.androidislamic.com \n\n   0.0.0.0 4.collecorvino.org \n\n   0.0.0.0 4.dlevo.com \n\n   0.0.0.0 4.e-why.net \n\n   0.0.0.0 4.newenergydata.biz \n\n   0.0.0.0 4.newenergydata.info \n\n   0.0.0.0 4.periziavela.com \n\n   0.0.0.0 4.pianetapollo.com \n\n   0.0.0.0 4.whereinitaly.com \n\n   0.0.0.0 4.whereinlazio.com \n\n   0.0.0.0 4.whereinliguria.com \n\n   0.0.0.0 4.whereinlombardy.com \n\n   0.0.0.0 4.whereinmilan.com \n\n   0.0.0.0 4.whereinmolise.com \n\n   0.0.0.0 4.whereinpiemonte.com \n\n   0.0.0.0 4.whereinpuglia.com \n\n   0.0.0.0 4.whereinsardegna.com \n\n   0.0.0.0 4.whereinsicilia.com \n\n   0.0.0.0 4.whereinsicily.com \n\n   0.0.0.0 4.whereintoscana.com \n\n   0.0.0.0 4.whereintrentinoaltoadige.com \n\n   0.0.0.0 4dexports.com \n\n   0.0.0.0 5.estasiatica.com \n\n   0.0.0.0 5.eventiduepuntozero.com \n\n   0.0.0.0 50efa6486f1ef.skydivesolutions.be \n\n   0.0.0.0 6.bbnface.com \n\n   0.0.0.0 6.bbnfaces.net \n\n   0.0.0.0 6.bbnsmsgateway.com \n\n   0.0.0.0 6.mamaswishes.com \n\n   0.0.0.0 6b8a953b2bf7788063d5-6e453f33ecbb90f11a62a5c376375af3.r71.cf5.rackcdn.com \n\n   0.0.0.0 97b1c56132dfcdd90f93-0c5c8388c0a5897e648f883e2c86dc72.r54.cf5.rackcdn.com \n\n   0.0.0.0 999fitness.com \n\n   0.0.0.0 a.update.51edm.net \n\n   0.0.0.0 ab.usageload32.com \n\n   0.0.0.0 abcdespanol.com \n\n   0.0.0.0 above.e-rezerwacje24.pl \n\n   0.0.0.0 absurdity.flarelight.com \n\n   0.0.0.0 achren.org \n\n   0.0.0.0 acool.csheaven.com \n\n   0.0.0.0 ad-beast.com \n\n   0.0.0.0 adgallery.whitehousedrugpolicy.gov \n\n   0.0.0.0 adlock.in \n\n   0.0.0.0 adobeflashupdate14.com \n\n   0.0.0.0 ads.wikipartes.com \n\n   0.0.0.0 adserving.favorit-network.com \n\n   0.0.0.0 adv.riza.it \n\n   0.0.0.0 advancetec.co.uk \n\n   0.0.0.0 afa15.com.ne.kr \n\n   0.0.0.0 agsteier.com \n\n   0.0.0.0 aintdoinshit.com \n\n   0.0.0.0 aippnetworks.com \n\n   0.0.0.0 aircraft.evote.cl \n\n   0.0.0.0 ajewishgift.com \n\n   0.0.0.0 akirkpatrick.com \n\n   0.0.0.0 alexanderinteriorsanddesign.com \n\n   0.0.0.0 alexandria90.etcserver.com \n\n   0.0.0.0 alisat.biz \n\n   0.0.0.0 alissonluis-musico.sites.uol.com.br \n\n   0.0.0.0 allforlove.de \n\n   0.0.0.0 allxscan.tk \n\n   0.0.0.0 alsoknowsit.com \n\n   0.0.0.0 ama-alliance.com \n\n   0.0.0.0 amazingvacationhotels.com \n\n   0.0.0.0 ambulanciaslazaro.com \n\n   0.0.0.0 amdfrance.com \n\n   0.0.0.0 americancareconcept.com \n\n   0.0.0.0 aminev.com \n\n   0.0.0.0 amu.adduraddonhere.info \n\n   0.0.0.0 amu.boxinstallercompany.info \n\n   0.0.0.0 amu.brandnewinstall.info \n\n   0.0.0.0 amu.helpyourselfinstall.info \n\n   0.0.0.0 amu.twobox4addon.info \n\n   0.0.0.0 analxxxclipsyjh.dnset.com \n\n   0.0.0.0 andysgame.com \n\n   0.0.0.0 anshrit.com \n\n   0.0.0.0 antalya.ru \n\n   0.0.0.0 app.pho8.com \n\n   0.0.0.0 arkinsoftware.in \n\n   0.0.0.0 artsconsortium.org \n\n   0.0.0.0 asham.tourstogo.us \n\n   0.0.0.0 associatesexports.com \n\n   0.0.0.0 atelierprincesse.web.fc2.com \n\n   0.0.0.0 atlcourier.com \n\n   0.0.0.0 atyss.barginginfrance.net \n\n   0.0.0.0 avirasecureserver.com \n\n   0.0.0.0 avokka.com \n\n   0.0.0.0 avppet.com \n\n   0.0.0.0 axisbuild.com \n\n   0.0.0.0 azoos.csheaven.com \n\n   0.0.0.0 b.nevadaprivateoffice.com \n\n   0.0.0.0 babos.scrapping.cc \n\n   0.0.0.0 bargainracks.co.uk \n\n   0.0.0.0 batcoroadlinescorporation.com \n\n   0.0.0.0 bbs.bjchun.com \n\n   0.0.0.0 bde.be \n\n   0.0.0.0 be-funk.com \n\n   0.0.0.0 beautysafari.com \n\n   0.0.0.0 becomedebtfree.com.au \n\n   0.0.0.0 beespace.com.ua \n\n   0.0.0.0 beldiplomcom.75.com1.ru \n\n   0.0.0.0 best100catfights.com \n\n   0.0.0.0 betterhomeandgardenideas.com \n\n   0.0.0.0 bezproudoff.cz \n\n   0.0.0.0 bien-vivre-en-sarladais.com \n\n   0.0.0.0 bilbaopisos.es \n\n   0.0.0.0 bio-air-technologies.com \n\n   0.0.0.0 bizzibeans.net \n\n   0.0.0.0 bj04.com \n\n   0.0.0.0 blackfalcon5.net \n\n   0.0.0.0 blacknite.eu \n\n   0.0.0.0 blog.replacemycontacts.com \n\n   0.0.0.0 bluecutsystem.com \n\n   0.0.0.0 bnsoutlaws.co.uk \n\n   0.0.0.0 boogu.barginginfrance.net \n\n   0.0.0.0 bookofkisl.com \n\n   0.0.0.0 boots.fotopyra.pl \n\n   0.0.0.0 borat.elticket.com.ar \n\n   0.0.0.0 boschetto-hotel.gr \n\n   0.0.0.0 bracbetul.com \n\n   0.0.0.0 bracewellfamily.com \n\n   0.0.0.0 bravetools.net \n\n   0.0.0.0 bride1.com \n\n   0.0.0.0 broadtech.co \n\n   0.0.0.0 buffalogoesout.com \n\n   0.0.0.0 buildviet.info \n\n   0.0.0.0 by98.com \n\n   0.0.0.0 cacl.fr \n\n   0.0.0.0 caclclo.web.fc2.com \n\n   0.0.0.0 callingcardsinstantly.com \n\n   0.0.0.0 campamento.queenscamp.com \n\n   0.0.0.0 cannabislyric.com \n\n   0.0.0.0 cannabispicture.com \n\n   0.0.0.0 cap2zen.com \n\n   0.0.0.0 centralwestwater.com.au \n\n   0.0.0.0 ceskarepublika.net \n\n   0.0.0.0 chaveiro.bio.br \n\n   0.0.0.0 chemgas.com \n\n   0.0.0.0 chsplantsales.co.uk \n\n   0.0.0.0 ciclismovalenciano.com \n\n   0.0.0.0 citymediamagazin.hu \n\n   0.0.0.0 classicallyabsurdphotography.com \n\n   0.0.0.0 classicspeedway.com \n\n   0.0.0.0 cluster013.ovh.net \n\n   0.0.0.0 cmicapui.ce.gov.br \n\n   0.0.0.0 coaha.frenchgerlemanelectric.com \n\n   0.0.0.0 coalimpex.com \n\n   0.0.0.0 cofeb13east.com \n\n   0.0.0.0 coffeol.com \n\n   0.0.0.0 concede.fmtlib.net \n\n   0.0.0.0 conds.ru \n\n   0.0.0.0 cope.it \n\n   0.0.0.0 corroshield.estb.com.sg \n\n   0.0.0.0 cosmetice-farduri.ro \n\n   0.0.0.0 cosmos.felago.es \n\n   0.0.0.0 cosmos.furnipict.com \n\n   0.0.0.0 cracks.vg \n\n   0.0.0.0 crackspider.us \n\n   0.0.0.0 crackzone.net \n\n   0.0.0.0 creditbootcamp.com \n\n   0.0.0.0 crops.dunight.eu \n\n   0.0.0.0 csmail.iggcn.com \n\n   0.0.0.0 cswilliamsburg.com \n\n   0.0.0.0 cudacorp.com \n\n   0.0.0.0 customsboysint.com \n\n   0.0.0.0 cwmgaming.com \n\n   0.0.0.0 cznshuya.ivnet.ru \n\n   0.0.0.0 d1.kuai8.com \n\n   0.0.0.0 d1054130-28095.cp.blacknight.com \n\n   0.0.0.0 d1171912.cp.blacknight.com \n\n   0.0.0.0 d32k27yvyi4kmv.cloudfront.net \n\n   0.0.0.0 d4.cumshots.ws \n\n   0.0.0.0 dancecourt.com \n\n   0.0.0.0 dashlinen.testing-domain-live.co.uk \n\n   0.0.0.0 dawnframing.com \n\n   0.0.0.0 dcanscapital.co.uk \n\n   0.0.0.0 ddd.gouwuke.cn \n\n   0.0.0.0 decografix.com \n\n   0.0.0.0 decorator.crabgrab.cl \n\n   0.0.0.0 decota.es \n\n   0.0.0.0 decrolyschool.be \n\n   0.0.0.0 deleondeos.com \n\n   0.0.0.0 deletespyware-adware.com \n\n   0.0.0.0 demo.vertexinfo.in \n\n   0.0.0.0 dent-lux.com.pl \n\n   0.0.0.0 dentairemalin.com \n\n   0.0.0.0 destre45.com \n\n   0.0.0.0 dev.wrathofshadows.net \n\n   0.0.0.0 dianepiette.co.uk \n\n   0.0.0.0 diaryofagameaddict.com \n\n   0.0.0.0 dimarsbg.com \n\n   0.0.0.0 dimenal.com.br \n\n   0.0.0.0 dimensionnail.ro \n\n   0.0.0.0 dimsnetwork.com \n\n   0.0.0.0 directxex.com \n\n   0.0.0.0 divine.lunarbreeze.com \n\n   0.0.0.0 dl.downf468.com \n\n   0.0.0.0 dl.heima8.com \n\n   0.0.0.0 dl.microsword.net \n\n   0.0.0.0 dl01.faddmr.com \n\n   0.0.0.0 dofeb.frenchgerlemanelectric.com \n\n   0.0.0.0 doktester.orgfree.com \n\n   0.0.0.0 dougmlee.com \n\n   0.0.0.0 down.feiyang163.com \n\n   0.0.0.0 down.guangsu.cn \n\n   0.0.0.0 down.unadnet.com.cn \n\n   0.0.0.0 down2.feiyang163.com \n\n   0.0.0.0 down3.feiyang163.com \n\n   0.0.0.0 download-archiver.ru \n\n   0.0.0.0 download.56.com \n\n   0.0.0.0 download.grandcloud.cn \n\n   0.0.0.0 download.ttrili.com \n\n   0.0.0.0 download207.mediafire.com \n\n   0.0.0.0 downloads-finereader.ru \n\n   0.0.0.0 downloads-whatsapp.com \n\n   0.0.0.0 dp-medien.eu \n\n   0.0.0.0 drank.fa779.com \n\n   0.0.0.0 dujur.barginginfrance.net \n\n   0.0.0.0 e-matelco.com \n\n   0.0.0.0 e1r.net \n\n   0.0.0.0 earthcontrolsys.com \n\n   0.0.0.0 echoa.randbinternationaltravel.com \n\n   0.0.0.0 eddenya.com \n\n   0.0.0.0 edf.fr.kfskz.com \n\n   0.0.0.0 eecky.butlerelectricsupply.com \n\n   0.0.0.0 eekro.cruisingsmallship.com \n\n   0.0.0.0 eeps.me \n\n   0.0.0.0 eeroo.frost-electric-supply.com \n\n   0.0.0.0 eetho.cruisingsmallship.com \n\n   0.0.0.0 efugl.iptvdeals.com \n\n   0.0.0.0 eldiariodeguadalajara.com \n\n   0.0.0.0 elew72isst.rr.nu \n\n   0.0.0.0 eliehabib.com \n\n   0.0.0.0 elocumjobs.com \n\n   0.0.0.0 emailing.wildcard.fr \n\n   0.0.0.0 emits.iptvdeals.com \n\n   0.0.0.0 eroov.iptvdeals.com \n\n   0.0.0.0 erupt.fernetmoretti.com.ar \n\n   0.0.0.0 esoad.frost-electric-supply.com \n\n   0.0.0.0 espdesign.com.au \n\n   0.0.0.0 estoa.frost-electric-supply.com \n\n   0.0.0.0 eternitymobiles.com \n\n   0.0.0.0 euro-vertrieb.com \n\n   0.0.0.0 europe-academy.net \n\n   0.0.0.0 europol.europe.eu.france.id647744160-2176514326.h5841.com \n\n   0.0.0.0 europol.europe.eu.id214218540-7444056787.h5841.com \n\n   0.0.0.0 ex.technor.com \n\n   0.0.0.0 exadu.mymag250.co.uk \n\n   0.0.0.0 exclaim.goldenteamacademy.cl \n\n   0.0.0.0 executivecoaching.co.il \n\n   0.0.0.0 exsexytop.tk \n\n   0.0.0.0 extreembilisim.com \n\n   0.0.0.0 f.gj555.net \n\n   0.0.0.0 faiyazahmed.com \n\n   0.0.0.0 fallencrafts.info \n\n   0.0.0.0 faq-candrive.tk \n\n   0.0.0.0 fbku.com \n\n   0.0.0.0 femalewrestlingnow.com \n\n   0.0.0.0 fetishfitnessbabes.com \n\n   0.0.0.0 fetishlocator.com \n\n   0.0.0.0 fgawegwr.chez.com \n\n   0.0.0.0 fgtkmcby02.eu \n\n   0.0.0.0 files.dsnetwb.com \n\n   0.0.0.0 finnhair.co.uk \n\n   0.0.0.0 firehouse651.com \n\n   0.0.0.0 fkhfgfg.tk \n\n   0.0.0.0 flashsavant.com \n\n   0.0.0.0 fondazioneciampi.org \n\n   0.0.0.0 formessengers.com \n\n   0.0.0.0 free-crochet-pattern.com \n\n   0.0.0.0 freefblikes.phpnet.us \n\n   0.0.0.0 freeserials.spb.ru \n\n   0.0.0.0 freeserials.ws \n\n   0.0.0.0 ftp.flyfishusa.com \n\n   0.0.0.0 funchill.com \n\n   0.0.0.0 funkucck.bluerobot.cl \n\n   0.0.0.0 generalchemicalsupply.com \n\n   0.0.0.0 getdatanetukscan.info \n\n   0.0.0.0 go-quicky.com \n\n   0.0.0.0 gogetgorgeous.com \n\n   0.0.0.0 gosciniec-paproc.pl \n\n   0.0.0.0 gravityexp.com \n\n   0.0.0.0 gredinatib.org \n\n   0.0.0.0 greev.randbinternationaltravel.com \n\n   0.0.0.0 grendizer.biz \n\n   0.0.0.0 groax.mymag250.co.uk \n\n   0.0.0.0 grosirkecantikan.com \n\n   0.0.0.0 gulf-industrial.com \n\n   0.0.0.0 gulsproductions.com \n\n   0.0.0.0 gurde.tourstogo.us \n\n   0.0.0.0 guyscards.com \n\n   0.0.0.0 gyboo.cruisingsmallship.com \n\n   0.0.0.0 gylra.cruisingsmallship.com \n\n   0.0.0.0 h1666015.stratoserver.net \n\n   0.0.0.0 hana-naveh.com \n\n   0.0.0.0 hanulsms.com \n\n   0.0.0.0 hardcorepornparty.com \n\n   0.0.0.0 harshwhispers.com \n\n   0.0.0.0 headless.ebkfwd.com \n\n   0.0.0.0 healthybloodpressure.info \n\n   0.0.0.0 helesouurusa.cjb.com \n\n   0.0.0.0 hexadl.line55.net \n\n   0.0.0.0 higher.dwebsi.tk \n\n   0.0.0.0 highflyingfood.com \n\n   0.0.0.0 hinsib.com \n\n   0.0.0.0 hmora.fred-build.tk \n\n   0.0.0.0 hnskorea.co.kr \n\n   0.0.0.0 hoawy.frost-electric-supply.com \n\n   0.0.0.0 hobbat.fvds.ru \n\n   0.0.0.0 hobby-hangar.net \n\n   0.0.0.0 hobbytotaalservice.nl \n\n   0.0.0.0 hoerbird.net \n\n   0.0.0.0 holishit.in \n\n   0.0.0.0 hosting-controlid1.tk \n\n   0.0.0.0 hosting-controlnext.tk \n\n   0.0.0.0 hosting-controlpin.tk \n\n   0.0.0.0 hosting-controlpr.tk \n\n   0.0.0.0 hotfacesitting.com \n\n   0.0.0.0 hotspot.cz \n\n   0.0.0.0 hrdcvn.com.vn \n\n   0.0.0.0 hst-19-33.splius.lt \n\n   0.0.0.0 hujii.qplanner.cf \n\n   0.0.0.0 hy-brasil.mhwang.com \n\n   0.0.0.0 hydraulicpowerpack.com \n\n   0.0.0.0 iamagameaddict.com \n\n   0.0.0.0 id405441215-8305493831.h121h9.com \n\n   0.0.0.0 igagh.tourstogo.us \n\n   0.0.0.0 igoby.frost-electric-supply.com \n\n   0.0.0.0 igroo.barginginfrance.net \n\n   0.0.0.0 image-circul.tk \n\n   0.0.0.0 images.topguncustomz.com \n\n   0.0.0.0 img.coldstoragemn.com \n\n   0.0.0.0 img.sspbaseball.org \n\n   0.0.0.0 img001.com \n\n   0.0.0.0 immediateresponseforcomputer.com \n\n   0.0.0.0 impressoras-cartoes.com.pt \n\n   0.0.0.0 inclusivediversity.co.uk \n\n   0.0.0.0 incoctel.cl \n\n   0.0.0.0 infoweb-coolinfo.tk \n\n   0.0.0.0 inlinea.co.uk \n\n   0.0.0.0 innatek.com \n\n   0.0.0.0 instruminahui.edu.ec \n\n   0.0.0.0 interactivearea.ru \n\n   0.0.0.0 internet-bb.tk \n\n   0.0.0.0 invention.festinolente.cl \n\n   0.0.0.0 ip-182-50-129-164.ip.secureserver.net \n\n   0.0.0.0 ip-182-50-129-181.ip.secureserver.net \n\n   0.0.0.0 ipl.hk \n\n   0.0.0.0 iptoo.cruisingsmallship.com \n\n   0.0.0.0 isonomia.com.ar \n\n   0.0.0.0 ithyk.frenchgerlemanelectric.com \n\n   0.0.0.0 iwgtest.co.uk \n\n   0.0.0.0 iwhab.randbinternationaltravel.com \n\n   0.0.0.0 ixoox.csheaven.com \n\n   0.0.0.0 iybasketball.info \n\n   0.0.0.0 izzy-cars.nl \n\n   0.0.0.0 japanesevehicles.us \n\n   0.0.0.0 jdfabrication.com \n\n   0.0.0.0 jeanlesigne.com \n\n   0.0.0.0 jeansvixens.com \n\n   0.0.0.0 jktdc.in \n\n   0.0.0.0 jo-2012.fr \n\n   0.0.0.0 job-companybuild.tk \n\n   0.0.0.0 job-compuse.tk \n\n   0.0.0.0 josip-stadler.org \n\n   0.0.0.0 js.tongji.linezing.com \n\n   0.0.0.0 jstaikos.com \n\n   0.0.0.0 jue0jc.lukodorsai.info \n\n   0.0.0.0 juedische-kammerphilharmonie.de \n\n   0.0.0.0 juicypussyclips.com \n\n   0.0.0.0 k.h.a.d.free.fr \n\n   0.0.0.0 kadirzerey.com \n\n   0.0.0.0 kadman.net \n\n   0.0.0.0 kalantzis.net \n\n   0.0.0.0 kapcotool.com \n\n   0.0.0.0 kassabravo.com \n\n   0.0.0.0 keemy.butlerelectricsupply.com \n\n   0.0.0.0 keyways.pt \n\n   0.0.0.0 kfc.i.illuminationes.com \n\n   0.0.0.0 kids-fashion.dk \n\n   0.0.0.0 kipasdenim.com \n\n   0.0.0.0 kollagen4you.se \n\n   0.0.0.0 krsa2gno.congrats-sweepstakes-winner.com \n\n   0.0.0.0 krsa2gno.important-security-brower-alert.com \n\n   0.0.0.0 krsa2gno.internet-security-alert.com \n\n   0.0.0.0 krsa2gno.todays-sweepstakes-winner.com \n\n   0.0.0.0 krsa2gno.youre-todays-lucky-sweeps-winner.com \n\n   0.0.0.0 kuglu.mymag250.co.uk \n\n   0.0.0.0 kulro.csheaven.com \n\n   0.0.0.0 kylie-walters.com \n\n   0.0.0.0 kyrsu.frost-electric-supply.com \n\n   0.0.0.0 lab-cntest.tk \n\n   0.0.0.0 landisbaptist.com \n\n   0.0.0.0 lay.elticket.com.ar \n\n   0.0.0.0 lcbcad.co.uk \n\n   0.0.0.0 leagleconsulting.com \n\n   0.0.0.0 lefos.net \n\n   0.0.0.0 legendsdtv.com \n\n   0.0.0.0 lexu.goggendorf.at \n\n   0.0.0.0 lhs-mhs.org \n\n   0.0.0.0 lifescience.sysu.edu.cn \n\n   0.0.0.0 likes.gisnetwork.net \n\n   0.0.0.0 linkforme.tk \n\n   0.0.0.0 liquid.dbahelp.com.ar \n\n   0.0.0.0 live-dir.tk \n\n   0.0.0.0 loft2126.dedicatedpanel.com \n\n   0.0.0.0 losas.cabanaslanina.com.ar \n\n   0.0.0.0 losos.caliane.com.br \n\n   0.0.0.0 luchtenbergdecor.com.br \n\n   0.0.0.0 luckyblank.info \n\n   0.0.0.0 luckyclean.info \n\n   0.0.0.0 luckyclear.info \n\n   0.0.0.0 luckyeffect.info \n\n   0.0.0.0 luckyhalo.info \n\n   0.0.0.0 luckypure.info \n\n   0.0.0.0 luckyshine.info \n\n   0.0.0.0 luckysuccess.info \n\n   0.0.0.0 luckysure.info \n\n   0.0.0.0 luckytidy.info \n\n   0.0.0.0 luggage-tv.com \n\n   0.0.0.0 luggagecast.com \n\n   0.0.0.0 luggagepreview.com \n\n   0.0.0.0 lunaticjazz.com \n\n   0.0.0.0 luwyou.com \n\n   0.0.0.0 lydwood.co.uk \n\n   0.0.0.0 m2132.ehgaugysd.net \n\n   0.0.0.0 mahindrainsurance.com \n\n   0.0.0.0 mailboto.com \n\n   0.0.0.0 malest.com \n\n   0.0.0.0 manoske.com \n\n   0.0.0.0 marchen-toy.co.jp \n\n   0.0.0.0 marialorena.com.br \n\n   0.0.0.0 markbruinink.nl \n\n   0.0.0.0 marx-brothers.mhwang.com \n\n   0.0.0.0 mathenea.com \n\n   0.0.0.0 maxisoft.co.uk \n\n   0.0.0.0 mbrdot.tk \n\n   0.0.0.0 mediatrade.h19.ru \n\n   0.0.0.0 mepra.blautechnology.cl \n\n   0.0.0.0 merrymilkfoods.com \n\n   0.0.0.0 metrocuadro.com.ve \n\n   0.0.0.0 mgfd1b.petrix.net \n\n   0.0.0.0 miespaciopilates.com \n\n   0.0.0.0 milf.gabriola.cl \n\n   0.0.0.0 milleniumpapelaria.com.br \n\n   0.0.0.0 mindstormstudio.ro \n\n   0.0.0.0 ministerio-publi.info \n\n   0.0.0.0 miracema.rj.gov.br \n\n   0.0.0.0 mirandolasrl.it \n\n   0.0.0.0 mlpoint.pt \n\n   0.0.0.0 mmile.com \n\n   0.0.0.0 mobatory.com \n\n   0.0.0.0 mobile.bitterstrawberry.org \n\n   0.0.0.0 mocka.frost-electric-supply.com \n\n   0.0.0.0 molla.gato1000.cl \n\n   0.0.0.0 monarchslo.com \n\n   0.0.0.0 montezuma.spb.ru \n\n   0.0.0.0 morenews3.net \n\n   0.0.0.0 mrpeter.it \n\n   0.0.0.0 ms11.net \n\n   0.0.0.0 mtldesigns.ca \n\n   0.0.0.0 mueller-holz-bau.com \n\n   0.0.0.0 murbil.hostei.com \n\n   0.0.0.0 mycleanpc.tk \n\n   0.0.0.0 mylabsrl.com \n\n   0.0.0.0 mylondon.hc0.me \n\n   0.0.0.0 myshopmarketim.com \n\n   0.0.0.0 mysmallcock.com \n\n   0.0.0.0 myvksaver.ru \n\n   0.0.0.0 nadegda-95.ru \n\n   0.0.0.0 nailbytes1.com \n\n   0.0.0.0 namso.butlerelectricsupply.com \n\n   0.0.0.0 narrow.azenergyforum.com \n\n   0.0.0.0 natural.buckeyeenergyforum.com \n\n   0.0.0.0 nbook.far.ru \n\n   0.0.0.0 nc2199.eden5.netclusive.de \n\n   0.0.0.0 nctbonline.co.uk \n\n   0.0.0.0 nefib.tourstogo.us \n\n   0.0.0.0 negociosdasha.com \n\n   0.0.0.0 nerez-schodiste-zabradli.com \n\n   0.0.0.0 nestorconsulting.net \n\n   0.0.0.0 networkmedical.com.hk \n\n   0.0.0.0 neumashop.cl \n\n   0.0.0.0 nevergreen.net \n\n   0.0.0.0 new-address.tk \n\n   0.0.0.0 new-softdriver.tk \n\n   0.0.0.0 news4cars.com \n\n   0.0.0.0 nikolamireasa.com \n\n   0.0.0.0 njtgsd.attackthethrone.com \n\n   0.0.0.0 nkgamers.com \n\n   0.0.0.0 nlconsulateorlandoorg.siteprotect.net \n\n   0.0.0.0 nmsbaseball.com \n\n   0.0.0.0 nobodyspeakstruth.narod.ru \n\n   0.0.0.0 nonsi.csheaven.com \n\n   0.0.0.0 noobgirls.com \n\n   0.0.0.0 nordiccountry.cz \n\n   0.0.0.0 nortonfire.co.uk \n\n   0.0.0.0 notebookservisru.161.com1.ru \n\n   0.0.0.0 noveslovo.com \n\n   0.0.0.0 nowina.info \n\n   0.0.0.0 ns1.the-sinner.net \n\n   0.0.0.0 ns1.updatesdns.org \n\n   0.0.0.0 ns2ns1.tk \n\n   0.0.0.0 nt-associates.com \n\n   0.0.0.0 nudebeachgalleries.net \n\n   0.0.0.0 nugly.barginginfrance.net \n\n   0.0.0.0 nuptialimages.com \n\n   0.0.0.0 nutnet.ir \n\n   0.0.0.0 oakso.tourstogo.us \n\n   0.0.0.0 oampa.csheaven.com \n\n   0.0.0.0 oapsa.tourstogo.us \n\n   0.0.0.0 oawoo.frenchgerlemanelectric.com \n\n   0.0.0.0 obada-konstruktiwa.org \n\n   0.0.0.0 obkom.net.ua \n\n   0.0.0.0 ocick.frost-electric-supply.com \n\n   0.0.0.0 ocpersian.com \n\n   0.0.0.0 officeon.ch.ma \n\n   0.0.0.0 oilwrestlingeurope.com \n\n   0.0.0.0 okeanbg.com \n\n   0.0.0.0 oknarai.ru \n\n   0.0.0.0 omrdatacapture.com \n\n   0.0.0.0 onrio.com.br \n\n   0.0.0.0 oofuv.cruisingsmallship.com \n\n   0.0.0.0 oojee.barginginfrance.net \n\n   0.0.0.0 ooksu.frost-electric-supply.com \n\n   0.0.0.0 oolsi.frost-electric-supply.com \n\n   0.0.0.0 oosee.barginginfrance.net \n\n   0.0.0.0 oowhe.frost-electric-supply.com \n\n   0.0.0.0 oprahsearch.com \n\n   0.0.0.0 optiker-michelmann.de \n\n   0.0.0.0 optilogus.com \n\n   0.0.0.0 optimization-methods.com \n\n   0.0.0.0 orbowlada.strefa.pl \n\n   0.0.0.0 orkut.krovatka.su \n\n   0.0.0.0 oshoa.iptvdeals.com \n\n   0.0.0.0 oshoo.iptvdeals.com \n\n   0.0.0.0 otylkaaotesanek.cz \n\n   0.0.0.0 outporn.com \n\n   0.0.0.0 ozzysixsixsix.web.fc2.com \n\n   0.0.0.0 pacan.gofreedom.info \n\n   0.0.0.0 pacman.gkgar.com \n\n   0.0.0.0 pamoran.net \n\n   0.0.0.0 papamamandoudouetmoi.com \n\n   0.0.0.0 paracadutismolucca.it \n\n   0.0.0.0 paraskov.com \n\n   0.0.0.0 patrickhickey.eu \n\n   0.0.0.0 pave.elisecries.com \n\n   0.0.0.0 pb-webdesign.net \n\n   0.0.0.0 peeg.fronterarq.cl \n\n   0.0.0.0 pension-helene.cz \n\n   0.0.0.0 penwithian.co.uk \n\n   0.0.0.0 pepelacer.computingservices123.com \n\n   0.0.0.0 perfectionautorepairs.com \n\n   0.0.0.0 personal.editura-amsibiu.ro \n\n   0.0.0.0 pgalvaoteles.pt \n\n   0.0.0.0 pharmadeal.gr \n\n   0.0.0.0 phitenmy.com \n\n   0.0.0.0 phoaz.cruisingsmallship.com \n\n   0.0.0.0 pic.starsarabian.com \n\n   0.0.0.0 pigra.csheaven.com \n\n   0.0.0.0 pix360.co.nf \n\n   0.0.0.0 plank.duplicolor.cl \n\n   0.0.0.0 plantaardigebrandstof.nl \n\n   0.0.0.0 plengeh.wen.ru \n\n   0.0.0.0 podzemi.myotis.info \n\n   0.0.0.0 pokachi.net \n\n   0.0.0.0 police11.provenprotection.net \n\n   0.0.0.0 pornstarss.tk \n\n   0.0.0.0 port.bg \n\n   0.0.0.0 portablevaporizer.com \n\n   0.0.0.0 portalfiremasters.com.br \n\n   0.0.0.0 portraitphotographygroup.com \n\n   0.0.0.0 pos-kupang.com \n\n   0.0.0.0 potvaporizer.com \n\n   0.0.0.0 powershopnet.net \n\n   0.0.0.0 pradakomechanicals.com \n\n   0.0.0.0 praxisww.com \n\n   0.0.0.0 pride-u-bike.com \n\n   0.0.0.0 private.hotelcesenaticobooking.info \n\n   0.0.0.0 produla.czatgg.pl \n\n   0.0.0.0 progettocrea.org \n\n   0.0.0.0 prorodeosportmed.com \n\n   0.0.0.0 psooz.tourstogo.us \n\n   0.0.0.0 ptewh.iptvdeals.com \n\n   0.0.0.0 ptool.barginginfrance.net \n\n   0.0.0.0 ptuph.barginginfrance.net \n\n   0.0.0.0 ptush.iptvdeals.com \n\n   0.0.0.0 publiccasinoil.com \n\n   0.0.0.0 puenteaereo.info \n\n   0.0.0.0 pulso.butlerelectricsupply.com \n\n   0.0.0.0 pumpkin.brisik.net \n\n   0.0.0.0 purethc.com \n\n   0.0.0.0 pwvita.pl \n\n   0.0.0.0 q28840.nb.host127-0-0-1.com \n\n   0.0.0.0 qbike.com.br \n\n   0.0.0.0 qualityindustrialcoatings.com \n\n   0.0.0.0 quinnwealth.com \n\n   0.0.0.0 quotidiennokoue.com \n\n   0.0.0.0 rainbowcolours.me.uk \n\n   0.0.0.0 rallye-de-fourmies.com \n\n   0.0.0.0 rallyeair.com \n\n   0.0.0.0 rat-on-subway.mhwang.com \n\n   0.0.0.0 rawoo.barginginfrance.net \n\n   0.0.0.0 reclamus.com \n\n   0.0.0.0 reishus.de \n\n   0.0.0.0 remorcicomerciale.ro \n\n   0.0.0.0 rentfromart.com \n\n   0.0.0.0 resolvethem.com \n\n   0.0.0.0 revistaelite.com \n\n   0.0.0.0 rl8vd.kikul.com \n\n   0.0.0.0 rocksresort.com.au \n\n   0.0.0.0 roks.ua \n\n   0.0.0.0 rolemodelstreetteam.invasioncrew.com \n\n   0.0.0.0 romsigmed.ro \n\n   0.0.0.0 romvarimarton.hu \n\n   0.0.0.0 roorbong.com \n\n   0.0.0.0 rsiuk.co.uk \n\n   0.0.0.0 ru.theswiftones.com \n\n   0.0.0.0 rubiks.ca \n\n   0.0.0.0 ruiyangcn.com \n\n   0.0.0.0 rumog.frost-electric-supply.com \n\n   0.0.0.0 rupor.info \n\n   0.0.0.0 sadiqtv.com \n\n   0.0.0.0 saemark.is \n\n   0.0.0.0 safety.amw.com \n\n   0.0.0.0 salon77.co.uk \n\n   0.0.0.0 santacruzsuspension.com \n\n   0.0.0.0 sasson-cpa.co.il \n\n   0.0.0.0 saturnleague.com \n\n   0.0.0.0 sayherbal.com \n\n   0.0.0.0 sbnc.hak.su \n\n   0.0.0.0 scaner-do.tk \n\n   0.0.0.0 scaner-figy.tk \n\n   0.0.0.0 scaner-file.tk \n\n   0.0.0.0 scaner-or.tk \n\n   0.0.0.0 scaner-sbite.tk \n\n   0.0.0.0 scaner-sboom.tk \n\n   0.0.0.0 scaner-sdee.tk \n\n   0.0.0.0 scaner-tfeed.tk \n\n   0.0.0.0 scaner-tgame.tk \n\n   0.0.0.0 scanty.colormark.cl \n\n   0.0.0.0 scdsfdfgdr12.tk \n\n   0.0.0.0 scream.garudamp3.com \n\n   0.0.0.0 sdg-translations.com \n\n   0.0.0.0 securitywebservices.com \n\n   0.0.0.0 seet10.jino.ru \n\n   0.0.0.0 sei.com.pe \n\n   0.0.0.0 semengineers.com \n\n   0.0.0.0 semiyun.com \n\n   0.0.0.0 sentrol.cl \n\n   0.0.0.0 seoholding.com \n\n   0.0.0.0 seonetwizard.com \n\n   0.0.0.0 serraikizimi.gr \n\n   0.0.0.0 server1.extra-web.cz \n\n   0.0.0.0 sexyoilwrestling.com \n\n   0.0.0.0 sexyster.tk \n\n   0.0.0.0 sexzoznamka.eu \n\n   0.0.0.0 sgs.us.com \n\n   0.0.0.0 shoac.mymag250.co.uk \n\n   0.0.0.0 shoal.grahanusareadymix.com \n\n   0.0.0.0 shovi.frost-electric-supply.com \n\n   0.0.0.0 signready.com \n\n   0.0.0.0 silurian.cn \n\n   0.0.0.0 simpi.tourstogo.us \n\n   0.0.0.0 site-checksite.tk \n\n   0.0.0.0 ska.energia.cz \n\n   0.0.0.0 skgroup.kiev.ua \n\n   0.0.0.0 skidki-yuga.ru \n\n   0.0.0.0 skiholidays4beginners.com \n\n   0.0.0.0 slightlyoffcenter.net \n\n   0.0.0.0 slimxxxtubeacn.dnset.com \n\n   0.0.0.0 slimxxxtubealn.ddns.name \n\n   0.0.0.0 slimxxxtubeanr.ddns.name \n\n   0.0.0.0 slimxxxtubeaxy.ddns.name \n\n   0.0.0.0 slimxxxtubeayv.ddns.name \n\n   0.0.0.0 slimxxxtubebej.dnset.com \n\n   0.0.0.0 slimxxxtubebgp.ddns.name \n\n   0.0.0.0 slimxxxtubebmq.dnset.com \n\n   0.0.0.0 slimxxxtubebnd.ddns.name \n\n   0.0.0.0 slimxxxtubecgl.ddns.name \n\n   0.0.0.0 slimxxxtubectk.dnset.com \n\n   0.0.0.0 slimxxxtubecty.ddns.name \n\n   0.0.0.0 slimxxxtubeczp.ddns.name \n\n   0.0.0.0 slimxxxtubedgv.dnset.com \n\n   0.0.0.0 slimxxxtubedjm.ddns.name \n\n   0.0.0.0 slimxxxtubedlb.ddns.name \n\n   0.0.0.0 slimxxxtubedvj.dnset.com \n\n   0.0.0.0 slimxxxtubedxc.ddns.name \n\n   0.0.0.0 slimxxxtubedya.ddns.name \n\n   0.0.0.0 slimxxxtubeejs.ddns.name \n\n   0.0.0.0 slimxxxtubeemz.dnset.com \n\n   0.0.0.0 slimxxxtubefdr.ddns.name \n\n   0.0.0.0 slimxxxtubefel.ddns.name \n\n   0.0.0.0 slimxxxtubeftb.dnset.com \n\n   0.0.0.0 slimxxxtubefzc.ddns.name \n\n   0.0.0.0 slimxxxtubehan.ddns.name \n\n   0.0.0.0 slimxxxtubehdn.dnset.com \n\n   0.0.0.0 slimxxxtubehli.dnset.com \n\n   0.0.0.0 slimxxxtubeidv.ddns.name \n\n   0.0.0.0 slimxxxtubeijc.dnset.com \n\n   0.0.0.0 slimxxxtubeiqb.dnset.com \n\n   0.0.0.0 slimxxxtubejie.dnset.com \n\n   0.0.0.0 slimxxxtubejlp.ddns.name \n\n   0.0.0.0 slimxxxtubejpe.ddns.name \n\n   0.0.0.0 slimxxxtubejvh.ddns.name \n\n   0.0.0.0 slimxxxtubejyk.ddns.name \n\n   0.0.0.0 slimxxxtubekad.ddns.name \n\n   0.0.0.0 slimxxxtubekgj.ddns.name \n\n   0.0.0.0 slimxxxtubekgv.ddns.name \n\n   0.0.0.0 slimxxxtubeklg.dnset.com \n\n   0.0.0.0 slimxxxtubekpn.ddns.name \n\n   0.0.0.0 slimxxxtubekrn.ddns.name \n\n   0.0.0.0 slimxxxtubelap.ddns.name \n\n   0.0.0.0 slimxxxtubelat.ddns.name \n\n   0.0.0.0 slimxxxtubelfr.ddns.name \n\n   0.0.0.0 slimxxxtubelzv.ddns.name \n\n   0.0.0.0 slimxxxtubemue.dnset.com \n\n   0.0.0.0 slimxxxtubeneg.ddns.name \n\n   0.0.0.0 slimxxxtubeneu.ddns.name \n\n   0.0.0.0 slimxxxtubengt.dnset.com \n\n   0.0.0.0 slimxxxtubenqp.ddns.name \n\n   0.0.0.0 slimxxxtubentf.dnset.com \n\n   0.0.0.0 slimxxxtubeocr.dnset.com \n\n   0.0.0.0 slimxxxtubeonf.dnset.com \n\n   0.0.0.0 slimxxxtubeopy.ddns.name \n\n   0.0.0.0 slimxxxtubeoxo.ddns.name \n\n   0.0.0.0 slimxxxtubeoxy.ddns.name \n\n   0.0.0.0 slimxxxtubeppj.dnset.com \n\n   0.0.0.0 slimxxxtubeqfo.ddns.name \n\n   0.0.0.0 slimxxxtubeqsh.ddns.name \n\n   0.0.0.0 slimxxxtubeqve.dnset.com \n\n   0.0.0.0 slimxxxtubeqwr.dnset.com \n\n   0.0.0.0 slimxxxtuberau.ddns.name \n\n   0.0.0.0 slimxxxtuberea.ddns.name \n\n   0.0.0.0 slimxxxtuberep.dnset.com \n\n   0.0.0.0 slimxxxtuberfe.dnset.com \n\n   0.0.0.0 slimxxxtuberjj.ddns.name \n\n   0.0.0.0 slimxxxtuberme.dnset.com \n\n   0.0.0.0 slimxxxtuberue.dnset.com \n\n   0.0.0.0 slimxxxtubesrs.dnset.com \n\n   0.0.0.0 slimxxxtubesrw.ddns.name \n\n   0.0.0.0 slimxxxtubesun.ddns.name \n\n   0.0.0.0 slimxxxtubetmf.ddns.name \n\n   0.0.0.0 slimxxxtubetmg.dnset.com \n\n   0.0.0.0 slimxxxtubetns.ddns.name \n\n   0.0.0.0 slimxxxtubetts.dnset.com \n\n   0.0.0.0 slimxxxtubeubp.dnset.com \n\n   0.0.0.0 slimxxxtubeujh.ddns.name \n\n   0.0.0.0 slimxxxtubeull.dnset.com \n\n   0.0.0.0 slimxxxtubeuvd.dnset.com \n\n   0.0.0.0 slimxxxtubevdn.ddns.name \n\n   0.0.0.0 slimxxxtubevih.dnset.com \n\n   0.0.0.0 slimxxxtubevjk.ddns.name \n\n   0.0.0.0 slimxxxtubewfl.ddns.name \n\n   0.0.0.0 slimxxxtubewiq.ddns.name \n\n   0.0.0.0 slimxxxtubewis.ddns.name \n\n   0.0.0.0 slimxxxtubewmt.dnset.com \n\n   0.0.0.0 slimxxxtubexei.ddns.name \n\n   0.0.0.0 slimxxxtubexiv.dnset.com \n\n   0.0.0.0 slimxxxtubexvq.ddns.name \n\n   0.0.0.0 slimxxxtubexwb.dnset.com \n\n   0.0.0.0 slimxxxtubexxq.dnset.com \n\n   0.0.0.0 slimxxxtubeyge.ddns.name \n\n   0.0.0.0 slimxxxtubeyhz.ddns.name \n\n   0.0.0.0 slimxxxtubeyza.ddns.name \n\n   0.0.0.0 smartify.org \n\n   0.0.0.0 smilll.depozit.hr \n\n   0.0.0.0 smrcek.com \n\n   0.0.0.0 sn-gzzx.com \n\n   0.0.0.0 somethingnice.hc0.me \n\n   0.0.0.0 somnoy.com \n\n   0.0.0.0 soros.departamentosejecutivos.cl \n\n   0.0.0.0 sos-medecins-stmalo.fr \n\n   0.0.0.0 soundcomputers.net \n\n   0.0.0.0 soxorok.ddospower.ro \n\n   0.0.0.0 spatsz.com \n\n   0.0.0.0 spekband.com \n\n   0.0.0.0 sportsulsan.co.kr \n\n   0.0.0.0 spread.diadanoivabh.com.br \n\n   0.0.0.0 spykit.110mb.com \n\n   0.0.0.0 srslogisticts.com \n\n   0.0.0.0 stailapoza.ro \n\n   0.0.0.0 static.retirementcommunitiesfyi.com \n\n   0.0.0.0 stjohnsdryden.org \n\n   0.0.0.0 stock.daydreamfuze.com \n\n   0.0.0.0 stockinter.intersport.es \n\n   0.0.0.0 stopmeagency.free.fr \n\n   0.0.0.0 storgas.co.rs \n\n   0.0.0.0 stork.escortfinder.cl \n\n   0.0.0.0 stormpages.com \n\n   0.0.0.0 strangeduckfilms.com \n\n   0.0.0.0 sudcom.org \n\n   0.0.0.0 sunlux.net \n\n   0.0.0.0 sunny99.cholerik.cz \n\n   0.0.0.0 svetyivanrilski.com \n\n   0.0.0.0 svision-online.de \n\n   0.0.0.0 sweettalk.co \n\n   0.0.0.0 sysconcalibration.com \n\n   0.0.0.0 systemscheckusa.com \n\n   0.0.0.0 szinhaz.hu \n\n   0.0.0.0 tabex.sopharma.bg \n\n   0.0.0.0 tamilcm.com \n\n   0.0.0.0 tatschke.net \n\n   0.0.0.0 tavuks.com \n\n   0.0.0.0 tcrwharen.homepage.t-online.de \n\n   0.0.0.0 teameda.comcastbiz.net \n\n   0.0.0.0 teameda.net \n\n   0.0.0.0 tecla-technologies.fr \n\n   0.0.0.0 tecnocuer.com \n\n   0.0.0.0 tecslide.com \n\n   0.0.0.0 tendersource.com \n\n   0.0.0.0 teprom.it \n\n   0.0.0.0 terem.eltransbt.ro \n\n   0.0.0.0 testtralala.xorg.pl \n\n   0.0.0.0 textsex.tk \n\n   0.0.0.0 thcextractor.com \n\n   0.0.0.0 thcvaporizer.com \n\n   0.0.0.0 thefxarchive.com \n\n   0.0.0.0 theweatherspace.com \n\n   0.0.0.0 thewinesteward.com \n\n   0.0.0.0 timothycopus.aimoo.com \n\n   0.0.0.0 titon.info \n\n   0.0.0.0 tk-gregoric.si \n\n   0.0.0.0 toddscarwash.com \n\n   0.0.0.0 tomalinoalambres.com.ar \n\n   0.0.0.0 topdecornegocios.com.br \n\n   0.0.0.0 tophostbg.net \n\n   0.0.0.0 totszentmarton.hu \n\n   0.0.0.0 tracking-stats-tr.usa.cc \n\n   0.0.0.0 traff1.com \n\n   0.0.0.0 trafficgrowth.com \n\n   0.0.0.0 trahic.ru \n\n   0.0.0.0 tremplin84.fr \n\n   0.0.0.0 treventuresonline.com \n\n   0.0.0.0 triangleservicesltd.com \n\n   0.0.0.0 trifle.ernstenco.be \n\n   0.0.0.0 troytempest.com \n\n   0.0.0.0 ttb.tbddlw.com \n\n   0.0.0.0 tube8vidsbbr.dnset.com \n\n   0.0.0.0 tube8vidsbhy.dnset.com \n\n   0.0.0.0 tube8vidsbzx.dnset.com \n\n   0.0.0.0 tube8vidscjk.ddns.name \n\n   0.0.0.0 tube8vidscqs.ddns.name \n\n   0.0.0.0 tube8vidscut.ddns.name \n\n   0.0.0.0 tube8vidsdob.dnset.com \n\n   0.0.0.0 tube8vidsdst.ddns.name \n\n   0.0.0.0 tube8vidsfgd.ddns.name \n\n   0.0.0.0 tube8vidshhr.ddns.name \n\n   0.0.0.0 tube8vidshkk.ddns.name \n\n   0.0.0.0 tube8vidshrw.dnset.com \n\n   0.0.0.0 tube8vidsiet.ddns.name \n\n   0.0.0.0 tube8vidsiww.ddns.name \n\n   0.0.0.0 tube8vidsjac.dnset.com \n\n   0.0.0.0 tube8vidsjan.ddns.name \n\n   0.0.0.0 tube8vidsjhn.ddns.name \n\n   0.0.0.0 tube8vidsjtq.ddns.name \n\n   0.0.0.0 tube8vidslmf.dnset.com \n\n   0.0.0.0 tube8vidslni.dnset.com \n\n   0.0.0.0 tube8vidslqk.ddns.name \n\n   0.0.0.0 tube8vidslrz.ddns.name \n\n   0.0.0.0 tube8vidsnlq.dnset.com \n\n   0.0.0.0 tube8vidsnrt.ddns.name \n\n   0.0.0.0 tube8vidsnvd.ddns.name \n\n   0.0.0.0 tube8vidsnyp.dnset.com \n\n   0.0.0.0 tube8vidsolh.ddns.name \n\n   0.0.0.0 tube8vidsotz.dnset.com \n\n   0.0.0.0 tube8vidsowd.dnset.com \n\n   0.0.0.0 tube8vidspeq.ddns.name \n\n   0.0.0.0 tube8vidsqof.ddns.name \n\n   0.0.0.0 tube8vidsrau.dnset.com \n\n   0.0.0.0 tube8vidsrdr.dnset.com \n\n   0.0.0.0 tube8vidsrhl.ddns.name \n\n   0.0.0.0 tube8vidsrom.dnset.com \n\n   0.0.0.0 tube8vidssan.dnset.com \n\n   0.0.0.0 tube8vidssjw.ddns.name \n\n   0.0.0.0 tube8vidssyg.dnset.com \n\n   0.0.0.0 tube8vidstrh.dnset.com \n\n   0.0.0.0 tube8vidstyp.ddns.name \n\n   0.0.0.0 tube8vidsuty.dnset.com \n\n   0.0.0.0 tube8vidsvaj.dnset.com \n\n   0.0.0.0 tube8vidsvcs.ddns.name \n\n   0.0.0.0 tube8vidsvmr.ddns.name \n\n   0.0.0.0 tube8vidsvrx.ddns.name \n\n   0.0.0.0 tube8vidsvtp.dnset.com \n\n   0.0.0.0 tube8vidswsy.dnset.com \n\n   0.0.0.0 tube8vidswtb.ddns.name \n\n   0.0.0.0 tube8vidswys.ddns.name \n\n   0.0.0.0 tube8vidsxlo.ddns.name \n\n   0.0.0.0 tube8vidsxmx.dnset.com \n\n   0.0.0.0 tube8vidsxpg.ddns.name \n\n   0.0.0.0 tube8vidsxpp.dnset.com \n\n   0.0.0.0 tube8vidsxwu.ddns.name \n\n   0.0.0.0 tube8vidsycs.dnset.com \n\n   0.0.0.0 tube8vidsyip.ddns.name \n\n   0.0.0.0 tube8vidsymz.dnset.com \n\n   0.0.0.0 tube8vidsyre.dnset.com \n\n   0.0.0.0 tube8vidsyyf.dnset.com \n\n   0.0.0.0 tube8vidszmi.ddns.name \n\n   0.0.0.0 tube8vidsznj.ddns.name \n\n   0.0.0.0 tube8vidsznx.ddns.name \n\n   0.0.0.0 tube8vidszyj.ddns.name \n\n   0.0.0.0 tubemoviez.com \n\n   0.0.0.0 typeofmarijuana.com \n\n   0.0.0.0 ubike.tourstogo.us \n\n   0.0.0.0 uchyz.cruisingsmallship.com \n\n   0.0.0.0 ukonline.hc0.me \n\n   0.0.0.0 ukrfarms.com.ua \n\n   0.0.0.0 ukugl.tourstogo.us \n\n   0.0.0.0 unalbilgisayar.com \n\n   0.0.0.0 undefined.it \n\n   0.0.0.0 unitex.home.pl \n\n   0.0.0.0 unlim-app.tk \n\n   0.0.0.0 updat120.clanteam.com \n\n   0.0.0.0 update.51edm.net \n\n   0.0.0.0 update.onescan.co.kr \n\n   0.0.0.0 updo.nl \n\n   0.0.0.0 uploads.tmweb.ru \n\n   0.0.0.0 upsoj.iptvdeals.com \n\n   0.0.0.0 upswings.net \n\n   0.0.0.0 urban-motorcycles.com \n\n   0.0.0.0 url-cameralist.tk \n\n   0.0.0.0 users173.lolipop.jp \n\n   0.0.0.0 utopia-muenchen.de \n\n   0.0.0.0 uvidu.butlerelectricsupply.com \n\n   0.0.0.0 v.inigsplan.ru \n\n   0.0.0.0 valouweeigenaren.nl \n\n   0.0.0.0 vdh-rimbach.de \n\n   0.0.0.0 vdula.czystykod.pl \n\n   0.0.0.0 veevu.tourstogo.us \n\n   0.0.0.0 veksi.barginginfrance.net \n\n   0.0.0.0 vernoblisk.com \n\n   0.0.0.0 vette-porno.nl \n\n   0.0.0.0 victor.connectcloud.ch \n\n   0.0.0.0 videoflyover.com \n\n   0.0.0.0 villalecchi.com \n\n   0.0.0.0 ville-st-remy-sur-avre.fr \n\n   0.0.0.0 vipdn123.blackapplehost.com \n\n   0.0.0.0 vistatech.us \n\n   0.0.0.0 vitalityxray.com \n\n   0.0.0.0 vitamasaz.pl \n\n   0.0.0.0 vitha.csheaven.com \n\n   0.0.0.0 vivaweb.org \n\n   0.0.0.0 vkont.bos.ru \n\n   0.0.0.0 vmay.com \n\n   0.0.0.0 vocational-training.us \n\n   0.0.0.0 vomit.facilitandosonhos.com.br \n\n   0.0.0.0 vroll.net \n\n   0.0.0.0 vural-electronic.com \n\n   0.0.0.0 vvps.ws \n\n   0.0.0.0 w4988.nb.host127-0-0-1.com \n\n   0.0.0.0 w612.nb.host127-0-0-1.com \n\n   0.0.0.0 wahyufian.zoomshare.com \n\n   0.0.0.0 wallpapers91.com \n\n   0.0.0.0 warco.pl \n\n   0.0.0.0 wc0x83ghk.homepage.t-online.de \n\n   0.0.0.0 web-domain.tk \n\n   0.0.0.0 web-fill.tk \n\n   0.0.0.0 web-olymp.ru \n\n   0.0.0.0 web-sensations.com \n\n   0.0.0.0 webcashmaker.com \n\n   0.0.0.0 webcom-software.ws \n\n   0.0.0.0 webordermanager.com \n\n   0.0.0.0 weboxmedia.by \n\n   0.0.0.0 websalesusa.com \n\n   0.0.0.0 websitebuildersinfo.in \n\n   0.0.0.0 welington.info \n\n   0.0.0.0 westlifego.com \n\n   0.0.0.0 wetjane.x10.mx \n\n   0.0.0.0 wetyt.tourstogo.us \n\n   0.0.0.0 wfoto.front.ru \n\n   0.0.0.0 whabi.csheaven.com \n\n   0.0.0.0 whave.iptvdeals.com \n\n   0.0.0.0 whitehorsetechnologies.net \n\n   0.0.0.0 win2150.vs.easily.co.uk \n\n   0.0.0.0 windspotter.net \n\n   0.0.0.0 winlock.usa.cc \n\n   0.0.0.0 winrar-soft.ru \n\n   0.0.0.0 winsetupcostotome.easthamvacations.info \n\n   0.0.0.0 wixx.caliptopis.cl \n\n   0.0.0.0 wkmg.co.kr \n\n   0.0.0.0 wmserver.net \n\n   0.0.0.0 womenslabour.org \n\n   0.0.0.0 wonchangvacuum.com.my \n\n   0.0.0.0 wopper.bioblitzgaming.ca \n\n   0.0.0.0 worldgymperu.com \n\n   0.0.0.0 wp9.ru \n\n   0.0.0.0 writingassociates.com \n\n   0.0.0.0 wroclawski.com.pl \n\n   0.0.0.0 wt10.haote.com \n\n   0.0.0.0 wv-law.com \n\n   0.0.0.0 www.0uk.net \n\n   0.0.0.0 www.2607.cn \n\n   0.0.0.0 www.3difx.com \n\n   0.0.0.0 www.3peaks.co.jp \n\n   0.0.0.0 www.acquisizionevideo.com \n\n   0.0.0.0 www.actiagroup.com \n\n   0.0.0.0 www.advancesrl.eu \n\n   0.0.0.0 www.aerreravasi.com \n\n   0.0.0.0 www.airbornehydrography.com \n\n   0.0.0.0 www.airsonett.se \n\n   0.0.0.0 www.alphamedical02.fr \n\n   0.0.0.0 www.angolotesti.it \n\n   0.0.0.0 www.anticarredodolomiti.com \n\n   0.0.0.0 www.archigate.it \n\n   0.0.0.0 www.areadiprova.eu \n\n   0.0.0.0 www.arkinsoftware.in \n\n   0.0.0.0 www.assculturaleincontri.it \n\n   0.0.0.0 www.asu.msmu.ru \n\n   0.0.0.0 www.atousoft.com \n\n   0.0.0.0 www.aucoeurdelanature.com \n\n   0.0.0.0 www.autoappassionati.it \n\n   0.0.0.0 www.avrakougioumtzi.gr \n\n   0.0.0.0 www.bcservice.it \n\n   0.0.0.0 www.bedoc.fr \n\n   0.0.0.0 www.bilder-upload.eu \n\n   0.0.0.0 www.blueimagen.com \n\n   0.0.0.0 www.casamama.nl \n\n   0.0.0.0 www.catgallery.com \n\n   0.0.0.0 www.caue971.org \n\n   0.0.0.0 www.ceisystems.it \n\n   0.0.0.0 www.cellularbeton.it \n\n   0.0.0.0 www.cerquasas.it \n\n   0.0.0.0 www.chemgas.com \n\n   0.0.0.0 www.chiaperottipaolo.it \n\n   0.0.0.0 www.cifor.com \n\n   0.0.0.0 www.coloritpak.by \n\n   0.0.0.0 www.consumeralternatives.org \n\n   0.0.0.0 www.cordonnerie-fb.fr \n\n   0.0.0.0 www.cortesidesign.com \n\n   0.0.0.0 www.daspar.net \n\n   0.0.0.0 www.del-marine.com \n\n   0.0.0.0 www.dezuiderwaard.nl \n\n   0.0.0.0 www.divshare.com \n\n   0.0.0.0 www.doctor-alex.com \n\n   0.0.0.0 www.donneuropa.it \n\n   0.0.0.0 www.dowdenphotography.com \n\n   0.0.0.0 www.downloaddirect.com \n\n   0.0.0.0 www.drteachme.com \n\n   0.0.0.0 www.ecoleprincessedeliege.be \n\n   0.0.0.0 www.eielectronics.com \n\n   0.0.0.0 www.eivamos.com \n\n   0.0.0.0 www.elisaart.it \n\n   0.0.0.0 www.email-login-support.com \n\n   0.0.0.0 www.emrlogistics.com \n\n   0.0.0.0 www.enchantier.com \n\n   0.0.0.0 www.exelio.be \n\n   0.0.0.0 www.fabioalbini.com \n\n   0.0.0.0 www.fasadobygg.com \n\n   0.0.0.0 www.feiyang163.com \n\n   0.0.0.0 www.fiduciariobajio.com.mx \n\n   0.0.0.0 www.fiocchidiriso.com \n\n   0.0.0.0 www.flowtec.com.br \n\n   0.0.0.0 www.fotoidea.com \n\n   0.0.0.0 www.freegames777.net \n\n   0.0.0.0 www.freemao.com \n\n   0.0.0.0 www.freewebtown.com \n\n   0.0.0.0 www.frosinonewesternshow.it \n\n   0.0.0.0 www.fsm-europe.eu \n\n   0.0.0.0 www.galileounaluna.com \n\n   0.0.0.0 www.gameangel.com \n\n   0.0.0.0 www.gasthofpost-ebs.de \n\n   0.0.0.0 www.gennaroespositomilano.it \n\n   0.0.0.0 www.gliamicidellunicef.it \n\n   0.0.0.0 www.gmcjjh.org \n\n   0.0.0.0 www.gold-city.it \n\n   0.0.0.0 www.gulsproductions.com \n\n   0.0.0.0 www.hausnet.ru \n\n   0.0.0.0 www.hitekshop.vn \n\n   0.0.0.0 www.hospedar.xpg.com.br \n\n   0.0.0.0 www.hoteldelamer-tregastel.com \n\n   0.0.0.0 www.icybrand.eu \n\n   0.0.0.0 www.imagerieduroc.com \n\n   0.0.0.0 www.inevo.co.il \n\n   0.0.0.0 www.infra.by \n\n   0.0.0.0 www.jcmarcadolib.com \n\n   0.0.0.0 www.joomlalivechat.com \n\n   0.0.0.0 www.kcta.or.kr \n\n   0.0.0.0 www.kjbbc.net \n\n   0.0.0.0 www.lajourneeducommercedeproximite.fr \n\n   0.0.0.0 www.lccl.org.uk \n\n   0.0.0.0 www.les-ptits-dodos.com \n\n   0.0.0.0 www.litra.com.mk \n\n   0.0.0.0 www.lostartofbeingadame.com \n\n   0.0.0.0 www.lowes-pianos-and-organs.com \n\n   0.0.0.0 www.luce.polimi.it \n\n   0.0.0.0 www.lyzgs.com \n\n   0.0.0.0 www.m-barati.de \n\n   0.0.0.0 www.makohela.tk \n\n   0.0.0.0 www.marcilly-le-chatel.fr \n\n   0.0.0.0 www.marinoderosas.com \n\n   0.0.0.0 www.marss.eu \n\n   0.0.0.0 www.milardi.it \n\n   0.0.0.0 www.mondoperaio.net \n\n   0.0.0.0 www.montacarichi.it \n\n   0.0.0.0 www.motivacionyrelajacion.com \n\n   0.0.0.0 www.moviedownloader.net \n\n   0.0.0.0 www.mrpeter.it \n\n   0.0.0.0 www.northpoleitalia.it \n\n   0.0.0.0 www.notaverde.com \n\n   0.0.0.0 www.nothingcompares.co.uk \n\n   0.0.0.0 www.nuvon.com \n\n   0.0.0.0 www.obyz.de \n\n   0.0.0.0 www.offerent.com \n\n   0.0.0.0 www.officialrdr.com \n\n   0.0.0.0 www.ohiomm.com \n\n   0.0.0.0 www.oiluk.net \n\n   0.0.0.0 www.ostsee-schnack.de \n\n   0.0.0.0 www.outlinearray.com \n\n   0.0.0.0 www.over50datingservices.com \n\n   0.0.0.0 www.paliteo.com \n\n   0.0.0.0 www.panazan.ro \n\n   0.0.0.0 www.parfumer.by \n\n   0.0.0.0 www.perupuntocom.com \n\n   0.0.0.0 www.petpleasers.ca \n\n   0.0.0.0 www.pgathailand.com \n\n   0.0.0.0 www.pieiron.co.uk \n\n   0.0.0.0 www.plantes-sauvages.fr \n\n   0.0.0.0 www.poesiadelsud.it \n\n   0.0.0.0 www.poffet.net \n\n   0.0.0.0 www.praxisww.com \n\n   0.0.0.0 www.prfelectrical.com.au \n\n   0.0.0.0 www.proascolcolombia.com \n\n   0.0.0.0 www.professionalblackbook.com \n\n   0.0.0.0 www.profill-smd.com \n\n   0.0.0.0 www.propan.ru \n\n   0.0.0.0 www.purplehorses.net \n\n   0.0.0.0 www.racingandclassic.com \n\n   0.0.0.0 www.realinnovation.com \n\n   0.0.0.0 www.rebeccacella.com \n\n   0.0.0.0 www.reifen-simon.com \n\n   0.0.0.0 www.rempko.sk \n\n   0.0.0.0 www.riccardochinnici.it \n\n   0.0.0.0 www.ristoromontebasso.it \n\n   0.0.0.0 www.rokus-tgy.hu \n\n   0.0.0.0 www.roltek.com.tr \n\n   0.0.0.0 www.rooversadvocatuur.nl \n\n   0.0.0.0 www.rst-velbert.de \n\n   0.0.0.0 www.saemark.is \n\n   0.0.0.0 www.salentoeasy.it \n\n   0.0.0.0 www.sankyo.gr.jp \n\n   0.0.0.0 www.sanseracingteam.com \n\n   0.0.0.0 www.sasenergia.pt \n\n   0.0.0.0 www.sbo.it \n\n   0.0.0.0 www.scanmyphones.com \n\n   0.0.0.0 www.scantanzania.com \n\n   0.0.0.0 www.schuh-zentgraf.de \n\n   0.0.0.0 www.seal-technicsag.ch \n\n   0.0.0.0 www.secondome.com \n\n   0.0.0.0 www.serciudadano.com.ar \n\n   0.0.0.0 www.sieltre.it \n\n   0.0.0.0 www.sitepalace.com \n\n   0.0.0.0 www.sj88.com \n\n   0.0.0.0 www.slayerlife.com \n\n   0.0.0.0 www.slivki.com.ua \n\n   0.0.0.0 www.smartgvcfunding.com \n\n   0.0.0.0 www.smartscan.ro \n\n   0.0.0.0 www.sonnoli.com \n\n   0.0.0.0 www.soskin.eu \n\n   0.0.0.0 www.spris.com \n\n   0.0.0.0 www.stirparts.ru \n\n   0.0.0.0 www.stormpages.com \n\n   0.0.0.0 www.studiochiarelli.eu \n\n   0.0.0.0 www.super8service.de \n\n   0.0.0.0 www.surfguide.fr \n\n   0.0.0.0 www.t-gas.co.uk \n\n   0.0.0.0 www.t-sb.net \n\n   0.0.0.0 www.tdms.saglik.gov.tr \n\n   0.0.0.0 www.technix.it \n\n   0.0.0.0 www.thesparkmachine.com \n\n   0.0.0.0 www.tiergestuetzt.de \n\n   0.0.0.0 www.toochattoo.com \n\n   0.0.0.0 www.torgi.kz \n\n   0.0.0.0 www.tpt.edu.in \n\n   0.0.0.0 www.tvnews.or.kr \n\n   0.0.0.0 www.two-of-us.at \n\n   0.0.0.0 www.unicaitaly.it \n\n   0.0.0.0 www.uriyuri.com \n\n   0.0.0.0 www.usaenterprise.com \n\n   0.0.0.0 www.vertourmer.com \n\n   0.0.0.0 www.village-gabarrier.com \n\n   0.0.0.0 www.vinyljazzrecords.com \n\n   0.0.0.0 www.vipcpms.com \n\n   0.0.0.0 www.vivaimontina.com \n\n   0.0.0.0 www.volleyball-doppeldorf.de \n\n   0.0.0.0 www.vvvic.com \n\n   0.0.0.0 www.whitesports.co.kr \n\n   0.0.0.0 www.widestep.com \n\n   0.0.0.0 www.wigglewoo.com \n\n   0.0.0.0 www.wildsap.com \n\n   0.0.0.0 www.wrestlingexposed.com \n\n   0.0.0.0 www.wyroki.eu \n\n   0.0.0.0 www.xiruz.kit.net \n\n   0.0.0.0 www.ywvcomputerprocess.info \n\n   0.0.0.0 www.zatzy.com \n\n   0.0.0.0 www.zctei.com \n\n   0.0.0.0 www.zyxyfy.com \n\n   0.0.0.0 www12.0zz0.com \n\n   0.0.0.0 www8.0zz0.com \n\n   0.0.0.0 xamateurpornlic.www1.biz \n\n   0.0.0.0 xicaxique.com.br \n\n   0.0.0.0 xindalawyer.com \n\n   0.0.0.0 xoomer.alice.it \n\n   0.0.0.0 xorgwebs.webs.com \n\n   0.0.0.0 xotsa.frenchgerlemanelectric.com \n\n   0.0.0.0 xpornstarsckc.ddns.name \n\n   0.0.0.0 yigitakcali.com \n\n   0.0.0.0 ylpzt.juzojossai.net \n\n   0.0.0.0 yougube.com \n\n   0.0.0.0 youtibe.com \n\n   0.0.0.0 youtuhe.com \n\n   0.0.0.0 yumekin.com \n\n   0.0.0.0 z32538.nb.host127-0-0-1.com \n\n   0.0.0.0 z7752.com \n\n   0.0.0.0 zgsysz.com \n\n   0.0.0.0 zibup.csheaven.com \n\n   0.0.0.0 zjjlf.croukwexdbyerr.net \n\n   0.0.0.0 zkic.com \n\n   0.0.0.0 zous.szm.sk \n\n   0.0.0.0 zt.tim-taxi.com \n\n   0.0.0.0 zyrdu.cruisingsmallship.com \n\n   0.0.0.0 101com.com \n\n   0.0.0.0 101order.com \n\n   0.0.0.0 123found.com \n\n   0.0.0.0 180hits.de \n\n   0.0.0.0 180searchassistant.com \n\n   0.0.0.0 1x1rank.com \n\n   0.0.0.0 207.net \n\n   0.0.0.0 247media.com \n\n   0.0.0.0 24log.com \n\n   0.0.0.0 24log.de \n\n   0.0.0.0 24pm-affiliation.com \n\n   0.0.0.0 2mdn.net \n\n   0.0.0.0 2o7.net \n\n   0.0.0.0 360yield.com \n\n   0.0.0.0 4affiliate.net \n\n   0.0.0.0 4d5.net \n\n   0.0.0.0 50websads.com \n\n   0.0.0.0 518ad.com \n\n   0.0.0.0 51yes.com \n\n   0.0.0.0 600z.com \n\n   0.0.0.0 777partner.com \n\n   0.0.0.0 77tracking.com \n\n   0.0.0.0 7bpeople.com \n\n   0.0.0.0 7search.com \n\n   0.0.0.0 99count.com \n\n   0.0.0.0 a-ads.com \n\n   0.0.0.0 a-counter.kiev.ua \n\n   0.0.0.0 a.0day.kiev.ua \n\n   0.0.0.0 a.aproductmsg.com \n\n   0.0.0.0 a.collective-media.net \n\n   0.0.0.0 a.consumer.net \n\n   0.0.0.0 a.mktw.net \n\n   0.0.0.0 a.sakh.com \n\n   0.0.0.0 a.ucoz.net \n\n   0.0.0.0 a.ucoz.ru \n\n   0.0.0.0 a.xanga.com \n\n   0.0.0.0 a32.g.a.yimg.com \n\n   0.0.0.0 aaddzz.com \n\n   0.0.0.0 abacho.net \n\n   0.0.0.0 abc-ads.com \n\n   0.0.0.0 absoluteclickscom.com \n\n   0.0.0.0 abz.com \n\n   0.0.0.0 ac.rnm.ca \n\n   0.0.0.0 accounts.pkr.com.invalid \n\n   0.0.0.0 acsseo.com \n\n   0.0.0.0 actionsplash.com \n\n   0.0.0.0 actualdeals.com \n\n   0.0.0.0 acuityads.com \n\n   0.0.0.0 ad-balancer.at \n\n   0.0.0.0 ad-balancer.net \n\n   0.0.0.0 ad-center.com \n\n   0.0.0.0 ad-images.suntimes.com \n\n   0.0.0.0 ad-pay.de \n\n   0.0.0.0 ad-rotator.com \n\n   0.0.0.0 ad-server.gulasidorna.se \n\n   0.0.0.0 ad-serverparc.nl \n\n   0.0.0.0 ad-souk.com \n\n   0.0.0.0 ad-space.net \n\n   0.0.0.0 ad-tech.com \n\n   0.0.0.0 ad-up.com \n\n   0.0.0.0 ad.100.tbn.ru \n\n   0.0.0.0 ad.71i.de \n\n   0.0.0.0 ad.980x.com \n\n   0.0.0.0 ad.a8.net \n\n   0.0.0.0 ad.abcnews.com \n\n   0.0.0.0 ad.abctv.com \n\n   0.0.0.0 ad.about.com \n\n   0.0.0.0 ad.aboutit.de \n\n   0.0.0.0 ad.aboutwebservices.com \n\n   0.0.0.0 ad.abum.com \n\n   0.0.0.0 ad.afy11.net \n\n   0.0.0.0 ad.allstar.cz \n\n   0.0.0.0 ad.altervista.org \n\n   0.0.0.0 ad.amgdgt.com \n\n   0.0.0.0 ad.anuntis.com \n\n   0.0.0.0 ad.auditude.com \n\n   0.0.0.0 ad.bizo.com \n\n   0.0.0.0 ad.bnmla.com \n\n   0.0.0.0 ad.bondage.com \n\n   0.0.0.0 ad.caradisiac.com \n\n   0.0.0.0 ad.centrum.cz \n\n   0.0.0.0 ad.cgi.cz \n\n   0.0.0.0 ad.choiceradio.com \n\n   0.0.0.0 ad.clix.pt \n\n   0.0.0.0 ad.cooks.com \n\n   0.0.0.0 ad.crwdcntrl.net \n\n   0.0.0.0 ad.digitallook.com \n\n   0.0.0.0 ad.directrev.com \n\n   0.0.0.0 ad.doctissimo.fr \n\n   0.0.0.0 ad.domainfactory.de \n\n   0.0.0.0 ad.e-kolay.net \n\n   0.0.0.0 ad.eurosport.com \n\n   0.0.0.0 ad.f1cd.ru \n\n   0.0.0.0 ad.flurry.com \n\n   0.0.0.0 ad.foxnetworks.com \n\n   0.0.0.0 ad.freecity.de \n\n   0.0.0.0 ad.gate24.ch \n\n   0.0.0.0 ad.globe7.com \n\n   0.0.0.0 ad.grafika.cz \n\n   0.0.0.0 ad.hbv.de \n\n   0.0.0.0 ad.hodomobile.com \n\n   0.0.0.0 ad.httpool.com \n\n   0.0.0.0 ad.hyena.cz \n\n   0.0.0.0 ad.iinfo.cz \n\n   0.0.0.0 ad.ilove.ch \n\n   0.0.0.0 ad.infoseek.com \n\n   0.0.0.0 ad.jamba.net \n\n   0.0.0.0 ad.jamster.co.uk \n\n   0.0.0.0 ad.jetsoftware.com \n\n   0.0.0.0 ad.keenspace.com \n\n   0.0.0.0 ad.leadbolt.net \n\n   0.0.0.0 ad.liveinternet.ru \n\n   0.0.0.0 ad.lupa.cz \n\n   0.0.0.0 ad.m5prod.net \n\n   0.0.0.0 ad.media-servers.net \n\n   0.0.0.0 ad.mediastorm.hu \n\n   0.0.0.0 ad.mgd.de \n\n   0.0.0.0 ad.musicmatch.com \n\n   0.0.0.0 ad.nachtagenten.de \n\n   0.0.0.0 ad.nozonedata.com \n\n   0.0.0.0 ad.nttnavi.co.jp \n\n   0.0.0.0 ad.nwt.cz \n\n   0.0.0.0 ad.onad.eu \n\n   0.0.0.0 ad.pandora.tv \n\n   0.0.0.0 ad.playground.ru \n\n   0.0.0.0 ad.preferances.com \n\n   0.0.0.0 ad.profiwin.de \n\n   0.0.0.0 ad.prv.pl \n\n   0.0.0.0 ad.rambler.ru \n\n   0.0.0.0 ad.reunion.com \n\n   0.0.0.0 ad.scanmedios.com \n\n   0.0.0.0 ad.sensismediasmart.com.au \n\n   0.0.0.0 ad.seznam.cz \n\n   0.0.0.0 ad.simgames.net \n\n   0.0.0.0 ad.slutload.com \n\n   0.0.0.0 ad.smartclip.net \n\n   0.0.0.0 ad.tbn.ru \n\n   0.0.0.0 ad.technoratimedia.com \n\n   0.0.0.0 ad.thewheelof.com \n\n   0.0.0.0 ad.turn.com \n\n   0.0.0.0 ad.tv2.no \n\n   0.0.0.0 ad.twitchguru.com \n\n   0.0.0.0 ad.usatoday.com \n\n   0.0.0.0 ad.virtual-nights.com \n\n   0.0.0.0 ad.watch.impress.co.jp \n\n   0.0.0.0 ad.wavu.hu \n\n   0.0.0.0 ad.way.cz \n\n   0.0.0.0 ad.weatherbug.com \n\n   0.0.0.0 ad.wsod.com \n\n   0.0.0.0 ad.wz.cz \n\n   0.0.0.0 ad.yadro.ru \n\n   0.0.0.0 ad.yourmedia.com \n\n   0.0.0.0 ad.zanox.com \n\n   0.0.0.0 ad0.bigmir.net \n\n   0.0.0.0 ad01.mediacorpsingapore.com \n\n   0.0.0.0 ad1.emediate.dk \n\n   0.0.0.0 ad1.emule-project.org \n\n   0.0.0.0 ad1.kde.cz \n\n   0.0.0.0 ad1.pamedia.com.au \n\n   0.0.0.0 ad2.iinfo.cz \n\n   0.0.0.0 ad2.ip.ro \n\n   0.0.0.0 ad2.linxcz.cz \n\n   0.0.0.0 ad2.lupa.cz \n\n   0.0.0.0 ad2flash.com \n\n   0.0.0.0 ad2games.com \n\n   0.0.0.0 ad3.iinfo.cz \n\n   0.0.0.0 ad3.pamedia.com.au \n\n   0.0.0.0 ad4game.com \n\n   0.0.0.0 adaction.de \n\n   0.0.0.0 adadvisor.net \n\n   0.0.0.0 adap.tv \n\n   0.0.0.0 adapt.tv \n\n   0.0.0.0 adbanner.ro \n\n   0.0.0.0 adbard.net \n\n   0.0.0.0 adblade.com \n\n   0.0.0.0 adblockanalytics.com \n\n   0.0.0.0 adboost.de.vu \n\n   0.0.0.0 adboost.net \n\n   0.0.0.0 adbooth.net \n\n   0.0.0.0 adbot.com \n\n   0.0.0.0 adbrite.com \n\n   0.0.0.0 adbroker.de \n\n   0.0.0.0 adbunker.com \n\n   0.0.0.0 adbutler.com \n\n   0.0.0.0 adbutler.de \n\n   0.0.0.0 adbuyer.com \n\n   0.0.0.0 adbuyer3.lycos.com \n\n   0.0.0.0 adcash.com \n\n   0.0.0.0 adcast.deviantart.com \n\n   0.0.0.0 adcell.de \n\n   0.0.0.0 adcenter.mdf.se \n\n   0.0.0.0 adcenter.net \n\n   0.0.0.0 adcentriconline.com \n\n   0.0.0.0 adcept.net \n\n   0.0.0.0 adclick.com \n\n   0.0.0.0 adclient.uimserv.net \n\n   0.0.0.0 adclient1.tucows.com \n\n   0.0.0.0 adcloud.net \n\n   0.0.0.0 adcomplete.com \n\n   0.0.0.0 adconion.com \n\n   0.0.0.0 adcontent.gamespy.com \n\n   0.0.0.0 adcycle.com \n\n   0.0.0.0 add.newmedia.cz \n\n   0.0.0.0 addealing.com \n\n   0.0.0.0 addesktop.com \n\n   0.0.0.0 addfreestats.com \n\n   0.0.0.0 addme.com \n\n   0.0.0.0 adecn.com \n\n   0.0.0.0 ademails.com \n\n   0.0.0.0 adengage.com \n\n   0.0.0.0 adexpose.com \n\n   0.0.0.0 adext.inkclub.com \n\n   0.0.0.0 adf.ly \n\n   0.0.0.0 adfactor.nl \n\n   0.0.0.0 adfarm.mediaplex.com \n\n   0.0.0.0 adflight.com \n\n   0.0.0.0 adforce.com \n\n   0.0.0.0 adform.com \n\n   0.0.0.0 adgardener.com \n\n   0.0.0.0 adgoto.com \n\n   0.0.0.0 adgridwork.com \n\n   0.0.0.0 adhese.be \n\n   0.0.0.0 adhese.com \n\n   0.0.0.0 adi.mainichi.co.jp \n\n   0.0.0.0 adimage.asiaone.com.sg \n\n   0.0.0.0 adimage.guardian.co.uk \n\n   0.0.0.0 adimages.been.com \n\n   0.0.0.0 adimages.carsoup.com \n\n   0.0.0.0 adimages.go.com \n\n   0.0.0.0 adimages.homestore.com \n\n   0.0.0.0 adimages.omroepzeeland.nl \n\n   0.0.0.0 adimages.sanomawsoy.fi \n\n   0.0.0.0 adimg.cnet.com \n\n   0.0.0.0 adimg.com.com \n\n   0.0.0.0 adimg.uimserv.net \n\n   0.0.0.0 adimg1.chosun.com \n\n   0.0.0.0 adimgs.sapo.pt \n\n   0.0.0.0 adimpact.com \n\n   0.0.0.0 adinjector.net \n\n   0.0.0.0 adinterax.com \n\n   0.0.0.0 adisfy.com \n\n   0.0.0.0 adition.com \n\n   0.0.0.0 adition.de \n\n   0.0.0.0 adition.net \n\n   0.0.0.0 adizio.com \n\n   0.0.0.0 adjix.com \n\n   0.0.0.0 adjug.com \n\n   0.0.0.0 adjuggler.com \n\n   0.0.0.0 adjuggler.yourdictionary.com \n\n   0.0.0.0 adjustnetwork.com \n\n   0.0.0.0 adk2.com \n\n   0.0.0.0 adk2ads.tictacti.com \n\n   0.0.0.0 adland.ru \n\n   0.0.0.0 adlantic.nl \n\n   0.0.0.0 adledge.com \n\n   0.0.0.0 adlegend.com \n\n   0.0.0.0 adlog.com.com \n\n   0.0.0.0 adloox.com \n\n   0.0.0.0 adlooxtracking.com \n\n   0.0.0.0 adlure.net \n\n   0.0.0.0 admagnet.net \n\n   0.0.0.0 admailtiser.com \n\n   0.0.0.0 adman.gr \n\n   0.0.0.0 adman.in.gr \n\n   0.0.0.0 adman.otenet.gr \n\n   0.0.0.0 admanagement.ch \n\n   0.0.0.0 admanager.btopenworld.com \n\n   0.0.0.0 admanager.carsoup.com \n\n   0.0.0.0 admarketplace.net \n\n   0.0.0.0 admarvel.com \n\n   0.0.0.0 admax.nexage.com \n\n   0.0.0.0 admedia.com \n\n   0.0.0.0 admedia.ro \n\n   0.0.0.0 admeld.com \n\n   0.0.0.0 admerize.be \n\n   0.0.0.0 admeta.com \n\n   0.0.0.0 admex.com \n\n   0.0.0.0 adminder.com \n\n   0.0.0.0 adminshop.com \n\n   0.0.0.0 admized.com \n\n   0.0.0.0 admob.com \n\n   0.0.0.0 admonitor.com \n\n   0.0.0.0 admotion.com.ar \n\n   0.0.0.0 adnet-media.net \n\n   0.0.0.0 adnet.asahi.com \n\n   0.0.0.0 adnet.biz \n\n   0.0.0.0 adnet.de \n\n   0.0.0.0 adnet.ru \n\n   0.0.0.0 adnet.worldreviewer.com \n\n   0.0.0.0 adnetinteractive.com \n\n   0.0.0.0 adnetwork.net \n\n   0.0.0.0 adnetworkperformance.com \n\n   0.0.0.0 adnews.maddog2000.de \n\n   0.0.0.0 adnotch.com \n\n   0.0.0.0 adnxs.com \n\n   0.0.0.0 adocean.pl \n\n   0.0.0.0 adonspot.com \n\n   0.0.0.0 adoperator.com \n\n   0.0.0.0 adorigin.com \n\n   0.0.0.0 adpepper.dk \n\n   0.0.0.0 adpepper.nl \n\n   0.0.0.0 adperium.com \n\n   0.0.0.0 adpia.vn \n\n   0.0.0.0 adplus.co.id \n\n   0.0.0.0 adplxmd.com \n\n   0.0.0.0 adprofile.net \n\n   0.0.0.0 adprojekt.pl \n\n   0.0.0.0 adq.nextag.com \n\n   0.0.0.0 adrazzi.com \n\n   0.0.0.0 adreactor.com \n\n   0.0.0.0 adremedy.com \n\n   0.0.0.0 adreporting.com \n\n   0.0.0.0 adres.internet.com \n\n   0.0.0.0 adrevolver.com \n\n   0.0.0.0 adriver.ru \n\n   0.0.0.0 adrolays.de \n\n   0.0.0.0 adrotate.de \n\n   0.0.0.0 adrotator.se \n\n   0.0.0.0 ads-click.com \n\n   0.0.0.0 ads.4tube.com \n\n   0.0.0.0 ads.5ci.lt \n\n   0.0.0.0 ads.abovetopsecret.com \n\n   0.0.0.0 ads.aceweb.net \n\n   0.0.0.0 ads.activestate.com \n\n   0.0.0.0 ads.adfox.ru \n\n   0.0.0.0 ads.administrator.de \n\n   0.0.0.0 ads.adshareware.net \n\n   0.0.0.0 ads.adultfriendfinder.com \n\n   0.0.0.0 ads.adultswim.com \n\n   0.0.0.0 ads.advance.net \n\n   0.0.0.0 ads.adverline.com \n\n   0.0.0.0 ads.affiliates.match.com \n\n   0.0.0.0 ads.ak.facebook.com.edgesuite.net \n\n   0.0.0.0 ads.allvatar.com \n\n   0.0.0.0 ads.alt.com \n\n   0.0.0.0 ads.amdmb.com \n\n   0.0.0.0 ads.amigos.com \n\n   0.0.0.0 ads.aol.co.uk \n\n   0.0.0.0 ads.aol.com \n\n   0.0.0.0 ads.apn.co.nz \n\n   0.0.0.0 ads.appsgeyser.com \n\n   0.0.0.0 ads.as4x.tmcs.net \n\n   0.0.0.0 ads.as4x.tmcs.ticketmaster.com \n\n   0.0.0.0 ads.asia1.com.sg \n\n   0.0.0.0 ads.asiafriendfinder.com \n\n   0.0.0.0 ads.ask.com \n\n   0.0.0.0 ads.aspalliance.com \n\n   0.0.0.0 ads.avazu.net \n\n   0.0.0.0 ads.batpmturner.com \n\n   0.0.0.0 ads.beenetworks.net \n\n   0.0.0.0 ads.belointeractive.com \n\n   0.0.0.0 ads.berlinonline.de \n\n   0.0.0.0 ads.betanews.com \n\n   0.0.0.0 ads.betfair.com \n\n   0.0.0.0 ads.betfair.com.au \n\n   0.0.0.0 ads.bigchurch.com \n\n   0.0.0.0 ads.bigfoot.com \n\n   0.0.0.0 ads.billiton.de \n\n   0.0.0.0 ads.bing.com \n\n   0.0.0.0 ads.bittorrent.com \n\n   0.0.0.0 ads.blog.com \n\n   0.0.0.0 ads.bloomberg.com \n\n   0.0.0.0 ads.bluelithium.com \n\n   0.0.0.0 ads.bluemountain.com \n\n   0.0.0.0 ads.bluesq.com \n\n   0.0.0.0 ads.bonniercorp.com \n\n   0.0.0.0 ads.boylesports.com \n\n   0.0.0.0 ads.brabys.com \n\n   0.0.0.0 ads.brain.pk \n\n   0.0.0.0 ads.brazzers.com \n\n   0.0.0.0 ads.bumq.com \n\n   0.0.0.0 ads.businessweek.com \n\n   0.0.0.0 ads.canalblog.com \n\n   0.0.0.0 ads.canoe.ca \n\n   0.0.0.0 ads.casinocity.com \n\n   0.0.0.0 ads.cbc.ca \n\n   0.0.0.0 ads.cc \n\n   0.0.0.0 ads.cc-dt.com \n\n   0.0.0.0 ads.centraliprom.com \n\n   0.0.0.0 ads.cgnetworks.com \n\n   0.0.0.0 ads.channel4.com \n\n   0.0.0.0 ads.cimedia.com \n\n   0.0.0.0 ads.clearchannel.com \n\n   0.0.0.0 ads.co.com \n\n   0.0.0.0 ads.com.com \n\n   0.0.0.0 ads.contactmusic.com \n\n   0.0.0.0 ads.contentabc.com \n\n   0.0.0.0 ads.contextweb.com \n\n   0.0.0.0 ads.crakmedia.com \n\n   0.0.0.0 ads.creative-serving.com \n\n   0.0.0.0 ads.creativematch.com \n\n   0.0.0.0 ads.cricbuzz.com \n\n   0.0.0.0 ads.cybersales.cz \n\n   0.0.0.0 ads.dada.it \n\n   0.0.0.0 ads.datinggold.com \n\n   0.0.0.0 ads.datingyes.com \n\n   0.0.0.0 ads.dazoot.ro \n\n   0.0.0.0 ads.deltha.hu \n\n   0.0.0.0 ads.dennisnet.co.uk \n\n   0.0.0.0 ads.desmoinesregister.com \n\n   0.0.0.0 ads.detelefoongids.nl \n\n   0.0.0.0 ads.deviantart.com \n\n   0.0.0.0 ads.digital-digest.com \n\n   0.0.0.0 ads.digitalmedianet.com \n\n   0.0.0.0 ads.digitalpoint.com \n\n   0.0.0.0 ads.directionsmag.com \n\n   0.0.0.0 ads.domeus.com \n\n   0.0.0.0 ads.eagletribune.com \n\n   0.0.0.0 ads.easy-forex.com \n\n   0.0.0.0 ads.eatinparis.com \n\n   0.0.0.0 ads.economist.com \n\n   0.0.0.0 ads.edbindex.dk \n\n   0.0.0.0 ads.egrana.com.br \n\n   0.0.0.0 ads.einmedia.com \n\n   0.0.0.0 ads.electrocelt.com \n\n   0.0.0.0 ads.elitetrader.com \n\n   0.0.0.0 ads.emirates.net.ae \n\n   0.0.0.0 ads.epltalk.com \n\n   0.0.0.0 ads.esmas.com \n\n   0.0.0.0 ads.eu.msn.com \n\n   0.0.0.0 ads.exactdrive.com \n\n   0.0.0.0 ads.expat-blog.biz \n\n   0.0.0.0 ads.expedia.com \n\n   0.0.0.0 ads.ezboard.com \n\n   0.0.0.0 ads.factorymedia.com \n\n   0.0.0.0 ads.fairfax.com.au \n\n   0.0.0.0 ads.faxo.com \n\n   0.0.0.0 ads.ferianc.com \n\n   0.0.0.0 ads.filmup.com \n\n   0.0.0.0 ads.financialcontent.com \n\n   0.0.0.0 ads.flooble.com \n\n   0.0.0.0 ads.fool.com \n\n   0.0.0.0 ads.footymad.net \n\n   0.0.0.0 ads.forbes.com \n\n   0.0.0.0 ads.forbes.net \n\n   0.0.0.0 ads.forium.de \n\n   0.0.0.0 ads.fortunecity.com \n\n   0.0.0.0 ads.fotosidan.se \n\n   0.0.0.0 ads.foxkidseurope.net \n\n   0.0.0.0 ads.foxnetworks.com \n\n   0.0.0.0 ads.foxnews.com \n\n   0.0.0.0 ads.freecity.de \n\n   0.0.0.0 ads.friendfinder.com \n\n   0.0.0.0 ads.ft.com \n\n   0.0.0.0 ads.futurenet.com \n\n   0.0.0.0 ads.gamecity.net \n\n   0.0.0.0 ads.gameforgeads.de \n\n   0.0.0.0 ads.gamershell.com \n\n   0.0.0.0 ads.gamespyid.com \n\n   0.0.0.0 ads.gamigo.de \n\n   0.0.0.0 ads.gaming-universe.de \n\n   0.0.0.0 ads.gawker.com \n\n   0.0.0.0 ads.geekswithblogs.net \n\n   0.0.0.0 ads.glispa.com \n\n   0.0.0.0 ads.globeandmail.com \n\n   0.0.0.0 ads.gmodules.com \n\n   0.0.0.0 ads.godlikeproductions.com \n\n   0.0.0.0 ads.goyk.com \n\n   0.0.0.0 ads.gplusmedia.com \n\n   0.0.0.0 ads.gradfinder.com \n\n   0.0.0.0 ads.grindinggears.com \n\n   0.0.0.0 ads.groundspeak.com \n\n   0.0.0.0 ads.gsm-exchange.com \n\n   0.0.0.0 ads.gsmexchange.com \n\n   0.0.0.0 ads.guardian.co.uk \n\n   0.0.0.0 ads.guardianunlimited.co.uk \n\n   0.0.0.0 ads.guru3d.com \n\n   0.0.0.0 ads.hardwaresecrets.com \n\n   0.0.0.0 ads.harpers.org \n\n   0.0.0.0 ads.hbv.de \n\n   0.0.0.0 ads.hearstmags.com \n\n   0.0.0.0 ads.heartlight.org \n\n   0.0.0.0 ads.heias.com \n\n   0.0.0.0 ads.hideyourarms.com \n\n   0.0.0.0 ads.hollywood.com \n\n   0.0.0.0 ads.horsehero.com \n\n   0.0.0.0 ads.horyzon-media.com \n\n   0.0.0.0 ads.iafrica.com \n\n   0.0.0.0 ads.ibest.com.br \n\n   0.0.0.0 ads.ibryte.com \n\n   0.0.0.0 ads.icq.com \n\n   0.0.0.0 ads.ign.com \n\n   0.0.0.0 ads.img.co.za \n\n   0.0.0.0 ads.imgur.com \n\n   0.0.0.0 ads.indiatimes.com \n\n   0.0.0.0 ads.infi.net \n\n   0.0.0.0 ads.internic.co.il \n\n   0.0.0.0 ads.ipowerweb.com \n\n   0.0.0.0 ads.isoftmarketing.com \n\n   0.0.0.0 ads.itv.com \n\n   0.0.0.0 ads.iwon.com \n\n   0.0.0.0 ads.jewishfriendfinder.com \n\n   0.0.0.0 ads.jiwire.com \n\n   0.0.0.0 ads.jobsite.co.uk \n\n   0.0.0.0 ads.jpost.com \n\n   0.0.0.0 ads.jubii.dk \n\n   0.0.0.0 ads.justhungry.com \n\n   0.0.0.0 ads.kaktuz.net \n\n   0.0.0.0 ads.kelbymediagroup.com \n\n   0.0.0.0 ads.kinobox.cz \n\n   0.0.0.0 ads.kinxxx.com \n\n   0.0.0.0 ads.kompass.com \n\n   0.0.0.0 ads.krawall.de \n\n   0.0.0.0 ads.lesbianpersonals.com \n\n   0.0.0.0 ads.linuxfoundation.org \n\n   0.0.0.0 ads.linuxjournal.com \n\n   0.0.0.0 ads.linuxsecurity.com \n\n   0.0.0.0 ads.livenation.com \n\n   0.0.0.0 ads.mariuana.it \n\n   0.0.0.0 ads.massinfra.nl \n\n   0.0.0.0 ads.mcafee.com \n\n   0.0.0.0 ads.mediaodyssey.com \n\n   0.0.0.0 ads.mediaturf.net \n\n   0.0.0.0 ads.medienhaus.de \n\n   0.0.0.0 ads.mgnetwork.com \n\n   0.0.0.0 ads.mmania.com \n\n   0.0.0.0 ads.moceanads.com \n\n   0.0.0.0 ads.motor-forum.nl \n\n   0.0.0.0 ads.motormedia.nl \n\n   0.0.0.0 ads.msn.com \n\n   0.0.0.0 ads.multimania.lycos.fr \n\n   0.0.0.0 ads.nationalgeographic.com \n\n   0.0.0.0 ads.ncm.com \n\n   0.0.0.0 ads.netclusive.de \n\n   0.0.0.0 ads.netmechanic.com \n\n   0.0.0.0 ads.networksolutions.com \n\n   0.0.0.0 ads.newdream.net \n\n   0.0.0.0 ads.newgrounds.com \n\n   0.0.0.0 ads.newmedia.cz \n\n   0.0.0.0 ads.newsint.co.uk \n\n   0.0.0.0 ads.newsquest.co.uk \n\n   0.0.0.0 ads.ninemsn.com.au \n\n   0.0.0.0 ads.nj.com \n\n   0.0.0.0 ads.nola.com \n\n   0.0.0.0 ads.nordichardware.com \n\n   0.0.0.0 ads.nordichardware.se \n\n   0.0.0.0 ads.nwsource.com \n\n   0.0.0.0 ads.nyi.net \n\n   0.0.0.0 ads.nytimes.com \n\n   0.0.0.0 ads.nyx.cz \n\n   0.0.0.0 ads.nzcity.co.nz \n\n   0.0.0.0 ads.o2.pl \n\n   0.0.0.0 ads.oddschecker.com \n\n   0.0.0.0 ads.okcimg.com \n\n   0.0.0.0 ads.ole.com \n\n   0.0.0.0 ads.olivebrandresponse.com \n\n   0.0.0.0 ads.oneplace.com \n\n   0.0.0.0 ads.ookla.com \n\n   0.0.0.0 ads.optusnet.com.au \n\n   0.0.0.0 ads.outpersonals.com \n\n   0.0.0.0 ads.passion.com \n\n   0.0.0.0 ads.pennet.com \n\n   0.0.0.0 ads.penny-arcade.com \n\n   0.0.0.0 ads.pheedo.com \n\n   0.0.0.0 ads.phpclasses.org \n\n   0.0.0.0 ads.pickmeup-ltd.com \n\n   0.0.0.0 ads.pkr.com \n\n   0.0.0.0 ads.planet.nl \n\n   0.0.0.0 ads.pni.com \n\n   0.0.0.0 ads.pof.com \n\n   0.0.0.0 ads.powweb.com \n\n   0.0.0.0 ads.primissima.it \n\n   0.0.0.0 ads.printscr.com \n\n   0.0.0.0 ads.prisacom.com \n\n   0.0.0.0 ads.program3.com \n\n   0.0.0.0 ads.psd2html.com \n\n   0.0.0.0 ads.pushplay.com \n\n   0.0.0.0 ads.quoka.de \n\n   0.0.0.0 ads.rcs.it \n\n   0.0.0.0 ads.recoletos.es \n\n   0.0.0.0 ads.rediff.com \n\n   0.0.0.0 ads.redlightcenter.com \n\n   0.0.0.0 ads.redtube.com \n\n   0.0.0.0 ads.resoom.de \n\n   0.0.0.0 ads.returnpath.net \n\n   0.0.0.0 ads.rpgdot.com \n\n   0.0.0.0 ads.s3.sitepoint.com \n\n   0.0.0.0 ads.satyamonline.com \n\n   0.0.0.0 ads.savannahnow.com \n\n   0.0.0.0 ads.saymedia.com \n\n   0.0.0.0 ads.scifi.com \n\n   0.0.0.0 ads.seniorfriendfinder.com \n\n   0.0.0.0 ads.sexinyourcity.com \n\n   0.0.0.0 ads.shizmoo.com \n\n   0.0.0.0 ads.shopstyle.com \n\n   0.0.0.0 ads.sift.co.uk \n\n   0.0.0.0 ads.silverdisc.co.uk \n\n   0.0.0.0 ads.slim.com \n\n   0.0.0.0 ads.smartclick.com \n\n   0.0.0.0 ads.soft32.com \n\n   0.0.0.0 ads.space.com \n\n   0.0.0.0 ads.sptimes.com \n\n   0.0.0.0 ads.stackoverflow.com \n\n   0.0.0.0 ads.stationplay.com \n\n   0.0.0.0 ads.sun.com \n\n   0.0.0.0 ads.supplyframe.com \n\n   0.0.0.0 ads.t-online.de \n\n   0.0.0.0 ads.tahono.com \n\n   0.0.0.0 ads.techtv.com \n\n   0.0.0.0 ads.techweb.com \n\n   0.0.0.0 ads.telegraph.co.uk \n\n   0.0.0.0 ads.theglobeandmail.com \n\n   0.0.0.0 ads.themovienation.com \n\n   0.0.0.0 ads.thestar.com \n\n   0.0.0.0 ads.timeout.com \n\n   0.0.0.0 ads.tmcs.net \n\n   0.0.0.0 ads.totallyfreestuff.com \n\n   0.0.0.0 ads.townhall.com \n\n   0.0.0.0 ads.trinitymirror.co.uk \n\n   0.0.0.0 ads.tripod.com \n\n   0.0.0.0 ads.tripod.lycos.co.uk \n\n   0.0.0.0 ads.tripod.lycos.de \n\n   0.0.0.0 ads.tripod.lycos.es \n\n   0.0.0.0 ads.tripod.lycos.it \n\n   0.0.0.0 ads.tripod.lycos.nl \n\n   0.0.0.0 ads.tripod.spray.se \n\n   0.0.0.0 ads.tso.dennisnet.co.uk \n\n   0.0.0.0 ads.uknetguide.co.uk \n\n   0.0.0.0 ads.ultimate-guitar.com \n\n   0.0.0.0 ads.uncrate.com \n\n   0.0.0.0 ads.undertone.com \n\n   0.0.0.0 ads.usatoday.com \n\n   0.0.0.0 ads.v3.com \n\n   0.0.0.0 ads.verticalresponse.com \n\n   0.0.0.0 ads.vgchartz.com \n\n   0.0.0.0 ads.videosz.com \n\n   0.0.0.0 ads.virtual-nights.com \n\n   0.0.0.0 ads.virtualcountries.com \n\n   0.0.0.0 ads.vnumedia.com \n\n   0.0.0.0 ads.waps.cn \n\n   0.0.0.0 ads.wapx.cn \n\n   0.0.0.0 ads.weather.ca \n\n   0.0.0.0 ads.web.aol.com \n\n   0.0.0.0 ads.web.cs.com \n\n   0.0.0.0 ads.web.de \n\n   0.0.0.0 ads.webmasterpoint.org \n\n   0.0.0.0 ads.websiteservices.com \n\n   0.0.0.0 ads.whi.co.nz \n\n   0.0.0.0 ads.whoishostingthis.com \n\n   0.0.0.0 ads.wiezoekje.nl \n\n   0.0.0.0 ads.wikia.nocookie.net \n\n   0.0.0.0 ads.wineenthusiast.com \n\n   0.0.0.0 ads.wunderground.com \n\n   0.0.0.0 ads.wwe.biz \n\n   0.0.0.0 ads.xhamster.com \n\n   0.0.0.0 ads.xtra.co.nz \n\n   0.0.0.0 ads.y-0.net \n\n   0.0.0.0 ads.yimg.com \n\n   0.0.0.0 ads.yldmgrimg.net \n\n   0.0.0.0 ads.yourfreedvds.com \n\n   0.0.0.0 ads.youtube.com \n\n   0.0.0.0 ads.zdnet.com \n\n   0.0.0.0 ads.ztod.com \n\n   0.0.0.0 ads03.redtube.com \n\n   0.0.0.0 ads1.canoe.ca \n\n   0.0.0.0 ads1.mediacapital.pt \n\n   0.0.0.0 ads1.msn.com \n\n   0.0.0.0 ads1.rne.com \n\n   0.0.0.0 ads1.theglobeandmail.com \n\n   0.0.0.0 ads1.virtual-nights.com \n\n   0.0.0.0 ads10.speedbit.com \n\n   0.0.0.0 ads180.com \n\n   0.0.0.0 ads2.brazzers.com \n\n   0.0.0.0 ads2.clearchannel.com \n\n   0.0.0.0 ads2.contentabc.com \n\n   0.0.0.0 ads2.gamecity.net \n\n   0.0.0.0 ads2.jubii.dk \n\n   0.0.0.0 ads2.net-communities.co.uk \n\n   0.0.0.0 ads2.oneplace.com \n\n   0.0.0.0 ads2.rne.com \n\n   0.0.0.0 ads2.virtual-nights.com \n\n   0.0.0.0 ads2.xnet.cz \n\n   0.0.0.0 ads2004.treiberupdate.de \n\n   0.0.0.0 ads3.contentabc.com \n\n   0.0.0.0 ads3.gamecity.net \n\n   0.0.0.0 ads3.virtual-nights.com \n\n   0.0.0.0 ads4.clearchannel.com \n\n   0.0.0.0 ads4.gamecity.net \n\n   0.0.0.0 ads4.virtual-nights.com \n\n   0.0.0.0 ads4homes.com \n\n   0.0.0.0 ads5.canoe.ca \n\n   0.0.0.0 ads5.virtual-nights.com \n\n   0.0.0.0 ads6.gamecity.net \n\n   0.0.0.0 ads7.gamecity.net \n\n   0.0.0.0 ads8.com \n\n   0.0.0.0 adsatt.abc.starwave.com \n\n   0.0.0.0 adsatt.abcnews.starwave.com \n\n   0.0.0.0 adsatt.espn.go.com \n\n   0.0.0.0 adsatt.espn.starwave.com \n\n   0.0.0.0 adsatt.go.starwave.com \n\n   0.0.0.0 adsby.bidtheatre.com \n\n   0.0.0.0 adscale.de \n\n   0.0.0.0 adscholar.com \n\n   0.0.0.0 adscience.nl \n\n   0.0.0.0 adscpm.com \n\n   0.0.0.0 adsdaq.com \n\n   0.0.0.0 adsdk.com \n\n   0.0.0.0 adsend.de \n\n   0.0.0.0 adserv.evo-x.de \n\n   0.0.0.0 adserv.gamezone.de \n\n   0.0.0.0 adserv.iafrica.com \n\n   0.0.0.0 adserv.qconline.com \n\n   0.0.0.0 adserve.ams.rhythmxchange.com \n\n   0.0.0.0 adserver-live.yoc.mobi \n\n   0.0.0.0 adserver.43plc.com \n\n   0.0.0.0 adserver.71i.de \n\n   0.0.0.0 adserver.adultfriendfinder.com \n\n   0.0.0.0 adserver.aidameter.com \n\n   0.0.0.0 adserver.aol.fr \n\n   0.0.0.0 adserver.beggarspromo.com \n\n   0.0.0.0 adserver.betandwin.de \n\n   0.0.0.0 adserver.bing.com \n\n   0.0.0.0 adserver.bizhat.com \n\n   0.0.0.0 adserver.break-even.it \n\n   0.0.0.0 adserver.cams.com \n\n   0.0.0.0 adserver.com \n\n   0.0.0.0 adserver.digitoday.com \n\n   0.0.0.0 adserver.dotcommedia.de \n\n   0.0.0.0 adserver.finditquick.com \n\n   0.0.0.0 adserver.flossiemediagroup.com \n\n   0.0.0.0 adserver.freecity.de \n\n   0.0.0.0 adserver.freenet.de \n\n   0.0.0.0 adserver.friendfinder.com \n\n   0.0.0.0 adserver.hardsextube.com \n\n   0.0.0.0 adserver.hardwareanalysis.com \n\n   0.0.0.0 adserver.html.it \n\n   0.0.0.0 adserver.irishwebmasterforum.com \n\n   0.0.0.0 adserver.janes.com \n\n   0.0.0.0 adserver.kyoceramita-europe.com \n\n   0.0.0.0 adserver.libero.it \n\n   0.0.0.0 adserver.news.com.au \n\n   0.0.0.0 adserver.ngz-network.de \n\n   0.0.0.0 adserver.nydailynews.com \n\n   0.0.0.0 adserver.o2.pl \n\n   0.0.0.0 adserver.oddschecker.com \n\n   0.0.0.0 adserver.omroepzeeland.nl \n\n   0.0.0.0 adserver.pl \n\n   0.0.0.0 adserver.portalofevil.com \n\n   0.0.0.0 adserver.portugalmail.net \n\n   0.0.0.0 adserver.portugalmail.pt \n\n   0.0.0.0 adserver.quizdingo.com \n\n   0.0.0.0 adserver.realhomesex.net \n\n   0.0.0.0 adserver.sanomawsoy.fi \n\n   0.0.0.0 adserver.sciflicks.com \n\n   0.0.0.0 adserver.sharewareonline.com \n\n   0.0.0.0 adserver.spankaway.com \n\n   0.0.0.0 adserver.startnow.com \n\n   0.0.0.0 adserver.theonering.net \n\n   0.0.0.0 adserver.twitpic.com \n\n   0.0.0.0 adserver.viagogo.com \n\n   0.0.0.0 adserver.virginmedia.com \n\n   0.0.0.0 adserver.yahoo.com \n\n   0.0.0.0 adserver01.de \n\n   0.0.0.0 adserver1-images.backbeatmedia.com \n\n   0.0.0.0 adserver1.backbeatmedia.com \n\n   0.0.0.0 adserver1.mindshare.de \n\n   0.0.0.0 adserver1.mokono.com \n\n   0.0.0.0 adserver1.ogilvy-interactive.de \n\n   0.0.0.0 adserver2.mindshare.de \n\n   0.0.0.0 adserver2.popdata.de \n\n   0.0.0.0 adserverplus.com \n\n   0.0.0.0 adserversolutions.com \n\n   0.0.0.0 adservinginternational.com \n\n   0.0.0.0 adsfac.eu \n\n   0.0.0.0 adsfac.net \n\n   0.0.0.0 adsfac.us \n\n   0.0.0.0 adshost1.com \n\n   0.0.0.0 adside.com \n\n   0.0.0.0 adsk2.co \n\n   0.0.0.0 adskape.ru \n\n   0.0.0.0 adsklick.de \n\n   0.0.0.0 adsmarket.com \n\n   0.0.0.0 adsmart.co.uk \n\n   0.0.0.0 adsmart.com \n\n   0.0.0.0 adsmart.net \n\n   0.0.0.0 adsmogo.com \n\n   0.0.0.0 adsnative.com \n\n   0.0.0.0 adsoftware.com \n\n   0.0.0.0 adsoldier.com \n\n   0.0.0.0 adsonar.com \n\n   0.0.0.0 adspace.ro \n\n   0.0.0.0 adspeed.net \n\n   0.0.0.0 adspirit.de \n\n   0.0.0.0 adsponse.de \n\n   0.0.0.0 adsremote.scrippsnetworks.com \n\n   0.0.0.0 adsrevenue.net \n\n   0.0.0.0 adsrv.deviantart.com \n\n   0.0.0.0 adsrv.eacdn.com \n\n   0.0.0.0 adsrv.iol.co.za \n\n   0.0.0.0 adsrvr.org \n\n   0.0.0.0 adsstat.com \n\n   0.0.0.0 adstat.4u.pl \n\n   0.0.0.0 adstest.weather.com \n\n   0.0.0.0 adsupply.com \n\n   0.0.0.0 adswitcher.com \n\n   0.0.0.0 adsymptotic.com \n\n   0.0.0.0 adsynergy.com \n\n   0.0.0.0 adsys.townnews.com \n\n   0.0.0.0 adsystem.simplemachines.org \n\n   0.0.0.0 adtech.de \n\n   0.0.0.0 adtechus.com \n\n   0.0.0.0 adtegrity.net \n\n   0.0.0.0 adthis.com \n\n   0.0.0.0 adtiger.de \n\n   0.0.0.0 adtoll.com \n\n   0.0.0.0 adtology.com \n\n   0.0.0.0 adtoma.com \n\n   0.0.0.0 adtrace.org \n\n   0.0.0.0 adtrade.net \n\n   0.0.0.0 adtrading.de \n\n   0.0.0.0 adtrak.net \n\n   0.0.0.0 adtriplex.com \n\n   0.0.0.0 adultadvertising.com \n\n   0.0.0.0 adv-adserver.com \n\n   0.0.0.0 adv-banner.libero.it \n\n   0.0.0.0 adv.cooperhosting.net \n\n   0.0.0.0 adv.freeonline.it \n\n   0.0.0.0 adv.hwupgrade.it \n\n   0.0.0.0 adv.livedoor.com \n\n   0.0.0.0 adv.webmd.com \n\n   0.0.0.0 adv.wp.pl \n\n   0.0.0.0 adv.yo.cz \n\n   0.0.0.0 advariant.com \n\n   0.0.0.0 adventory.com \n\n   0.0.0.0 advert.bayarea.com \n\n   0.0.0.0 advert.dyna.ultraweb.hu \n\n   0.0.0.0 adverticum.com \n\n   0.0.0.0 adverticum.net \n\n   0.0.0.0 adverticus.de \n\n   0.0.0.0 advertise.com \n\n   0.0.0.0 advertiseireland.com \n\n   0.0.0.0 advertisespace.com \n\n   0.0.0.0 advertising.com \n\n   0.0.0.0 advertising.guildlaunch.net \n\n   0.0.0.0 advertisingbanners.com \n\n   0.0.0.0 advertisingbox.com \n\n   0.0.0.0 advertmarket.com \n\n   0.0.0.0 advertmedia.de \n\n   0.0.0.0 advertpro.sitepoint.com \n\n   0.0.0.0 advertpro.ya.com \n\n   0.0.0.0 adverts.carltononline.com \n\n   0.0.0.0 advertserve.com \n\n   0.0.0.0 advertstream.com \n\n   0.0.0.0 advertwizard.com \n\n   0.0.0.0 advideo.uimserv.net \n\n   0.0.0.0 adview.ppro.de \n\n   0.0.0.0 advisormedia.cz \n\n   0.0.0.0 adviva.com \n\n   0.0.0.0 adviva.net \n\n   0.0.0.0 advnt.com \n\n   0.0.0.0 adwareremovergold.com \n\n   0.0.0.0 adwhirl.com \n\n   0.0.0.0 adwitserver.com \n\n   0.0.0.0 adworldnetwork.com \n\n   0.0.0.0 adworx.at \n\n   0.0.0.0 adworx.be \n\n   0.0.0.0 adworx.nl \n\n   0.0.0.0 adx.allstar.cz \n\n   0.0.0.0 adx.atnext.com \n\n   0.0.0.0 adxpansion.com \n\n   0.0.0.0 adxpose.com \n\n   0.0.0.0 adxvalue.com \n\n   0.0.0.0 adyea.com \n\n   0.0.0.0 adzerk.net \n\n   0.0.0.0 adzerk.s3.amazonaws.com \n\n   0.0.0.0 adzones.com \n\n   0.0.0.0 af-ad.co.uk \n\n   0.0.0.0 affbuzzads.com \n\n   0.0.0.0 affili.net \n\n   0.0.0.0 affiliate.1800flowers.com \n\n   0.0.0.0 affiliate.7host.com \n\n   0.0.0.0 affiliate.doubleyourdating.com \n\n   0.0.0.0 affiliate.dtiserv.com \n\n   0.0.0.0 affiliate.gamestop.com \n\n   0.0.0.0 affiliate.mercola.com \n\n   0.0.0.0 affiliate.mogs.com \n\n   0.0.0.0 affiliate.offgamers.com \n\n   0.0.0.0 affiliate.travelnow.com \n\n   0.0.0.0 affiliate.viator.com \n\n   0.0.0.0 affiliatefuel.com \n\n   0.0.0.0 affiliatefuture.com \n\n   0.0.0.0 affiliates.allposters.com \n\n   0.0.0.0 affiliates.babylon.com \n\n   0.0.0.0 affiliates.devilfishpartners.com \n\n   0.0.0.0 affiliates.digitalriver.com \n\n   0.0.0.0 affiliates.globat.com \n\n   0.0.0.0 affiliates.ige.com \n\n   0.0.0.0 affiliates.internationaljock.com \n\n   0.0.0.0 affiliates.streamray.com \n\n   0.0.0.0 affiliates.thinkhost.net \n\n   0.0.0.0 affiliates.thrixxx.com \n\n   0.0.0.0 affiliates.ultrahosting.com \n\n   0.0.0.0 affiliatetracking.com \n\n   0.0.0.0 affiliatetracking.net \n\n   0.0.0.0 affiliatewindow.com \n\n   0.0.0.0 affiliation-france.com \n\n   0.0.0.0 afftracking.justanswer.com \n\n   0.0.0.0 ah-ha.com \n\n   0.0.0.0 ahalogy.com \n\n   0.0.0.0 aidu-ads.de \n\n   0.0.0.0 aim4media.com \n\n   0.0.0.0 aistat.net \n\n   0.0.0.0 aktrack.pubmatic.com \n\n   0.0.0.0 alclick.com \n\n   0.0.0.0 alenty.com \n\n   0.0.0.0 alexa-sitestats.s3.amazonaws.com \n\n   0.0.0.0 all4spy.com \n\n   0.0.0.0 alladvantage.com \n\n   0.0.0.0 allosponsor.com \n\n   0.0.0.0 amazingcounters.com \n\n   0.0.0.0 amazon-adsystem.com \n\n   0.0.0.0 amung.us \n\n   0.0.0.0 an.tacoda.net \n\n   0.0.0.0 anahtars.com \n\n   0.0.0.0 analytics.adpost.org \n\n   0.0.0.0 analytics.google.com \n\n   0.0.0.0 analytics.live.com \n\n   0.0.0.0 analytics.yahoo.com \n\n   0.0.0.0 anm.intelli-direct.com \n\n   0.0.0.0 annonser.dagbladet.no \n\n   0.0.0.0 apex-ad.com \n\n   0.0.0.0 api.intensifier.de \n\n   0.0.0.0 apture.com \n\n   0.0.0.0 arc1.msn.com \n\n   0.0.0.0 arcadebanners.com \n\n   0.0.0.0 ard.xxxblackbook.com \n\n   0.0.0.0 are-ter.com \n\n   0.0.0.0 as.webmd.com \n\n   0.0.0.0 as1.advfn.com \n\n   0.0.0.0 as2.advfn.com \n\n   0.0.0.0 assets1.exgfnetwork.com \n\n   0.0.0.0 assoc-amazon.com \n\n   0.0.0.0 at-adserver.alltop.com \n\n   0.0.0.0 atdmt.com \n\n   0.0.0.0 athena-ads.wikia.com \n\n   0.0.0.0 atwola.com \n\n   0.0.0.0 auctionads.com \n\n   0.0.0.0 auctionads.net \n\n   0.0.0.0 audience2media.com \n\n   0.0.0.0 audit.median.hu \n\n   0.0.0.0 audit.webinform.hu \n\n   0.0.0.0 auto-bannertausch.de \n\n   0.0.0.0 autohits.dk \n\n   0.0.0.0 avenuea.com \n\n   0.0.0.0 avpa.javalobby.org \n\n   0.0.0.0 avres.net \n\n   0.0.0.0 avsads.com \n\n   0.0.0.0 awempire.com \n\n   0.0.0.0 awin1.com \n\n   0.0.0.0 aylarl.com \n\n   0.0.0.0 azfront.com \n\n   0.0.0.0 b-1st.com \n\n   0.0.0.0 b.aol.com \n\n   0.0.0.0 b.engadget.com \n\n   0.0.0.0 ba.afl.rakuten.co.jp \n\n   0.0.0.0 babs.tv2.dk \n\n   0.0.0.0 backbeatmedia.com \n\n   0.0.0.0 banik.redigy.cz \n\n   0.0.0.0 banner-exchange-24.de \n\n   0.0.0.0 banner.ad.nu \n\n   0.0.0.0 banner.ambercoastcasino.com \n\n   0.0.0.0 banner.blogranking.net \n\n   0.0.0.0 banner.buempliz-online.ch \n\n   0.0.0.0 banner.casino.net \n\n   0.0.0.0 banner.casinodelrio.com \n\n   0.0.0.0 banner.cotedazurpalace.com \n\n   0.0.0.0 banner.coza.com \n\n   0.0.0.0 banner.cz \n\n   0.0.0.0 banner.easyspace.com \n\n   0.0.0.0 banner.elisa.net \n\n   0.0.0.0 banner.eurogrand.com \n\n   0.0.0.0 banner.featuredusers.com \n\n   0.0.0.0 banner.getgo.de \n\n   0.0.0.0 banner.goldenpalace.com \n\n   0.0.0.0 banner.img.co.za \n\n   0.0.0.0 banner.inyourpocket.com \n\n   0.0.0.0 banner.jobsahead.com \n\n   0.0.0.0 banner.joylandcasino.com \n\n   0.0.0.0 banner.kiev.ua \n\n   0.0.0.0 banner.linux.se \n\n   0.0.0.0 banner.media-system.de \n\n   0.0.0.0 banner.mindshare.de \n\n   0.0.0.0 banner.nixnet.cz \n\n   0.0.0.0 banner.noblepoker.com \n\n   0.0.0.0 banner.northsky.com \n\n   0.0.0.0 banner.orb.net \n\n   0.0.0.0 banner.penguin.cz \n\n   0.0.0.0 banner.prestigecasino.com \n\n   0.0.0.0 banner.rbc.ru \n\n   0.0.0.0 banner.relcom.ru \n\n   0.0.0.0 banner.tanto.de \n\n   0.0.0.0 banner.titan-dsl.de \n\n   0.0.0.0 banner.vadian.net \n\n   0.0.0.0 banner.webmersion.com \n\n   0.0.0.0 banner.wirenode.com \n\n   0.0.0.0 bannerads.de \n\n   0.0.0.0 bannerboxes.com \n\n   0.0.0.0 bannercommunity.de \n\n   0.0.0.0 bannerconnect.com \n\n   0.0.0.0 bannerconnect.net \n\n   0.0.0.0 bannerexchange.cjb.net \n\n   0.0.0.0 bannerflow.com \n\n   0.0.0.0 bannergrabber.internet.gr \n\n   0.0.0.0 bannerhost.com \n\n   0.0.0.0 bannerimage.com \n\n   0.0.0.0 bannerlandia.com.ar \n\n   0.0.0.0 bannermall.com \n\n   0.0.0.0 bannermarkt.nl \n\n   0.0.0.0 bannerpower.com \n\n   0.0.0.0 banners.adultfriendfinder.com \n\n   0.0.0.0 banners.amigos.com \n\n   0.0.0.0 banners.apnuk.com \n\n   0.0.0.0 banners.asiafriendfinder.com \n\n   0.0.0.0 banners.audioholics.com \n\n   0.0.0.0 banners.babylon-x.com \n\n   0.0.0.0 banners.bol.com.br \n\n   0.0.0.0 banners.cams.com \n\n   0.0.0.0 banners.clubseventeen.com \n\n   0.0.0.0 banners.czi.cz \n\n   0.0.0.0 banners.dine.com \n\n   0.0.0.0 banners.direction-x.com \n\n   0.0.0.0 banners.directnic.com \n\n   0.0.0.0 banners.easydns.com \n\n   0.0.0.0 banners.ebay.com \n\n   0.0.0.0 banners.freett.com \n\n   0.0.0.0 banners.friendfinder.com \n\n   0.0.0.0 banners.getiton.com \n\n   0.0.0.0 banners.iq.pl \n\n   0.0.0.0 banners.isoftmarketing.com \n\n   0.0.0.0 banners.lifeserv.com \n\n   0.0.0.0 banners.linkbuddies.com \n\n   0.0.0.0 banners.passion.com \n\n   0.0.0.0 banners.resultonline.com \n\n   0.0.0.0 banners.sexsearch.com \n\n   0.0.0.0 banners.sys-con.com \n\n   0.0.0.0 banners.thomsonlocal.com \n\n   0.0.0.0 banners.videosz.com \n\n   0.0.0.0 banners.virtuagirlhd.com \n\n   0.0.0.0 banners.wunderground.com \n\n   0.0.0.0 bannerserver.com \n\n   0.0.0.0 bannersgomlm.com \n\n   0.0.0.0 bannershotlink.perfectgonzo.com \n\n   0.0.0.0 bannersng.yell.com \n\n   0.0.0.0 bannerspace.com \n\n   0.0.0.0 bannerswap.com \n\n   0.0.0.0 bannertesting.com \n\n   0.0.0.0 bannery.cz \n\n   0.0.0.0 bannieres.acces-contenu.com \n\n   0.0.0.0 bans.adserver.co.il \n\n   0.0.0.0 bans.bride.ru \n\n   0.0.0.0 barnesandnoble.bfast.com \n\n   0.0.0.0 baypops.com \n\n   0.0.0.0 bbelements.com \n\n   0.0.0.0 bbn.img.com.ua \n\n   0.0.0.0 begun.ru \n\n   0.0.0.0 belstat.com \n\n   0.0.0.0 belstat.nl \n\n   0.0.0.0 berp.com \n\n   0.0.0.0 best-pr.info \n\n   0.0.0.0 best-top.ro \n\n   0.0.0.0 bestsearch.net \n\n   0.0.0.0 bhclicks.com \n\n   0.0.0.0 bidclix.com \n\n   0.0.0.0 bidclix.net \n\n   0.0.0.0 bidtrk.com \n\n   0.0.0.0 bidvertiser.com \n\n   0.0.0.0 bigads.guj.de \n\n   0.0.0.0 bigbangmedia.com \n\n   0.0.0.0 bigclicks.com \n\n   0.0.0.0 billboard.cz \n\n   0.0.0.0 bitads.net \n\n   0.0.0.0 bitmedianetwork.com \n\n   0.0.0.0 bizad.nikkeibp.co.jp \n\n   0.0.0.0 bizrate.com \n\n   0.0.0.0 blast4traffic.com \n\n   0.0.0.0 blingbucks.com \n\n   0.0.0.0 blogads.com \n\n   0.0.0.0 blogcounter.de \n\n   0.0.0.0 blogherads.com \n\n   0.0.0.0 blogrush.com \n\n   0.0.0.0 blogtoplist.se \n\n   0.0.0.0 blogtopsites.com \n\n   0.0.0.0 blueadvertise.com \n\n   0.0.0.0 bluekai.com \n\n   0.0.0.0 bluelithium.com \n\n   0.0.0.0 bluewhaleweb.com \n\n   0.0.0.0 bm.annonce.cz \n\n   0.0.0.0 bn.bfast.com \n\n   0.0.0.0 boersego-ads.de \n\n   0.0.0.0 boldchat.com \n\n   0.0.0.0 boom.ro \n\n   0.0.0.0 boomads.com \n\n   0.0.0.0 boost-my-pr.de \n\n   0.0.0.0 box.anchorfree.net \n\n   0.0.0.0 bpath.com \n\n   0.0.0.0 braincash.com \n\n   0.0.0.0 brandreachsys.com \n\n   0.0.0.0 bravenet.com.invalid \n\n   0.0.0.0 bridgetrack.com \n\n   0.0.0.0 brightinfo.com \n\n   0.0.0.0 british-banners.com \n\n   0.0.0.0 bs.yandex.ru \n\n   0.0.0.0 budsinc.com \n\n   0.0.0.0 bullseye.backbeatmedia.com \n\n   0.0.0.0 buyhitscheap.com \n\n   0.0.0.0 buysellads.com \n\n   0.0.0.0 buzzonclick.com \n\n   0.0.0.0 bvalphaserver.com \n\n   0.0.0.0 bwp.download.com \n\n   0.0.0.0 c.bigmir.net \n\n   0.0.0.0 c.compete.com \n\n   0.0.0.0 c1.nowlinux.com \n\n   0.0.0.0 campaign.bharatmatrimony.com \n\n   0.0.0.0 caniamedia.com \n\n   0.0.0.0 carbonads.com \n\n   0.0.0.0 carbonads.net \n\n   0.0.0.0 casalemedia.com \n\n   0.0.0.0 casalmedia.com \n\n   0.0.0.0 cash4members.com \n\n   0.0.0.0 cash4popup.de \n\n   0.0.0.0 cashcrate.com \n\n   0.0.0.0 cashengines.com \n\n   0.0.0.0 cashfiesta.com \n\n   0.0.0.0 cashlayer.com \n\n   0.0.0.0 cashpartner.com \n\n   0.0.0.0 casinogames.com \n\n   0.0.0.0 casinopays.com \n\n   0.0.0.0 casinorewards.com \n\n   0.0.0.0 casinotraffic.com \n\n   0.0.0.0 casinotreasure.com \n\n   0.0.0.0 cbanners.virtuagirlhd.com \n\n   0.0.0.0 cben1.net \n\n   0.0.0.0 cbmall.com \n\n   0.0.0.0 cbx.net \n\n   0.0.0.0 cdn.freefacti.com \n\n   0.0.0.0 cecash.com \n\n   0.0.0.0 ceskydomov.alias.ngs.modry.cz \n\n   0.0.0.0 cetrk.com \n\n   0.0.0.0 cgicounter.puretec.de \n\n   0.0.0.0 ch.questionmarket.com \n\n   0.0.0.0 channelintelligence.com \n\n   0.0.0.0 chart.dk \n\n   0.0.0.0 chartbeat.com \n\n   0.0.0.0 chartbeat.net \n\n   0.0.0.0 checkm8.com \n\n   0.0.0.0 checkstat.nl \n\n   0.0.0.0 chestionar.ro \n\n   0.0.0.0 chitika.net \n\n   0.0.0.0 cibleclick.com \n\n   0.0.0.0 cityads.telus.net \n\n   0.0.0.0 cj.com \n\n   0.0.0.0 cjbmanagement.com \n\n   0.0.0.0 cjlog.com \n\n   0.0.0.0 claria.com \n\n   0.0.0.0 class-act-clicks.com \n\n   0.0.0.0 click.absoluteagency.com \n\n   0.0.0.0 click.fool.com \n\n   0.0.0.0 click.kmindex.ru \n\n   0.0.0.0 click2freemoney.com \n\n   0.0.0.0 click2paid.com \n\n   0.0.0.0 clickability.com \n\n   0.0.0.0 clickadz.com \n\n   0.0.0.0 clickagents.com \n\n   0.0.0.0 clickbank.com \n\n   0.0.0.0 clickbank.net \n\n   0.0.0.0 clickbooth.com \n\n   0.0.0.0 clickboothlnk.com \n\n   0.0.0.0 clickbrokers.com \n\n   0.0.0.0 clickcompare.co.uk \n\n   0.0.0.0 clickdensity.com \n\n   0.0.0.0 clickedyclick.com \n\n   0.0.0.0 clickhereforcellphones.com \n\n   0.0.0.0 clickhouse.com \n\n   0.0.0.0 clickhype.com \n\n   0.0.0.0 clicklink.jp \n\n   0.0.0.0 clickmedia.ro \n\n   0.0.0.0 clicks.equantum.com \n\n   0.0.0.0 clicks.mods.de \n\n   0.0.0.0 clickserve.cc-dt.com \n\n   0.0.0.0 clicksor.com \n\n   0.0.0.0 clicktag.de \n\n   0.0.0.0 clickthrucash.com \n\n   0.0.0.0 clickthruserver.com \n\n   0.0.0.0 clickthrutraffic.com \n\n   0.0.0.0 clicktrace.info \n\n   0.0.0.0 clicktrack.ziyu.net \n\n   0.0.0.0 clicktracks.com \n\n   0.0.0.0 clicktrade.com \n\n   0.0.0.0 clickxchange.com \n\n   0.0.0.0 clickz.com \n\n   0.0.0.0 clickzxc.com \n\n   0.0.0.0 clicmanager.fr \n\n   0.0.0.0 clients.tbo.com \n\n   0.0.0.0 clixgalore.com \n\n   0.0.0.0 clkads.com \n\n   0.0.0.0 clkrev.com \n\n   0.0.0.0 cluster.adultworld.com \n\n   0.0.0.0 clustrmaps.com \n\n   0.0.0.0 cmpstar.com \n\n   0.0.0.0 cnomy.com \n\n   0.0.0.0 cnt.spbland.ru \n\n   0.0.0.0 cnt1.pocitadlo.cz \n\n   0.0.0.0 code-server.biz \n\n   0.0.0.0 colonize.com \n\n   0.0.0.0 comclick.com \n\n   0.0.0.0 commindo-media-ressourcen.de \n\n   0.0.0.0 commissionmonster.com \n\n   0.0.0.0 compactbanner.com \n\n   0.0.0.0 comprabanner.it \n\n   0.0.0.0 confirmed-profits.com \n\n   0.0.0.0 connextra.com \n\n   0.0.0.0 contaxe.de \n\n   0.0.0.0 content.acc-hd.de \n\n   0.0.0.0 content.ad \n\n   0.0.0.0 contextweb.com \n\n   0.0.0.0 conversantmedia.com \n\n   0.0.0.0 conversionruler.com \n\n   0.0.0.0 cookies.cmpnet.com \n\n   0.0.0.0 coremetrics.com \n\n   0.0.0.0 count.rbc.ru \n\n   0.0.0.0 count.rin.ru \n\n   0.0.0.0 count.west263.com \n\n   0.0.0.0 counted.com \n\n   0.0.0.0 counter.bloke.com \n\n   0.0.0.0 counter.cnw.cz \n\n   0.0.0.0 counter.cz \n\n   0.0.0.0 counter.dreamhost.com \n\n   0.0.0.0 counter.fateback.com \n\n   0.0.0.0 counter.mirohost.net \n\n   0.0.0.0 counter.mojgorod.ru \n\n   0.0.0.0 counter.nowlinux.com \n\n   0.0.0.0 counter.rambler.ru \n\n   0.0.0.0 counter.search.bg \n\n   0.0.0.0 counter.sparklit.com \n\n   0.0.0.0 counter.yadro.ru \n\n   0.0.0.0 counters.honesty.com \n\n   0.0.0.0 counting.kmindex.ru \n\n   0.0.0.0 counts.tucows.com \n\n   0.0.0.0 coupling-media.de \n\n   0.0.0.0 cpalead.com \n\n   0.0.0.0 cpays.com \n\n   0.0.0.0 cpmaffiliation.com \n\n   0.0.0.0 cpmstar.com \n\n   0.0.0.0 cpxadroit.com \n\n   0.0.0.0 cpxinteractive.com \n\n   0.0.0.0 cqcounter.com \n\n   0.0.0.0 crakmedia.com \n\n   0.0.0.0 craktraffic.com \n\n   0.0.0.0 crawlability.com \n\n   0.0.0.0 crazypopups.com \n\n   0.0.0.0 creafi-online-media.com \n\n   0.0.0.0 creative.ak.facebook.com \n\n   0.0.0.0 creative.whi.co.nz \n\n   0.0.0.0 creatives.as4x.tmcs.net \n\n   0.0.0.0 creatives.livejasmin.com \n\n   0.0.0.0 crispads.com \n\n   0.0.0.0 criteo.com \n\n   0.0.0.0 crowdgravity.com \n\n   0.0.0.0 crtv.mate1.com \n\n   0.0.0.0 crwdcntrl.net \n\n   0.0.0.0 ctnetwork.hu \n\n   0.0.0.0 cubics.com \n\n   0.0.0.0 customad.cnn.com \n\n   0.0.0.0 cyberbounty.com \n\n   0.0.0.0 cybermonitor.com \n\n   0.0.0.0 d.adroll.com \n\n   0.0.0.0 dakic-ia-300.com \n\n   0.0.0.0 danban.com \n\n   0.0.0.0 dapper.net \n\n   0.0.0.0 datashreddergold.com \n\n   0.0.0.0 dbbsrv.com \n\n   0.0.0.0 dc-storm.com \n\n   0.0.0.0 de17a.com \n\n   0.0.0.0 dealdotcom.com \n\n   0.0.0.0 debtbusterloans.com \n\n   0.0.0.0 decknetwork.net \n\n   0.0.0.0 deloo.de \n\n   0.0.0.0 demandbase.com \n\n   0.0.0.0 di1.shopping.com \n\n   0.0.0.0 dialerporn.com \n\n   0.0.0.0 didtheyreadit.com \n\n   0.0.0.0 direct-xxx-access.com \n\n   0.0.0.0 directaclick.com \n\n   0.0.0.0 directivepub.com \n\n   0.0.0.0 directleads.com \n\n   0.0.0.0 directorym.com \n\n   0.0.0.0 directtrack.com \n\n   0.0.0.0 discountclick.com \n\n   0.0.0.0 displayadsmedia.com \n\n   0.0.0.0 displaypagerank.com \n\n   0.0.0.0 dist.belnk.com \n\n   0.0.0.0 dmtracker.com \n\n   0.0.0.0 dmtracking.alibaba.com \n\n   0.0.0.0 dmtracking2.alibaba.com \n\n   0.0.0.0 dnads.directnic.com \n\n   0.0.0.0 domaining.in \n\n   0.0.0.0 domainsponsor.com \n\n   0.0.0.0 domainsteam.de \n\n   0.0.0.0 doubleclick.com \n\n   0.0.0.0 doubleclick.de \n\n   0.0.0.0 doubleclick.net \n\n   0.0.0.0 doublepimp.com \n\n   0.0.0.0 drumcash.com \n\n   0.0.0.0 dynamic.fmpub.net \n\n   0.0.0.0 e-adimages.scrippsnetworks.com \n\n   0.0.0.0 e-bannerx.com \n\n   0.0.0.0 e-debtconsolidation.com \n\n   0.0.0.0 e-m.fr \n\n   0.0.0.0 e-n-t-e-r-n-e-x.com \n\n   0.0.0.0 e-planning.net \n\n   0.0.0.0 e.kde.cz \n\n   0.0.0.0 eadexchange.com \n\n   0.0.0.0 eas.almamedia.fi \n\n   0.0.0.0 easyhits4u.com \n\n   0.0.0.0 ebayadvertising.com \n\n   0.0.0.0 ebocornac.com \n\n   0.0.0.0 ebuzzing.com \n\n   0.0.0.0 ecircle-ag.com \n\n   0.0.0.0 eclick.vn \n\n   0.0.0.0 ecoupons.com \n\n   0.0.0.0 edgeio.com \n\n   0.0.0.0 effectivemeasure.com \n\n   0.0.0.0 effectivemeasure.net \n\n   0.0.0.0 eiv.baidu.com \n\n   0.0.0.0 elitedollars.com \n\n   0.0.0.0 elitetoplist.com \n\n   0.0.0.0 emarketer.com \n\n   0.0.0.0 emediate.dk \n\n   0.0.0.0 emediate.eu \n\n   0.0.0.0 engine.espace.netavenir.com \n\n   0.0.0.0 enginenetwork.com \n\n   0.0.0.0 enoratraffic.com \n\n   0.0.0.0 enquisite.com \n\n   0.0.0.0 entercasino.com \n\n   0.0.0.0 entrecard.s3.amazonaws.com \n\n   0.0.0.0 epiccash.com \n\n   0.0.0.0 eqads.com \n\n   0.0.0.0 ero-advertising.com \n\n   0.0.0.0 esellerate.net \n\n   0.0.0.0 estat.com \n\n   0.0.0.0 etahub.com \n\n   0.0.0.0 etargetnet.com \n\n   0.0.0.0 etracker.de \n\n   0.0.0.0 eu-adcenter.net \n\n   0.0.0.0 eu1.madsone.com \n\n   0.0.0.0 eur.a1.yimg.com \n\n   0.0.0.0 eurekster.com \n\n   0.0.0.0 euro-linkindex.de \n\n   0.0.0.0 euroclick.com \n\n   0.0.0.0 euros4click.de \n\n   0.0.0.0 eusta.de \n\n   0.0.0.0 evergage.com \n\n   0.0.0.0 evidencecleanergold.com \n\n   0.0.0.0 ewebcounter.com \n\n   0.0.0.0 exchange-it.com \n\n   0.0.0.0 exchange.bg \n\n   0.0.0.0 exchangead.com \n\n   0.0.0.0 exchangeclicksonline.com \n\n   0.0.0.0 exit76.com \n\n   0.0.0.0 exitexchange.com \n\n   0.0.0.0 exitfuel.com \n\n   0.0.0.0 reimageplus.com \n\n   0.0.0.0 exoclick.com \n\n   0.0.0.0 trackpprofile.com \n\n   0.0.0.0 p.promocionesparati.com \n\n   0.0.0.0 exogripper.com \n\n   0.0.0.0 experteerads.com \n\n   0.0.0.0 exponential.com \n\n   0.0.0.0 express-submit.de \n\n   0.0.0.0 extractorandburner.com \n\n   0.0.0.0 extreme-dm.com \n\n   0.0.0.0 extremetracking.com \n\n   0.0.0.0 eyeblaster.com \n\n   0.0.0.0 eyereturn.com \n\n   0.0.0.0 eyeviewads.com \n\n   0.0.0.0 eyewonder.com \n\n   0.0.0.0 ezula.com \n\n   0.0.0.0 f5biz.com \n\n   0.0.0.0 fast-adv.it \n\n   0.0.0.0 fastclick.com \n\n   0.0.0.0 fastclick.com.edgesuite.net \n\n   0.0.0.0 fastclick.net \n\n   0.0.0.0 fb-promotions.com \n\n   0.0.0.0 fc.webmasterpro.de \n\n   0.0.0.0 feedbackresearch.com \n\n   0.0.0.0 feedjit.com \n\n   0.0.0.0 ffxcam.fairfax.com.au \n\n   0.0.0.0 fimc.net \n\n   0.0.0.0 fimserve.com \n\n   0.0.0.0 findcommerce.com \n\n   0.0.0.0 findyourcasino.com \n\n   0.0.0.0 fineclicks.com \n\n   0.0.0.0 first.nova.cz \n\n   0.0.0.0 firstlightera.com \n\n   0.0.0.0 flashtalking.com \n\n   0.0.0.0 fleshlightcash.com \n\n   0.0.0.0 flexbanner.com \n\n   0.0.0.0 flowgo.com \n\n   0.0.0.0 flurry.com \n\n   0.0.0.0 fonecta.leiki.com \n\n   0.0.0.0 foo.cosmocode.de \n\n   0.0.0.0 forex-affiliate.net \n\n   0.0.0.0 fpctraffic.com \n\n   0.0.0.0 fpctraffic2.com \n\n   0.0.0.0 fragmentserv.iac-online.de \n\n   0.0.0.0 free-banners.com \n\n   0.0.0.0 freebanner.com \n\n   0.0.0.0 freelogs.com \n\n   0.0.0.0 freeonlineusers.com \n\n   0.0.0.0 freepay.com \n\n   0.0.0.0 freestats.com \n\n   0.0.0.0 freestats.tv \n\n   0.0.0.0 freewebcounter.com \n\n   0.0.0.0 funklicks.com \n\n   0.0.0.0 funpageexchange.com \n\n   0.0.0.0 fusionads.net \n\n   0.0.0.0 fusionquest.com \n\n   0.0.0.0 fxclix.com \n\n   0.0.0.0 fxstyle.net \n\n   0.0.0.0 galaxien.com \n\n   0.0.0.0 game-advertising-online.com \n\n   0.0.0.0 gamehouse.com \n\n   0.0.0.0 gamesites100.net \n\n   0.0.0.0 gamesites200.com \n\n   0.0.0.0 gamesitestop100.com \n\n   0.0.0.0 gator.com \n\n   0.0.0.0 gbanners.hornymatches.com \n\n   0.0.0.0 gemius.pl \n\n   0.0.0.0 geo.digitalpoint.com \n\n   0.0.0.0 geobanner.adultfriendfinder.com \n\n   0.0.0.0 geovisite.com \n\n   0.0.0.0 getclicky.com \n\n   0.0.0.0 globalismedia.com \n\n   0.0.0.0 globaltakeoff.net \n\n   0.0.0.0 globaltrack.com \n\n   0.0.0.0 globe7.com \n\n   0.0.0.0 globus-inter.com \n\n   0.0.0.0 gmads.net \n\n   0.0.0.0 go-clicks.de \n\n   0.0.0.0 go-rank.de \n\n   0.0.0.0 goingplatinum.com \n\n   0.0.0.0 gold.weborama.fr \n\n   0.0.0.0 goldstats.com \n\n   0.0.0.0 google-analytics.com \n\n   0.0.0.0 googleadservices.com \n\n   0.0.0.0 googlesyndication.com \n\n   0.0.0.0 gostats.com \n\n   0.0.0.0 gp.dejanews.com \n\n   0.0.0.0 gpr.hu \n\n   0.0.0.0 grafstat.ro \n\n   0.0.0.0 grapeshot.co.uk \n\n   0.0.0.0 greystripe.com \n\n   0.0.0.0 gtop.ro \n\n   0.0.0.0 gtop100.com \n\n   0.0.0.0 harrenmedia.com \n\n   0.0.0.0 harrenmedianetwork.com \n\n   0.0.0.0 havamedia.net \n\n   0.0.0.0 heias.com \n\n   0.0.0.0 hentaicounter.com \n\n   0.0.0.0 herbalaffiliateprogram.com \n\n   0.0.0.0 hexusads.fluent.ltd.uk \n\n   0.0.0.0 heyos.com \n\n   0.0.0.0 hgads.com \n\n   0.0.0.0 hidden.gogoceleb.com \n\n   0.0.0.0 hightrafficads.com \n\n   0.0.0.0 histats.com \n\n   0.0.0.0 hit-parade.com \n\n   0.0.0.0 hit.bg \n\n   0.0.0.0 hit.ua \n\n   0.0.0.0 hit.webcentre.lycos.co.uk \n\n   0.0.0.0 hitbox.com \n\n   0.0.0.0 hitcents.com \n\n   0.0.0.0 hitexchange.net \n\n   0.0.0.0 hitfarm.com \n\n   0.0.0.0 hitiz.com \n\n   0.0.0.0 hitlist.ru \n\n   0.0.0.0 hitlounge.com \n\n   0.0.0.0 hitometer.com \n\n   0.0.0.0 hits.europuls.eu \n\n   0.0.0.0 hits.informer.com \n\n   0.0.0.0 hits.puls.lv \n\n   0.0.0.0 hits.theguardian.com \n\n   0.0.0.0 hits4me.com \n\n   0.0.0.0 hits4pay.com \n\n   0.0.0.0 hitslink.com \n\n   0.0.0.0 hittail.com \n\n   0.0.0.0 hollandbusinessadvertising.nl \n\n   0.0.0.0 homepageking.de \n\n   0.0.0.0 hostedads.realitykings.com \n\n   0.0.0.0 hotkeys.com \n\n   0.0.0.0 hotlog.ru \n\n   0.0.0.0 hotrank.com.tw \n\n   0.0.0.0 htmlhubing.xyz \n\n   0.0.0.0 httpool.com \n\n   0.0.0.0 hurricanedigitalmedia.com \n\n   0.0.0.0 hydramedia.com \n\n   0.0.0.0 hyperbanner.net \n\n   0.0.0.0 hypertracker.com \n\n   0.0.0.0 i-clicks.net \n\n   0.0.0.0 i.xx.openx.com \n\n   0.0.0.0 i1img.com \n\n   0.0.0.0 i1media.no \n\n   0.0.0.0 ia.iinfo.cz \n\n   0.0.0.0 iad.anm.co.uk \n\n   0.0.0.0 iadnet.com \n\n   0.0.0.0 iasds01.com \n\n   0.0.0.0 iconadserver.com \n\n   0.0.0.0 icptrack.com \n\n   0.0.0.0 idcounter.com \n\n   0.0.0.0 identads.com \n\n   0.0.0.0 idot.cz \n\n   0.0.0.0 idregie.com \n\n   0.0.0.0 idtargeting.com \n\n   0.0.0.0 ientrymail.com \n\n   0.0.0.0 iesnare.com \n\n   0.0.0.0 ifa.tube8live.com \n\n   0.0.0.0 ilbanner.com \n\n   0.0.0.0 ilead.itrack.it \n\n   0.0.0.0 ilovecheating.com \n\n   0.0.0.0 imageads.canoe.ca \n\n   0.0.0.0 imagecash.net \n\n   0.0.0.0 images-pw.secureserver.net \n\n   0.0.0.0 images.v3.com \n\n   0.0.0.0 imarketservices.com \n\n   0.0.0.0 img.prohardver.hu \n\n   0.0.0.0 imgpromo.easyrencontre.com \n\n   0.0.0.0 imitrk.com \n\n   0.0.0.0 imonitor.nethost.cz \n\n   0.0.0.0 imprese.cz \n\n   0.0.0.0 impressionmedia.cz \n\n   0.0.0.0 impressionz.co.uk \n\n   0.0.0.0 imrworldwide.com \n\n   0.0.0.0 inboxdollars.com \n\n   0.0.0.0 incentaclick.com \n\n   0.0.0.0 indexstats.com \n\n   0.0.0.0 indieclick.com \n\n   0.0.0.0 industrybrains.com \n\n   0.0.0.0 inetlog.ru \n\n   0.0.0.0 infinite-ads.com \n\n   0.0.0.0 infinityads.com \n\n   0.0.0.0 infolinks.com \n\n   0.0.0.0 information.com \n\n   0.0.0.0 inringtone.com \n\n   0.0.0.0 insightexpress.com \n\n   0.0.0.0 insightexpressai.com \n\n   0.0.0.0 inspectorclick.com \n\n   0.0.0.0 instantmadness.com \n\n   0.0.0.0 intelliads.com \n\n   0.0.0.0 intellitxt.com \n\n   0.0.0.0 interactive.forthnet.gr \n\n   0.0.0.0 intergi.com \n\n   0.0.0.0 internetfuel.com \n\n   0.0.0.0 interreklame.de \n\n   0.0.0.0 interstat.hu \n\n   0.0.0.0 ip.ro \n\n   0.0.0.0 ip193.cn \n\n   0.0.0.0 iperceptions.com \n\n   0.0.0.0 ipro.com \n\n   0.0.0.0 ireklama.cz \n\n   0.0.0.0 itfarm.com \n\n   0.0.0.0 itop.cz \n\n   0.0.0.0 its-that-easy.com \n\n   0.0.0.0 itsptp.com \n\n   0.0.0.0 jcount.com \n\n   0.0.0.0 jinkads.de \n\n   0.0.0.0 joetec.net \n\n   0.0.0.0 jokedollars.com \n\n   0.0.0.0 js.users.51.la \n\n   0.0.0.0 juicyads.com \n\n   0.0.0.0 jumptap.com \n\n   0.0.0.0 justrelevant.com \n\n   0.0.0.0 justwebads.com \n\n   0.0.0.0 k.iinfo.cz \n\n   0.0.0.0 kanoodle.com \n\n   0.0.0.0 keymedia.hu \n\n   0.0.0.0 kindads.com \n\n   0.0.0.0 kissmetrics.com \n\n   0.0.0.0 kliks.nl \n\n   0.0.0.0 komoona.com \n\n   0.0.0.0 kompasads.com \n\n   0.0.0.0 kontera.com \n\n   0.0.0.0 kt-g.de \n\n   0.0.0.0 ktu.sv2.biz \n\n   0.0.0.0 lakequincy.com \n\n   0.0.0.0 layer-ad.de \n\n   0.0.0.0 layer-ads.de \n\n   0.0.0.0 lbn.ru \n\n   0.0.0.0 lct.salesforce.com \n\n   0.0.0.0 lead-analytics.nl \n\n   0.0.0.0 leadaffiliates.com \n\n   0.0.0.0 leadboltads.net \n\n   0.0.0.0 leadclick.com \n\n   0.0.0.0 leadingedgecash.com \n\n   0.0.0.0 leadzupc.com \n\n   0.0.0.0 levelrate.de \n\n   0.0.0.0 lfstmedia.com \n\n   0.0.0.0 liftdna.com \n\n   0.0.0.0 ligatus.com \n\n   0.0.0.0 ligatus.de \n\n   0.0.0.0 lightningcast.net \n\n   0.0.0.0 lightspeedcash.com \n\n   0.0.0.0 link-booster.de \n\n   0.0.0.0 link4ads.com \n\n   0.0.0.0 linkadd.de \n\n   0.0.0.0 linkbuddies.com \n\n   0.0.0.0 linkexchange.com \n\n   0.0.0.0 linkexchange.ru \n\n   0.0.0.0 linkprice.com \n\n   0.0.0.0 linkrain.com \n\n   0.0.0.0 linkreferral.com \n\n   0.0.0.0 links-ranking.de \n\n   0.0.0.0 linkshighway.com \n\n   0.0.0.0 linkstorms.com \n\n   0.0.0.0 linkswaper.com \n\n   0.0.0.0 linktarget.com \n\n   0.0.0.0 liquidad.narrowcastmedia.com \n\n   0.0.0.0 liveintent.com \n\n   0.0.0.0 liverail.com \n\n   0.0.0.0 loading321.com \n\n   0.0.0.0 log.btopenworld.com \n\n   0.0.0.0 logua.com \n\n   0.0.0.0 lop.com \n\n   0.0.0.0 lucidmedia.com \n\n   0.0.0.0 lzjl.com \n\n   0.0.0.0 m.webtrends.com \n\n   0.0.0.0 m1.webstats4u.com \n\n   0.0.0.0 m4n.nl \n\n   0.0.0.0 madclient.uimserv.net \n\n   0.0.0.0 madisonavenue.com \n\n   0.0.0.0 mads.cnet.com \n\n   0.0.0.0 madvertise.de \n\n   0.0.0.0 marchex.com \n\n   0.0.0.0 market-buster.com \n\n   0.0.0.0 marketing.888.com \n\n   0.0.0.0 marketing.hearstmagazines.nl \n\n   0.0.0.0 marketing.nyi.net \n\n   0.0.0.0 marketing.osijek031.com \n\n   0.0.0.0 marketingsolutions.yahoo.com \n\n   0.0.0.0 maroonspider.com \n\n   0.0.0.0 mas.sector.sk \n\n   0.0.0.0 mastermind.com \n\n   0.0.0.0 matchcraft.com \n\n   0.0.0.0 mathtag.com \n\n   0.0.0.0 max.i12.de \n\n   0.0.0.0 maximumcash.com \n\n   0.0.0.0 mbn.com.ua \n\n   0.0.0.0 mbs.megaroticlive.com \n\n   0.0.0.0 mbuyu.nl \n\n   0.0.0.0 mdotm.com \n\n   0.0.0.0 measuremap.com \n\n   0.0.0.0 media-adrunner.mycomputer.com \n\n   0.0.0.0 media-servers.net \n\n   0.0.0.0 media.ftv-publicite.fr \n\n   0.0.0.0 media.funpic.de \n\n   0.0.0.0 media6degrees.com \n\n   0.0.0.0 mediaarea.eu \n\n   0.0.0.0 mediacharger.com \n\n   0.0.0.0 mediadvertising.ro \n\n   0.0.0.0 mediageneral.com \n\n   0.0.0.0 mediamath.com \n\n   0.0.0.0 mediamgr.ugo.com \n\n   0.0.0.0 mediaplazza.com \n\n   0.0.0.0 mediaplex.com \n\n   0.0.0.0 mediascale.de \n\n   0.0.0.0 mediatext.com \n\n   0.0.0.0 mediax.angloinfo.com \n\n   0.0.0.0 mediaz.angloinfo.com \n\n   0.0.0.0 medleyads.com \n\n   0.0.0.0 medyanetads.com \n\n   0.0.0.0 megacash.de \n\n   0.0.0.0 megago.com \n\n   0.0.0.0 megastats.com \n\n   0.0.0.0 megawerbung.de \n\n   0.0.0.0 metaffiliation.com \n\n   0.0.0.0 metanetwork.com \n\n   0.0.0.0 methodcash.com \n\n   0.0.0.0 metrics.windowsitpro.com \n\n   0.0.0.0 mgid.com \n\n   0.0.0.0 miarroba.com \n\n   0.0.0.0 microstatic.pl \n\n   0.0.0.0 microticker.com \n\n   0.0.0.0 midnightclicking.com \n\n   0.0.0.0 misstrends.com \n\n   0.0.0.0 mixpanel.com \n\n   0.0.0.0 mixtraffic.com \n\n   0.0.0.0 mlm.de \n\n   0.0.0.0 mmismm.com \n\n   0.0.0.0 mmtro.com \n\n   0.0.0.0 moatads.com \n\n   0.0.0.0 mobclix.com \n\n   0.0.0.0 mocean.mobi \n\n   0.0.0.0 moneyexpert.com \n\n   0.0.0.0 monsterpops.com \n\n   0.0.0.0 mopub.com \n\n   0.0.0.0 mouseflow.com \n\n   0.0.0.0 mpstat.us \n\n   0.0.0.0 mr-rank.de \n\n   0.0.0.0 mrskincash.com \n\n   0.0.0.0 mtree.com \n\n   0.0.0.0 musiccounter.ru \n\n   0.0.0.0 muwmedia.com \n\n   0.0.0.0 myaffiliateprogram.com \n\n   0.0.0.0 mybloglog.com \n\n   0.0.0.0 mycounter.ua \n\n   0.0.0.0 mypagerank.net \n\n   0.0.0.0 mypagerank.ru \n\n   0.0.0.0 mypowermall.com \n\n   0.0.0.0 mystat-in.net \n\n   0.0.0.0 mystat.pl \n\n   0.0.0.0 mytop-in.net \n\n   0.0.0.0 n69.com \n\n   0.0.0.0 naiadsystems.com.invalid \n\n   0.0.0.0 naj.sk \n\n   0.0.0.0 namimedia.com \n\n   0.0.0.0 nastydollars.com \n\n   0.0.0.0 navigator.io \n\n   0.0.0.0 navrcholu.cz \n\n   0.0.0.0 nbjmp.com \n\n   0.0.0.0 ndparking.com \n\n   0.0.0.0 nedstat.com \n\n   0.0.0.0 nedstat.nl \n\n   0.0.0.0 nedstatbasic.net \n\n   0.0.0.0 nedstatpro.net \n\n   0.0.0.0 nend.net \n\n   0.0.0.0 neocounter.neoworx-blog-tools.net \n\n   0.0.0.0 neoffic.com \n\n   0.0.0.0 net-filter.com \n\n   0.0.0.0 netaffiliation.com \n\n   0.0.0.0 netagent.cz \n\n   0.0.0.0 netclickstats.com \n\n   0.0.0.0 netcommunities.com \n\n   0.0.0.0 netdirect.nl \n\n   0.0.0.0 netincap.com \n\n   0.0.0.0 netpool.netbookia.net \n\n   0.0.0.0 netshelter.net \n\n   0.0.0.0 network.business.com \n\n   0.0.0.0 neudesicmediagroup.com \n\n   0.0.0.0 newads.bangbros.com \n\n   0.0.0.0 newbie.com \n\n   0.0.0.0 newnet.qsrch.com \n\n   0.0.0.0 newnudecash.com \n\n   0.0.0.0 newopenx.detik.com \n\n   0.0.0.0 newt1.adultadworld.com \n\n   0.0.0.0 newt1.adultworld.com \n\n   0.0.0.0 newtopsites.com \n\n   0.0.0.0 ng3.ads.warnerbros.com \n\n   0.0.0.0 ngs.impress.co.jp \n\n   0.0.0.0 nitroclicks.com \n\n   0.0.0.0 novem.pl \n\n   0.0.0.0 nuggad.net \n\n   0.0.0.0 numax.nu-1.com \n\n   0.0.0.0 nuseek.com \n\n   0.0.0.0 oas.benchmark.fr \n\n   0.0.0.0 oas.foxnews.com \n\n   0.0.0.0 oas.repubblica.it \n\n   0.0.0.0 oas.roanoke.com \n\n   0.0.0.0 oas.salon.com \n\n   0.0.0.0 oas.toronto.com \n\n   0.0.0.0 oas.uniontrib.com \n\n   0.0.0.0 oas.villagevoice.com \n\n   0.0.0.0 oascentral.businessweek.com \n\n   0.0.0.0 oascentral.chicagobusiness.com \n\n   0.0.0.0 oascentral.fortunecity.com \n\n   0.0.0.0 oascentral.register.com \n\n   0.0.0.0 oewa.at \n\n   0.0.0.0 oewabox.at \n\n   0.0.0.0 offerforge.com \n\n   0.0.0.0 offermatica.com \n\n   0.0.0.0 olivebrandresponse.com \n\n   0.0.0.0 omniture.com \n\n   0.0.0.0 onclasrv.com \n\n   0.0.0.0 onclickads.net \n\n   0.0.0.0 oneandonlynetwork.com \n\n   0.0.0.0 onenetworkdirect.com \n\n   0.0.0.0 onestat.com \n\n   0.0.0.0 onestatfree.com \n\n   0.0.0.0 onewaylinkexchange.net \n\n   0.0.0.0 online-metrix.net \n\n   0.0.0.0 onlinecash.com \n\n   0.0.0.0 onlinecashmethod.com \n\n   0.0.0.0 onlinerewardcenter.com \n\n   0.0.0.0 openad.tf1.fr \n\n   0.0.0.0 openad.travelnow.com \n\n   0.0.0.0 openads.friendfinder.com \n\n   0.0.0.0 openads.org \n\n   0.0.0.0 openx.angelsgroup.org.uk \n\n   0.0.0.0 openx.blindferret.com \n\n   0.0.0.0 opienetwork.com \n\n   0.0.0.0 optimost.com \n\n   0.0.0.0 optmd.com \n\n   0.0.0.0 ordingly.com \n\n   0.0.0.0 ota.cartrawler.com \n\n   0.0.0.0 otto-images.developershed.com \n\n   0.0.0.0 outbrain.com \n\n   0.0.0.0 overture.com \n\n   0.0.0.0 owebmoney.ru \n\n   0.0.0.0 oxado.com \n\n   0.0.0.0 oxcash.com \n\n   0.0.0.0 oxen.hillcountrytexas.com \n\n   0.0.0.0 p.adpdx.com \n\n   0.0.0.0 pagead.l.google.com \n\n   0.0.0.0 pagefair.com \n\n   0.0.0.0 pagerank-ranking.com \n\n   0.0.0.0 pagerank-ranking.de \n\n   0.0.0.0 pagerank-submitter.com \n\n   0.0.0.0 pagerank-submitter.de \n\n   0.0.0.0 pagerank-suchmaschine.de \n\n   0.0.0.0 pagerank-united.de \n\n   0.0.0.0 pagerank4u.eu \n\n   0.0.0.0 pagerank4you.com \n\n   0.0.0.0 pageranktop.com \n\n   0.0.0.0 partage-facile.com \n\n   0.0.0.0 partner-ads.com \n\n   0.0.0.0 partner.pelikan.cz \n\n   0.0.0.0 partner.topcities.com \n\n   0.0.0.0 partnerad.l.google.com \n\n   0.0.0.0 partnercash.de \n\n   0.0.0.0 partners.priceline.com \n\n   0.0.0.0 passion-4.net \n\n   0.0.0.0 pay-ads.com \n\n   0.0.0.0 paycounter.com \n\n   0.0.0.0 paypopup.com \n\n   0.0.0.0 payserve.com \n\n   0.0.0.0 pbnet.ru \n\n   0.0.0.0 pcash.imlive.com \n\n   0.0.0.0 peep-auktion.de \n\n   0.0.0.0 peer39.com \n\n   0.0.0.0 pennyweb.com \n\n   0.0.0.0 pepperjamnetwork.com \n\n   0.0.0.0 percentmobile.com \n\n   0.0.0.0 perf.weborama.fr \n\n   0.0.0.0 perfectaudience.com \n\n   0.0.0.0 perfiliate.com \n\n   0.0.0.0 performancerevenue.com \n\n   0.0.0.0 performancerevenues.com \n\n   0.0.0.0 performancing.com \n\n   0.0.0.0 pgmediaserve.com \n\n   0.0.0.0 pgpartner.com \n\n   0.0.0.0 pheedo.com \n\n   0.0.0.0 phoenix-adrunner.mycomputer.com \n\n   0.0.0.0 phpadsnew.new.natuurpark.nl \n\n   0.0.0.0 phpmyvisites.net \n\n   0.0.0.0 picadmedia.com \n\n   0.0.0.0 pillscash.com \n\n   0.0.0.0 pimproll.com \n\n   0.0.0.0 pixel.adsafeprotected.com \n\n   0.0.0.0 pixel.jumptap.com \n\n   0.0.0.0 pixel.redditmedia.com \n\n   0.0.0.0 planetactive.com \n\n   0.0.0.0 play4traffic.com \n\n   0.0.0.0 playhaven.com \n\n   0.0.0.0 plista.com \n\n   0.0.0.0 plugrush.com \n\n   0.0.0.0 pointroll.com \n\n   0.0.0.0 pop-under.ru \n\n   0.0.0.0 popads.net \n\n   0.0.0.0 popub.com \n\n   0.0.0.0 popunder.ru \n\n   0.0.0.0 popup.msn.com \n\n   0.0.0.0 popupmoney.com \n\n   0.0.0.0 popupnation.com \n\n   0.0.0.0 popups.infostart.com \n\n   0.0.0.0 popuptraffic.com \n\n   0.0.0.0 porngraph.com \n\n   0.0.0.0 porntrack.com \n\n   0.0.0.0 postrelease.com \n\n   0.0.0.0 potenza.cz \n\n   0.0.0.0 pr-star.de \n\n   0.0.0.0 pr-ten.de \n\n   0.0.0.0 praddpro.de \n\n   0.0.0.0 prchecker.info \n\n   0.0.0.0 precisioncounter.com \n\n   0.0.0.0 predictad.com \n\n   0.0.0.0 premium-offers.com \n\n   0.0.0.0 primaryads.com \n\n   0.0.0.0 primetime.net \n\n   0.0.0.0 privatecash.com \n\n   0.0.0.0 pro-advertising.com \n\n   0.0.0.0 pro.i-doctor.co.kr \n\n   0.0.0.0 proext.com \n\n   0.0.0.0 profero.com \n\n   0.0.0.0 projectwonderful.com \n\n   0.0.0.0 promo.badoink.com \n\n   0.0.0.0 promo.ulust.com \n\n   0.0.0.0 promo1.webcams.nl \n\n   0.0.0.0 promobenef.com \n\n   0.0.0.0 promos.fling.com \n\n   0.0.0.0 promote.pair.com \n\n   0.0.0.0 promotion-campaigns.com \n\n   0.0.0.0 pronetadvertising.com \n\n   0.0.0.0 propellerads.com \n\n   0.0.0.0 proranktracker.com \n\n   0.0.0.0 proton-tm.com \n\n   0.0.0.0 protraffic.com \n\n   0.0.0.0 provexia.com \n\n   0.0.0.0 prsitecheck.com \n\n   0.0.0.0 psstt.com \n\n   0.0.0.0 pub.chez.com \n\n   0.0.0.0 pub.club-internet.fr \n\n   0.0.0.0 pub.hardware.fr \n\n   0.0.0.0 pub.realmedia.fr \n\n   0.0.0.0 pubdirecte.com \n\n   0.0.0.0 publicidad.elmundo.es \n\n   0.0.0.0 pubmatic.com \n\n   0.0.0.0 pubs.lemonde.fr \n\n   0.0.0.0 pulse360.com \n\n   0.0.0.0 q.azcentral.com \n\n   0.0.0.0 qctop.com \n\n   0.0.0.0 qnsr.com \n\n   0.0.0.0 quantcast.com \n\n   0.0.0.0 quantserve.com \n\n   0.0.0.0 quarterserver.de \n\n   0.0.0.0 questaffiliates.net \n\n   0.0.0.0 quigo.com \n\n   0.0.0.0 quinst.com \n\n   0.0.0.0 quisma.com \n\n   0.0.0.0 rad.msn.com \n\n   0.0.0.0 radar.cedexis.com \n\n   0.0.0.0 radarurl.com \n\n   0.0.0.0 radiate.com \n\n   0.0.0.0 rampidads.com \n\n   0.0.0.0 rank-master.com \n\n   0.0.0.0 rank-master.de \n\n   0.0.0.0 rankchamp.de \n\n   0.0.0.0 ranking-charts.de \n\n   0.0.0.0 ranking-hits.de \n\n   0.0.0.0 ranking-id.de \n\n   0.0.0.0 ranking-links.de \n\n   0.0.0.0 ranking-liste.de \n\n   0.0.0.0 ranking-street.de \n\n   0.0.0.0 rankingscout.com \n\n   0.0.0.0 rankyou.com \n\n   0.0.0.0 rapidcounter.com \n\n   0.0.0.0 rate.ru \n\n   0.0.0.0 ratings.lycos.com \n\n   0.0.0.0 rb1.design.ru \n\n   0.0.0.0 re-directme.com \n\n   0.0.0.0 reachjunction.com \n\n   0.0.0.0 reactx.com \n\n   0.0.0.0 readserver.net \n\n   0.0.0.0 realcastmedia.com \n\n   0.0.0.0 realclix.com \n\n   0.0.0.0 realmedia-a800.d4p.net \n\n   0.0.0.0 realtechnetwork.com \n\n   0.0.0.0 realtracker.com \n\n   0.0.0.0 reduxmedia.com \n\n   0.0.0.0 reduxmediagroup.com \n\n   0.0.0.0 reedbusiness.com.invalid \n\n   0.0.0.0 reefaquarium.biz \n\n   0.0.0.0 referralware.com \n\n   0.0.0.0 regnow.com \n\n   0.0.0.0 reinvigorate.net \n\n   0.0.0.0 reklam.rfsl.se \n\n   0.0.0.0 reklama.mironet.cz \n\n   0.0.0.0 reklama.reflektor.cz \n\n   0.0.0.0 reklamcsere.hu \n\n   0.0.0.0 reklame.unwired-i.net \n\n   0.0.0.0 reklamer.com.ua \n\n   0.0.0.0 relevanz10.de \n\n   0.0.0.0 relmaxtop.com \n\n   0.0.0.0 remotead.cnet.com \n\n   0.0.0.0 republika.onet.pl \n\n   0.0.0.0 retargeter.com \n\n   0.0.0.0 revenue.net \n\n   0.0.0.0 revenuedirect.com \n\n   0.0.0.0 revsci.net \n\n   0.0.0.0 revstats.com \n\n   0.0.0.0 richmails.com \n\n   0.0.0.0 richmedia.yimg.com \n\n   0.0.0.0 richwebmaster.com \n\n   0.0.0.0 rightstats.com \n\n   0.0.0.0 rlcdn.com \n\n   0.0.0.0 rle.ru \n\n   0.0.0.0 rmads.msn.com \n\n   0.0.0.0 rmedia.boston.com \n\n   0.0.0.0 roar.com \n\n   0.0.0.0 robotreplay.com \n\n   0.0.0.0 roia.biz \n\n   0.0.0.0 rok.com.com \n\n   0.0.0.0 rose.ixbt.com \n\n   0.0.0.0 rotabanner.com \n\n   0.0.0.0 roxr.net \n\n   0.0.0.0 rtbpop.com \n\n   0.0.0.0 rtbpopd.com \n\n   0.0.0.0 ru-traffic.com \n\n   0.0.0.0 ru4.com \n\n   0.0.0.0 rubiconproject.com \n\n   0.0.0.0 s.adroll.com \n\n   0.0.0.0 s2d6.com \n\n   0.0.0.0 sageanalyst.net \n\n   0.0.0.0 sbx.pagesjaunes.fr \n\n   0.0.0.0 scambiobanner.aruba.it \n\n   0.0.0.0 scanscout.com \n\n   0.0.0.0 scopelight.com \n\n   0.0.0.0 scorecardresearch.com \n\n   0.0.0.0 scratch2cash.com \n\n   0.0.0.0 scripte-monster.de \n\n   0.0.0.0 searchfeast.com \n\n   0.0.0.0 searchmarketing.com \n\n   0.0.0.0 searchramp.com \n\n   0.0.0.0 secure.webconnect.net \n\n   0.0.0.0 sedoparking.com \n\n   0.0.0.0 sedotracker.com \n\n   0.0.0.0 seeq.com.invalid \n\n   0.0.0.0 sensismediasmart.com.au \n\n   0.0.0.0 seo4india.com \n\n   0.0.0.0 serv0.com \n\n   0.0.0.0 servedbyadbutler.com \n\n   0.0.0.0 servedbyopenx.com \n\n   0.0.0.0 servethis.com \n\n   0.0.0.0 services.hearstmags.com \n\n   0.0.0.0 serving-sys.com \n\n   0.0.0.0 sexaddpro.de \n\n   0.0.0.0 sexadvertentiesite.nl \n\n   0.0.0.0 sexcounter.com \n\n   0.0.0.0 sexinyourcity.com \n\n   0.0.0.0 sexlist.com \n\n   0.0.0.0 sextracker.com \n\n   0.0.0.0 sexystat.com \n\n   0.0.0.0 shareadspace.com \n\n   0.0.0.0 shareasale.com \n\n   0.0.0.0 sharepointads.com \n\n   0.0.0.0 sher.index.hu \n\n   0.0.0.0 shinystat.com \n\n   0.0.0.0 shinystat.it \n\n   0.0.0.0 shoppingads.com \n\n   0.0.0.0 siccash.com \n\n   0.0.0.0 sidebar.angelfire.com \n\n   0.0.0.0 sinoa.com \n\n   0.0.0.0 sitemerkezi.net \n\n   0.0.0.0 sitemeter.com \n\n   0.0.0.0 sitestat.com \n\n   0.0.0.0 sixsigmatraffic.com \n\n   0.0.0.0 skylink.vn \n\n   0.0.0.0 slickaffiliate.com \n\n   0.0.0.0 slopeaota.com \n\n   0.0.0.0 smart4ads.com \n\n   0.0.0.0 smartadserver.com \n\n   0.0.0.0 smowtion.com \n\n   0.0.0.0 snapads.com \n\n   0.0.0.0 snoobi.com \n\n   0.0.0.0 socialspark.com \n\n   0.0.0.0 softclick.com.br \n\n   0.0.0.0 spacash.com \n\n   0.0.0.0 sparkstudios.com \n\n   0.0.0.0 specificmedia.co.uk \n\n   0.0.0.0 specificpop.com \n\n   0.0.0.0 spezialreporte.de \n\n   0.0.0.0 spinbox.techtracker.com \n\n   0.0.0.0 spinbox.versiontracker.com \n\n   0.0.0.0 sponsorads.de \n\n   0.0.0.0 sponsorpro.de \n\n   0.0.0.0 sponsors.thoughtsmedia.com \n\n   0.0.0.0 spot.fitness.com \n\n   0.0.0.0 spotxchange.com \n\n   0.0.0.0 sprinks-clicks.about.com \n\n   0.0.0.0 spylog.com \n\n   0.0.0.0 spywarelabs.com \n\n   0.0.0.0 spywarenuker.com \n\n   0.0.0.0 spywords.com \n\n   0.0.0.0 srwww1.com \n\n   0.0.0.0 starffa.com \n\n   0.0.0.0 start.freeze.com \n\n   0.0.0.0 stat.cliche.se \n\n   0.0.0.0 stat.dealtime.com \n\n   0.0.0.0 stat.dyna.ultraweb.hu \n\n   0.0.0.0 stat.pl \n\n   0.0.0.0 stat.su \n\n   0.0.0.0 stat.tudou.com \n\n   0.0.0.0 stat.webmedia.pl \n\n   0.0.0.0 stat.zenon.net \n\n   0.0.0.0 stat24.com \n\n   0.0.0.0 stat24.meta.ua \n\n   0.0.0.0 statcounter.com \n\n   0.0.0.0 static.fmpub.net \n\n   0.0.0.0 static.itrack.it \n\n   0.0.0.0 staticads.btopenworld.com \n\n   0.0.0.0 statistik-gallup.net \n\n   0.0.0.0 statm.the-adult-company.com \n\n   0.0.0.0 stats.blogger.com \n\n   0.0.0.0 stats.cts-bv.nl \n\n   0.0.0.0 stats.directnic.com \n\n   0.0.0.0 stats.hyperinzerce.cz \n\n   0.0.0.0 stats.mirrorfootball.co.uk \n\n   0.0.0.0 stats.olark.com \n\n   0.0.0.0 stats.suite101.com \n\n   0.0.0.0 stats.surfaid.ihost.com \n\n   0.0.0.0 stats.townnews.com \n\n   0.0.0.0 stats.unwired-i.net \n\n   0.0.0.0 stats.wordpress.com \n\n   0.0.0.0 stats.x14.eu \n\n   0.0.0.0 stats4all.com \n\n   0.0.0.0 statsie.com \n\n   0.0.0.0 statxpress.com \n\n   0.0.0.0 steelhouse.com \n\n   0.0.0.0 steelhousemedia.com \n\n   0.0.0.0 stickyadstv.com \n\n   0.0.0.0 suavalds.com \n\n   0.0.0.0 subscribe.hearstmags.com \n\n   0.0.0.0 sugoicounter.com \n\n   0.0.0.0 superclix.de \n\n   0.0.0.0 superstats.com \n\n   0.0.0.0 supertop.ru \n\n   0.0.0.0 supertop100.com \n\n   0.0.0.0 suptullog.com \n\n   0.0.0.0 surfmusik-adserver.de \n\n   0.0.0.0 swissadsolutions.com \n\n   0.0.0.0 swordfishdc.com \n\n   0.0.0.0 sx.trhnt.com \n\n   0.0.0.0 t.insigit.com \n\n   0.0.0.0 t.pusk.ru \n\n   0.0.0.0 taboola.com \n\n   0.0.0.0 tacoda.net \n\n   0.0.0.0 tagular.com \n\n   0.0.0.0 tailsweep.co.uk \n\n   0.0.0.0 tailsweep.com \n\n   0.0.0.0 tailsweep.se \n\n   0.0.0.0 takru.com \n\n   0.0.0.0 tangerinenet.biz \n\n   0.0.0.0 tapad.com \n\n   0.0.0.0 targad.de \n\n   0.0.0.0 targetingnow.com \n\n   0.0.0.0 targetnet.com \n\n   0.0.0.0 targetpoint.com \n\n   0.0.0.0 tatsumi-sys.jp \n\n   0.0.0.0 tcads.net \n\n   0.0.0.0 techclicks.net \n\n   0.0.0.0 teenrevenue.com \n\n   0.0.0.0 teliad.de \n\n   0.0.0.0 text-link-ads.com \n\n   0.0.0.0 textad.sexsearch.com \n\n   0.0.0.0 textads.biz \n\n   0.0.0.0 textads.opera.com \n\n   0.0.0.0 textlinks.com \n\n   0.0.0.0 tfag.de \n\n   0.0.0.0 theadhost.com \n\n   0.0.0.0 theads.me \n\n   0.0.0.0 thecounter.com \n\n   0.0.0.0 therapistla.com \n\n   0.0.0.0 therichkids.com \n\n   0.0.0.0 thrnt.com \n\n   0.0.0.0 thruport.com \n\n   0.0.0.0 tinybar.com \n\n   0.0.0.0 tizers.net \n\n   0.0.0.0 tlvmedia.com \n\n   0.0.0.0 tntclix.co.uk \n\n   0.0.0.0 top-casting-termine.de \n\n   0.0.0.0 top-site-list.com \n\n   0.0.0.0 top.list.ru \n\n   0.0.0.0 top.mail.ru \n\n   0.0.0.0 top.proext.com \n\n   0.0.0.0 top100-images.rambler.ru \n\n   0.0.0.0 top100.mafia.ru \n\n   0.0.0.0 top123.ro \n\n   0.0.0.0 top20.com \n\n   0.0.0.0 top20free.com \n\n   0.0.0.0 top90.ro \n\n   0.0.0.0 topbarh.box.sk \n\n   0.0.0.0 topblogarea.se \n\n   0.0.0.0 topbucks.com \n\n   0.0.0.0 topforall.com \n\n   0.0.0.0 topgamesites.net \n\n   0.0.0.0 toplist.cz \n\n   0.0.0.0 toplist.pornhost.com \n\n   0.0.0.0 toplista.mw.hu \n\n   0.0.0.0 toplistcity.com \n\n   0.0.0.0 topmmorpgsites.com \n\n   0.0.0.0 topping.com.ua \n\n   0.0.0.0 toprebates.com \n\n   0.0.0.0 topsafelist.net \n\n   0.0.0.0 topsearcher.com \n\n   0.0.0.0 topsir.com \n\n   0.0.0.0 topsite.lv \n\n   0.0.0.0 topsites.com.br \n\n   0.0.0.0 topstats.com \n\n   0.0.0.0 totemcash.com \n\n   0.0.0.0 touchclarity.com \n\n   0.0.0.0 touchclarity.natwest.com \n\n   0.0.0.0 tour.brazzers.com \n\n   0.0.0.0 tpnads.com \n\n   0.0.0.0 track.adform.net \n\n   0.0.0.0 track.anchorfree.com \n\n   0.0.0.0 track.gawker.com \n\n   0.0.0.0 trackalyzer.com \n\n   0.0.0.0 tracker.icerocket.com \n\n   0.0.0.0 tracker.marinsm.com \n\n   0.0.0.0 tracking.crunchiemedia.com \n\n   0.0.0.0 tracking.gajmp.com \n\n   0.0.0.0 tracking.internetstores.de \n\n   0.0.0.0 tracking.yourfilehost.com \n\n   0.0.0.0 tracking101.com \n\n   0.0.0.0 trackingsoft.com \n\n   0.0.0.0 trackmysales.com \n\n   0.0.0.0 tradeadexchange.com \n\n   0.0.0.0 tradedoubler.com \n\n   0.0.0.0 traffic-exchange.com \n\n   0.0.0.0 traffic.liveuniversenetwork.com \n\n   0.0.0.0 trafficadept.com \n\n   0.0.0.0 trafficcdn.liveuniversenetwork.com \n\n   0.0.0.0 trafficfactory.biz \n\n   0.0.0.0 trafficholder.com \n\n   0.0.0.0 traffichunt.com \n\n   0.0.0.0 trafficjunky.net \n\n   0.0.0.0 trafficleader.com \n\n   0.0.0.0 trafficsecrets.com \n\n   0.0.0.0 trafficspaces.net \n\n   0.0.0.0 trafficstrategies.com \n\n   0.0.0.0 trafficswarm.com \n\n   0.0.0.0 traffictrader.net \n\n   0.0.0.0 trafficz.com \n\n   0.0.0.0 trafficz.net \n\n   0.0.0.0 traffiq.com \n\n   0.0.0.0 trafic.ro \n\n   0.0.0.0 travis.bosscasinos.com \n\n   0.0.0.0 trekblue.com \n\n   0.0.0.0 trekdata.com \n\n   0.0.0.0 trendcounter.com \n\n   0.0.0.0 trhunt.com \n\n   0.0.0.0 tribalfusion.com \n\n   0.0.0.0 trix.net \n\n   0.0.0.0 truehits.net \n\n   0.0.0.0 truehits1.gits.net.th \n\n   0.0.0.0 truehits2.gits.net.th \n\n   0.0.0.0 tsms-ad.tsms.com \n\n   0.0.0.0 tubemogul.com \n\n   0.0.0.0 turn.com \n\n   0.0.0.0 tvas-a.pw \n\n   0.0.0.0 tvas-c.pw \n\n   0.0.0.0 tvmtracker.com \n\n   0.0.0.0 twittad.com \n\n   0.0.0.0 tyroo.com \n\n   0.0.0.0 uarating.com \n\n   0.0.0.0 ukbanners.com \n\n   0.0.0.0 ultramercial.com \n\n   0.0.0.0 unanimis.co.uk \n\n   0.0.0.0 untd.com \n\n   0.0.0.0 updated.com \n\n   0.0.0.0 urlcash.net \n\n   0.0.0.0 us.a1.yimg.com \n\n   0.0.0.0 usapromotravel.com \n\n   0.0.0.0 usmsad.tom.com \n\n   0.0.0.0 utarget.co.uk \n\n   0.0.0.0 utils.mediageneral.net \n\n   0.0.0.0 v1.cnzz.com \n\n   0.0.0.0 validclick.com \n\n   0.0.0.0 valuead.com \n\n   0.0.0.0 valueclick.com \n\n   0.0.0.0 valueclickmedia.com \n\n   0.0.0.0 valuecommerce.com \n\n   0.0.0.0 valuesponsor.com \n\n   0.0.0.0 veille-referencement.com \n\n   0.0.0.0 ventivmedia.com \n\n   0.0.0.0 vericlick.com \n\n   0.0.0.0 vertadnet.com \n\n   0.0.0.0 veruta.com \n\n   0.0.0.0 vervewireless.com \n\n   0.0.0.0 vibrantmedia.com \n\n   0.0.0.0 video-stats.video.google.com \n\n   0.0.0.0 videoegg.com \n\n   0.0.0.0 view4cash.de \n\n   0.0.0.0 viewpoint.com \n\n   0.0.0.0 visistat.com \n\n   0.0.0.0 visit.webhosting.yahoo.com \n\n   0.0.0.0 visitbox.de \n\n   0.0.0.0 visual-pagerank.fr \n\n   0.0.0.0 visualrevenue.com \n\n   0.0.0.0 voicefive.com \n\n   0.0.0.0 vpon.com \n\n   0.0.0.0 vrs.cz \n\n   0.0.0.0 vs.tucows.com \n\n   0.0.0.0 vungle.com \n\n   0.0.0.0 wads.webteh.com \n\n   0.0.0.0 warlog.info \n\n   0.0.0.0 warlog.ru \n\n   0.0.0.0 wdads.sx.atl.publicus.com \n\n   0.0.0.0 web-stat.com \n\n   0.0.0.0 web.informer.com \n\n   0.0.0.0 web2.deja.com \n\n   0.0.0.0 webads.co.nz \n\n   0.0.0.0 webads.nl \n\n   0.0.0.0 webangel.ru \n\n   0.0.0.0 webcash.nl \n\n   0.0.0.0 webcounter.cz \n\n   0.0.0.0 webcounter.goweb.de \n\n   0.0.0.0 webgains.com \n\n   0.0.0.0 webmaster-partnerprogramme24.de \n\n   0.0.0.0 webmasterplan.com \n\n   0.0.0.0 webmasterplan.de \n\n   0.0.0.0 weborama.fr \n\n   0.0.0.0 webpower.com \n\n   0.0.0.0 webreseau.com \n\n   0.0.0.0 webseoanalytics.com \n\n   0.0.0.0 websponsors.com \n\n   0.0.0.0 webstat.channel4.com \n\n   0.0.0.0 webstat.com \n\n   0.0.0.0 webstat.net \n\n   0.0.0.0 webstats4u.com \n\n   0.0.0.0 webtrackerplus.com \n\n   0.0.0.0 webtraffic.se \n\n   0.0.0.0 webtraxx.de \n\n   0.0.0.0 webtrendslive.com \n\n   0.0.0.0 wegcash.com \n\n   0.0.0.0 werbung.meteoxpress.com \n\n   0.0.0.0 wetrack.it \n\n   0.0.0.0 whaleads.com \n\n   0.0.0.0 whenu.com \n\n   0.0.0.0 whispa.com \n\n   0.0.0.0 whoisonline.net \n\n   0.0.0.0 wholesaletraffic.info \n\n   0.0.0.0 widespace.com \n\n   0.0.0.0 widgetbucks.com \n\n   0.0.0.0 wikia-ads.wikia.com \n\n   0.0.0.0 window.nixnet.cz \n\n   0.0.0.0 wintricksbanner.googlepages.com \n\n   0.0.0.0 witch-counter.de \n\n   0.0.0.0 wlmarketing.com \n\n   0.0.0.0 wmirk.ru \n\n   0.0.0.0 wonderlandads.com \n\n   0.0.0.0 wondoads.de \n\n   0.0.0.0 woopra.com \n\n   0.0.0.0 worldwide-cash.net \n\n   0.0.0.0 wtlive.com \n\n   0.0.0.0 www-banner.chat.ru \n\n   0.0.0.0 www-google-analytics.l.google.com \n\n   0.0.0.0 www.banner-link.com.br \n\n   0.0.0.0 www.dnps.com \n\n   0.0.0.0 www.kaplanindex.com \n\n   0.0.0.0 www.money4exit.de \n\n   0.0.0.0 www.photo-ads.co.uk \n\n   0.0.0.0 www1.gto-media.com \n\n   0.0.0.0 www8.glam.com \n\n   0.0.0.0 x-traceur.com \n\n   0.0.0.0 x6.yakiuchi.com \n\n   0.0.0.0 xchange.ro \n\n   0.0.0.0 xclicks.net \n\n   0.0.0.0 xertive.com \n\n   0.0.0.0 xg4ken.com \n\n   0.0.0.0 xiti.com \n\n   0.0.0.0 xplusone.com \n\n   0.0.0.0 xponsor.com \n\n   0.0.0.0 xq1.net \n\n   0.0.0.0 xrea.com \n\n   0.0.0.0 xtendmedia.com \n\n   0.0.0.0 xtremetop100.com \n\n   0.0.0.0 xxxcounter.com \n\n   0.0.0.0 xxxmyself.com \n\n   0.0.0.0 y.ibsys.com \n\n   0.0.0.0 yab-adimages.s3.amazonaws.com \n\n   0.0.0.0 yabuka.com \n\n   0.0.0.0 yadro.ru \n\n   0.0.0.0 yesads.com \n\n   0.0.0.0 yesadvertising.com \n\n   0.0.0.0 yieldads.com \n\n   0.0.0.0 yieldlab.net \n\n   0.0.0.0 yieldmanager.com \n\n   0.0.0.0 yieldmanager.net \n\n   0.0.0.0 yieldmo.com \n\n   0.0.0.0 yieldtraffic.com \n\n   0.0.0.0 yoc.mobi \n\n   0.0.0.0 yoggrt.com \n\n   0.0.0.0 z5x.net \n\n   0.0.0.0 zangocash.com \n\n   0.0.0.0 zanox-affiliate.de \n\n   0.0.0.0 zanox.com \n\n   0.0.0.0 zantracker.com \n\n   0.0.0.0 zedo.com \n\n   0.0.0.0 zencudo.co.uk \n\n   0.0.0.0 zenkreka.com \n\n   0.0.0.0 zenzuu.com \n\n   0.0.0.0 zeus.developershed.com \n\n   0.0.0.0 zeusclicks.com \n\n   0.0.0.0 zintext.com \n\n   0.0.0.0 zmedia.com \n\n   0.0.0.0 zv1.november-lax.com \n\n   0.0.0.0 ac3.msn.com \n\n   0.0.0.0 choice.microsoft.com \n\n   0.0.0.0 choice.microsoft.com.nsatc.net \n\n   0.0.0.0 compatexchange.cloudapp.net \n\n   0.0.0.0 corp.sts.microsoft.com \n\n   0.0.0.0 corpext.msitadfs.glbdns2.microsoft.com \n\n   0.0.0.0 cs1.wpc.v0cdn.net \n\n   0.0.0.0 diagnostics.support.microsoft.com \n\n   0.0.0.0 feedback.search.microsoft.com \n\n   0.0.0.0 feedback.windows.com \n\n   0.0.0.0 i1.services.social.microsoft.com \n\n   0.0.0.0 i1.services.social.microsoft.com.nsatc.net \n\n   0.0.0.0 oca.telemetry.microsoft.com \n\n   0.0.0.0 oca.telemetry.microsoft.com.nsatc.net \n\n   0.0.0.0 pre.footprintpredict.com \n\n   0.0.0.0 redir.metaservices.microsoft.com \n\n   0.0.0.0 services.wes.df.telemetry.microsoft.com \n\n   0.0.0.0 settings-sandbox.data.microsoft.com \n\n   0.0.0.0 sls.update.microsoft.com.akadns.net \n\n   0.0.0.0 sqm.df.telemetry.microsoft.com \n\n   0.0.0.0 sqm.telemetry.microsoft.com \n\n   0.0.0.0 sqm.telemetry.microsoft.com.nsatc.net \n\n   0.0.0.0 ssw.live.com \n\n   0.0.0.0 statsfe1.ws.microsoft.com \n\n   0.0.0.0 statsfe2.update.microsoft.com.akadns.net \n\n   0.0.0.0 survey.watson.microsoft.com \n\n   0.0.0.0 telecommand.telemetry.microsoft.com \n\n   0.0.0.0 telecommand.telemetry.microsoft.com.nsatc.net \n\n   0.0.0.0 telemetry.urs.microsoft.com \n\n   0.0.0.0 vortex-bn2.metron.live.com.nsatc.net \n\n   0.0.0.0 vortex-cy2.metron.live.com.nsatc.net \n\n   0.0.0.0 vortex-sandbox.data.microsoft.com \n\n   0.0.0.0 vortex-win.data.microsoft.com \n\n   0.0.0.0 vortex.data.microsoft.com \n\n   0.0.0.0 watson.live.com \n\n   0.0.0.0 watson.microsoft.com \n\n   0.0.0.0 watson.ppe.telemetry.microsoft.com \n\n   0.0.0.0 watson.telemetry.microsoft.com \n\n   0.0.0.0 watson.telemetry.microsoft.com.nsatc.net \n\n ";
                core.WRITE_TO_HOST(hosts_pishing);

                // save
                SAVE("winpurify_pishing", "1");
            }
            else
            {
                if (LOAD("winpurify_pishing") == "1")
                {
                    // save
                    SAVE("winpurify_pishing", "0");
                }
            }
        }
        public void DISABLE_CRASHLOGFEEDBACK(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                core.POWERSHELL(@"New-Item -Path 'HKCU:\Software\Microsoft\Siuf\Rules' -Force | Out-Null");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Siuf\Rules' -Name 'NumberOfSIUFInPeriod' -Type DWord -Value 0");

                // save
                SAVE("winpurify_feedback", "1");
            }
            else
            {
                if (LOAD("winpurify_feedback") == "1")
                {
                    core.POWERSHELL(@"New-Item -Path 'HKCU:\Software\Microsoft\Siuf\Rules' -Force | Out-Null");
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Siuf\Rules' -Name 'NumberOfSIUFInPeriod' -Type DWord -Value 1");

                    // save
                    SAVE("winpurify_feedback", "0");
                }
            }
        }
        public void DISABLE_WINDOWSDEFENDER(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                core.POWERSHELL("Set-MpPreference -DisableRealtimeMonitoring $true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "00000001", "true");
                core.REGISTRY_WRITE(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "00000001", "true");

                // save
                SAVE("winpurify_defender", "1");
            }
            else
            {
                if (LOAD("winpurify_defender") == "1")
                {
                    core.POWERSHELL("Set-MpPreference -DisableRealtimeMonitoring $false");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "00000000", "true");
                    core.REGISTRY_WRITE(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "00000000", "true");

                    // save
                    SAVE("winpurify_defender", "0");
                }
            }
        }
        public void MAKE_RESTOREPOINT(string set = "none")
        {
            var core = new Core();
            // Not in this version
        }
        public void DISABLE_REMOTE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKLM:\System\CurrentControlSet\Control\Remote Assistance' -Name 'fAllowToGetHelp' -Type DWord -Value 0");

                // save
                SAVE("winpurify_remote", "1");
            }
            else
            {
                if (LOAD("winpurify_remote") == "1")
                {
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKLM:\System\CurrentControlSet\Control\Remote Assistance' -Name 'fAllowToGetHelp' -Type DWord -Value 1");

                    // save
                    SAVE("winpurify_remote", "0");
                }
            }
        }
        public void DISABLE_ADVERTISINGID(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Disable from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion", "AdvertisingInfo", "00000001", "true");

                // save
                SAVE("winpurify_ads", "1");
            }
            else
            {
                if (LOAD("winpurify_ads") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion", "AdvertisingInfo", "00000000", "true");

                    // save
                    SAVE("winpurify_ads", "0");
                }
            }
        }
        public void DISABLE_TRACKINGINFO(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Disable tracking processes/services
                core.CMD("sc config diagtrack start=disabled");
                core.CMD("sc config dmwappushservice start=disabled");
                core.CMD("sc config RetailDemo start=disabled");
                core.POWERSHELL(@"Set - ItemProperty - Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Sensor\Overrides\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}' - Name 'SensorPermissionState' - Type DWord - Value 0");
                core.POWERSHELL(@"Set - ItemProperty - Path 'HKLM:\System\CurrentControlSet\Services\lfsvc\Service\Configuration' - Name 'Status' - Type DWord - Value 0'");

                // save
                SAVE("winpurify_tracking", "1");
            }
            else
            {
                if (LOAD("winpurify_tracking") == "1")
                {
                    core.CMD("sc config diagtrack start=enabled");
                    core.CMD("sc config dmwappushservice start=enabled");
                    core.CMD("sc config RetailDemo start=enabled");

                    // save
                    SAVE("winpurify_tracking", "0");
                }
            }
        }
        public void DISABLE_LOGGINGSERVICES(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Disable tracking processes/services
                core.CMD("sc config diagtrack start=disabled");
                core.CMD("sc config dmwappushservice start=disabled");
                core.CMD("sc config RetailDemo start=disabled");
                // Add some key to regedit from cmd
                core.CMD(@"reg add 'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection' /v AllowTelemetry /t REG_DWORD /d 0 /f > NUL 2>&1");
                core.CMD(@"reg add 'HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\DataCollection' /v AllowTelemetry /t REG_DWORD /d 0 /f > NUL 2>&1");
                // Disable Windows tasks
                core.CMD(@"schtasks /change /TN '\Microsoft\Windows\Application Experience\Microsoft Compatibility Appraiser' /DISABLE");
                core.CMD(@"schtasks /change /TN '\Microsoft\Windows\Application Experience\ProgramDataUpdater' /DISABLE");
                core.CMD(@"schtasks /change /TN '\Microsoft\Windows\Customer Experience Improvement Program\Consolidator' /DISABLE");
                core.CMD(@"schtasks /change /TN '\Microsoft\Windows\Customer Experience Improvement Program\KernelCeipTask' /DISABLE");
                core.CMD(@"schtasks /change /TN '\Microsoft\Windows\Customer Experience Improvement Program\UsbCeip' /DISABLE");
                core.CMD(@"echo '' > C:\ProgramData\Microsoft\Diagnosis\ETLLogs\AutoLogger\AutoLogger-Diagtrack-Listener.etl");
                // Delete stored logs from regedit
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ 088e3905 - 0323 - 4b02 - 9826 - 5d99428e115f} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ 24ad3ad4 - a569 - 4530 - 98e1 - ab02f9417aa8} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ 374DE290 - 123F - 4565 - 9164 - 39C4925E467B} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ 3ADD1653 - EB32 - 4cb0 - BBD7 - DFA0ABB5ACCA} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ 3dfdf296 - dbec - 4fb4 - 81d1 - 6a3438bcf4de} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ A0953C92 - 50DC - 43bf - BE83 - 3742FED03C9C} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ A8CDFF1C - 4878 - 43be - B5FD - F8091C1C60D0} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ B4BFCC3A - DB2C - 424C - B029 - 7FE99A87C641} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ d3162b92 - 9365 - 467a - 956b - 92703aca08af} ' /f > NUL 2>&1 ");
                core.CMD(@"REG DELETE  'HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{ f86fa3ab - 70d2 - 4fc7 - 9c99 - fcbf05467f3a} ' /f > NUL 2>&1 ");

                // save
                SAVE("winpurify_logging", "1");
            }
            else
            {
                if (LOAD("winpurify_logging") == "1")
                {
                    core.CMD("sc config diagtrack start=enabled");
                    core.CMD("sc config dmwappushservice start=enabled");
                    core.CMD("sc config RetailDemo start=enabled");

                    // save
                    SAVE("winpurify_logging", "0");
                }
            }
        }
        public void DISABLE_WIFISENSE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Disable from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config\", "AutoConnectAllowedOEM", "00000001", "true");

                // save
                SAVE("winpurify_wifisense", "1");
            }
            else
            {
                if (LOAD("winpurify_wifisense") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config\", "AutoConnectAllowedOEM", "00000000", "true");

                    // save
                    SAVE("winpurify_wifisense", "0");
                }
            }
        }

        // Performance functions
        public void DISABLE_WINUPDATES(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Replace from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAutoUpdate", "00000001", "true");
                core.REGISTRY_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAutoUpdate", "00000001", "true");

                // save
                SAVE("winpurify_winupdate", "1");
            }
            else
            {
                if (LOAD("winpurify_winupdate") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAutoUpdate", "00000000", "true");
                    core.REGISTRY_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAutoUpdate", "00000000", "true");

                    // save
                    SAVE("winpurify_winupdate", "0");
                }
            }
        }
        public void DISABLE_WINDOWSEFFECTS(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Stop uxsms service
                core.POWERSHELL(@"sc stop uxsms");

                // Disable from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\AnimateMinMax", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ComboBoxAnimation", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ControlAnimations", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\CursorShadow", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DragFullWindows", "DefaultApplied", "00000001", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DropShadow", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DWMAeroPeekEnabled", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DWMEnabled", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DWMSaveThumbnailEnabled", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\FontSmoothing", "DefaultApplied", "00000001", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ListBoxSmoothScrolling", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ListviewAlphaSelect", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ListviewShadow", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\MenuAnimation", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\SelectionFade", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\TaskbarAnimations", "DefaultApplied", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\TooltipAnimation", "DefaultApplied", "00000000", "true");

                // Stop uxsms service
                core.POWERSHELL(@"sc stop uxsms");

                // save
                SAVE("winpurify_wineffects", "1");
            }
            else
            {
                if (LOAD("winpurify_wineffects") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\AnimateMinMax", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ComboBoxAnimation", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ControlAnimations", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\CursorShadow", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DragFullWindows", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DropShadow", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DWMAeroPeekEnabled", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DWMEnabled", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DWMSaveThumbnailEnabled", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\FontSmoothing", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ListBoxSmoothScrolling", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ListviewAlphaSelect", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\ListviewShadow", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\MenuAnimation", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\SelectionFade", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\TaskbarAnimations", "DefaultApplied", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\TooltipAnimation", "DefaultApplied", "00000001", "true");

                    // save
                    SAVE("winpurify_wineffects", "0");
                }
            }
        }
        public void DISABLE_WINDOWMOVING(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Stop uxsms service
                core.POWERSHELL(@"sc stop uxsms");

                // Disable from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DragFullWindows", "DefaultApplied", "00000000", "true");

                // Stop uxsms service
                core.POWERSHELL(@"sc stop uxsms");

                // save
                SAVE("winpurify_winmove", "1");
            }
            else
            {
                if (LOAD("winpurify_winmove") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DragFullWindows", "DefaultApplied", "00000001", "true");

                    // save
                    SAVE("winpurify_winmove", "0");
                }
            }
        }
        public void REMOVE_HELPFILES(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Delete files in Help folder
                core.DEL_DIR_FILES(core.GET_FIRST_DRIVE() + @"Windows\Help");

                // save
                SAVE("winpurify_help", "1");
            }
            else
            {
                if (LOAD("winpurify_help") == "1")
                {
                    // save
                    SAVE("winpurify_help", "0");
                }
            }
        }
        public void PRUNE_TEMPFOLDER(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Delete each file in Temp folder
                core.DEL_DIR_FILES(Path.GetTempPath().ToString());

                // save
                SAVE("winpurify_temp", "1");
            }
            else
            {
                if (LOAD("winpurify_temp") == "1")
                {
                    // save
                    SAVE("winpurify_temp", "0");
                }
            }
        }
        public void PRUNE_WINDOWSUPDATECACHE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Delete files in SoftwareDistribution download folder
                core.DEL_DIR_FILES(core.GET_FIRST_DRIVE() + @"Windows\SoftwareDistribution\Download");

                // save
                SAVE("winpurify_winupcache", "1");
            }
            else
            {
                if (LOAD("winpurify_winupcache") == "1")
                {
                    // save
                    SAVE("winpurify_winupcache", "0");
                }
            }
        }
        public void DISABLE_NOTIFICATIONCENTER(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Replace from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", "EnableLegacyBalloonNotifications", "00000001", "true");
                core.POWERSHELL(@"New-Item -Path 'HKCU:\Software\Policies\Microsoft\Windows\Explorer' | Out-Null");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Policies\Microsoft\Windows\Explorer' -Name 'DisableNotificationCenter' -Type DWord -Value 1");
                core.POWERSHELL(@"Set - ItemProperty - Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\PushNotifications' - Name 'ToastEnabled' -Type DWord -Value 0");

                // save
                SAVE("winpurify_notificationscenter", "1");
            }
            else
            {
                if (LOAD("winpurify_notificationscenter") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", "EnableLegacyBalloonNotifications", "00000000", "true");
                    core.POWERSHELL(@"New-Item -Path 'HKCU:\Software\Policies\Microsoft\Windows\Explorer' | Out-Null");
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Policies\Microsoft\Windows\Explorer' -Name 'DisableNotificationCenter' -Type DWord -Value 0");
                    core.POWERSHELL(@"Set - ItemProperty - Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\PushNotifications' - Name 'ToastEnabled' -Type DWord -Value 1");

                    // save
                    SAVE("winpurify_notificationscenter", "0");
                }
            }
        }
        public void DISABLE_MULTIDESKTOP(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Disable from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", "00000000", "true");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'ShowTaskViewButton' -Type DWord -Value 0");

                // save
                SAVE("winpurify_multidesktop", "1");
            }
            else
            {
                if (LOAD("winpurify_multidesktop") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", "00000001", "true");
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'ShowTaskViewButton' -Type DWord -Value 1");

                    // save
                    SAVE("winpurify_multidesktop", "0");
                }
            }
        }
        public void REPLACE_CALENDAR(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Replace from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ImmersiveShell", "UseWin32TrayClockExperience", "00000001", "true");

                // save
                SAVE("winpurify_replacecalendar", "1");
            }
            else
            {
                if (LOAD("winpurify_replacecalendar") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ImmersiveShell", "UseWin32TrayClockExperience", "00000000", "true");

                    // save
                    SAVE("winpurify_replacecalendar", "0");
                }
            }
        }
        public void REPLACE_CMD(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Replace from regedit
                core.REGISTRY_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DontUserPowerShellOnWinx", "00000000", "true");
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DontUserPowerShellOnWinx", "00000000", "true");

                // save
                SAVE("winpurify_replacecmd", "1");
            }
            else
            {
                if (LOAD("winpurify_replacecmd") == "1")
                {
                    core.REGISTRY_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DontUserPowerShellOnWinx", "00000001", "true");
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DontUserPowerShellOnWinx", "00000001", "true");

                    // save
                    SAVE("winpurify_replacecmd", "0");
                }
            }
        }
        public void DISABLE_AEROSHAKE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Disable from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows", "Explorer", "00000001", "true");

                // save
                SAVE("winpurify_aeroshake", "1");
            }
            else
            {
                if (LOAD("winpurify_aeroshake") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows", "Explorer", "00000000", "true");

                    // save
                    SAVE("winpurify_aeroshake", "0");
                }
            }
        }
        public void DISABLE_STARTUPDELAY(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Disable from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Serialize", "StartupDelayInMSec", "00000000", "true");

                // save
                SAVE("winpurify_startdelay", "1");
            }
            else
            {
                if (LOAD("winpurify_startdelay") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Serialize", "StartupDelayInMSec", "00000001", "true");

                    // save
                    SAVE("winpurify_startdelay", "0");
                }
            }
        }
        public void SHOW_EXT(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Switch from regedit
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'HideFileExt' -Type DWord -Value 0");

                // save
                SAVE("winpurify_showext", "1");
            }
            else
            {
                if (LOAD("winpurify_showext") == "1")
                {
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'HideFileExt' -Type DWord -Value 1");

                    // save
                    SAVE("winpurify_showext", "0");
                }
            }
        }
        public void DELETE_PAGEFILES(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Delete from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\CurrentControlSet\Control\Session Manager\Memory Management", "ClearPageFileAtShutDown", "00000001", "true");

                // save
                SAVE("winpurify_pagefiles", "1");
            }
            else
            {
                if (LOAD("winpurify_pagefiles") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\CurrentControlSet\Control\Session Manager\Memory Management", "ClearPageFileAtShutDown", "00000000", "true");

                    // save
                    SAVE("winpurify_pagefiles", "0");
                }
            }
        }
        public void ENABLE_LEGACYNOTIFICATIONS(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Delete from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", "Explorer", "00000001", "true");

                // save
                SAVE("winpurify_legacynotifications", "1");
            }
            else
            {
                if (LOAD("winpurify_legacynotifications") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", "Explorer", "00000000", "true");

                    // save
                    SAVE("winpurify_legacynotifications", "0");
                }
            }
        }
        public void PREVENT_UPDATESHUTDOWN(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Delete from regedit
                core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAUAsDefaultShutdownOption", "00000001", "true");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKLM:\Software\Microsoft\WindowsUpdate\UX\Settings' -Name 'UxOption' -Type DWord -Value 1");

                // save
                SAVE("winpurify_updaterestart", "1");
            }
            else
            {
                if (LOAD("winpurify_updaterestart") == "1")
                {
                    core.REGISTRY_USER_WRITE(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", "NoAUAsDefaultShutdownOption", "00000000", "true");
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKLM:\Software\Microsoft\WindowsUpdate\UX\Settings' -Name 'UxOption' -Type DWord -Value 0");

                    // save
                    SAVE("winpurify_updaterestart", "0");
                }
            }
        }
        public void SHOW_XPTASKBAR(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'TaskbarGlomLevel' -Type DWord -Value 1");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'TaskbarSmallIcons' -Type DWord -Value 1");

                // save
                SAVE("winpurify_xptaskbar", "1");
            }
            else
            {
                if (LOAD("winpurify_xptaskbar") == "1")
                {
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'TaskbarGlomLevel' -Type DWord -Value 0");
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced' -Name 'TaskbarSmallIcons' -Type DWord -Value 0");

                    // save
                    SAVE("winpurify_xptaskbar", "0");
                }
            }
        }

        // Apps functions
        public void REMOVE_UWPSUPPORT(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove UWP apps from powershell
                core.POWERSHELL(@"Get-AppxPackage -allusers | Remove-AppxPackage");

                // save
                SAVE("winpurify_uwpsupport", "1");
            }
            else
            {
                if (LOAD("winpurify_uwpsupport") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");
                    // save
                    SAVE("winpurify_uwpsupport", "0");
                }
            }
        }
        public void REMOVE_ALLPREINSTALLED(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove UWP apps (No Store)
                core.POWERSHELL(@"Get-AppxPackage -allusers | Remove-AppxPackage");
                core.POWERSHELL(@"Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.WindowsStore_2015.8.25.0_x64__8wekyb3d8bbwe\AppxManifest.xml' -DisableDevelopmentMode");

                // save
                SAVE("winpurify_preinstalled", "1");
            }
            else
            {
                if (LOAD("winpurify_preinstalled") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");
                    // save
                    SAVE("winpurify_preinstalled", "0");
                }
            }
        }
        public void DISABLE_CORTANA(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Step (1/3)
                core.POWERSHELL(@"Get-AppxPackage | Select Name, PackageFullName | Remove-AppxPackage Microsoft.Windows.Cortana_1.4.8.176_neutral_neutral_cw5n1h2txyewy");
                core.POWERSHELL(@"get-appxpackage -name 'Microsoft.Windows.Cortana' | remove-appxpackage");

                // Step (2/3)
                core.POWERSHELL(@"New-Item -Path 'HKCU:\Software\Microsoft\Personalization\Settings' -Force | Out-Null");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Personalization\Settings' -Name 'AcceptedPrivacyPolicy' -Type DWord -Value 0");
                core.POWERSHELL(@"New-Item -Path 'HKCU:\Software\Microsoft\InputPersonalization' -Force | Out-Null");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\InputPersonalization' -Name 'RestrictImplicitTextCollection' -Type DWord -Value 1");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\InputPersonalization' -Name 'RestrictImplicitInkCollection' -Type DWord -Value 1");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\InputPersonalization' -Name 'RestrictImplicitInkCollection' -Type DWord -Value 1");
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\InputPersonalization\TrainedDataStore' -Name 'HarvestContacts' -Type DWord -Value 0");

                // Step (3/3)
                core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Search' -Name 'SearchboxTaskbarMode' -Type DWord -Value 0");

                // save
                SAVE("winpurify_cortana", "1");
            }
            else
            {
                if (LOAD("winpurify_cortana") == "1")
                {
                    core.POWERSHELL(@"Set-ItemProperty -Path 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Search' -Name 'SearchboxTaskbarMode' -Type DWord -Value 1");

                    // save
                    SAVE("winpurify_cortana", "0");
                }
            }
        }
        public void DISABLE_STORE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *windowsstore* | remove-appxpackage");

                // save
                SAVE("winpurify_store", "1");
            }
            else
            {
                if (LOAD("winpurify_store") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_store", "0");
                }
            }
        }
        public void DISABLE_EDGE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *edge* | remove-appxpackage");

                // save
                SAVE("winpurify_edge", "1");
            }
            else
            {
                if (LOAD("winpurify_edge") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_edge", "0");
                }
            }
        }
        public void DISABLE_GROOVE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *zune* | remove-appxpackage");

                // save
                SAVE("winpurify_groove", "1");
            }
            else
            {
                if (LOAD("winpurify_groove") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_groove", "0");
                }
            }
        }
        public void DISABLE_OUTLOOK(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *communicationsapps* | remove-appxpackage");

                // save
                SAVE("winpurify_outlook", "1");
            }
            else
            {
                if (LOAD("winpurify_outlook") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_outlook", "0");
                }
            }
        }
        public void DISABLE_FILMSTV(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *zune* | remove-appxpackage");

                // save
                SAVE("winpurify_filmstv", "1");
            }
            else
            {
                if (LOAD("winpurify_filmstv") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_filmstv", "0");
                }
            }
        }
        public void REPLACE_PHOTOLEGACY(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                string reg_content = @"Windows Registry Editor Version 5.00\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll]\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll\\shell]\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll\\shell\\open]\r\n 'MuiVerb'='@photoviewer.dll,-3043'\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll\\shell\\open\\command]\r\n @=hex(2):25,00,53,00,79,00,73,00,74,00,65,00,6d,00,52,00,6f,00,6f,00,74,00,25,\\r\n 00,5c,00,53,00,79,00,73,00,74,00,65,00,6d,00,33,00,32,00,5c,00,72,00,75,00,\\r\n 6e,00,64,00,6c,00,6c,00,33,00,32,00,2e,00,65,00,78,00,65,00,20,00,22,00,25,\\r\n 00,50,00,72,00,6f,00,67,00,72,00,61,00,6d,00,46,00,69,00,6c,00,65,00,73,00,\\r\n 25,00,5c,00,57,00,69,00,6e,00,64,00,6f,00,77,00,73,00,20,00,50,00,68,00,6f,\\r\n 00,74,00,6f,00,20,00,56,00,69,00,65,00,77,00,65,00,72,00,5c,00,50,00,68,00,\\r\n 6f,00,74,00,6f,00,56,00,69,00,65,00,77,00,65,00,72,00,2e,00,64,00,6c,00,6c,\\r\n 00,22,00,2c,00,20,00,49,00,6d,00,61,00,67,00,65,00,56,00,69,00,65,00,77,00,\\r\n 5f,00,46,00,75,00,6c,00,6c,00,73,00,63,00,72,00,65,00,65,00,6e,00,20,00,25,\\r\n 00,31,00,00,00\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll\\shell\\open\\DropTarget]\r\n 'Clsid'='{FFE2A43C-56B9-4bf5-9A79-CC6D4285608A}'\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll\\shell\\print]\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll\\shell\\print\\command]\r\n @=hex(2):25,00,53,00,79,00,73,00,74,00,65,00,6d,00,52,00,6f,00,6f,00,74,00,25,\\r\n 00,5c,00,53,00,79,00,73,00,74,00,65,00,6d,00,33,00,32,00,5c,00,72,00,75,00,\\r\n 6e,00,64,00,6c,00,6c,00,33,00,32,00,2e,00,65,00,78,00,65,00,20,00,22,00,25,\\r\n 00,50,00,72,00,6f,00,67,00,72,00,61,00,6d,00,46,00,69,00,6c,00,65,00,73,00,\\r\n 25,00,5c,00,57,00,69,00,6e,00,64,00,6f,00,77,00,73,00,20,00,50,00,68,00,6f,\\r\n 00,74,00,6f,00,20,00,56,00,69,00,65,00,77,00,65,00,72,00,5c,00,50,00,68,00,\\r\n 6f,00,74,00,6f,00,56,00,69,00,65,00,77,00,65,00,72,00,2e,00,64,00,6c,00,6c,\\r\n 00,22,00,2c,00,20,00,49,00,6d,00,61,00,67,00,65,00,56,00,69,00,65,00,77,00,\\r\n 5f,00,46,00,75,00,6c,00,6c,00,73,00,63,00,72,00,65,00,65,00,6e,00,20,00,25,\\r\n 00,31,00,00,00\r\n \r\n [HKEY_CLASSES_ROOT\\Applications\\photoviewer.dll\\shell\\print\\DropTarget]\r\n 'Clsid'='{60fd46de-f830-4894-a628-6fa81bc0190d}'\r\n";
                core.FILE_WRITE_ALL(@"0001.reg", reg_content);
                Process regeditProcess = Process.Start(@"regedit.exe", "/s 0001.reg");

                // save
                SAVE("winpurify_photolegacy", "1");
            }
            else
            {
                if (LOAD("winpurify_photolegacy") == "1")
                {
                    // save
                    SAVE("winpurify_photolegacy", "0");
                }
            }
        }
        public void DISABLE_GETOFFICE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *officehub* | remove-appxpackage");

                // save
                SAVE("winpurify_getoffice", "1");
            }
            else
            {
                if (LOAD("winpurify_getoffice") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_getoffice", "0");
                }
            }
        }
        public void DISABLE_WEATHER(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *bingweather* | remove-appxpackage");

                // save
                SAVE("winpurify_weather", "1");
            }
            else
            {
                if (LOAD("winpurify_weather") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_weather", "0");
                }
            }
        }
        public void DISABLE_NEWS(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *bingnews* | remove-appxpackage");
                core.POWERSHELL(@"get-appxpackage *bingfinance* | remove-appxpackage");
                core.POWERSHELL(@"get-appxpackage *bingsports* | remove-appxpackage");

                // save
                SAVE("winpurify_news", "1");
            }
            else
            {
                if (LOAD("winpurify_news") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_news", "0");
                }
            }
        }
        public void DISABLE_CONTACTS(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *people* | remove-appxpackage");

                // save
                SAVE("winpurify_contacts", "1");
            }
            else
            {
                if (LOAD("winpurify_contacts") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_contacts", "0");
                }
            }
        }
        public void DISABLE_SKYPEPREVIEW(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *messaging* | remove-appxpackage");
                core.POWERSHELL(@"get-appxpackage *skypeapp* | remove-appxpackage");

                // save
                SAVE("winpurify_skypeprev", "1");
            }
            else
            {
                if (LOAD("winpurify_skypeprev") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_skypeprev", "0");
                }
            }
        }
        public void DISABLE_XBOX(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from Powershell
                core.POWERSHELL(@"get-appxpackage *xbox* | remove-appxpackage");
                core.POWERSHELL(@"get-appxpackage -name 'Microsoft.XboxGameCallableUI' | remove-appxpackage");
                core.POWERSHELL(@"get-appxpackage -name 'Microsoft.XboxIdentityProvider' | remove-appxpackage");

                // save
                SAVE("winpurify_xbox", "1");
            }
            else
            {
                if (LOAD("winpurify_xbox") == "1")
                {
                    core.POWERSHELL(@"Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register '$($_.InstallLocation)\AppXManifest.xml'}");

                    // save
                    SAVE("winpurify_xbox", "0");
                }
            }

        }
        public void DISABLE_ONEDRIVE(string set = "none")
        {
            var core = new Core();

            if (set == "none")
            {
                // Remove from PowerShell
                core.POWERSHELL(@"taskkill /f /im OneDrive.exe");
                core.POWERSHELL(@"C:\\Windows\System32\OneDriveSetup.exe /uninstall");
                core.POWERSHELL(@"C:\\Windows\SysWOW64\OneDriveSetup.exe /uninstall");

                // save
                SAVE("winpurify_onedrive", "1");
            }
            else
            {
                if (LOAD("winpurify_onedrive") == "1")
                {
                    core.POWERSHELL(@"taskkill /f /im OneDrive.exe");
                    core.POWERSHELL(@"C:\\Windows\System32\OneDriveSetup.exe");
                    core.POWERSHELL(@"C:\\Windows\SysWOW64\OneDriveSetup.exe");

                    // save
                    SAVE("winpurify_onedrive", "0");
                }
            }
        }
    }
}
