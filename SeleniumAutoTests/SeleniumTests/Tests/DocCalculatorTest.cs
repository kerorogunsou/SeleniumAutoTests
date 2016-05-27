using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class DocCalculatorTest<TWebDriver> : TestBase where TWebDriver : IWebDriver, new()
    {
        private DocCalculatorPage _docPage = new DocCalculatorPage();

        private SelectElement _originalLanguageDropdown;

        private SelectElement _translatedLanguageDropdown;

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(DocCalculatorPage.Url);

            _driver = new TWebDriver();
            _driver.Navigate().GoToUrl(DocCalculatorPage.Url);
            _originalLanguageDropdown = _docPage.OriginalLanguage(_driver);
            _translatedLanguageDropdown = _docPage.TranslatedLanguage(_driver);
        }

        [Test]
        public void CheckLanguagesDropdownEmptyness()
        {
            TestContext.WriteLine("\tlanguage dropdowns check");

            var originalLanguages = _originalLanguageDropdown.Options;
            Assert.IsNotEmpty(originalLanguages, "Original language count is less than zero");
            var translatedLanguages = _translatedLanguageDropdown.Options;
            Assert.IsNotEmpty(translatedLanguages, "Translation language count is less than zero");
        }

        [Test]
        public void CanChooseRusToEng()
        {
            TestContext.WriteLine("\tcan choose russian to english translation check");

            Assert.IsTrue(_docPage.CanSelectLanguage(_driver, _originalLanguageDropdown, "Русский"), 
                "Can't select Russian as original language");
            Assert.IsTrue(_docPage.CanSelectLanguage(_driver, _translatedLanguageDropdown, "Английский"), 
                "Can't select English as translated language");
        }
    }
}
