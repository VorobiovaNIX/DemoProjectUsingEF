using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProjectUsingEF.Configuration
{
    public class Settings : ISettings
    {
        public Settings() { }
        public string HubApplicationUrl { get; set; }
        public string ImsApplicationUrl { get; set; }
        public bool HeadlessMode { get; set; }
        public string Browser { get; set; }
        public List<User> HubUsers { get; set; }
        public List<EnvironmentConnection> EnvironmentManagement { get; set; }
    }
}
