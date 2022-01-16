using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class PasswordHistory
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
