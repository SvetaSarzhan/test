using NUnit.Framework;
using TestProject.Infrascructure;
using TestProject.PageObject;

namespace TestProject.Tests
{
    class GoogleTranslateTest : BaseClass
    {
        [Test, Description("")]
        public void CheckTranslateFromEnglishToUkraineAndViseVerse()
        {
            string[] orininalWord = {"dog", "spider", "penguin", "jellyfish", "dolphin", "polar bear", "crocodile"};

            string result = string.Empty;

            OpenUrl(Configuration.SiteUrl);
            GoogleTranslatePage googleTranslatePage = new GoogleTranslatePage(ExtendDriver);
            googleTranslatePage.SelectUkrainianLanguage();

            foreach (var item in orininalWord)
            {
                var translatedWordFromEnglish = googleTranslatePage.TranslateWord(item);
                googleTranslatePage.ClickTotranslateViseVerse();
                var translatedWordFromUkrainian = googleTranslatePage.TranslateWord(translatedWordFromEnglish);
                if (!item.Equals(translatedWordFromUkrainian))
                {
                    result += $"The original english word {item} doesn't translated to ukrainian correctly\n";                   
                }                
                googleTranslatePage.ClickTotranslateViseVerse();
                googleTranslatePage.ClickToClearOriginalWord();
            }
            Assert.IsTrue(string.IsNullOrEmpty(result), result);
        }
    }
}
