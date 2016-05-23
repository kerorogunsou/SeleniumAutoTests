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
    public class InterpretingOfferTest<TWebDriver> : TestBase where TWebDriver : IWebDriver, new()
    {
        InterpretingOfferPage _offerPage = new InterpretingOfferPage();
        SelectElement _activityDropdown;

        [SetUp]
        public void Setup()
        {
            _driver = new TWebDriver();
            _driver.Navigate().GoToUrl(InterpretingOfferPage.Url);
            _activityDropdown = _offerPage.ActivityDropdown(_driver);
        }

        [Test]
        public void CheckActivityDropdownNotEmpty()
        {
            var activityOptions = _activityDropdown.Options;
            Assert.IsNotEmpty(activityOptions, "Activity options list is empty");
        }

        [Test]
        public void CheckCanSelectAnyActivities()
        {
            int optionCount = _offerPage.ActivityDropdown(_driver).Options.Count;
            for (int optionIndex = 0; optionIndex < optionCount; optionIndex++)
            {
                Assert.IsTrue(_offerPage.CanSelectActivity(_activityDropdown, optionIndex), "Cant select activity number " + optionIndex.ToString());
            }
        }
    }
}
