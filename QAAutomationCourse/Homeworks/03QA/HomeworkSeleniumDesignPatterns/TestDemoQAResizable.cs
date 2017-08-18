using SeleniumDesignPatternsDemo.Pages.ResizablePage;
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
    public class TestDemoQAResizable
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
        public void ResizeDefault()
        {
            var resizablePage = new ResizablePage(this.driver);
            resizablePage.NavigateTo();
            resizablePage.IncreaseWidthAndHeightBy(resizablePage.resizeButton, 100);
            int resizeButtonHalfSize = 8;

            resizablePage.AssertResizeNewSize(resizeButtonHalfSize, resizeButtonHalfSize);
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void ResizeAnimate()
        {
            var resizablePage = new ResizablePage(this.driver);
            resizablePage.NavigateTo();
            resizablePage.AnimateResizeButton.Click();
            resizablePage.IncreaseWidthAndHeightBy(resizablePage.resizeAnimateButton, 50);
            int resizeButtonHalfSize = 8;

            resizablePage.AssertResizeNewSize(resizeButtonHalfSize, resizeButtonHalfSize);
        }

        [Test, Property("Priority", 2)]
        [Author("DD")]
        public void ResizeMaxMin()
        {
            var resizablePage = new ResizablePage(this.driver);
            resizablePage.NavigateTo();
            resizablePage.MaxMinResizeButton.Click();
            resizablePage.IncreaseWidthAndHeightBy(resizablePage.resizeMaxMinButton, 1000);
            
            resizablePage.AssertResizeMaxMinNewSize(350, 250);
        }
    }
}
