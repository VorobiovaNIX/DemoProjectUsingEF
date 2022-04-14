using BoDi;
using NUnit.Framework;
using DemoProjectUsingEF.Configuration;
using DemoProjectUsingEF.Drivers;
using OpenQA.Selenium;
using DemoProjectUsingEF.Helpers;

namespace DemoProjectUsingEF.POM.GidOnline
{
    class LogInPage
    {
        private IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        private WaitHelper _waitHelper;


        readonly string ApplicationUrl = ConfigurationLoader.Settings.ApplicationUrl;
        private readonly string loginField = "//form[@id='loginform']//label/input[@id='user_login']";
        private readonly string passwordField = "//form[@id='loginform']//input[@id='user_pass']";
        private readonly string loginButton = "//input[@id='wp-submit']";
        private readonly string errorloginMessage = "//div[@id='login_error']";


        public LogInPage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _waitHelper = new WaitHelper(_objectContainer);
            _webDriver = _driverManager.GetDriver();
        }
        public LogInPage EnterLogin(string value)
        {
            IWebElement element = _webDriver.SwitchTo().Frame(0).FindElement(By.XPath(loginField));
            element.SendKeys(value);
            return this;
        }
        public LogInPage EnterPasword(string value)
        {
            IWebElement element = _waitHelper.SendTextWait(passwordField);
            element.SendKeys(value);
            return this;
        }

        public LogInPage ClickOnLoginButton()
        {
            _waitHelper.ClickWait(loginButton).Click();
            return this;
        }

        public LogInPage VerifyThatErrorDisplay()
        {
            Assert.IsTrue(_waitHelper.GetTextWait(errorloginMessage).FindElement(By.XPath(errorloginMessage)).Displayed,
                "There's no error login message");
            return this;
        }
    }
}
