using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    class DocCalculatorPage : Page
    {
        public const string Url = "http://abbyy-ls.ru/doc-calculator";
        public SelectElement OriginalLanguage(IWebDriver driver)
        {
            var fromLanguage = driver.FindElement(By.Name("from-lang"));
            return new SelectElement(fromLanguage);
        }
        public SelectElement TranslatedLanguage(IWebDriver driver)
        {
            var toLanguage = driver.FindElement(By.Name("to-lang"));
            return new SelectElement(toLanguage);
        }
        public bool CanSelectLanguage(IWebDriver driver, SelectElement dropdown, string selection)
        {
            try
            {
                dropdown.SelectByText(selection);
                new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => Equals(selection, dropdown.SelectedOption.Text.Trim()));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
    }
}
