using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class ActiveDirectoryDomain
    {
        public int Id { get; set; }
        public string DistinguishedName { get; set; }
    }
}
