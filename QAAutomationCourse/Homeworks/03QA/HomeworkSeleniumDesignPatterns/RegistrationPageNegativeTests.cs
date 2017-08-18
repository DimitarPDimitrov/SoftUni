using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.RegistrationPage;
using System;
using System.Configuration;
using System.IO;

namespace SeleniumDesignPatternsDemo
{
    [TestFixture]
    public class RegisterInDemoQA
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {

                string pathToProject = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string filename = pathToProject + ConfigurationManager.AppSettings["RelativeLogs"]
                                    + "\\" + TestContext.CurrentContext.Test.Name;
                string filenameTxt = filename + ".txt";
                if (File.Exists(filenameTxt))
                {
                    File.Delete(filenameTxt);
                }
                File.WriteAllText(filenameTxt, TestContext.CurrentContext.Test.FullName + Environment.NewLine
                                            + TestContext.CurrentContext.Result.Message + Environment.NewLine);

                string filenameJpg = filename + ".jpg";
                if (File.Exists(filenameJpg))
                {
                    File.Delete(filenameJpg);
                }
                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filenameJpg, ScreenshotImageFormat.Jpeg);
            }
            driver.Quit();
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithoutFirstName()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutFirstName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithoutLastName()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void RegisterWithoutHobby()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutHobby");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SendRegistrationForm(user);

            regPage.AssertHobbyErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithoutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithShortPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithShortPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithInvalidPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithInvalidPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithoutUsername()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutUsername");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertUsernameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithoutEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithInvalidEmail");
            
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void RegisterWithInvalidProfilePictureFormat()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithInvalidProfilePictureFormat");
            
            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithMissingPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithMissingPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordError("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithShortPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithShortPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordError("* Minimum 8 characters required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithMissingConfirmPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithMissingConfirmPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SendRegistrationForm(user);

            regPage.AssertConfirmPasswordError("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithMismatchPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithMismatchPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SendRegistrationForm(user);

            regPage.AssertConfirmPasswordError("* Fields do not match");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_Mismatch()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterPasswordStrength_Mismatch");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Mismatch");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_VeryWeak()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterPasswordStrength_VeryWeak");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SendRegistrationForm(user);

            regPage.AssertPasswordStrength("Very weak");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_Weak()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterPasswordStrength_Weak");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Weak");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_Medium()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterPasswordStrength_Medium");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Medium");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_Strong()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterPasswordStrength_Strong");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Strong");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterUnsuccesful_UsernameAlreadyExist()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterUnsuccesful_UsernameAlreadyExist");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SendRegistrationForm(user);

            regPage.AssertErrorMessage("Username already exists");
        }
    }
}
