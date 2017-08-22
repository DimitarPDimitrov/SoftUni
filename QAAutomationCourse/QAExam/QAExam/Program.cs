using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using QAExam.Pages.CountriesPage;
using QAExam.Pages.FlagsPage;
using QAExam.Pages.HomePage;
using QAExam.Pages.ServicePage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QAExam
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExtension(@"..\..\Extensions\adblock_chrome.crx");
            ChromeDriver driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();
            driver.Url = @"https://www.countries-ofthe-world.com/";

            HomePage homePage = new HomePage(driver);
            homePage.AllWorld.Click();

            CountriesPage countriesPage = new CountriesPage(driver);

            var list1 = countriesPage.CountrieList1;
            var list2 = countriesPage.CountrieList2;
            var list3 = countriesPage.CountrieList3;

            List<IWebElement>[] countryArray = new List<IWebElement>[3];

            countryArray[0] = list1;
            countryArray[1] = list2;
            countryArray[2] = list3;

            var coutries = new List<string>();
            for (int i = 0; i < countryArray.Length; i++)
            {
                foreach (var item in countryArray[i])
                {
                    if (item.Text.Length > 1)
                    {
                        string countrieName = item.Text.Split('(')[0].Replace(' ', '-');

                        if (countrieName.Contains("Czech"))
                        {
                            countrieName = "the-" + countrieName;
                        }
                        else if (countrieName.Contains("Netherlands"))
                        {
                            countrieName = "the-" + countrieName;
                        }
                        else if (countrieName.Contains("Vatican"))
                        {
                            countrieName = "the-" + countrieName;
                        }
                        else if (countrieName.Contains("United"))
                        {
                            countrieName = "the-" + countrieName;
                        }
                        if (countrieName.EndsWith("-"))
                            countrieName = countrieName.Substring(0, countrieName.Length - 1);

                        coutries.Add(countrieName.ToLower());
                    }
                }
            }

            FlagsPage flagsPage = new FlagsPage(driver);
            foreach (var item in coutries)
            {
                driver.Url = $"http://flagpedia.net/{item}";
                Actions actions = new Actions(driver);
                actions.MoveToElement(flagsPage.scrollTo);
                actions.Perform();

                Thread.Sleep(1000);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filename = @"..\..\Screenshots\" + $"{flagsPage.CoutryName.Text}-{flagsPage.CapitalName.Text}-{flagsPage.Code.Text}.jpg";
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            }

            List<string> namesForIP = new List<string>();

            foreach (var country in coutries)
            {
                string temp = country.Substring(0,3);
                string name = country;

                if (temp == "the")
                {
                    name = name.Remove(0, 4);
                }
                name = name.Replace('-', ' ');
                namesForIP.Add(name.ToUpper());
            }


            ServicePage servicePage = new ServicePage(driver);
            driver.Url = @"http://services.ce3c.be/ciprg/";

            foreach (var name in namesForIP)
            {
                servicePage.InputField.Clear();
                servicePage.InputField.SendKeys(name);
                servicePage.Formating.Click();
                Thread.Sleep(1000);
                servicePage.Button.Click();
                Thread.Sleep(1000);

                string IPs = driver.FindElement(By.XPath("/html/body/pre")).Text;
                string filenameTxt = @"..\..\CountryIPs\" + $"{name}" + ".txt";
                File.WriteAllText(filenameTxt, IPs);

                driver.Navigate().Back();
            }


            //driver.Close();

        }
    }
}
