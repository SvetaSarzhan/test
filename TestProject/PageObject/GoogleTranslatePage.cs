using OpenQA.Selenium;
using TestProject.Infrascructure.Browsers;

namespace TestProject.PageObject
{
    class GoogleTranslatePage : BasePage
    {
        #region Locators        
        private readonly By _originalLanguageInput = By.CssSelector("[class*='orig tlid-source-tex']");
        private readonly By _translationLanguageField = By.XPath("//*[@class='tlid-translation translation']/span");
        private readonly By _swapTranslate = By.CssSelector("[class*='jfk-button-narrow']");
        #endregion

        public GoogleTranslatePage(Driver driver) : base(driver)
        {
        }

        private void TypeOriginalWordToTranslate(string originalWord)
        {
            CommonLoggerInfo("");
            Type(_originalLanguageInput, originalWord);
            WaitForPageLoad();
        }

        private string GettingTranslationFromOriginalWord()
        {
            CommonLoggerInfo("");
            return GetTextFromElement(_translationLanguageField);
        }

        public void ClickTotranslateViseVerse()
        {
            CommonLoggerInfo("");
            Click(_swapTranslate);
        }

        public string TranslateWord(string originalWord)
        {
            TypeOriginalWordToTranslate(originalWord);
            return GettingTranslationFromOriginalWord();
        }
    }
}