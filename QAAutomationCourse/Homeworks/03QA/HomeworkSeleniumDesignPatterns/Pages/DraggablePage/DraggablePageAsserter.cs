using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
    public static class DraggablePageAsserter
    {
        public static void AssertDraggableStyleValue(this DraggablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.DraggableDefault.GetAttribute("style"));
        }

        public static void AssertDragableVerticalStyleValue(this DraggablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.DraggableVertical.GetAttribute("style"));
        }

        public static void AssertDragableHorizontalStyleValue(this DraggablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.DraggableHorizontal.GetAttribute("style"));
        }

        public static void AssertDragableCenterCursorStyleValue(this DraggablePage page, string dragValue)
        {
            Assert.AreEqual(dragValue, page.DraggableCenterCursor.GetAttribute("style"));
        }

        public static void AssertEventsAttributeValue(this DraggablePage page, string styleValue)
        {
            Assert.AreEqual(styleValue, page.DragEvent.GetAttribute("style"));
        }
    }
}
