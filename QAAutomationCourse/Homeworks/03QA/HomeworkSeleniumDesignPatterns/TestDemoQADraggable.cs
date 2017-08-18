using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.IO;
using System.Linq;
using SeleniumDesignPatternsDemo.Pages.DraggablePage;
using System;

namespace SeleniumDesignPatternsDemo
{
    [TestFixture]
    public class TestDemoQADraggable
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
        public void DraggableDefault()
        {
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();

            draggablePage.DragAndDropBy(draggablePage.DraggableDefault, 50, 50);

            draggablePage.AssertDraggableStyleValue("position: relative; width: 247px; right: auto; height: 150px; bottom: auto; left: 50px; top: 50px;");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DraggableConstantMoveVertical()
        {
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            draggablePage.ConstantMoveButton.Click();

            draggablePage.DragAndDropBy(draggablePage.DraggableVertical, 0, 50);

            draggablePage.AssertDragableVerticalStyleValue("position: relative; height: 90px; bottom: auto; left: 0px; top: 50px;");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DraggableConstantMoveHorizontal()
        {
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            draggablePage.ConstantMoveButton.Click();

            draggablePage.DragAndDropBy(draggablePage.DraggableHorizontal, 100, 0);

            draggablePage.AssertDragableHorizontalStyleValue("position: relative; width: 90px; right: auto; left: 100px; top: 0px;");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DraggableCenterCursor()
        {
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            draggablePage.CursorStyleButton.Click();

            draggablePage.DragAndDropBy(draggablePage.DraggableCenterCursor, 100, 100);

            draggablePage.AssertDragableCenterCursorStyleValue("position: relative; width: 100px; right: auto; height: 100px; bottom: auto; left: 93.8646px; top: 93.5313px;");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DraggableEvents()
        {
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            draggablePage.EventsButton.Click();

            draggablePage.DragAndDropBy(draggablePage.DragEvent, 50, 50);

            draggablePage.AssertEventsAttributeValue("position: relative; width: 247px; right: auto; height: 216px; bottom: auto; left: 50px; top: 50px;");
        }
    }
}
