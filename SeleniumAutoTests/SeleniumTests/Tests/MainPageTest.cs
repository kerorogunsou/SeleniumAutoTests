using System;
using System.Linq;

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
    public class MainPageTest<TWebDriver> : TestBase where TWebDriver : IWebDriver, new()
    {
        private MainPage _mainPage = new MainPage();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(MainPage.Url);

            _driver = new TWebDriver();
            _driver.Navigate().GoToUrl(MainPage.Url);
        }

        [Test]
        public void CheckMenuImages()
        {
            TestContext.WriteLine("\tmenu images check");

            var tabImgPairs = _mainPage.Tabs(_driver).Zip(
                _mainPage.Pictures(_driver), (tab, img) => new { Tab = tab, Img = img });
            foreach (var tabImgPair in tabImgPairs)
            {
                tabImgPair.Tab.Click();
                new WebDriverWait(_driver, TimeSpan.FromSeconds(1)).Until(d => tabImgPair.Img.Displayed);
                var valueOfImageDisplayProperty = tabImgPair.Img.GetCssValue("display");
                var errorMessage = string.Format("Picture '{0}' not displayed", tabImgPair.Tab.Text);
                var expectedValueOfImageDisplayProperty = "block";
                Assert.AreEqual(expectedValueOfImageDisplayProperty,
                    valueOfImageDisplayProperty, errorMessage);
            }
        }
    }
}
