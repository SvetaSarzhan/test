using NUnit.Framework;
using TestProject.Infrascructure;
using TestProject.PageObject;

namespace TestProject.Tests
{
    class GoogleTranslateMobileTest : BaseClassMobile
    {
        [Test, Description("Checking translate words from english to ukrainian")]
        public void CheckTranslateFromEnglishToUkraineAndViseVerse()
        {
            string[] originalWord = { "dog", "spider", "penguin", "jellyfish", "dolphin", "polar bear", "crocodile" };

            string result = string.Empty;

            OpenUrl(Configuration.SiteUrl);
            GoogleTranslatePage googleTranslatePage = new GoogleTranslatePage(ExtendDriver);
            googleTranslatePage.SelectUkrainianLanguage();

            foreach (var item in originalWord)
            {
                var translatedWordFromEnglish = googleTranslatePage.TranslateWord(item);
                googleTranslatePage.ClickToTranslateViseVerse();
                var translatedWordFromUkrainian = googleTranslatePage.TranslateWord(translatedWordFromEnglish);
                if (!item.Equals(translatedWordFromUkrainian))
                {
                    result += $"The original english word {item} doesn't translated to ukrainian correctly\n";
                }
                googleTranslatePage.ClickToTranslateViseVerse();
                googleTranslatePage.ClickToClearOriginalWord();
            }
            Assert.IsTrue(string.IsNullOrEmpty(result), result);
        }
    }
}
