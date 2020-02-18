using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject.Infrascructure.Browsers
{
	public class ChromeInstance : Driver
	{
		public ChromeInstance(bool isMobile = false) : base(isMobile)
		{
		}

		protected override IWebDriver GetInstance()
		{
			BaseClass.Logger.Information("Initialize Chrome, mobile=" + IsMobile);
			var _chromeOptions = new ChromeOptions();

			if (IsMobile)
			{
				_chromeOptions.EnableMobileEmulation("Nexus 5");
				_chromeOptions.AddArgument("--window-size=385,740");
				_chromeOptions.AddArgument("disable-infobars");
			}
			else
			{
				_chromeOptions.AddArgument("--start-maximized");
			}

			_chromeOptions.AddArgument("no-sandbox");
			_chromeOptions.AddArgument("disable-notifications");

			_chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);

			ChromeDriver _instance = new ChromeDriver(_chromeOptions);

			_instance.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);

			return _instance;
		}
	}
}