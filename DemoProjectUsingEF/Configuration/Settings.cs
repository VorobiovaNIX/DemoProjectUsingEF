using DemoProjectUsingEF.Configuration;
using System.Collections.Generic;

namespace BluePrism.Tests.Configuration.Configuration
{
    public class Settings : ISettings
    {
        public string ApplicationUrl { get; set; }
        public string ImsApplicationUrl { get; set; }
        public bool HeadlessMode { get; set; }
        public string Browser { get; set; }
        public List<User> HubUsers { get; set; }
    }
}