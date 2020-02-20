using OpenQA.Selenium;
using TestProject.Infrascructure;
using TestProject.Infrascructure.Browsers;
using SeleniumExtras.PageObjects;

namespace TestProject.PageObject
{
    public abstract class BasePage : BaseClass
    {
        protected BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            Driver = driver;
        }

        protected BasePage(Driver driver) : this(driver.WebDriver)
        {
            ExtendDriver = driver;
            IsMobile = driver.IsMobile;
        }
    }
}
