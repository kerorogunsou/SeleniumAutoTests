using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SeleniumTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class MainPageTest<TWebDriver> : TestBase where TWebDriver : IWebDriver, new()
    {
        MainPage _mainPage = new MainPage();

        [SetUp]
        public void Setup()
        {
            _driver = new TWebDriver();
            _driver.Navigate().GoToUrl(MainPage.Url);
        }

        [Test]
        public void CheckMenuImages()
        {
            var tabImgPairs = _mainPage.Tabs(_driver).Zip(_mainPage.Pictures(_driver), (tab, img) => new { Tab = tab, Img = img });
            foreach (var tabImgPair in tabImgPairs)
            {
                tabImgPair.Tab.Click();
                new WebDriverWait(_driver, TimeSpan.FromSeconds(1)).Until(d => tabImgPair.Img.Displayed);
                var valueOfImageDisplayProperty = tabImgPair.Img.GetCssValue("display");
                var errorMessage = string.Format("Picture '{0}' not displayed", tabImgPair.Tab.Text);
                Assert.AreEqual("block", valueOfImageDisplayProperty, errorMessage);
            }
        }
    }
}
