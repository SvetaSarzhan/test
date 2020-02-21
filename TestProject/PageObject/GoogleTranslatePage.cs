using OpenQA.Selenium;
using System;
using TestProject.Infrascructure.Browsers;

namespace TestProject.PageObject
{
    class GoogleTranslatePage : BasePage
    {
        #region Locators    
        private readonly By _originalLanguageInput;
        private readonly By _translationLanguageField;
        private readonly By _swapTranslateBtn;
        private readonly By _clearOriginalWordBtn;
        private readonly By _moreLanguageBtn;
        private readonly By _ukrainianLanguageOption;
        #endregion

        public GoogleTranslatePage(Driver driver) : base(driver)
        {
            if (driver.IsMobile)
            {
                _originalLanguageInput = By.CssSelector("[class*='orig tlid-source-tex']");
                _translationLanguageField = By.XPath("//*[@class='tlid-translation translation']/span");
                _swapTranslateBtn = By.CssSelector("[class*='jfk-button-narrow']");
                _clearOriginalWordBtn = By.CssSelector("[class*='tlid-clear-source-text']");
                _moreLanguageBtn = By.CssSelector("[class*='tl-select']");
                _ukrainianLanguageOption = By.XPath("//*[contains(@class, 'language_list_tl_list')]//*[contains(@class, 'language_list_item_wrapper-uk')]");
            }
            else
            {
                _originalLanguageInput = By.CssSelector("[class*='orig tlid-source-tex']");
                _translationLanguageField = By.XPath("//*[@class='tlid-translation translation']/span");
                _swapTranslateBtn = By.CssSelector("[class*='jfk-button-narrow']");
                _clearOriginalWordBtn = By.CssSelector("[class*='tlid-clear-source-text']");
                _moreLanguageBtn = By.CssSelector("[class*='tl-more']");
                _ukrainianLanguageOption = By.XPath("//*[contains(@class, 'language_list_tl_list')]//*[contains(@class, 'language_list_item_wrapper-uk')]");
            }
        }

        private void TypeOriginalWordToTranslate(string originalWord)
        {
            CommonLoggerInfo($"Type original word {originalWord} for translation");
            Type(_originalLanguageInput, originalWord);            
        }

        public void SelectUkrainianLanguage()
        {
            CommonLoggerInfo("Select from the more language list - ukrainian");
            Click(_moreLanguageBtn);
            Click(_ukrainianLanguageOption);
        }

        private string GettingTranslationFromOriginalWord()
        {
            CommonLoggerInfo("Get the translated text");
            WaitForAnyElementAppiarence(TimeSpan.FromSeconds(5), _translationLanguageField);
            return GetTextFromElement(_translationLanguageField);
        }

        public void ClickToTranslateViseVerse()
        {
            CommonLoggerInfo("Click the vise verse button to reverse languages");
            Click(_swapTranslateBtn);
            ClickToClearOriginalWord();
        }

        public void ClickToClearOriginalWord()
        {
            CommonLoggerInfo("Click X icon to clear the input field");
            Click(_clearOriginalWordBtn);
        }

        public string TranslateWord(string originalWord)
        {
            TypeOriginalWordToTranslate(originalWord);
            return GettingTranslationFromOriginalWord();            
        }
    }
}