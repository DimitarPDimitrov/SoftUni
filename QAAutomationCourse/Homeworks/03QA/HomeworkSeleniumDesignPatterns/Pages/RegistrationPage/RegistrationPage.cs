using OpenQA.Selenium;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace SeleniumDesignPatternsDemo.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {

        protected string url = ConfigurationManager.AppSettings["URL"];
        public RegistrationPage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL
        {
            get
            {
                return ConfigurationManager.AppSettings["URL"] + "registration/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(this.FirstName, user.FirstName);
            Type(this.LastName, user.LastName);
            ClickOnElements(this.MaritalStatus, user.MaritalStatus);
            ClickOnElements(this.Hobbys, user.Hobbys);
            this.CountryOption.SelectByText(user.Country);
            this.MounthOption.SelectByText(user.BirthMonth);
            this.DayOption.SelectByText(user.BirthDay);
            this.YearOption.SelectByText(user.BirthYear);
            Type(this.Phone, user.Phone);
            Type(this.UserName, user.UserName);
            Type(this.Email, user.Email);
          //  this.UploadButton.Click();
          //  this.Driver.SwitchTo().ActiveElement().SendKeys(user.Picture);
            Type(this.Description, user.Description);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
        }

        public void SendRegistrationForm(RegistrationUser user)
        {
            this.SubmitButton.Click();
        }

        private void ClickOnElements(List<IWebElement> elements, string conditions)
        {
            var numbers = conditions.Split(',').Select(Int32.Parse).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == 1)
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            if (text == null)
                {
                element.SendKeys("");
                }
            else
                element.SendKeys(text.ToString());
        }

    }
}
