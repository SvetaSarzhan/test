﻿using OpenQA.Selenium;
using System;
using TestProject.Infrascructure.Browsers;

namespace TestProject.PageObject
{
    class GoogleTranslatePage : BasePage
    {
        #region Locators        
        private readonly By _originalLanguageInput = By.CssSelector("[class*='orig tlid-source-tex']");
        private readonly By _translationLanguageField = By.XPath("//*[@class='tlid-translation translation']/span");
        private readonly By _swapTranslateBtn = By.CssSelector("[class*='jfk-button-narrow']");
        private readonly By _clearOriginalWordBtn = By.CssSelector("[class*='tlid-clear-source-text']");
        #endregion

        public GoogleTranslatePage(Driver driver) : base(driver)
        {
        }

        private void TypeOriginalWordToTranslate(string originalWord)
        {
            CommonLoggerInfo("");
            Type(_originalLanguageInput, originalWord);            
        }

        private string GettingTranslationFromOriginalWord()
        {
            CommonLoggerInfo("");
            WaitForAnyElementAppiarence(TimeSpan.FromSeconds(5), _translationLanguageField);
            return GetTextFromElement(_translationLanguageField);
        }

        public void ClickTotranslateViseVerse()
        {
            CommonLoggerInfo("");
            Click(_swapTranslateBtn);
            ClickToClearOriginalWord();
        }

        public void ClickToClearOriginalWord()
        {
            CommonLoggerInfo("");
            Click(_clearOriginalWordBtn);
        }

        public string TranslateWord(string originalWord)
        {
            TypeOriginalWordToTranslate(originalWord);
            return GettingTranslationFromOriginalWord();            
        }
    }
}