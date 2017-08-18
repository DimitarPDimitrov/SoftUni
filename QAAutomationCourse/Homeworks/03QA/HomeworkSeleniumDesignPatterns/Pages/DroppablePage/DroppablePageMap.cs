using OpenQA.Selenium;


namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public partial class DroppablePage
    {
        public IWebElement Source
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableview\"]/p"));
            }
        }

        public IWebElement Target
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableview"));
            }
        }

        public IWebElement AcceptButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-2"));
            }
        }

        public IWebElement DraggableNonValid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggable-nonvalid\"]/p"));
            }
        }

        public IWebElement DraggableAccept
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppableaccept\"]"));
            }
        }

        public IWebElement PreventPropagationButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-3"));
            }
        }

        public IWebElement DraggablePropagation
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableprop\"]/p"));
            }
        }

        public IWebElement InnerDroppable
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppable2-inner\"]"));
            }
        }

        public IWebElement RevertDragPosButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-4"));
            }
        }

        public IWebElement DraggableRevert
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggablerevert\"]"));
            }
        }

        public IWebElement DroppableRevert
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppablerevert\"]"));
            }
        }

        public IWebElement ShoppingCartButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-5"));
            }
        }

        public IWebElement LolcatShirt
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-7\"]/ul/li[1]"));
            }
        }

        public IWebElement ShopCart
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"cart\"]/div/ol/li"));
            }
        }

    }
}
