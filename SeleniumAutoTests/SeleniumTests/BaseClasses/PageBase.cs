using OpenQA.Selenium;
using System.Collections.Generic;


namespace SeleniumTests
{
    public abstract class PageBase
    {
        private const string _phoneClass = "call_phone_1";

        private const string _inactiveLanguageXpath = "//a[@class='lang-switcher__item']/img";

        private const string _activeLanguageXpath = "//span[@class='lang-switcher__current-item_info']/img";

        public List<IWebElement> PhoneLabels(IWebDriver driver)
        {
            List<IWebElement> phoneLabels = new List<IWebElement>();

            phoneLabels.AddRange(driver.FindElements(By.ClassName(_phoneClass)));
            return phoneLabels;
        }
        public List<IWebElement> LanguageDropdownItems(IWebDriver driver)
        {
            IList<IWebElement> inactiveItems = driver.FindElements(By.XPath(_inactiveLanguageXpath));
            List<IWebElement> allItems = new List<IWebElement>();

            allItems.Add(driver.FindElement(By.XPath(_activeLanguageXpath)));
            allItems.AddRange(inactiveItems);
            return allItems;
        }
    }
}
