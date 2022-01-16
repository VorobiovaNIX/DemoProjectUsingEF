using DemoProjectUsingEF.Configuration;
using System.Collections.Generic;

namespace BluePrism.Tests.Configuration.Configuration
{
    public class Settings : ISettings
    {
        public string BaseUrl { get; set; }

        public bool HeadlessMode { get; set; }
        public string Browser { get; set; }
        public List<User> HubUsers { get; set; }
    }
}