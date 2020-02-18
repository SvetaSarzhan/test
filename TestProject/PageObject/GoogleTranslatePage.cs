using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.PageObject
{
    class GoogleTranslatePage
    {
        #region Locators
        private readonly By _moreLaguagesTranslatioBlock = By.CssSelector("[class*='tl-more']");
        private readonly By _moreLanguagesOriginalBlock = By.CssSelector("[class*='sl-more']");
        private readonly By _englishLanguageMoreList = By.XPath("//*[contains(@aria-label, 'English')]");
        private readonly By _ukrainianLanguageTranslation = By.XPath("//div[contains(@class, 'tl_list')]//*[contains(text(), 'Ukrainian')]");
        private readonly By _originalLanguageInput = By.CssSelector("[class*='orig tlid-source-tex']");
        private readonly By _translationLanguageField = By.XPath("//*[@class='tlid-translation translation']/span");
        #endregion


    }
}
