using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class License
    {
        public int Id { get; set; }
        public string PluginId { get; set; }
        public string LicenseKey { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
