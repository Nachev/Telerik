using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculateArithmeticalExpression;

namespace ShuntingYardTest
{
    [TestClass]
    public class UnitTest1
    {
        private string _result;

        [TestMethod]
        public void EmptyExpression()
        {
            Given(string.Empty);
            Expect(string.Empty);
        }

        [TestMethod]
        public void NullExpression()
        {
            Given(null);
            Expect(string.Empty);
        }

        [TestMethod]
        public void InputOnlyNumberReturnsNumber()
        {
            Given("123");
            Expect("123");
        }

        [TestMethod]
        public void HandleSimpleBinaryOperator()
        {
            Given("3 + 2");
            Expect("3 2 +");
        }

        [TestMethod]
        public void HandlesMultipleOperatorsInSamePrecedence()
        {
            Given("3 + 1 - 2");
            Expect("3 1 + 2 -");
        }

        [TestMethod]
        public void HandlesFloatingPointNumbers()
        {
            Given("3.14 + 54");
            Expect("3.14 54 +");
        }

        [TestMethod]
        public void HandlesMultiplePrecedences()
        {
            Given("4 - 2 * 5");
            Expect("4 2 5 * -");
        }

        [TestMethod]
        public void HandlesLowHighLowPrecedence()
        {
            Given("4.5 - 3 * 2 - 1");
            Expect("4.5 3 2 * - 1 -");
        }

        [TestMethod]
        public void RemoveUnnecessaryPrenthesis()
        {
            Given("( 4 * 3 ) + 5");
            Expect("4 3 * 5 +");
        }

        [TestMethod]
        public void HandleNecessaryParenthesis()
        {
            Given("( 3 + 3 ) / 6");
            Expect("3 3 + 6 /");
        }

        [TestMethod]
        public void HandleUnnecessaryNestedParenthesis()
        {
            Given("( 3 + ( 4 * 3 ) ) - 2");
            Expect("3 4 3 * + 2 -");
        }

        [TestMethod]
        public void HandlesNecessaryNestedParenthesis()
        {
            Given("( ( 5 + 3 ) * 2 ) - 8");
            Expect("5 3 + 2 * 8 -");
        }

        [TestMethod]
        public void HandleBasicFunctionCall()
        {
            Given("f ( 3 )");
            Expect("3 f()");
        }

        [TestMethod]
        public void HandleMultipleParameters()
        {
            Given("pow ( 10 , 2 )");
            Expect("10 2 pow()");
        }

        [TestMethod]
        public void HandleNestesFunction()
        { 
            Given("f ( 3 , g ( 4 + 5 , 1 ) )");
            Expect("3 4 5 + 1 g() f()");
        }

        private void Expect(string expected)
        {
            Assert.AreEqual(expected, _result);
        }

        private void Given(string expression)
        {
            var test = new ShuntingYardAlgorithm();
            _result = test.Transform(expression);
        }
    }
}
