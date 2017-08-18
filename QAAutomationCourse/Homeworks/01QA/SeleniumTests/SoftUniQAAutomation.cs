using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [TestFixture]
    class SoftUniQAAutomation
    {
        [Test]
        public void NavigateToSoftUni()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.softuni.bg";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            IWebElement linkEducations = driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/a"));
            linkEducations.Click();
            IWebElement linkQA = driver.FindElement(By.PartialLinkText("QA Automation"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", linkQA);
            linkQA.Click();
            IWebElement headingH1 = driver.FindElement(By.ClassName("page-title"));
            IWebElement headingH2 = driver.FindElement(By.ClassName("content-title"));
            
            Assert.AreEqual("Курс QA Automation - март 2017", headingH1.Text);
            Assert.AreEqual("Курс QA Automation - март 2017", headingH2.Text);
            driver.Quit();
        }
    }
}
