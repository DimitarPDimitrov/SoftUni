using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumDesignPatternsDemo.Pages;
using System.Configuration;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public partial class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return ConfigurationManager.AppSettings["URL"] + "droppable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDrop(IWebElement source, IWebElement target)
        {
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(source, target);
            drag.Perform();
        }
    }
}
