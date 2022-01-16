using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class EnvironmentConnection
    {
        public int Id { get; set; }
        public int Timeout { get; set; }
        public int AuthType { get; set; }
        public int EnvironmentId { get; set; }
        public string ConnectionString { get; set; }
        public string ApiUrl { get; set; }

        public virtual Environment Environment { get; set; }
    }
}
