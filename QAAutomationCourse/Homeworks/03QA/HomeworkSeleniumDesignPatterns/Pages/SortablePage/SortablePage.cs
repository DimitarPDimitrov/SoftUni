using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Configuration;


namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
    public partial class SortablePage : BasePage
    {
        public SortablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return ConfigurationManager.AppSettings["URL"] + "sortable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(URL);

        }

        public void DragSortable(IWebElement item, int offsetX, int offsetY)
        {
            Actions builder = new Actions(Driver);
            var sort = builder.ClickAndHold(item).MoveByOffset(offsetX, 1). MoveByOffset(1, offsetY).Release(item).Build();
            sort.Perform();
        }

        public void DragSortableGrid(IWebElement item, int offsetX, int offsetY)
        {
            Actions builder = new Actions(Driver);
            var sort = builder.ClickAndHold(item).MoveByOffset(offsetX, 1).MoveByOffset(1, offsetY).Release(item).Build();
            sort.Perform();
        }
    }
}
