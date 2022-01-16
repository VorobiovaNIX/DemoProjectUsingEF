using System;
using TechTalk.SpecFlow;
using BoDi;
using OpenQA.Selenium;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using DemoProjectUsingEF.Utils;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(1)]
namespace DemoProjectUsingEF.Drivers
{
    [Binding]
    class DriverManager
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private DriverFactory driverFactory;
        private static string _browser;
        private static bool _environmentRemote = false;

        public DriverManager(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            driverFactory = new DriverFactory();
        }

        [BeforeTestRun]
        public static void SetEnvironment()
        {
            var settings = ConfigurationLoader.Settings;
            _browser = settings.Browser;
        }

        [BeforeScenario]
        public void SelectBrowser()
        {
            Initialize();
        }

        public void Initialize()
        {

            //local
            if (!_environmentRemote)
            {
                _driver = driverFactory.InitLocalDriver(_browser);
                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)_driver;
                allowsDetection.FileDetector = new LocalFileDetector();
            }
            //remote
            else if (_environmentRemote)
            {
                _driver = driverFactory.InitRemoteDriver(_browser);
                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)_driver;
                allowsDetection.FileDetector = new LocalFileDetector();
            }
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver, "driver");
        }

        public IWebDriver GetDriver()
        {
            _driver = _objectContainer.Resolve<IWebDriver>("driver");
            return _driver;
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }


    }
}
