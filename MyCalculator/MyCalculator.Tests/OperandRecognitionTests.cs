using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
    [TestClass]
    public class OperandRecognitionTests
    {
        private readonly Calculator calc = new Calculator();
        [TestMethod]
        public void SimpleInput()
        {

            Match parsedInput = calc.ParseInput("5+5");
            Assert.AreEqual(5,calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5, calc.GetSecondOperand(parsedInput));
        }

        [TestMethod]
        public void SimpleInputWithNegative()
        {
            Match parsedInput = calc.ParseInput("-5+5");
            Assert.AreEqual(-5, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("5+-5");
            Assert.AreEqual(5, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(-5, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("-5+-5");
            Assert.AreEqual(-5, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(-5, calc.GetSecondOperand(parsedInput));
        }

        [TestMethod]
        public void DoubleInput()
        {
            Match parsedInput = calc.ParseInput("5.0+5.0");
            Assert.AreEqual(5, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("5.0+5");
            Assert.AreEqual(5, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("5.0000000+5");
            Assert.AreEqual(5, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("5.1+5.2");
            Assert.AreEqual(5.1, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5.2, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("-5.123+-5.12");
            Assert.AreEqual(-5.123, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(-5.12, calc.GetSecondOperand(parsedInput));
        }

        [TestMethod]
        public void ExtraSpaces()
        {
            Match parsedInput = calc.ParseInput("  5  +  5  ");
            Assert.AreEqual(5, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("5.12 + 5.13");
            Assert.AreEqual(5.12, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5.13, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("5.12 + -5.13");
            Assert.AreEqual(5.12, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(-5.13, calc.GetSecondOperand(parsedInput));

            parsedInput = calc.ParseInput("-5.12 + 5.13");
            Assert.AreEqual(-5.12, calc.GetFirstOperand(parsedInput));
            Assert.AreEqual(5.13, calc.GetSecondOperand(parsedInput));
        }
    }
}
