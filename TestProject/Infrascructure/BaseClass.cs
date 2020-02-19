using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.ObjectModel;
using TestProject.Infrascructure.Browsers;

namespace TestProject.Infrascructure
{
	public abstract class BaseClass
	{
		protected IWebDriver Driver;
		public bool IsMobile = false;
		protected Driver ExtendDriver;
		public static readonly Logger Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

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

		public static void CommonLoggerInfo(string message)
		{
			Logger.Information(message);
		}

		protected void OpenUrl(string url)
		{
			var jse = (IJavaScriptExecutor)Driver;
			jse.ExecuteScript("console.clear()");
			CommonLoggerInfo("Open URL: " + url);
			try
			{
				var navigate = Driver.Navigate();
				navigate.GoToUrl(url);
				if (IsElementAppeared(By.CssSelector(".code404")))
					throw new Exception("404/500 error on the page " + url);
			}
			catch (Exception)
			{
				CommonLoggerInfo("Failed to open URL: " + url);
				throw;
			}
		}

		protected void Type(By locator, string text)
		{
			var element = Driver.FindElement(locator);
			element.SendKeys(Keys.Control + "a");
			element.SendKeys(Keys.Delete);
			element.SendKeys(text);
		}

		protected void Click(By locator)
		{			
			Driver.FindElement(locator).Click();
		}

		protected string GetTextFromElement(By by)
		{
			return Driver.FindElement(by).Text;
		}

		protected ReadOnlyCollection<IWebElement> GetAllElementsLocatedBy(By by)
		{
			return Driver.FindElements(by);
		}

		protected bool IsElementAppeared(By locator)
		{
			return GetAllElementsLocatedBy(locator).Count > 0;
		}

		protected virtual void WaitForPageLoad()
		{
			var waitForDocumentReady = new WebDriverWait(Driver, TimeSpan.FromSeconds(1));
			waitForDocumentReady.Until(wdriver =>
				((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
		}
	}
}