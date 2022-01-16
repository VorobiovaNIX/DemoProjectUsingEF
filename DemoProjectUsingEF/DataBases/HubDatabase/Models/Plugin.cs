using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Plugin
    {
        public Plugin()
        {
            RolePlugins = new HashSet<RolePlugin>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RolePlugin> RolePlugins { get; set; }
    }
}
