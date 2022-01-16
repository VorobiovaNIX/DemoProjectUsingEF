using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProjectUsingEF.Configuration
{
    public interface ISettings
    {
        string BaseUrl { get; set; }

        bool HeadlessMode { get; set; }
        string Browser { get; set; }
        List<User> HubUsers { get; set; }
    }
}