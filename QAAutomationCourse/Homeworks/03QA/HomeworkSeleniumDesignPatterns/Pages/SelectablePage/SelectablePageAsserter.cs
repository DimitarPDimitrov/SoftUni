using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
    public static class SelectablePageAsserter
    {
        public static void AssertItemsAreMarked(this SelectablePage page, IWebElement first, IWebElement second, IWebElement third)
        {
            Assert.AreEqual("ui-widget-content ui-corner-left ui-selectee ui-selected", first.GetAttribute("class"));
            Assert.AreEqual("ui-widget-content ui-corner-left ui-selectee ui-selected", second.GetAttribute("class"));
            Assert.AreEqual("ui-widget-content ui-corner-left ui-selectee ui-selected", third.GetAttribute("class"));
        }

        public static void AssertGridItemsAreMarked(this SelectablePage page, IWebElement first, IWebElement second, IWebElement third)
        {
            Assert.AreEqual("ui-state-default ui-corner-left ui-selectee ui-selected", first.GetAttribute("class"));
            Assert.AreEqual("ui-state-default ui-corner-left ui-selectee ui-selected", second.GetAttribute("class"));
            Assert.AreEqual("ui-state-default ui-corner-left ui-selectee ui-selected", third.GetAttribute("class"));
        }

        public static void AssertSerializeItemsAreMarked(this SelectablePage page)
        {
            Assert.AreEqual("ui-widget-content ui-corner-left ui-selectee ui-selected", page.serializeItem6.GetAttribute("class"));
            Assert.AreEqual("You’ve selected: #6.", page.serializeFeedback.Text);
         }
    }
}
