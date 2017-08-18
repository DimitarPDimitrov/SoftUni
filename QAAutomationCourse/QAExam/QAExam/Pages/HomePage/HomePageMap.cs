using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace QAExam.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement AllWorld
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"leftmenu-style\"]/ul[2]/li[1]"));
            }
        }
    }
}