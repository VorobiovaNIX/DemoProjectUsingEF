using DemoProjectUsingEF.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecFlow;

namespace DemoProjectUsingEF.Utils
{

    [Binding]
    public static class ConfigurationLoader
    {
        private static readonly Lazy<IConfigurationRoot> _config = new Lazy<IConfigurationRoot>(() =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
               // .AddJsonFile("appsettings.Development.json", true)
                .Build());

        public static string HubDbConnection => _config.Value.GetConnectionString("HubDbConnection");
        public static string ImsDbConnection => _config.Value.GetConnectionString("ImsDbConnection");
        public static string InteractDbConnection => _config.Value.GetConnectionString("InteractDbConnection");
        public static string EmailServiceDbConnection => _config.Value.GetConnectionString("EmailServiceDbConnection");
        public static ISettings Settings => _config.Value.GetSection(nameof(Configuration.Settings)).Get<Settings>();

    }
}
