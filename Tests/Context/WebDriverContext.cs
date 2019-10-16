using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverSupport;

namespace Tests.Context
{
    [Binding]
    public class WebDriverContext
    {

        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;

        public WebDriverContext(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            driver = new BrowserManager().NewDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            driver.Quit();
            driver = null;
        }

    }
}
