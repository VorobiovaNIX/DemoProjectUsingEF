using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class RolePlugin
    {
        public int RoleId { get; set; }
        public int PluginId { get; set; }

        public virtual Plugin Plugin { get; set; }
        public virtual Role Role { get; set; }
    }
}
