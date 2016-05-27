using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class InterpretingOfferPage : PageBase
    {
        /// <summary>
        /// page url
        /// </summary>
        public const string Url = "http://abbyy-ls.ru/interpreting_offer";

        private const string _activityName = "submitted[event_type]";

        public SelectElement ActivityDropdown(IWebDriver driver)
        {
            var activity = driver.FindElement(By.Name(_activityName));
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
