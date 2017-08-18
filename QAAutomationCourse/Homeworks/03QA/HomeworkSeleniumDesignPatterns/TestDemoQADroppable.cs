using SeleniumDesignPatternsDemo.Pages.DroppablePage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.IO;
using System;

namespace SeleniumDesignPatternsDemo
{
    [TestFixture]
    public class TestDemoQADroppable
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
        public void DroppableDefault()
        {
            var droppablePage = new DroppablePage(this.driver);
            droppablePage.NavigateTo();

            droppablePage.DragAndDrop(droppablePage.Source, droppablePage.Target);

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DroppableAccept()
        {
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.NavigateTo();
            droppablePage.AcceptButton.Click();
            droppablePage.DragAndDrop(droppablePage.DraggableNonValid, droppablePage.DraggableAccept);

            droppablePage.AssertDraggableAcceptAttributeValue("ui-widget-header ui-droppable");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DroppablePrevent()
        {
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.NavigateTo();
            droppablePage.PreventPropagationButton.Click();
            droppablePage.DragAndDrop(droppablePage.DraggablePropagation, droppablePage.InnerDroppable);

            droppablePage.AssertDraggablePreventAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DroppableRevert()
        {
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.NavigateTo();
            droppablePage.RevertDragPosButton.Click();
            droppablePage.DragAndDrop(droppablePage.DraggableRevert, droppablePage.DroppableRevert);

            droppablePage.AssertRevertDraggablePosAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void DroppableShoppingCart()
        {
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.NavigateTo();
            droppablePage.ShoppingCartButton.Click();
            droppablePage.DragAndDrop(droppablePage.LolcatShirt, droppablePage.ShopCart);

            droppablePage.AssertShopCartTextValue("Lolcat Shirt");
        }
    }
}
