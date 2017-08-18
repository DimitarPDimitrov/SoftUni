using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Configuration;
using SeleniumDesignPatternsDemo.Pages;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
    public partial class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return ConfigurationManager.AppSettings["URL"] + "draggable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDropBy(IWebElement Element, int x, int y)
        {
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDropToOffset(Element, x, y);
            drag.Perform();
        }
    }
}
