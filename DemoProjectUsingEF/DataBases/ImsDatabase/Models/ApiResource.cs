using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class ApiResource
    {
        public ApiResource()
        {
            ApiResourceClaims = new HashSet<ApiResourceClaim>();
            ApiResourceProperties = new HashSet<ApiResourceProperty>();
            ApiScopes = new HashSet<ApiScope>();
            ApiSecrets = new HashSet<ApiSecret>();
        }

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }

        public virtual ICollection<ApiResourceClaim> ApiResourceClaims { get; set; }
        public virtual ICollection<ApiResourceProperty> ApiResourceProperties { get; set; }
        public virtual ICollection<ApiScope> ApiScopes { get; set; }
        public virtual ICollection<ApiSecret> ApiSecrets { get; set; }
    }
}
