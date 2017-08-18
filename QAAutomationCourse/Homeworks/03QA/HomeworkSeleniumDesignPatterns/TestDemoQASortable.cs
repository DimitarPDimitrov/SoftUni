using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumDesignPatternsDemo.Pages.SortablePage;
using System;
using System.Configuration;
using System.IO;

namespace SeleniumDesignPatternsDemo
{
    class TestDemoQASortable
    {
        public IWebDriver driver;
        

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
               
                string pathToProject = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string filename = pathToProject + ConfigurationManager.AppSettings["RelativeLogs"]
                                    + "\\" + TestContext.CurrentContext.Test.Name;
                string filenameTxt = filename + ".txt";
                if (File.Exists(filenameTxt))
                {
                    File.Delete(filenameTxt);
                }
                File.WriteAllText(filenameTxt, TestContext.CurrentContext.Test.FullName + Environment.NewLine
                                            + TestContext.CurrentContext.Result.Message + Environment.NewLine);

                string filenameJpg = filename + ".jpg";
                if (File.Exists(filenameJpg))
                {
                    File.Delete(filenameJpg);
                }
                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filenameJpg, ScreenshotImageFormat.Jpeg);
            }
            driver.Quit();
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void SortableDefault()
        {
            var sortablePage = new SortablePage(this.driver);
            sortablePage.NavigateTo();

            sortablePage.DragSortable(sortablePage.sortableItem3, 0, 70);

            sortablePage.AssertItemsOrder();
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void SortableConnectLists()
        {
            var sortablePage = new SortablePage(this.driver);
            this.driver.Manage().Window.Maximize();
            sortablePage.NavigateTo();
            sortablePage.sortableConnectListButton.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sortablePage.h2);

            sortablePage.DragSortable(sortablePage.sortable1Item3, 150, 60);

            sortablePage.AssertItemsOrderConnectLists();
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void AssertItemsOrderInGrid()
        {
            var sortablePage = new SortablePage(this.driver);
            this.driver.Manage().Window.Maximize();
            sortablePage.NavigateTo();
            sortablePage.sortableDisplayAsGridButton.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sortablePage.h2);

            sortablePage.DragSortableGrid(sortablePage.sortableGridItem2, 120, 150);

            sortablePage.AssertItemsOrderInGrid();
        }
    }
}

