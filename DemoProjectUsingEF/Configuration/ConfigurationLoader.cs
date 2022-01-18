using BluePrism.Tests.Configuration.Configuration;
using DemoProjectUsingEF.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecFlow;

namespace DemoProjectUsingEF.Configuration
{

    [Binding]
    public static class ConfigurationLoader
    {

        private static readonly Lazy<IConfigurationRoot> _config = new Lazy<IConfigurationRoot>(() =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", true)
                .Build());

        public static string HubDbConnection => _config.Value.GetConnectionString("HubDbConnection");
        public static string ImsDbConnection => _config.Value.GetConnectionString("ImsDbConnection");
        public static ISettings Settings => _config.Value.GetSection("Settings").Get<Settings>();

    }
}
