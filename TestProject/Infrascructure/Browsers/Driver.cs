using OpenQA.Selenium;

namespace TestProject.Infrascructure.Browsers
{
    public abstract class Driver
    {
        public bool IsMobile { get; set; }

        public IWebDriver WebDriver { get; set; }

        protected Driver(bool isMobile)
        {
            IsMobile = isMobile;
            WebDriver = GetInstance();
        }

        protected abstract IWebDriver GetInstance();

        ~Driver()
        {
            WebDriver.Quit();
        }
    }
}
