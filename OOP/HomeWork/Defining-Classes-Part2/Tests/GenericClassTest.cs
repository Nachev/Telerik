namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DefiningClassesPart2;

    [TestClass]
    public class GenericClassTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            GenericList<int> nov = new GenericList<int>(5);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.InsertAt(2, 3);
            var expected = new GenericList<int>(5);
            expected.Add(0);
            expected.Add(0);
            expected.Add(3);
            expected.Add(0);
            Assert.AreEqual(expected.ToString(), nov.ToString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            GenericList<int> nov = new GenericList<int>(3);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.InsertAt(2, 3);
            nov.InsertAt(3, 0);
            var expected = new GenericList<int>(5);
            expected.Add(0);
            expected.Add(0);
            expected.Add(3);
            expected.Add(0);
            expected.Add(0);
            Assert.AreEqual(expected.ToString(), nov.ToString());
        }

        [TestMethod]
        public void TestMethod3()
        {
            GenericList<int> nov = new GenericList<int>(3);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.InsertAt(2, 3);
            nov.InsertAt(3, 0);
            var expected = new GenericList<int>(5);
            expected.Add(0);
            expected.Add(0);
            expected.Add(3);
            expected.Add(0);
            expected.Add(0);
            Assert.AreEqual(expected.Count, nov.Count);
        }

        [TestMethod]
        public void TestMethod4()
        {
            GenericList<int> nov = new GenericList<int>(1);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.InsertAt(2, 3);
            nov.InsertAt(3, 0);
            var expected = new GenericList<int>();
            expected.Add(0);
            expected.Add(0);
            expected.Add(3);
            expected.Add(0);
            expected.Add(0);
            Assert.AreEqual(expected.Count, nov.Count);
        }

        [TestMethod]
        public void TestMethod5()
        {
            GenericList<int> nov = new GenericList<int>(1);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.InsertAt(2, 3);
            nov.Add(0);
            nov.Add(0);
            nov.InsertAt(3, 0);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            nov.Add(0);
            var expected = new GenericList<int>();
            expected.Add(0);
            expected.Add(0);
            expected.Add(3);
            expected.Add(0);
            expected.Add(0);
            Assert.AreNotEqual(expected.Length, nov.Length);
        }
    }
}
