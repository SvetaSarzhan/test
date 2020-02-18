using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;


namespace TestProject.Infrascructure.Browsers
{
    public static class OperaInstance
    {
        private static IWebDriver _instance;
        private static OperaOptions _operaOptions;
        
        public static IWebDriver GetInstance()
        {
            BaseClass.Logger.Information("Initialize Opera");
            _operaOptions = new OperaOptions {BinaryLocation = @"C:\Program Files\Opera\launcher.exe"};

            _instance = new OperaDriver(_operaOptions);
            _instance.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            _instance.Manage().Window.Maximize();
            return _instance;
        }
    }
}