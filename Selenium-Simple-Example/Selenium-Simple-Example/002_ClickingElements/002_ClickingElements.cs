using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium_Simple_Example._002_ClickingElements
{
    /// <summary>
    /// Summary description for _002_ClickingElements
    /// </summary>
    [TestClass]
    public class _002_ClickingElements
    {
        private IWebDriver _webDriver = null;

        [TestMethod]
        public void ClickArticleByLinkText()
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
            _webDriver.Quit();
        }

        [TestMethod]
        public void ClickArticleByClassName()
        {
            _webDriver = new FirefoxDriver();
            _webDriver.Navigate().GoToUrl("https://secretdiaryofacyclist.wordpress.com/");

            // Capturing an Post Area on Screen.
            IWebElement post = _webDriver.FindElement(By.ClassName("posts"));

            // Since the Post Area is not clickable, I'm finding the first class name in the post area and clicking through

            // notice I'm stringing together the click action to a find by element in this example.
            post.FindElement(By.LinkText("Featured Article in TEST Magazine")).Click();

            //No assertion as demo'in the click of using a find by Class Name the area Posts
            // then finding an element inside the post
            _webDriver.Quit();
        }

        [TestMethod]
        public void CaputurePostAreaById()
        {
            _webDriver = new FirefoxDriver();
            _webDriver.Navigate().GoToUrl("https://secretdiaryofacyclist.wordpress.com/");

            // Capturing an Post Area on Screen.
            IWebElement post = _webDriver.FindElement(By.Id("posts"));

            // Since the Post Area is not clickable, I'm finding the first class name in the post area and clicking through

            // notice I'm stringing together the click action to a find by element in this example.
            post.FindElement(By.LinkText("Featured Article in TEST Magazine")).Click();

            //No assertion as demo'in the click of using a find by ID the area Posts
            // then finding an element inside the post
            _webDriver.Quit();
        }

        [TestMethod]
        public void ClickArticleByCss()
        {
            _webDriver = new FirefoxDriver();
            _webDriver.Navigate().GoToUrl("https://secretdiaryofacyclist.wordpress.com/");

            // Capturing an Post Area on Screen.
            _webDriver.FindElement(By.CssSelector("#post-343 > div:nth-child(1) > h2:nth-child(1) > a:nth-child(1)")).Click();

            //No assertion as demo'in the click of using Css
            _webDriver.Quit();
        }
    }
}
