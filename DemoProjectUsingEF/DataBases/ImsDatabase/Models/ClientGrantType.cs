﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class ClientGrantType
    {
        public int Id { get; set; }
        public string GrantType { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
