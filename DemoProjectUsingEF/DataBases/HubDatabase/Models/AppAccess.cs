using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class AppAccess
    {
        public AppAccess()
        {
            VirtualWorkerAppAccesses = new HashSet<VirtualWorkerAppAccess>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string UserName { get; set; }
        public bool IntegrationAuthentication { get; set; }
        public string Notes { get; set; }
        public int? ExpiryPeriod { get; set; }
        public int ApplicationId { get; set; }
        public int? EnvironmentId { get; set; }

        public virtual Application Application { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual ICollection<VirtualWorkerAppAccess> VirtualWorkerAppAccesses { get; set; }
    }
}
