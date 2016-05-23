using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class InterpretingOfferPage : Page
    {
        public const string Url = "http://abbyy-ls.ru/interpreting_offer";

        public SelectElement ActivityDropdown(IWebDriver driver)
        {
            var activity = driver.FindElement(By.Name("submitted[event_type]"));
            return new SelectElement(activity);
        }

        public bool CanSelectActivity(SelectElement dropdown, int index)
        {
            try
            {
                dropdown.SelectByIndex(index);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
    }
}
