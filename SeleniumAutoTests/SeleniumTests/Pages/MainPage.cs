using System.Collections.Generic;

using OpenQA.Selenium;


namespace SeleniumTests
{
    public class MainPage : PageBase
    {
        /// <summary>
        /// page url
        /// </summary>
        public const string Url = "http://abbyy-ls.ru/";

        private const int _imageCount = 5;

        private readonly string[] _tabLinkTexts = new string[_imageCount] {
            "Управление переводом",
            "Снижение издержек",
            "Инновации сервиса",
            "Качество перевода",
            "Автоматизация процессов"
        };

        private readonly string[] _imagesCss = new string[_imageCount] {
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
