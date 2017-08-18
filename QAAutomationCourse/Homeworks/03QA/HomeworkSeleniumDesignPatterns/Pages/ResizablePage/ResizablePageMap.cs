using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.ResizablePage
{
    public partial class ResizablePage
    {
        public IWebElement resizeButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizable\"]/div[3]"));
            }
        }

        public IWebElement resizeWindow
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizable"));
            }
        }

        public IWebElement AnimateResizeButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-2"));
            }
                
         }

        public IWebElement resizeAnimateButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizableani\"]/div[3]"));
            }
        }

        public IWebElement resizeAnimateWindow
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizableani"));
            }
        }

        public IWebElement MaxMinResizeButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-5"));
            }
        }

        public IWebElement resizeMaxMinButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizable_max_min\"]/div[3]"));
            }
        }

        public IWebElement resizeMaxMinWindow
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizable_max_min\"]"));
            }
        }
    }
}
