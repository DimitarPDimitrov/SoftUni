using OpenQA.Selenium;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
    public partial class DraggablePage
    {
        public IWebElement DraggableDefault
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggable"));
            }
        }

        public IWebElement ConstantMoveButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            }
        }

        public IWebElement DraggableVertical
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl"));
            }
        }

        public IWebElement DraggableHorizontal
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl2"));
            }
        }

        public IWebElement CursorStyleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]"));
            }
        }

        public IWebElement DraggableCenterCursor
        {
            get
            {
                return this.Driver.FindElement(By.Id("drag"));
            }
        }

        public IWebElement EventsButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-4\"]"));
            }
        }

        public IWebElement DragEvent
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"dragevent\"]"));
            }
        }

        public IWebElement DragEventDragValue
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"event-drag\"]/span[2]"));
            }
        }
    }
}
