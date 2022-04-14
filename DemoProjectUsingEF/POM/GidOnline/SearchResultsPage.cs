using BoDi;
using NUnit.Framework;
using DemoProjectUsingEF.Configuration;
using DemoProjectUsingEF.Drivers;
using OpenQA.Selenium;
using DemoProjectUsingEF.Helpers;

namespace DemoProjectUsingEF.POM.GidOnline
{
    class SearchResultsPage
    {
        private IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        private WaitHelper _waitHelper;


        readonly string ApplicationUrl = ConfigurationLoader.Settings.ApplicationUrl;
        private readonly string searchButton = "//input[@id='btnSearch']";
        private readonly string searchField = "//input[@id='s']";
        private readonly string successInfoLine = "//div[@id='inls']";
        private readonly string noResultTitle = "//div[@id='searchno']";

        public SearchResultsPage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _waitHelper = new WaitHelper(_objectContainer);
            _webDriver = _driverManager.GetDriver();
        }

        public SearchResultsPage VerifyThatResultsDisplay(string searchValue)
        {
            Assert.IsTrue(_waitHelper.GetTextWait(successInfoLine).Text.Contains(searchValue),
                "There's no search results");
            return this;
        }

        public SearchResultsPage VerifyThatResultsDontDisplay()
        {
            Assert.IsTrue(_waitHelper.GetTextWait(noResultTitle)
                .Text.Contains("Ничего не найдено по запросу"), "There's no search results");
            return this;
        }
    }
}
