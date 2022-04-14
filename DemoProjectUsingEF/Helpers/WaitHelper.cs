using BoDi;
using DemoProjectUsingEF.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace DemoProjectUsingEF.Helpers
{
    class WaitHelper
    {
        private IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        private WebDriverWait wait;

        public WaitHelper(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
            _webDriver = _driverManager.GetDriver();
            wait = new WebDriverWait(new SystemClock(),
                                     _webDriver,
                                     TimeSpan.FromSeconds(10),
                                     sleepInterval: TimeSpan.FromMilliseconds(100));
        }

        public IWebElement ClickWait(string locator)
        {
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            ScrollToView(element);
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
            return element;
        }

        public IWebElement ClickButtonOnViewWait(string buttonLocator, string viewLocator)
        {
            ScrollIntoView(buttonLocator, viewLocator);
            return ClickWait(buttonLocator);
        }

        public IWebElement SendTextWait(string locator)
        {
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            ScrollToView(element);
            return element;
        }

        public IWebElement ExistsWait(string locator)
        {
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
            return element;
        }

        public void NavigateWait(string url)
        {
            string shortURL = url.Replace("https:", "").Replace("http:", "");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(shortURL));
            return;
        }

        public string GetPageUrl(bool isWaitNeeded = false, string waitingForURL = "")
        {
            if (isWaitNeeded) NavigateWait(waitingForURL);
            return _webDriver.Url;
        }

        public IWebElement GetTextWait(string locator)
        {
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            ScrollToView(element);
            return element;
        }

        public void ScrollToView(IWebElement element)
        {
            Actions actionProvider = new Actions(_webDriver);
            var jsDriver = (IJavaScriptExecutor)_webDriver;

            // Performs mouse move action onto the element
            try
            {
                jsDriver.ExecuteScript("window.scrollTo(0,document.body.scrollHeight);", element);

                actionProvider.MoveToElement(element).Build().Perform();
            }
            catch { }
        }

        public IWebElement ScrollIntoView(string locator)
        {
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            ClickWait(locator);

            return element;
        }

        public IWebElement ScrollIntoView(string locator, string waitArea)
        {
            IWebElement area = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(waitArea)));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locator)));
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(false);", element);
            ClickWait(locator);

            return element;
        }

        public void WaitForJavaScriptLoad(byte MaxdelaySeconds = 10)
        {
            Actions actionProvider = new Actions(_webDriver);
            var jsDriver = (IJavaScriptExecutor)_webDriver;

            int delay = MaxdelaySeconds;
            while (delay > 0)
            {
                Thread.Sleep(300);
                var jquery = (bool)jsDriver
                    .ExecuteScript("return window.jQuery == undefined");
                if (jquery)
                {
                    break;
                }
                var ajaxIsComplete = (bool)jsDriver
                    .ExecuteScript("return window.jQuery.active == 0");
                if (ajaxIsComplete)
                {
                    break;
                }
                delay--;
            }
        }

        public void ClickUntilElementExist(string searchedElement, string clickedElement, int attempts = 10, int timeout = 3000)
        {
            int _attempts = 0;
            while (_attempts < attempts)
            {
                try
                {
                    _webDriver.FindElement(By.XPath(searchedElement));
                    break;
                }
                catch
                {
                    _attempts++;
                    _webDriver.FindElement(By.XPath(clickedElement)).Click();
                    Thread.Sleep(timeout);
                }
            }
        }

        public void WaitForUrlChange(string currentUrl)
        {
            wait.Until((driver) => driver.Url != currentUrl);
        }

        public void ClickElementJS(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)_webDriver;
            jsDriver.ExecuteScript("arguments[0].click();", element);
        }

        public void Refresh()
        {
            _webDriver.Navigate().Refresh();
        }
    }
}
