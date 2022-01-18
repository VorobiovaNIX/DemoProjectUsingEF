using BoDi;
using DemoProjectUsingEF.DataBases.HubDatabase;
using TechTalk.SpecFlow;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DemoProjectUsingEF.Configuration;

namespace DemoProjectUsingEF.Steps.DBSteps
{
    [Binding]
    class HubDatabaseSteps
    {

        private IObjectContainer _objectContainer;
        private HubContext _dbContext;
        public static Lazy<IServiceProvider> LazyProviderHub { get => _lazyProviderHub; set => _lazyProviderHub = value; }
        private static Lazy<IServiceProvider> _lazyProviderHub = new Lazy<IServiceProvider>(() =>
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<HubContext>(options => options.UseSqlServer(ConfigurationLoader.HubDbConnection));
            var provider = serviceCollection.BuildServiceProvider();
            return provider;
        });

        public HubDatabaseSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _objectContainer.RegisterInstanceAs(_lazyProviderHub.Value, "hubServiceProvider");

        }

        [Given(@"Clean up Hub DB")]
        public void CleanUpHubDb()
        {
            _dbContext = LazyProviderHub.Value.GetService<HubContext>();
            CleanUp.Clean(_dbContext);
        }
    }
}
