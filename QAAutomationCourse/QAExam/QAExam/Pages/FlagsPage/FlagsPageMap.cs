using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace QAExam.Pages.FlagsPage
{
    public partial class FlagsPage
    {
        public IWebElement CoutryName
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[2]"));
            }
        }

        public IWebElement CapitalName
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[3]"));
            }
        }

        public IWebElement Code
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[10]"));
            }
        }
        public IWebElement scrollTo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"footer\"]/p/a"));
            }
        }
    }
}