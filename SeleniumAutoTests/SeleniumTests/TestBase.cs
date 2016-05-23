using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using System;
using System.Drawing.Imaging;

namespace SeleniumTests
{
    public abstract class TestBase
    {
        protected IWebDriver _driver;
        Page _page = new Page();

        [Test]
        public void CheckPhone()
        {
            var phoneLabels = _page.PhoneLabels(_driver);
            var phoneIsVisible = phoneLabels.Exists(p => p.GetCssValue("display") != "none");
            Assert.IsTrue(phoneIsVisible, "Phone number is not visible");
        }

        [Test]
        public void CheckLanguages()
        {
            var languageOptions = _page.LanguageDropdownItems(_driver);
            Assert.IsTrue(languageOptions.Exists(p => p.GetAttribute("alt") == "RU"), "Language menu doesnt contain russian lanuage");
            Assert.IsTrue(languageOptions.Exists(p => p.GetAttribute("alt") == "ENG"), "Language menu doesnt contain english lanuage");
            Assert.IsTrue(languageOptions.Exists(p => p.GetAttribute("alt") == "DE"), "Language menu doesnt contain german lanuage");
            Assert.IsTrue(languageOptions.Exists(p => p.GetAttribute("alt") == "UK"), "Language menu doesnt contain ukraine lanuage");
        }

        [TearDown]
        public void Teardown()
        {
            if(TestContext.CurrentContext.WorkDirectory == null)
            {
                System.IO.File.WriteAllText("error log.txt", "probably wrong NUnit runner version");
                TakeScreenshot(" unable to get test result");
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string errorInfo = TestContext.CurrentContext.Result.Message.Split(new char[] { '\n', '\r' })[0];
                TakeScreenshot(errorInfo);
            }
            _driver.Quit();
        }

        private void TakeScreenshot(string info)
        {
            var screenshotDriver = _driver as ITakesScreenshot;
            string time = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            screenshotDriver.GetScreenshot().SaveAsFile(time + info + ".png", ImageFormat.Png);
        }
    }
}
