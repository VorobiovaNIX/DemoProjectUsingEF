using BoDi;
using DemoProjectUsingEF.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProjectUsingEF.POM
{
    class LocalDataBase
    {
        IObjectContainer _objectContainer;
        private DriverManager _driverManager;
        private IWebDriver _webDriver;
        // private WaitHelper waitHelper;
       // private static AppContext context = new AppContext();

        public LocalDataBase(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driverManager = new DriverManager(_objectContainer);
           // waitHelper = new WaitHelper(_objectContainer);
            _webDriver = _driverManager.getDriver();
        }


    }
}