using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class DeployedService
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DeployedServiceType { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
