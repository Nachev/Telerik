namespace QA.Framework.Core.Extensions
{
    using System.Collections.Generic;
    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public static class CollectionAssertions
    {
        private const string MessageFormat = "Collection members count is not {0} as expected, but {1}";

        public static ICollection<T> AssertCountIs<T>(this ICollection<T> collection, int expectedCount) where T : HtmlControl
        {
            int actualCount = collection.Count;
            Assert.AreEqual(expectedCount, actualCount, string.Format(MessageFormat, expectedCount, actualCount));
            return collection;
        }
    }
}