using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace TestProject.Infrascructure.Browsers
{
    public class FirefoxInstance : Driver
    {
        public FirefoxInstance(bool isMobile = false) : base(isMobile)
        {
        }

        protected override IWebDriver GetInstance()
        {
            IWebDriver _instance;
            BaseClass.Logger.Information("Initialize Firefox, mobile=" + IsMobile);
            var profile = new FirefoxOptions { Profile = new FirefoxProfile { AcceptUntrustedCertificates = true } };
            if (IsMobile)
            {
                profile.SetPreference("general.useragent.override", Configuration.MobileUserAgent);
            }

            _instance = new FirefoxDriver(profile);

            if (IsMobile)
            {
                _instance.Manage().Window.Size = new Size(412, 732);
            }
            else
            {
                _instance.Manage().Window.Maximize();
            }
            _instance.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            return _instance;
        }
    }
}