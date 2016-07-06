using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Selenium_Simple_Example
{
    [TestClass]
    public class SeleniumWebSiteTests
    {
        private IWebDriver _webDriver = null;

        [TestMethod]
        public void TitleTest()
        {
            // Setting up basic webdriver, remember FireFox must be installed for this test to work
            _webDriver = new FirefoxDriver();

            // Simple navigation to a website - my blog
            _webDriver.Navigate().GoToUrl("https://secretdiaryofacyclist.wordpress.com/");

            // Asserting we've landed on the page by checking the title of the page is as expected ignoring case
            // Using MsTest to assert
            Assert.IsTrue(_webDriver.Title.ToLower().Contains("the world of blogging from a qa point of view"));
        }

        [TestMethod]
        public void ArticleExistsUsingClick()
        {
            // Setting up basic webdriver, remember FireFox must be installed for this test to work
            _webDriver = new FirefoxDriver();

            // Simple navigation to a website - my blog
            _webDriver.Navigate().GoToUrl("https://secretdiaryofacyclist.wordpress.com/");

            // Capturing an article Title and clicking through to the Article.
            IWebElement articleTitle = _webDriver.FindElement(By.LinkText("Featured Article in TEST Magazine"));
            articleTitle.Click();

           
            // Asserting we've landed on the page by checking the title of the page is as expected ignoring case
            // Using MsTest to assert
            Assert.IsTrue(_webDriver.Title.ToLower().Contains("featured article in test magazine"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _webDriver.Quit();
        }
    }
}
