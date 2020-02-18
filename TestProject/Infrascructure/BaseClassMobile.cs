using NUnit.Framework;

namespace TestProject.Infrascructure
{
    public class BaseClassMobile : BaseClass
    {
        [OneTimeSetUp]
        public override void SetUp()
        {
            var currentBrowser = TestContext.Parameters.Get("Browser", "Chrome");
            Logger.Information($"Initialize browser - {currentBrowser}");
            ExtendDriver = BrowserManager.GetInstance(currentBrowser, true);
            Driver = ExtendDriver.WebDriver;
            IsMobile = ExtendDriver.IsMobile;
        }
    }
}
