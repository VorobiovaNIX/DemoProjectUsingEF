using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class ClientPostLogoutRedirectUri
    {
        public int Id { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
