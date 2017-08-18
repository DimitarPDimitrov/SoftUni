using OpenQA.Selenium;
using SeleniumDesignPatternsDemo.Models;
using System.Collections.Generic;

namespace SeleniumDesignPatternsDemo.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        private string url = "http://demoqa.com/registration/";

        public RegistrationPage(IWebDriver driver)
            :base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(url);
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(this.FirstName, user.FirstName);
            Type(this.LastName, user.LastName);
            ClickOnElements(this.MartialStatus, user.MatrialStatus);
            ClickOnElements(this.Hobbys, user.Hobbys);
            this.CountryOption.SelectByText(user.Country);
            this.MounthOption.SelectByText(user.BirthMonth);
            this.DayOption.SelectByText(user.BirthDay);
            this.YearOption.SelectByText(user.BirthYear);
            Type(this.Phone, user.Phone);
            Type(this.UserName, user.UserName);
            Type(this.Email, user.Email);
            this.UploadButton.Click();
            this.Driver.SwitchTo().ActiveElement().SendKeys(user.Picture);
            Type(this.Description, user.Description);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
        }

        public void SendRegistrationForm(RegistrationUser user)
        {
            this.SubmitButton.Click();
        }

        private void ClickOnElements(List<IWebElement> elements, List<bool> conditions)
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i])
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

    }
}
