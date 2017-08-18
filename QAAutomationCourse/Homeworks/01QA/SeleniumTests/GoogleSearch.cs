using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class GoogleSearch
    {
        [Test]
        public void NavigateSeleniumHQ()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.google.com";
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.Clear();
            searchField.SendKeys("Selenium\r\n");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement firstLink = wait.Until<IWebElement>((w) =>
            {
                return w.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/h3/a"));
            });
            firstLink.Click();
            IWebElement seleniumPageTitle = wait.Until<IWebElement>((w) =>
            {
                return w.FindElement(By.XPath("/html/head/title"));
            });

            string url = driver.Url;
            Assert.AreEqual("http://www.seleniumhq.org/", driver.Url);
            Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);
            driver.Quit();
        }
    }
}
