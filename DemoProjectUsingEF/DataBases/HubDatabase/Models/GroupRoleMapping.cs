using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class GroupRoleMapping
    {
        public int Id { get; set; }
        public int ApplicationRoleId { get; set; }
        public string Sid { get; set; }
        public string DistinguishedName { get; set; }
        public int? GroupType { get; set; }

        public virtual Role ApplicationRole { get; set; }
    }
}
