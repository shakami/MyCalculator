using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalculator.Tests
{
    [TestClass]
    public class CalculationTests
    {
        private readonly Calculator calc = new Calculator();
        [TestMethod]
        public void SimpleInput()
        {
            double num = calc.ComputeResult(5, 5, "+");
            Assert.AreEqual(10, num);

            num = calc.ComputeResult(5, 0, "+");
            Assert.AreEqual(5, num);

            num = calc.ComputeResult(0, 5, "+");
            Assert.AreEqual(5, num);

            num = calc.ComputeResult(5, 5, "-");
            Assert.AreEqual(0, num);

            num = calc.ComputeResult(5, 5, "*");
            Assert.AreEqual(25, num);

            num = calc.ComputeResult(5, 5, "/");
            Assert.AreEqual(1, num);
        }

        [TestMethod]
        public void SimpleInputWithNegative()
        {
            double num = calc.ComputeResult(5, -5, "+");
            Assert.AreEqual(0, num);

            num = calc.ComputeResult(-5, 5, "+");
            Assert.AreEqual(0, num);

            num = calc.ComputeResult(-5, -5, "+");
            Assert.AreEqual(-10, num);

            num = calc.ComputeResult(-5, -5, "-");
            Assert.AreEqual(0, num);
        }

        [TestMethod]
        public void DoubleInput()
        {
            double num = calc.ComputeResult(5.1, 5.2, "+");
            Assert.AreEqual(10.3, num);

            num = calc.ComputeResult(5.123, -0.123, "+");
            Assert.AreEqual(5, num);

            num = calc.ComputeResult(-1, 5, "*");
            Assert.AreEqual(-5, num);
        }

        [TestMethod]
        public void DevideByZero()
        {
            double num = calc.ComputeResult(1, 0, "/");
            Assert.AreEqual(double.PositiveInfinity, num);

            num = calc.ComputeResult(-1, 0, "/");
            Assert.AreEqual(double.NegativeInfinity, num);
        }
    }
}
