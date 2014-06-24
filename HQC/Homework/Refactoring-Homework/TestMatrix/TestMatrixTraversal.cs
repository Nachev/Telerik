namespace TestMatrix
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Matrix;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

    /// <summary>
    /// Summary description for TestMatrixTraversal
    /// </summary>
    [TestClass]
    public class TestMatrixTraversal
    {
        private readonly string InputMessage = string.Format(
                "Enter integer number for dimensions of a square matrix (n x n),\n" +
                              "in range ({0} <= n <= {1})\n-> ",
                1,
                100);
        private readonly IList<CoordinatesCouple> directions = new ReadOnlyCollection<CoordinatesCouple>(
            new[]
            {
                new CoordinatesCouple(1, 1), // DownRight - 0
                new CoordinatesCouple(1, 0), // Down - 1
                new CoordinatesCouple(1, -1), // DownLeft - 2
                new CoordinatesCouple(0, -1), // Left - 3
                new CoordinatesCouple(-1, -1), // UpLeft - 4
                new CoordinatesCouple(-1, 0), // Up - 5
                new CoordinatesCouple(-1, 1), // UpRight - 6
                new CoordinatesCouple(0, 1), // Right - 7
            });

        [TestMethod]
        public void TestMatrixTraversalWithInputTwo()
        {
            using (StringReader sr = new StringReader("2"))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                RotatingMatrixTraversal.Main();

                string expected = InputMessage + " 1 4\r\n 3 2\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestMatrixTraversalWithInputSix()
        {
            using (StringReader sr = new StringReader("6"))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                RotatingMatrixTraversal.Main();

                string expected = InputMessage + "  1 16 17 18 19 20\r\n" +
                    " 15  2 27 28 29 21\r\n" +
                    " 14 31  3 26 30 22\r\n" +
                    " 13 36 32  4 25 23\r\n" +
                    " 12 35 34 33  5 24\r\n" +
                    " 11 10  9  8  7  6\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }
        
        
        [TestMethod]
        public void TestMatrixTraversalWithIncorrectInputSixTimesShouldResultErrorMessage()
        {
            using (StringReader sr = new StringReader("b\nb\nb\nb\nb\nb\nb\nb\nb\nb\nb\nb\n"))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                RotatingMatrixTraversal.Main();

                string expected = "Attempts limit reached! Maximal number of input attempts is";
                Assert.IsTrue(sw.ToString().Contains(expected));
            }
        }
    }
}