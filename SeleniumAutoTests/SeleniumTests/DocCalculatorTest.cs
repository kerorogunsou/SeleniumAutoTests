using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace SeleniumTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class DocCalculatorTest<TWebDriver> : TestBase where TWebDriver : IWebDriver, new()
    {
        DocCalculatorPage _docPage = new DocCalculatorPage();
        SelectElement _originalLanguageDropdown;
        SelectElement _translatedLanguageDropdown;

        [SetUp]
        public void Setup()
        {
            _driver = new TWebDriver();
            _driver.Navigate().GoToUrl(DocCalculatorPage.Url);
            _originalLanguageDropdown = _docPage.OriginalLanguage(_driver);
            _translatedLanguageDropdown = _docPage.TranslatedLanguage(_driver);
        }

        [Test]
        public void CheckLanguagesDropdownEmptyness()
        {
            var originalLanguages = _originalLanguageDropdown.Options;
            Assert.IsNotEmpty(originalLanguages, "Original language count is less than zero");
            var translatedLanguages = _translatedLanguageDropdown.Options;
            Assert.IsNotEmpty(translatedLanguages, "Translation language count is less than zero");
        }

        [Test]
        public void CanChooseRusToEng()
        {
            Assert.IsTrue(_docPage.CanSelectLanguage(_driver, _originalLanguageDropdown, "Русский"), "Can't select Russian as original language");
            Assert.IsTrue(_docPage.CanSelectLanguage(_driver, _translatedLanguageDropdown, "Английский"), "Can't select English as translated language");
        }
    }
}
