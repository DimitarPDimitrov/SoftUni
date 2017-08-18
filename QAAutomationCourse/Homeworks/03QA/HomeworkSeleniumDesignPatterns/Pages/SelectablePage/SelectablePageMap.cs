using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
    public partial class SelectablePage
    {
        public IWebElement defaultItem1
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[1]"));
            }
        }

        public IWebElement defaultItem2
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[2]"));
            }
        }

        public IWebElement defaultItem3
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[3]"));
            }
        }

        public IWebElement SelectableGridButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-2"));
            }
        }

        public IWebElement gridItem5
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[5]"));
            }
        }

        public IWebElement gridItem9
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[9]"));
            }
        }

        public IWebElement gridItem10
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[10]"));
            }
        }

        public IWebElement SelectableSerializeButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-3"));
            }
        }

        public IWebElement serializeItem6
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable-serialize\"]/li[6]"));
            }
        }

        public IWebElement serializeFeedback
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"feedback\"]"));
            }
        }

    }
}
