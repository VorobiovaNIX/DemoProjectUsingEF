using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class VirtualWorkerAppAccess
    {
        public int Vwid { get; set; }
        public int Aaid { get; set; }

        public virtual AppAccess Aa { get; set; }
        public virtual ConnectVirtualWorker Vw { get; set; }
    }
}
