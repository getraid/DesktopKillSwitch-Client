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


namespace DesktopKillSwitch_Client
{
    public partial class DKSC : ServiceBase
    {
        public DKSC()
        {
            InitializeComponent();
            CanShutdown = true;
        }

        public string KillServer { get; set; } = "http://192.168.178.45:5123";

        private static readonly HttpClient client = new HttpClient();

        protected override void OnStart(string[] args)
        {
            //load ip from text file 'ip'
            try
            {
                //doesnt work. Permissions maybe? rn hardcode is the way :^)
                KillServer = System.IO.File.ReadAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"ip"));
            }
            catch
            {
           
            }

        }

        protected override void OnStop()
        {
            //test
            //try
            //{
            //    client.PostAsync(KillServer + "/shutdown", null).Wait();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        /// <summary>
        /// Important: https://stackoverflow.com/a/53783761
        /// </summary>
        protected override void OnShutdown()
        {
            client.PostAsync(KillServer + "/shutdown", null).Wait();
            base.OnShutdown();
        }
    }
}
