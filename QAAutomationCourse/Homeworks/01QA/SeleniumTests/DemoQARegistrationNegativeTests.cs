using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class DemoQARegistrationNegativeTests
    {
        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demoqa.com/registration/";
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        [Test]
        public void DemoQAREgistartion_FirstAndLastNamesCannotBeEmpty()
        {
            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Input(firstName, "");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Input(lastName, "");
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span"));

            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("* This field is required", errorMessage.Text);
        }

        [Test]
        public void DemoQAREgistartion_PhoneNumberMustBeAtLeast10Digits()
        {
            IWebElement phoneNum = driver.FindElement(By.Id("phone_9"));
            Input(phoneNum, "123456");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Input(userName, "");
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span"));
            
            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("* Minimum 10 Digits starting with Country Code", errorMessage.Text);
        }

        [Test]
        public void DemoQAREgistartion_EmailMustBeValidStringInvalidString()
        {
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Input(email, "Mitko_outlook.com");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Input(userName, "");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));

            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("* Invalid email address", errorMessage.Text);
        }

        [Test]
        public void DemoQAREgistartion_EmailMustBeValidStringEmptyString()
        {
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Input(email, "");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Input(userName, "");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));

            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("* This field is required", errorMessage.Text);
        }

        [Test]
        public void DemoQAREgistartion_PasswordCannotBeEmpty()
        {
            IWebElement pass = driver.FindElement(By.Id("password_2"));
            Input(pass, "");
            IWebElement passConfirm = driver.FindElement(By.Id("confirm_password_password_2"));
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('confirm_password_password_2').focus()");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));

            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("* This field is required", errorMessage.Text);
        }

        [Test]
        public void DemoQAREgistartion_PasswordTooShort()
        {
            IWebElement pass = driver.FindElement(By.Id("password_2"));
            Input(pass, "123456");
            IWebElement passConfirm = driver.FindElement(By.Id("confirm_password_password_2"));
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('confirm_password_password_2').focus()");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));

            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("* Minimum 8 characters required", errorMessage.Text);
           
        }

        [Test]
        public void DemoQAREgistartion_PasswordShouldMatch()
        {
           
            IWebElement pass = driver.FindElement(By.Id("password_2"));
            Input(pass, "1234567890");
            IWebElement passConfirm = driver.FindElement(By.Id("confirm_password_password_2"));
            Input(passConfirm, "123456789");
            IWebElement submitBtn = driver.FindElement(By.Name("pie_submit"));
            submitBtn.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span"));

            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("* Fields do not match", errorMessage.Text);
        }

        [Test]
        public void DemoQAREgistartion_PasswordVeryWeak()
        {
            IWebElement pass = driver.FindElement(By.Id("password_2"));
            Input(pass, "1234567890");
            IWebElement passConfirm = driver.FindElement(By.Id("confirm_password_password_2"));
            Input(passConfirm, "1234567890");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement errorMessage = driver.FindElement(By.Id("piereg_passwordStrength"));

            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("Very weak", errorMessage.Text);
        }

        private void Input(IWebElement element, string str)
        {
            element.Clear();
            element.SendKeys(str);
        }

        private void SelectDropdownOption(IWebDriver driver, string element, string text)
        {
            IWebElement dropDown = driver.FindElement(By.Id(element));
            SelectElement elementOption = new SelectElement(dropDown);
            elementOption.SelectByText(text);
        }
    }
}