using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ConnectWidgetInstance
    {
        public int Id { get; set; }
        public int DashboardId { get; set; }
        public int WidgetInfoId { get; set; }
        public int Xaxis { get; set; }
        public int Yaxis { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Settings { get; set; }

        public virtual ConnectDashboard Dashboard { get; set; }
        public virtual ConnectWidgetInfo WidgetInfo { get; set; }
    }
}
