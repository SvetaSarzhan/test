using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace TestProject.Infrascructure.Browsers
{
    public static class IeInstance
    {
        private static IWebDriver _instance;
        
        public static IWebDriver GetInstance()
        {
            BaseClass.Logger.Information("Initialize IE");
            var options = new InternetExplorerOptions { IgnoreZoomLevel = true };
            _instance = new InternetExplorerDriver(options);
            _instance.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            _instance.Manage().Window.Maximize();
            return _instance;
        }
    }
}