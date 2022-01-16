﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DemoProjectUsingEF.DataBases.ImsDatabase.Models
{
    public partial class ClientSecret
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
