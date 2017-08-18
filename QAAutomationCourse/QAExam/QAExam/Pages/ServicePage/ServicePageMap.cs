using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace QAExam.Pages.ServicePage
{
    public partial class ServicePage
    {
        public IWebElement InputField
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/form/input[1]"));
            }
        }
        

        public IWebElement Formating
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/form/input[3]"));
            }
        }

        public IWebElement Button
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/form/input[5]"));
            }
        }
    }
}