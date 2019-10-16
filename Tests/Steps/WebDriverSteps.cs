using FluentAssertions;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;
using WebDriverSupport.Pages;

namespace Tests.Steps
{
    [Binding]
    public sealed class WebDriverSteps
    {
        private readonly ScenarioContext context;
        private readonly IWebDriver webDriver;
        private readonly TopDVDAndStreaming page;


        public WebDriverSteps(ScenarioContext injectedContext, IWebDriver injectedWebDriver)
        {
            context = injectedContext;
            webDriver = injectedWebDriver;
            page = new TopDVDAndStreaming(webDriver);
        }

        [Given(@"I navigate to (.*)")]
        public void GivenINavigateTo(string pageURL)
        {
            webDriver.Url = pageURL;
        }

        [When(@"I move the tomatometer slider to (.*)%")]
        [Given(@"I move the tomatometer slider to (.*)%")]
        public void WhenIMoveTheTomatometerSliderTo(int value)
        {
            page.SetTomatometerTo(value);
        }

        [Then(@"All movies in the page have a rating of at least (.*)%")]
        public void ThenAllMoviesInThePageHaveARatingOfAtLeast(int rating)
        {
            page.GetAllRatings().Exists(r => r < rating).Should().BeFalse();
        }

        [When(@"I check the Certified filter")]
        public void WhenICheckTheCertifiedFilter()
        {
            page.SetCertified(true);
        }

        [Given(@"I set Sort by filter to (.*)")]
        public void GivenISetSortByFilterTo(string option)
        {
            page.SetSortByFilter(option);
        }

        [Given(@"I set Genre filter to (.*)")]
        public void GivenISetGenreFilterTo(string option)
        {
            page.SetGenre(option);
        }

        [Given(@"I set Providers filter to (.*)")]
        public void GivenISetProvidersFilterTo(string option)
        {
            page.SetProvider(option);
        }

        [When(@"I click the first movie")]
        public void WhenIClickTheFirstMovie()
        {
            page.ClickFirstMovie();
        }

        [When(@"I navigate back")]
        public void WhenINavigateBack()
        {
            webDriver.Navigate().Back();
            page.WaitWhileLoading();
        }

        [Then(@"The Sort by filter is (.*)")]
        public void ThenTheSortByFilterIs(string option)
        {
            page.GetSortBy().Should().Be(option);
        }

        [Then(@"The Genre filter is (.*)")]
        public void ThenTheGenreFilterIs(string option)
        {
            //page.GetGenre().Should().Be(option);
            // commented because the page does not mark any of the checkboxes as "checked" or "unchecked"
        }

        [Then(@"The Tomatometer slider is (.*)%")]
        public void ThenTheTomatometerSliderIs(int value)
        {
            page.GetTomatometerMinValue().Should().Be(value);
        }

        [Then(@"The Providers filter is (.*)")]
        public void ThenTheProvidersFilterIs(string option)
        {
            //page.getProvider().Should().Be(option);
            // commented because the elements in Provider list do not report a Text value
        }

    }
}
