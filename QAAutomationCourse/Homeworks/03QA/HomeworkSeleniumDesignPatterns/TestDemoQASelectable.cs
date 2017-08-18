using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.IO;
using SeleniumDesignPatternsDemo.Pages.SelectablePage;
using System;

namespace SeleniumDesignPatternsDemo
{
    class TestDemoQASelectable
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
        public void SelectableDefault()
        {
            var selectablePage = new SelectablePage(this.driver);
            selectablePage.NavigateTo();
            selectablePage.ClickAndDrag(selectablePage.defaultItem1, selectablePage.defaultItem3);

            selectablePage.AssertItemsAreMarked(selectablePage.defaultItem1, selectablePage.defaultItem2, selectablePage.defaultItem3);
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void SelectableGrid()
        {
            var selectablePage = new SelectablePage(this.driver);
            selectablePage.NavigateTo();
            selectablePage.SelectableGridButton.Click();
            selectablePage.ClickAndMark(selectablePage.gridItem5, selectablePage.gridItem9, selectablePage.gridItem10);

            selectablePage.AssertGridItemsAreMarked(selectablePage.gridItem5, selectablePage.gridItem9, selectablePage.gridItem10);
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void SelectableSerialize()
        {
            var selectablePage = new SelectablePage(this.driver);
            selectablePage.NavigateTo();
            selectablePage.SelectableSerializeButton.Click();
            selectablePage.serializeItem6.Click();

            selectablePage.AssertSerializeItemsAreMarked();
        }
    }
}
