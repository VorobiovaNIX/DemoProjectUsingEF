using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class Customer
    {
        public Customer()
        {
            DeployedServices = new HashSet<DeployedService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public virtual ICollection<DeployedService> DeployedServices { get; set; }
    }
}
