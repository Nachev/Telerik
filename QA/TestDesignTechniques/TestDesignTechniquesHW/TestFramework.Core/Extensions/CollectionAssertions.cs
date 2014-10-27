namespace TestFramework.Core.Extensions
{
    using System.Collections.Generic;
    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public static class CollectionAssertions
    {
        public static ICollection<T> AssertElementsCount<T>(this ICollection<T> collection, int expectedCount) where T : HtmlControl
        {
            int realCount = collection.Count;
            string exceptionMessage = string.Format("Number of elements in the collection was expected to be {0}, but it was {1}", expectedCount, realCount);

            Assert.AreEqual<int>(expectedCount, realCount, exceptionMessage);

            return collection;
        }
    }
}