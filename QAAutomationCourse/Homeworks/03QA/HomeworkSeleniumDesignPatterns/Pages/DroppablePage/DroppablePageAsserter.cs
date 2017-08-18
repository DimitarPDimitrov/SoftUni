using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public static class DroppablePageAsserter
    {
        public static void AssertTargetAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.Target.GetAttribute("class"));
        }

        public static void AssertDraggableAcceptAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.DraggableAccept.GetAttribute("class"));
        }

        public static void AssertDraggablePreventAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.InnerDroppable.GetAttribute("class"));
        }

        public static void AssertRevertDraggablePosAttributeValue(this DroppablePage page, string classValue2)
        {
            //Assert.AreEqual(classValue1, page.DraggableRevert.GetAttribute("style"));
            Assert.AreEqual(classValue2, page.DroppableRevert.GetAttribute("class"));
        }

        public static void AssertShopCartTextValue(this DroppablePage page, string textValue)
        {
            Assert.AreEqual(textValue, page.ShopCart.Text);
        }
    }
}
