using System;
using System.Threading;
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
        public void LaunchBrowserAndClosing()
        {
            // Setting up basic webdriver, remember FireFox must be installed for this test to work
            _webDriver = new FirefoxDriver();

            // Simple navigation to a website - my blog
            _webDriver.Navigate().GoToUrl("https://secretdiaryofacyclist.wordpress.com/");

            Thread.Sleep(2000);

            // Closing down the browser session - cleaning up the test
            _webDriver.Quit();
        }

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
            _webDriver.Quit();
        }
       
    }
}
