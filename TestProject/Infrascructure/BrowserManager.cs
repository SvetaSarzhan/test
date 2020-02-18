using System;
using TestProject.Infrascructure.Browsers;

namespace TestProject.Infrascructure
{
    internal static class BrowserManager
    {
        public static Driver GetInstance(bool mobile = false)
        {
            Driver instance;
            switch (Configuration.Browser)
            {
                case "Chrome":
                    instance = new ChromeInstance();
                    break;
                case "Firefox":
                    instance = new FirefoxInstance();
                    break;
                case "HeadLess":
                    instance = new HeadlessInstance();
                    break;
                default:
                    instance = new ChromeInstance();
                    break;
            }
            instance.WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(1);
            return instance;
        }

        public static Driver GetInstance(string browser, bool mobile = false)
        {
            Driver instance;
            switch (browser)
            {
                case "Chrome":
                    instance = new ChromeInstance(mobile);
                    break;
                case "Firefox":
                    instance = new FirefoxInstance(mobile);
                    break;
                case "HeadLess":
                    instance = new HeadlessInstance(mobile);
                    break;
                default:
                    instance = new ChromeInstance(mobile);
                    break;
            }
            instance.WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(1);
            return instance;
        }
    }
}
