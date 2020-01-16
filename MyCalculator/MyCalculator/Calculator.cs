using System;
using System.Text.RegularExpressions;


namespace MyCalculator
{
    public class Calculator
    {
        public Calculator()
        {
            lastResult = 0;
            Console.WriteLine("Arithmetic Calculator");
            Console.WriteLine("\"q\" to extit");
            Console.WriteLine("\"r\" ro recall last result");
        }

        public void Run()
        {
            string userInput;
            userInput = Console.ReadLine();
            while (userInput != "q")
            {
                Match parsedInput = ParseInput(userInput);
                if (parsedInput.Success)
                {
                    StartCalculation(parsedInput);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
                userInput = Console.ReadLine();
            }
        }

        private void StartCalculation(Match parsedInput)
        {
            double operand1 = GetFirstOperand(parsedInput);
            double operand2 = GetSecondOperand(parsedInput);
            string operatorSymbol = GetOperator(parsedInput);

            lastResult = ComputeResult(operand1, operand2, operatorSymbol);
            Console.WriteLine(lastResult);
        }

        public double GetFirstOperand(Match parsedInput)
        {
            string operand1 = parsedInput.Groups["operand1"].Value;
            if (operand1 == "r")
            {
                return lastResult;
            }
            return double.Parse(operand1);
        }

        public double GetSecondOperand(Match parsedInput)
        {
            return double.Parse(parsedInput.Groups["operand2"].Value);
        }

        public string GetOperator(Match parsedInput)
        {
            return parsedInput.Groups["operator"].Value;
        }
        
        public Match ParseInput(string userInput)
        {
            Regex calculatorInput = new Regex(@"^\s*(?<operand1>(-?[0-9]+(\.[0-9]+)?)|r)\s*(?<operator>\+|\-|\*|\/)\s*(?<operand2>-?[0-9]+(\.[0-9]+)?)\s*$");
            return calculatorInput.Match(userInput);
        }

        public double ComputeResult(double operand1, double operand2, string operatorSymbol)
        {
            double result = 0;
            switch (operatorSymbol)
            {
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    try
                    {
                        result = operand1 / operand2;
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("cannot divide by zero");
                    }
                    break;
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
            return result;
        }

        private double lastResult;
    }
}
