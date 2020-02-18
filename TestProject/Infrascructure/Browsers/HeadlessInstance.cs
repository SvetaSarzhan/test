using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestProject.Infrascructure.Browsers
{
    public  class HeadlessInstance : Driver
    {
        public HeadlessInstance(bool isMobile = false) : base(isMobile)
        {
        }

        protected override IWebDriver GetInstance()
        {
            BaseClass.Logger.Information("Initialize Headless, mobile=" + IsMobile);
            var _chromeOptions = new ChromeOptions();
            if (IsMobile)
            {
                _chromeOptions.EnableMobileEmulation("Nexus 6");
                _chromeOptions.AddArgument("--headless --disable-gpu --window-size=412,732");
            }
            else
            {
                _chromeOptions.AddArgument("--headless --disable-gpu --window-size=1320,1696");
            }
            _chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            var _instance = new ChromeDriver(_chromeOptions);
            _instance.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            return _instance;
        }
    }
}