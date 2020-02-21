using System;
using TestProject.Infrascructure.Browsers;

namespace TestProject.Infrascructure
{
    internal static class BrowserManager
    {
        public static Driver GetInstance(bool mobile, string browser = null)
        {
            Driver instance;
            switch (browser ??= Configuration.Browser)
            {               
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
