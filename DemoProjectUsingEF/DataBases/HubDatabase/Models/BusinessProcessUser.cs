using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.HubDatabase.Models
{
    public partial class BusinessProcessUser
    {
        public int UserId { get; set; }
        public int Bpid { get; set; }
        public int MemberRole { get; set; }
        public byte MemberSignedOffState { get; set; }
        public DateTime? SignOffDate { get; set; }

        public virtual BusinessProcess Bp { get; set; }
        public virtual User User { get; set; }
    }
}
