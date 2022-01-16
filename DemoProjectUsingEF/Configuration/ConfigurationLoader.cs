using BluePrism.Tests.Configuration.Configuration;
using DemoProjectUsingEF.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecFlow;

namespace DemoProjectUsingEF.Utils
{

    [Binding]
    public static class ConfigurationLoader
    {
        public static readonly Lazy<IConfiguration> Config = new Lazy<IConfiguration>(() => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
#if DEBUG
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
#endif
            .Build());

        private static ConnectionStringOptions connectionStrings;
        private static UrlOptions urls;

        public static ConnectionStringOptions ConnectionString
        {
            get
            {
                if (connectionStrings is null)
                {
                    connectionStrings = new();
                    Config.Value.GetSection("ConnectionStrings").Bind(connectionStrings);
                }

                return connectionStrings;
            }
        }

        public static UrlOptions Urls
        {
            get
            {
                if (urls is null)
                {
                    urls = new();
                    Config.Value.GetSection("Urls").Bind(urls);
                }

                return urls;
            }
        }

        // public static ISettings Settings => Config.Value.GetSection(nameof(Settings)).Get<Settings>();
        public static ISettings Settings => Config.Value.GetSection(nameof(Settings)).Get<Settings>();
    }
}
