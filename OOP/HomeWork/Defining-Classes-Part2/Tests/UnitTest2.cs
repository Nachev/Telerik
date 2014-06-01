namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MatrixClass;

    [TestClass]
    public class UnitTest2
    {
        private string _result;

        [TestMethod]
        public void TestMethod1()
        {
            var testMtrx1 = new Matrix<int>(new[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } });
            var testMtrx2 = new Matrix<int>(new[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } });
            Given(testMtrx1);
            Expect("1 2 3 \n1 2 3 \n1 2 3 ");
        }



        private void Expect(string expected)
        {
            Assert.AreEqual(expected, _result);
        }

        private void Given(Matrix<int> testMatrix1, Matrix<int> testMatrix2 = null)
        {
            _result = testMatrix1.ToString();
        }
    }
}
