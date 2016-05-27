using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests
{
    class DocCalculatorPage : PageBase
    {
        /// <summary>
        /// page url
        /// </summary>
        public const string Url = "http://abbyy-ls.ru/doc-calculator";

        private const string _fromLanguageName = "from-lang";

        private const string _toLanguageName = "to-lang";

        public SelectElement OriginalLanguage(IWebDriver driver)
        {
            var fromLanguage = driver.FindElement(By.Name(_fromLanguageName));
            return new SelectElement(fromLanguage);
        }

        public SelectElement TranslatedLanguage(IWebDriver driver)
        {
            var toLanguage = driver.FindElement(By.Name(_toLanguageName));
            return new SelectElement(toLanguage);
        }

        public bool CanSelectLanguage(IWebDriver driver, SelectElement dropdown, string selection)
        {
            try
            {
                dropdown.SelectByText(selection);
                new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
                    d => Equals(selection, dropdown.SelectedOption.Text.Trim())
                    );
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
    }
}
