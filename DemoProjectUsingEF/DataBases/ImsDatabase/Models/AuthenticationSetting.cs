using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class AuthenticationSetting
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
