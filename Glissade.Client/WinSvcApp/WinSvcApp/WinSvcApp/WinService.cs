using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinSvcApp
{
    partial class WinService : ServiceBase
    {
        private readonly Thread _workerMain;
        private bool _isWorking = true;

        public WinService()
        {
            InitializeComponent();
            _workerMain = new Thread(WorkerMain) { IsBackground = true };
        }


        public void StartInternal()
        {
            OnStart(null);
        }

        public void StopInternal()
        {
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            _isWorking = true;
            _workerMain.Start();
            // TODO: Add code here to start your service.
        }

        protected override void OnStop()
        {
            _isWorking = false;
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        [STAThread]
        private void WorkerMain()
        {
            while (_isWorking)
            {
                //Do something
                Thread.Sleep(2000);
            }
        }
    }
}
