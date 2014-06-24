namespace TestMatrix
{
    using System;
    using System.IO;
    using Matrix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestConsoleManager
    {
        [TestMethod]
        public void TestInputMethodShouldParseNumberCorrectly()
        {
            var sr = new StringReader("1");
            Console.SetIn(sr);

            int? parsed = ConsoleManager.DimensionsInput("test", 1, 100);
            Assert.AreEqual(1, parsed);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestMoreThanFiveTimesWrongInputShouldThrowAnException()
        {
            var sr = new StringReader("c");
            for (int i = 0; i < 6; i++)
            {
                Console.SetIn(sr);
                int? parsed = ConsoleManager.DimensionsInput("test", 1, 100);
            }
        }
        /*
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestInputWithIncorrectInputSixTimesShouldThrowAnExceprion()
        {
            using (StringReader sr = new StringReader("b"))
            {
                Console.SetIn(sr);
                Console.SetIn(sr);
                Console.SetIn(sr);
                Console.SetIn(sr);
                Console.SetIn(sr);
                Console.SetIn(sr);

                RotatingMatrixTraversal.Main();
            }
        }*/
    }
}
