using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ConnectDashboard
    {
        public ConnectDashboard()
        {
            ConnectWidgetInstances = new HashSet<ConnectWidgetInstance>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconBase64 { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ConnectWidgetInstance> ConnectWidgetInstances { get; set; }
    }
}
