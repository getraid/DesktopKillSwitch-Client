using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DesktopKillSwitch_Client
{
    public partial class DKSC : ServiceBase
    {


        public DKSC()
        {
            InitializeComponent();

        }
        public string Apistring { get; set; }

        private static readonly HttpClient client = new HttpClient();

        protected override void OnStart(String[] args)
        {

            var api = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\getraid", "DESKTOPKILLSWITCHAPI", "-1");
            var port = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\getraid", "DESKTOPKILLSWITCHPORT", "-1");

            //Regex to verify that the value of the user is 
            string ipPattern = @"^((25[0-5]|(2[0-4]|1[0-9]|[1-9]|)[0-9])(\.(?!$)|$)){4}$";
            bool validIp = Regex.Match(api, ipPattern).Success;

            string portPattern = @"^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$";
            bool validPort = Regex.Match(port, portPattern).Success;

            if (validIp && validPort)
            {
                var combined = "http://" + api + ":" + port;
                Apistring = combined;
            }
            else
            {
                EventLog.WriteEntry("DesktopKillSwitch", "IP or PORT are wrong / not entered. Please reinstall the program and use a valid IP and PORT for the server. " +
                 @"If you don't want to reinstall, change the settings in the Windows Registry at 'HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\getraid' ", EventLogEntryType.Error);
                Stop();
            }

            base.OnStart(args);
        }

        /// <summary>
        /// Important: https://stackoverflow.com/a/53783761
        /// </summary>
        protected override void OnShutdown()
        {

            client.PostAsync(Apistring + "/shutdown", null).Wait(30000);
            base.OnShutdown();
        }
    }
}
