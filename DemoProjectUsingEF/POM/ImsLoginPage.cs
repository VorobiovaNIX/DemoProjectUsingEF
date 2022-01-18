using BoDi;
using DemoProjectUsingEF.Configuration;
using DemoProjectUsingEF.Drivers;
using DemoProjectUsingEF.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BluePrism.Web.AutomatedUITests.POM
{
    class ImsLoginPage
    {

        private IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        private WaitHelper _waitHelper;

        private string usernameInput = $"//*[contains(.,'Username')]/following::input";
        private string passwordInput = $"//*[contains(.,'Password')]/following::input";
        private string loginButton = $"//button[contains(.,'Log in')]";
        private readonly string logOut = "//a[@href='#/account/logout']";
        private string title = "//title[.='IMS Server']";
        private string languageSelect = "//input[@role='combobox']";
        private string languagesList = "//reach-portal//li/span";
        private readonly string onPageTitle = "//h1[contains(text(), 'Dashboard')]";
        private readonly string hubButton = "//button[.='Hub']";
        private readonly string interactButton = "//button[.='Interact']";
        private static string closeButtonNotification = "//button[@aria-label='close']";

        private string interactUserAvatar = "//div[contains(@class, 'user-avatar-div')]";
        private string interactLogOutButton = "//a[@href='/account/logout']";
        readonly string imsUrl = ConfigurationLoader.Settings.ImsApplicationUrl;
        private readonly string ErrorToast = "//div[contains(@class, 'toast--error')]//span";

        public ImsLoginPage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _waitHelper = new WaitHelper(_objectContainer);
            _webDriver = _driverManager.GetDriver();
        }

        public ImsLoginPage SendTextToUsernameInput(string username)
        {
            IWebElement element = _waitHelper.SendTextWait(usernameInput);
            element.SendKeys(username);
            return this;
        }

        public ImsLoginPage SendTextToPasswordInput(string password)
        {
            IWebElement element = _waitHelper.SendTextWait(passwordInput);
            element.SendKeys(password);
            return this;
        }

        public ImsLoginPage ClickLogIn()
        {
            IWebElement element = _waitHelper.ClickWait(loginButton);
            element.FindElement(By.XPath(loginButton)).Click();
            return this;
        }

        public ImsLoginPage NavigateToIMS()
        {
            _webDriver.Navigate().GoToUrl(imsUrl);
            _waitHelper.NavigateWait(imsUrl);
            return this;
        }

        public ImsLoginPage NavigateToRegistrationPage()
        {
            var url = ($"{imsUrl}/#/user-registration");
            _webDriver.Navigate().GoToUrl(url);
            _waitHelper.NavigateWait(url);
            return this;
        }

        public ImsLoginPage VerifyThatLogInPageIsOpened()
        {
            Assert.That(() => _imsLoginPageMap.GetPageUrl().StartsWith($"{ConfigurationLoader.Settings.ImsApplicationUrl}/#/account/login"),
                Is.True.After(5).Seconds.PollEvery(100), "There is not IMS Log in page");
            return this;
        }

        public ImsLoginPage VerifyListOfLanguages(List<String> expectedLanguages)
        {
            _imsLoginPageAssertions.AreEqual(expectedLanguages, _imsLoginPageMap.GetListOfTexts(languagesList), $"List of languages is not correct");
            return this;
        }

        public ImsLoginPage GoToHub()
        {
            _imsLoginPageMap.ClickButton(hubButton);
            return this;
        }

        public ImsLoginPage GoToInteract()
        {
            _imsLoginPageMap.ClickButton(interactButton);
            return this;
        }


        public ImsLoginPage LogOut()
        {
            _imsLoginPageMap.ClickButton(logOut);
            _imsLoginPageMap.GetElement(usernameInput);
            return this;
        }

        public ImsLoginPage CloseNotification()
        {
            _imsLoginPageMap.ClickButton(closeButtonNotification);
            return this;
        }
        public ImsLoginPage VerifyThatWelcomePageIsOpened()
        {
            _imsLoginPageAssertions.IsTrue(_imsLoginPageMap.GetPageUrl(true, $"{ConfigurationLoader.Settings.ImsApplicationUrl}/#/welcome").StartsWith($"{ConfigurationLoader.Settings.ImsApplicationUrl}/#/welcome"), "This is not IMS Welcome page");
            return this;
        }

        public ImsLoginPage VerifyThatErrorMessageIsDisplayed(string message)
        {
            _imsLoginPageAssertions.IsTrue(_imsLoginPageMap.GetElement(ErrorToast).Displayed, "Toaster notification is not displayed");
            _imsLoginPageAssertions.AreEqual(message, _imsLoginPageMap.GetText(ErrorToast), "Error message is incorrect.");
            return this;
        }
    }
}
