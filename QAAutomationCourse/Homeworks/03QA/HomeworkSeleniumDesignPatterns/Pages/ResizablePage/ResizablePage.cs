using System;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Interactions;

namespace SeleniumDesignPatternsDemo.Pages.ResizablePage
{
    public partial class ResizablePage : BasePage
    {
        public ResizablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return ConfigurationManager.AppSettings["URL"] + "resizable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void IncreaseWidthAndHeightBy(IWebElement resizer, int increaseSize)
        {
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(resizer, increaseSize, increaseSize);
            resize.Perform();
        }
    }
}
