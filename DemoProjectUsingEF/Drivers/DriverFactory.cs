using DemoProjectUsingEF.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DemoProjectUsingEF.Drivers
{
    class DriverFactory
    {
        private IWebDriver _driver;
        private OptionsFactory options = new OptionsFactory();
        public IWebDriver InitLocalDriver(string browser)
        {
            var webDriverServerPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            switch (browser)
            {
                case "chrome":
                    _driver = new ChromeDriver(webDriverServerPath, options.getChromeOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
                case "firefox":
                    _driver = new FirefoxDriver(webDriverServerPath, options.getFirefoxOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
                case "edge":
                    _driver = new EdgeDriver(webDriverServerPath, options.getEdgeOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
                default:
                    _driver = new ChromeDriver(webDriverServerPath, options.getChromeOptions());
                    _driver.Manage().Window.Maximize();
                    return _driver;
            }
        }

        public IWebDriver InitRemoteDriver(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    return RemoteWebDriverBuilder(options.getChromeOptions());

                case "firefox":
                    return RemoteWebDriverBuilder(options.getFirefoxOptions());

                case "edge":
                    return RemoteWebDriverBuilder(options.getEdgeOptions());

                default:
                    return RemoteWebDriverBuilder(options.getChromeOptions());
            }
        }
        private IWebDriver RemoteWebDriverBuilder(DriverOptions options)
        {
            var settings = ConfigurationLoader.Settings;
            string hub = settings.HubApplicationUrl;
            _driver = new RemoteWebDriver(new Uri(hub), options);
            _driver.Manage().Window.Maximize();
            return _driver;
        }

    }
}