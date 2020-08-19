using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace DesktopKillSwitch_Client
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent(); 
            dkscServiceInstaller.AfterInstall += (sender2, args) => new ServiceController(dkscServiceInstaller.ServiceName).Start();
        }

    }
}
