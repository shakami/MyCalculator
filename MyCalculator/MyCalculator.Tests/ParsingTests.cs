using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
    [TestClass]
    public class ParsingTests
    {
        private readonly Calculator calc = new Calculator();

        [TestMethod]
        public void ParseSimpleInput()
        {
            // addition
            Assert.AreEqual("5+5", calc.ParseInput("5+5").Value);

            // subtraction
            Assert.AreEqual("5-5", calc.ParseInput("5-5").Value);

            // multiplication
            Assert.AreEqual("5*5", calc.ParseInput("5*5").Value);

            // division
            Assert.AreEqual("5/5", calc.ParseInput("5/5").Value);
        }

        [TestMethod]
        public void ParseSimpleInputWithNegative()
        {
            // addition
            Assert.AreEqual("-5+5", calc.ParseInput("-5+5").Value);
            Assert.AreEqual("5+-5", calc.ParseInput("5+-5").Value);

            // subtraction
            Assert.AreEqual("5--5", calc.ParseInput("5--5").Value);
            Assert.AreEqual("-5-5", calc.ParseInput("-5-5").Value);

            // multiplication
            Assert.AreEqual("-5*5", calc.ParseInput("-5*5").Value);
            Assert.AreEqual("5*-5", calc.ParseInput("5*-5").Value);

            // division
            Assert.AreEqual("-5/5", calc.ParseInput("-5/5").Value);
            Assert.AreEqual("5/-5", calc.ParseInput("5/-5").Value);
        }

        [TestMethod]
        public void ParseExtraSpaces()
        {
            Assert.AreEqual(" 5+5", calc.ParseInput(" 5+5").Value);
            Assert.AreEqual("        5+5", calc.ParseInput("        5+5").Value);
            Assert.AreEqual("5 +5", calc.ParseInput("5 +5").Value);
            Assert.AreEqual("5+ 5", calc.ParseInput("5+ 5").Value);
            Assert.AreEqual("5 + 5", calc.ParseInput("5 + 5").Value);
            Assert.AreEqual("  5    +  5 ", calc.ParseInput("  5    +  5 ").Value);
        }

        [TestMethod]
        public void DoNotParse()
        {
            Assert.AreEqual("", calc.ParseInput("abc").Value);
            Assert.AreEqual("", calc.ParseInput("5+5abc").Value);
            Assert.AreEqual("", calc.ParseInput("abc5+5").Value);
            Assert.AreEqual("", calc.ParseInput("5+abc").Value);
            Assert.AreEqual("", calc.ParseInput("abc+5").Value);
            Assert.AreEqual("", calc.ParseInput("a5b+c5").Value);
            Assert.AreEqual("", calc.ParseInput("a b c").Value);
            Assert.AreEqual("", calc.ParseInput("5+/5").Value);
            Assert.AreEqual("", calc.ParseInput("+++").Value);
            Assert.AreEqual("", calc.ParseInput("5+5*").Value);
            Assert.AreEqual("", calc.ParseInput("*/1").Value);
            Assert.AreEqual("", calc.ParseInput("q").Value);
        }
    }
}
