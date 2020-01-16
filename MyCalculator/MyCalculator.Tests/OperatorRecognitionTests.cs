using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
    [TestClass]
    public class OperatorRecognitionTests
    {
        private readonly Calculator calc = new Calculator();
        [TestMethod]
        public void SimpleInput()
        {
            string op = calc.GetOperator(calc.ParseInput("5+5"));
            Assert.AreEqual("+", op);

            op = calc.GetOperator(calc.ParseInput("5-5"));
            Assert.AreEqual("-", op);

            op = calc.GetOperator(calc.ParseInput("5*5"));
            Assert.AreEqual("*", op);

            op = calc.GetOperator(calc.ParseInput("5/5"));
            Assert.AreEqual("/", op);
        }

        [TestMethod]
        public void DoubleInput()
        {
            string op = calc.GetOperator(calc.ParseInput("5.0+5.1"));
            Assert.AreEqual("+", op);
        }

        [TestMethod]
        public void ExtraSpaces()
        {
            string op = calc.GetOperator(calc.ParseInput("5 +5"));
            Assert.AreEqual("+", op);

            op = calc.GetOperator(calc.ParseInput("5+ 5"));
            Assert.AreEqual("+", op);

            op = calc.GetOperator(calc.ParseInput(" 5+5 "));
            Assert.AreEqual("+", op);

            op = calc.GetOperator(calc.ParseInput("  5  + 5      "));
            Assert.AreEqual("+", op);
        }
    }
}
