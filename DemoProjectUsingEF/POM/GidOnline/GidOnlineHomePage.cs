using BoDi;
using NUnit.Framework;
using DemoProjectUsingEF.Configuration;
using DemoProjectUsingEF.Drivers;
using OpenQA.Selenium;
using DemoProjectUsingEF.Helpers;

namespace DemoProjectUsingEF.POM.GidOnline
{
    class GidOnlineHomePage
    {
        private IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        private WaitHelper _waitHelper;


        readonly string ApplicationUrl = ConfigurationLoader.Settings.ApplicationUrl;
        private readonly string logo = "//div[@id='headerline']//img[@title='ГидОнлайн']";
        private readonly string searchButton = "//input[@id='btnSearch']";
        private readonly string searchField = "//input[@id='s']";
        private static string sideButton(string text) => $"//a[@rel='nofollow']/span[text()='{text}']";
        private static string sectionButton(string text) => $"//div[@id='catline']/ul/li/a[text()='{text}']";


        public GidOnlineHomePage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _waitHelper = new WaitHelper(_objectContainer);
            _webDriver = _driverManager.GetDriver();
        }

        public GidOnlineHomePage VerifyThatLogoDisplays()
        {
            Assert.IsTrue(_waitHelper.GetTextWait(logo).Displayed, "There's no logo on web page");
            return this;
        }

        public GidOnlineHomePage NavigateToHomePage()
        {
            _webDriver.Navigate().GoToUrl(ApplicationUrl);
            _waitHelper.NavigateWait(ApplicationUrl);
            return this;
        }

        public GidOnlineHomePage NavigateToVesternPage()
        {
            _webDriver.Navigate().GoToUrl($"{ApplicationUrl}/genre/vestern/");
            _waitHelper.NavigateWait($"{ApplicationUrl}/genre/vestern/");
            return this;
        }

        public GidOnlineHomePage FillOutValueToTheSerchField(string value)
        {
            IWebElement element = _waitHelper.SendTextWait(searchField);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(value);
            return this;
        }

        public GidOnlineHomePage ClickOnSearchButton()
        {
            _waitHelper.ClickWait(searchButton).Click();
            return this;
        }

        public GidOnlineHomePage ClickOnSideButton(string nameButton)
        {
            _waitHelper.ClickWait(sideButton(nameButton)).Click();
            return this;
        }

        public GidOnlineHomePage ClickOnSection(string sectionName)
        {
            _waitHelper.ClickWait(sectionButton(sectionName)).Click();
            return this;
        }

    }
}
