using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProjectUsingEF.Configuration
{
    public class ConnectionStringOptions
    {
        public string HubDbConnection { get; set; }

        public string ImsDbConnection { get; set; }

        public string InteractDbConnection { get; set; }

        public string EmailServiceDbConnection { get; set; }
    }
}
