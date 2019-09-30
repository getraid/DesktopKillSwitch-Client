using System;
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

namespace DesktopKillSwitch_Client
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        // https://stackoverflow.com/a/3808841
        private bool RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        protected override void OnStart(string[] args)
        {
            //check if settings exist
            if (Properties.Settings.Default.ipOfNodeServer != null && Properties.Settings.Default.port != null)
            {
                // apply ip. If can't reach ip:port/desktopkillswitch,
                if (RemoteFileExists(string.Concat(@"http//{0}:{1}/desktopkillswitch", Properties.Settings.Default.ipOfNodeServer, Properties.Settings.Default.port)))
                {
                }
                else
                {
                    // ip is invaild and service can stop
                    Stop();
                }
            }
            else
            {
                // save empty dummy settings and restart
                // OnStart(null);
            }
        }

        protected override void OnStop()
        {
        }
        protected override void OnShutdown()
        {
            //Here insert code to connect to nodeserver and send signal.
            base.OnShutdown();
        }
    }
}
