using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumTests
{
    public class Page
    {
        public List<IWebElement> PhoneLabels(IWebDriver driver)
        {
            List<IWebElement> phoneLabels = new List<IWebElement>();
            phoneLabels.AddRange(driver.FindElements(By.ClassName("call_phone_1")));
            return phoneLabels;
        }
        public List<IWebElement> LanguageDropdownItems(IWebDriver driver)
        {
            IList<IWebElement> inactiveItems = driver.FindElements(By.XPath("//a[@class='lang-switcher__item']/img"));
            List<IWebElement> allItems = new List<IWebElement>();
            allItems.Add(driver.FindElement(By.XPath("//span[@class='lang-switcher__current-item_info']/img")));
            allItems.AddRange(inactiveItems);
            return allItems;
        }
    }
}
