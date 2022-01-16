using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class ConnectWidgetInfo
    {
        public ConnectWidgetInfo()
        {
            ConnectWidgetInstances = new HashSet<ConnectWidgetInstance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public string DescriptionFile { get; set; }
        public string ShortDescription { get; set; }
        public int Position { get; set; }
        public string PluginName { get; set; }

        public virtual ICollection<ConnectWidgetInstance> ConnectWidgetInstances { get; set; }
    }
}
