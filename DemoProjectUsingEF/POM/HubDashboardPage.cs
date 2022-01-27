using BoDi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using DemoProjectUsingEF.Configuration;
using DemoProjectUsingEF.Drivers;
using OpenQA.Selenium;
using DemoProjectUsingEF.Helpers;

namespace DemoProjectUsingEF.POM
{
    class HubDashboardPage
    {
        private IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        private WaitHelper _waitHelper;


        readonly string HubUrl = ConfigurationLoader.Settings.HubApplicationUrl;
        private readonly string onPageTitle = "//main//h1";
        private readonly string logOut = "//a[@href='#/account/logout']";
        private string CloseDrawer = $"//div[@data-testid='add-widgets-drawer']//button[contains(., 'Close drawer')]";
        private string Next = $"//button[contains(.,'Next')]";
        public static string buttonOnAreYouSureModal(string buttonName) => $"//div[contains(@class, 'modal')]//div[@aria-hidden='false']//div//button[text()='{buttonName}']";
        public static string pageOnBreadcrumbs(string webpage) => $"//div/nav[@aria-label='breadcrumb']//li/a[text()='{webpage}']";

        public HubDashboardPage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _waitHelper = new WaitHelper(_objectContainer);
            _webDriver = _driverManager.GetDriver();
        }

        public HubDashboardPage VerifyThatItIsDashboardPage()
        {
            Assert.AreEqual("Dashboard", _waitHelper.ClickWait(onPageTitle).Text, "It is not Hub Dasboard page");
            return this;
        }

        public HubDashboardPage NavigateToDashboard()
        {
            _webDriver.Navigate().GoToUrl($"{HubUrl}/#/dashboard");
            _waitHelper.NavigateWait($"{HubUrl}/#/dashboard");
            return this;
        }

        public HubDashboardPage ClickOnBreadcrumbsNavigation(string webPage)
        {
            _waitHelper.ClickWait(pageOnBreadcrumbs(webPage)).Click();
            return this;
        }

        public HubDashboardPage ClickOnButtonOnAreYouSureModal(string buttonName)
        {
            _waitHelper.ClickWait(pageOnBreadcrumbs(buttonOnAreYouSureModal(buttonName))).Click();
            return this;
        }

        public HubDashboardPage GetHubPageTitle()
        {
            _hubContext.StoreTextValue(_hubDashboardMap.GetText(onPageTitle), "DashboardTitle");
            return this;
        }

        public HubDashboardPage ClickLogOutButton()
        {
            _waitHelper.ClickWait(logOut).Click();
            return this;
        }
    }
}
