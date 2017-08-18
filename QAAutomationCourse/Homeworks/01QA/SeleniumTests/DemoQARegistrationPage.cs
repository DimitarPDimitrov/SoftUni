using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class DemoQARegistrationPage
    {
        [Test]
        public void NavigateToRegistrationPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.demoqa.com";
            WebDriverWait wate = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement registrationLink = driver.FindElement(By.Id("menu-item-374"));
            registrationLink.Click();
            IWebElement pageHeader = driver.FindElement(By.XPath("//*[@id=\"post-49\"]/header/h1"));

            Assert.AreEqual("Registration", pageHeader.Text);
            driver.Quit();
        }
    }
}
