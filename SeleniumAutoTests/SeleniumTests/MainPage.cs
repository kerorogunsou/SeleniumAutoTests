using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumTests
{
    public class MainPage : Page
    {
        public const string Url = "http://abbyy-ls.ru/";
        public const int ImageCount = 5;

        string[] _tabLinkTexts = new string[ImageCount] {
            "Управление переводом",
            "Снижение издержек",
            "Инновации сервиса",
            "Качество перевода",
            "Автоматизация процессов"
        };

        string[] _imagesCss = new string[ImageCount] {
            ".frontslider2-rightcol-item.slide.item1 .frontslider2bg",
            ".frontslider2-rightcol-item.slide.item5 .frontslider2bg",
            ".frontslider2-rightcol-item.slide.item3 .frontslider2bg",
            ".frontslider2-rightcol-item.slide.item4 .frontslider2bg",
            ".frontslider2-rightcol-item.slide.item2 .frontslider2bg"
        };

        public IEnumerable<IWebElement> Tabs(IWebDriver driver)
        {
            foreach (var tab in _tabLinkTexts)
            {
                yield return driver.FindElement(By.LinkText(tab));
            }
        }

        public IEnumerable<IWebElement> Pictures(IWebDriver driver)
        {
            foreach (var image in _imagesCss)
            {
                yield return driver.FindElement(By.CssSelector(image));
            }
        }
    }
}
