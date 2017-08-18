using OpenQA.Selenium;
using System.Configuration;


namespace SeleniumDesignPatternsDemo.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        private string url = ConfigurationManager.AppSettings["URL"];

        public HomePage(IWebDriver driver)
            :base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(url);
        }
    }
}
