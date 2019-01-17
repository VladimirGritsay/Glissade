using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WinSvcApp
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            serviceInstaller1.ServiceName = "WinSvcApp_Name";
            serviceInstaller1.DisplayName = "WinSvcApp_DisplayName";
            serviceInstaller1.Description = "WinSvcApp_Description";
        }
    }
}
