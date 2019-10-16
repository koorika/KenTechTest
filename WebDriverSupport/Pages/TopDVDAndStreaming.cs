using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace WebDriverSupport.Pages
{
    public class TopDVDAndStreaming
    {
        private string[] genres = {
            "Action", "Animation", "Art & Foreign", "Classics", "Comedy", "Documentary",
            "Drama", "Horror", "Kids & Family", "Mystery", "Romance", "Sci-fi & Fantasy"
        };

        private string[] providers = {
            "FandangoNOW", "Netflix Streaming", "iTunes", "Amazon", "Amazon Prime", "HBO GO", "Vudu"
        };

        private By PageTitleLocator = By.CssSelector("#page-title");

        private By TomatometerLocator = By.CssSelector("#tomatometerFilter");
        private By MinTomatometerLocator = By.CssSelector("#tomatometerFilter > div > div.slider-wrapper > div > div > div:nth-child(1) > div");
        private By TomatometerBaseLocator = By.CssSelector("#tomatometerFilter > div > div.slider-wrapper > div > div");
        private By MeterScores = By.CssSelector("div.movie_info > a > div > span > span.tMeterScore");
        private By CertifiedCheckboxLocator = By.CssSelector("#cf-checkbox");
        private By SortByDropDown = By.CssSelector("#sort-dropdown > button");
        private string SortByOption = "div[data-sort-option='{0}']";
        private By SortOptionSelection = By.CssSelector("#sort-dropdown > div > div.sortoption.selected");
        private By GenreDropdown = By.CssSelector("#genre-dropdown > button");
        private string GenreOptionLocator = "#genre-dropdown > div > div > div:nth-child({0}) > span";
        
        private By ProvidersDropdown = By.CssSelector("#service-dropdown > button");
        private string ProvidersOptionLocator = "#service-dropdown > div > div > div:nth-child({0}) > span";
        private By ProvidersSelectionLocator = By.CssSelector("#service-dropdown > div > div > div.service.selected");
        private By FirstMovieLocator = By.CssSelector("#content-column > div:nth-child(5) > div.mb-movies > div:nth-child(2) > div.poster_container > a > img");


        private readonly IWebDriver driver;

        public TopDVDAndStreaming(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickFirstMovie()
        {
            driver.FindElement(FirstMovieLocator).Click();
        }

        public string GetSortBy()
        {
            return driver.FindElement(SortOptionSelection).GetAttribute("data-sort-option");
        }

        public void SetTomatometerTo(int value)
        {
            Actions actions = new Actions(driver);
            IWebElement TomatometerElement = driver.FindElement(TomatometerLocator);
            TomatometerElement.Click();
            IWebElement MinTomatometerElement = driver.FindElement(MinTomatometerLocator);
            IWebElement TomatometerBaseElement = driver.FindElement(TomatometerBaseLocator);
            int xOffset = MinTomatometerElement.Location.X- TomatometerBaseElement.Location.X;
            int yOffset = MinTomatometerElement.Location.Y - TomatometerBaseElement.Location.Y;
            actions.DragAndDropToOffset(MinTomatometerElement, xOffset, yOffset).Build().Perform();
            TomatometerElement.Click();
            xOffset = (int)(value / 100f * (TomatometerBaseElement.Size.Width));
            actions.DragAndDropToOffset(MinTomatometerElement, xOffset, yOffset).Build().Perform();
            MoveToPageTitle();
        }

        public void MoveToPageTitle()
        {
            IWebElement PageTitleElement = driver.FindElement(PageTitleLocator);
            Actions actions = new Actions(driver);
            actions.MoveToElement(PageTitleElement).Build().Perform();
        }

        public string getProvider()
        {
            //return driver.FindElement(ProvidersSelectionLocator).Text;
            return "Nope. That's the right locator but Text comes up empty.";
        }

        public string GetGenre()
        {
            return "Nope. No locator can resolve this. All elements withing the Genre selection are identical, either selected or not";
        }

        public void SetGenre(string option)
        {
            IWebElement GenreDropDownElement = driver.FindElement(GenreDropdown);
            GenreDropDownElement.Click();
            int index = Array.IndexOf(genres, option) + 1;
            IWebElement GenreOptionElement = driver.FindElement(
                By.CssSelector(GenreOptionLocator.Replace("{0}", index + "")));
            Actions actions = new Actions(driver);
            actions.MoveToElement(GenreOptionElement).Build().Perform();
            GenreOptionElement.Click();
            MoveToPageTitle();
        }

        public void SetProvider(string option)
        {
            IWebElement ProviderDropDownElement = driver.FindElement(ProvidersDropdown);
            ProviderDropDownElement.Click();
            int index = Array.IndexOf(providers, option) + 1;
            IWebElement ProvidersOptionElement = driver.FindElement(
                By.CssSelector(ProvidersOptionLocator.Replace("{0}", index + "")));
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProvidersOptionElement).Build().Perform();
            ProvidersOptionElement.Click();
            MoveToPageTitle();
        }

        public int GetTomatometerMinValue()
        {
            IWebElement MinTomatometerElement = driver.FindElement(MinTomatometerLocator);
            IWebElement TomatometerBaseElement = driver.FindElement(TomatometerBaseLocator);
            return (int)((float)(MinTomatometerElement.Location.X - TomatometerBaseElement.Location.X) /
                (TomatometerBaseElement.Size.Width - TomatometerBaseElement.Location.X));
        }

        public List<int> GetAllRatings()
        {
            WaitWhileLoading();
            List<int> result = new List<int>();
            var AllMeterScores = driver.FindElements(MeterScores);
            foreach (var item in AllMeterScores)
            {
                result.Add(int.Parse(item.Text.Replace("%", "")));
            }
            return result;
        }

        public void WaitWhileLoading()
        {
            string selector = "#main-row > div";
            WebDriverWait waiter = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            waiter.PollingInterval = new TimeSpan(0, 0, 1);
            bool firstwaitTimeout = false;
            try
            {
                if (waiter.Until(driver => driver.FindElement(By.CssSelector(selector)).GetAttribute("style").Contains("opacity")))
                {
                    firstwaitTimeout = true;
                    waiter.Until(driver => !driver.FindElement(By.CssSelector(selector)).GetAttribute("style").Contains("opacity"));
                }
            }
            catch (Exception ex)
            {
                if (firstwaitTimeout) throw ex;
                //it's ok to timeout on the first wait
            }
        }

        public void SetCertified(bool certified)
        {
            IWebElement TomatometerElement = driver.FindElement(TomatometerLocator);
            TomatometerElement.Click();
            IWebElement CertifiedElement = driver.FindElement(CertifiedCheckboxLocator);
            CertifiedElement.Click();// this needs much more TLC to be at its best
            MoveToPageTitle();
        }

        public void SetSortByFilter(string option)
        {
            IWebElement SortByDropDownElement = driver.FindElement(SortByDropDown);
            SortByDropDownElement.Click();
            driver.FindElement(By.CssSelector(SortByOption.Replace("{0}", option))).Click();
            MoveToPageTitle();
        }

    }
}
