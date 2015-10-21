using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace OfficeTime
{
    public class CheckForWorkstationLocking : IDisposable
    {
        private SessionSwitchEventHandler sseh;
        void SysEventsCheck(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock: Console.WriteLine("Lock Encountered"); break;
                case SessionSwitchReason.SessionUnlock: Console.WriteLine("UnLock Encountered"); break;
            }
        }

        public void Run()
        {
            sseh = new SessionSwitchEventHandler(SysEventsCheck);
            SystemEvents.SessionSwitch += sseh;
        }


        #region IDisposable Members

        public void Dispose()
        {
            SystemEvents.SessionSwitch -= sseh;
        }

        #endregion
    }
}
