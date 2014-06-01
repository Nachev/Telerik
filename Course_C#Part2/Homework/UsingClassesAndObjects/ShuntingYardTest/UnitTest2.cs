using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculateArithmeticalExpression;

namespace ShuntingYardTest
{
    [TestClass]
    public class UnitTest2
    {
        private string _testString;

        [TestMethod]
        public void RemoveEmptySpaces()
        {
            Given("3 + 5-4*1");
            Expect("3 + 5 - 4 * 1");
        }

        [TestMethod]
        public void NormalizeExpressionTest()
        {
            Given("3+5 -4*1");
            Expect("3 + 5 - 4 * 1");
        }

        [TestMethod]
        public void HandleParenthesis()
        {
            Given("3 + (5-4)*1");
            Expect("3 + ( 5 - 4 ) * 1");
        }

        [TestMethod]
        public void HandleFunctions()
        {
            Given("pow(2+6,2) +5");
            Expect("pow ( 2 + 6 , 2 ) + 5");
        }

        private void Expect(string expected)
        {
            Assert.AreEqual(expected, _testString);
        }

        private void Given(string input)
        {
            var test = new NormalizeExpression();
            _testString = test.Process(input);
        }
    }
}
