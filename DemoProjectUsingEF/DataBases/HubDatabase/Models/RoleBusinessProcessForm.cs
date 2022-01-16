using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class RoleBusinessProcessForm
    {
        public int RoleId { get; set; }
        public int BusinessProcessFormId { get; set; }

        public virtual BusinessProcessForm BusinessProcessForm { get; set; }
        public virtual Role Role { get; set; }
    }
}
