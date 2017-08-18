using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Interactions;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
    public partial class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return ConfigurationManager.AppSettings["URL"] + "selectable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(URL);
        }

        public void ClickAndDrag(IWebElement start, IWebElement end)
        {
            Actions builder = new Actions(this.Driver);
            var select = builder.ClickAndHold(start).MoveToElement(end).Release();
            select.Perform();
        }

        public void ClickAndMark(IWebElement first, IWebElement second, IWebElement third)
        {
            Actions builder = new Actions(this.Driver);
            var select = builder.KeyDown(Keys.Control).Click(first)
                        .MoveToElement(second).Click(second)
                        .MoveToElement(third).Click(third)
                        .Release().KeyUp(Keys.Control);
            select.Perform();
        }
    }
}
