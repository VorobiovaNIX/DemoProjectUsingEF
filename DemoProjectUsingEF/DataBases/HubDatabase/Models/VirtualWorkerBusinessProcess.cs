using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class VirtualWorkerBusinessProcess
    {
        public int Vwid { get; set; }
        public int Bpid { get; set; }

        public virtual BusinessProcess Bp { get; set; }
        public virtual ConnectVirtualWorker Vw { get; set; }
    }
}
