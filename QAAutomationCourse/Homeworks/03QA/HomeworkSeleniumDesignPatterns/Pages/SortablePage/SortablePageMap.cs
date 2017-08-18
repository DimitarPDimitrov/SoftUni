using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
    public partial class SortablePage
    {

        public IWebElement sortableItem3
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[3]"));
            }
        }

        public IWebElement sortableContainer
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"tabs-1\"]/div"));
            }
        }

        public IWebElement sortableConnectListButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-2"));
            }
        }

        public IWebElement sortable1Item3
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable1\"]/li[3]"));
            }
        }

        public IWebElement h2
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"post-149\"]/div/h2"));
            }
        }

        public IWebElement sortable2Container
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable2\"]"));
            }
        }

        public IWebElement sortableDisplayAsGridButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-3"));
            }
        }

        public IWebElement sortableGridContainer
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"tabs-3\"]/div"));
            }
        }

        public IWebElement sortableGridItem2
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable_grid\"]/li[2]"));
            }
        }

    }
}
