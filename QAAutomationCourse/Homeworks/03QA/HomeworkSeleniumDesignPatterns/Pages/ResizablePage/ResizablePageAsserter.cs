using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.ResizablePage
{
    public static class ResizablePageAsserter
    {
        public static void AssertResizeNewSize(this ResizablePage page, int halfIndexWidth, int halfIndexHeight)
        {
            int lowerBoundWidth = page.resizeWindow.Size.Width - halfIndexWidth;
            int upperBoundWidth = page.resizeWindow.Size.Width + halfIndexWidth;
            int lowerBoundHeight = page.resizeWindow.Size.Height - halfIndexHeight;
            int upperBoundHeight = page.resizeWindow.Size.Height + halfIndexHeight;
            
             
            Assert.IsTrue(lowerBoundWidth < page.resizeWindow.Size.Width 
                            && page.resizeWindow.Size.Width < upperBoundWidth);
            Assert.IsTrue(lowerBoundHeight < page.resizeWindow.Size.Height 
                            && page.resizeWindow.Size.Height < upperBoundHeight);
        }

        public static void AssertResizeAnimateNewSize(this ResizablePage page, int halfIndexWidth, int halfIndexHeight)
        {
            int lowerBoundWidth = page.resizeAnimateWindow.Size.Width - halfIndexWidth;
            int upperBoundWidth = page.resizeAnimateWindow.Size.Width + halfIndexWidth;
            int lowerBoundHeight = page.resizeAnimateWindow.Size.Height - halfIndexHeight;
            int upperBoundHeight = page.resizeAnimateWindow.Size.Height + halfIndexHeight;


            Assert.IsTrue(lowerBoundWidth < page.resizeAnimateWindow.Size.Width
                            && page.resizeAnimateWindow.Size.Width < upperBoundWidth);
            Assert.IsTrue(lowerBoundHeight < page.resizeAnimateWindow.Size.Height
                            && page.resizeAnimateWindow.Size.Height < upperBoundHeight);
        }

        public static void AssertResizeMaxMinNewSize(this ResizablePage page, int maxWidth, int maxHeight)
        {
            Assert.AreEqual(maxWidth, page.resizeMaxMinWindow.Size.Width);
            Assert.AreEqual(maxHeight, page.resizeMaxMinWindow.Size.Height);
        }
    }
}
