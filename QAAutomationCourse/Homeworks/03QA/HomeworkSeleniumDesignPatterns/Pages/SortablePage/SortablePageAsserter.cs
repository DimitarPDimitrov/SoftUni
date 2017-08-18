using NUnit.Framework;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
    public static class SortablePageAsserter
    {
        public static void AssertItemsOrder(this SortablePage page)
        {
            Assert.AreEqual("Item 1\r\nItem 2\r\nItem 4\r\nItem 5\r\nItem 3\r\nItem 6\r\nItem 7", page.sortableContainer.Text);
        }

        public static void AssertItemsOrderConnectLists(this SortablePage page)
        {
            Assert.AreEqual("Item 1\r\nItem 2\r\nItem 3\r\nItem 4\r\nItem 3\r\nItem 5", page.sortable2Container.Text);
        }

        public static void AssertItemsOrderInGrid(this SortablePage page)
        {
            Assert.AreEqual("1\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n2\r\n12", page.sortableGridContainer.Text);
        }
    }
}