using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace QAExam.Pages.CountriesPage
{
    public partial class CountriesPage
    {
        //public IWebElement BG {

        //    get
        //    {
        //        return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[2]/ul[1]/li[28]"));

        //    }
        //}

        public List<IWebElement> CountrieList1
        {
            get
            {

                var ul = this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[2]/ul[1]"));
                List<IWebElement> li = ul.FindElements(By.TagName("li")).ToList();

                return li;

            }
        }

        public List<IWebElement> CountrieList2
        {
            get
            {

                var ul = this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[2]/ul[2]"));
                List<IWebElement> li = ul.FindElements(By.TagName("li")).ToList();

                return li;

            }
        }

        public List<IWebElement> CountrieList3
        {
            get
            {

                var ul = this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[2]/ul[3]"));
                List<IWebElement> li = ul.FindElements(By.TagName("li")).ToList();

                return li;

            }
        }
    }
}