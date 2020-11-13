using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestWindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = 60000;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            Library.WriteErrorLog("Test windows service started");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Library.WriteErrorLog("Timer ticked and som job has been done successfully");
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            Library.WriteErrorLog("Test windows service stopped");
        }
    }
}
