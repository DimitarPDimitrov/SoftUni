using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.RegistrationPage;
using System.Collections.Generic;


namespace SeleniumWebDriverFirstTests
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
            this.driver.Quit();
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithoutFirstName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithoutLastName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void RegisterWithoutHobby()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

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
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithShortPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithLongPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "12345678901234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithoutUsername()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertUsernameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithoutEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "123",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 3)]
        [Author("DD")]
        public void RegisterWithInvalidProfilePictureFormat()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "123",
                                                         @"\\Models\DummyPDF.pdf",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterWithMissingPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordError("* This field is required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithShortPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234",
                                                         "1234567890");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordError("* Minimum 8 characters required");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterWithMissingConfirmPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "");

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
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "12345678901");

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
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890",
                                                         "12345678901");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Mismatch");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_VeryWeak()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "123",
                                                         "123");

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
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890qwertyuiop!@#",
                                                         "1234567890qwertyuiop!@#");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Weak");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_Medium()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890qwertyuiop!@#Ж",
                                                         "1234567890qwertyuiop!@#Ж");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Medium");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void RegisterPasswordStrength_Strong()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"\\Models\8560552146_6b50021122.jpg",
                                                         "IHAAAAA",
                                                         "1234567890qwertyuiop!@#Жз",
                                                         "1234567890qwertyuiop!@#Жз");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrength("Strong");
        }

        [Test, Property("Priority", 1)]
        [Author("DD")]
        public void RegisterUnsuccesful_UsernameAlreadyExist()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Dimitar",
                                                         "Dimitrov",
                                                         new List<bool>(new bool[] { false, true, false }),
                                                         new List<bool>(new bool[] { false, true, true }),
                                                         "Bulgaria",
                                                         "8",
                                                         "9",
                                                         "1974",
                                                         "1234567890",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"",
                                                         "IHAAAAA",
                                                         "1234567890qwertyuiop!@#Жз",
                                                         "1234567890qwertyuiop!@#Жз");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);
            regPage.SendRegistrationForm(user);

            regPage.AssertErrorMessage("Username already exists");
        }

        //[Test]
        //public void RegisterWithValidData()
        //{
        //    var regPage = new RegistrationPage(this.driver);
        //    RegistrationUser user = new RegistrationUser("Dimitar",
        //                                                 "Dimitrov",
        //                                                 new List<bool>(new bool[] { false, true, false }),
        //                                                 new List<bool>(new bool[] { false, true, true }),
        //                                                 "Bulgaria",
        //                                                 "8",
        //                                                 "9",
        //                                                 "1974",
        //                                                 "8888888888",
        //                                                 "Buro",
        //                                                 "burkata@abv.bg",
        //                                                 @"http://demoqa.com/wp-content/uploads/2014/08/Tools-QA-213.png",
        //                                                 "IHAAAAA",
        //                                                 "1234567890",
        //                                                 "1234567890");

        //    regPage.NavigateTo();
        //    regPage.FillRegistrationForm(user);

        //    regPage.AssertSuccessMessage("Thank you for your registration");
        //}
    }
}
