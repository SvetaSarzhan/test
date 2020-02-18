using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using Serilog.Core;
using TestProject.Infrascructure.Browsers;

namespace TestProject.Infrascructure
{
	public abstract class BaseClass
	{
		protected IWebDriver Driver;
		public bool IsMobile = false;
		protected Driver ExtendDriver;
		public static readonly Logger Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();


		public static void CommonLoggerInfo(string message)
		{
			Logger.Information(message);
		}

		// Web driver set up
		[OneTimeSetUp]
		public virtual void SetUp()
		{
			var currentBrowser = TestContext.Parameters.Get("Browser", "Chrome");
			Logger.Information("Initialize browser");
			ExtendDriver = BrowserManager.GetInstance();
			Driver = ExtendDriver.WebDriver;
		}

		// Web driver quit
		[OneTimeTearDown]
		public virtual void TearDown()
		{
			Logger.Information("Tear down");
			if (Driver != null)
			{
				Driver.Quit();
				Driver = null;
			}
		}
	}
}