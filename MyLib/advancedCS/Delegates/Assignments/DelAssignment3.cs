using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.Delegates.Assignments
{
    public delegate int CalculatorDelegate(int numberOne, int numberTwo);

    public class Calculator
    {
        public int Add(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }

        public int Subtract(int numberOne, int numberTwo)
        {
            return numberOne - numberTwo;
        }

        public int Multiply(int numberOne, int numberTwo)
        {
            return numberOne * numberTwo;
        }
    }

    public class Calculation
    {
        public int PerformCalculation(int choice, int numberOne, int numberTwo)
        {
            CalculatorDelegate calculatorDelegate = null;

            switch (choice)
            {
                case 1:
                    calculatorDelegate = new CalculatorDelegate(new Calculator().Add);
                    break;
                case 2:
                    calculatorDelegate = new CalculatorDelegate(new Calculator().Subtract);
                    break;
                case 3:
                    calculatorDelegate = new CalculatorDelegate(new Calculator().Multiply);
                    break;
                default:
                    calculatorDelegate = new CalculatorDelegate(new Calculator().Add);
                    break;
            }

            return calculatorDelegate(numberOne, numberTwo);
        }
    }
    public class DelAssignment3
    {
        public static void Main()
        {
            Calculation calculation = new Calculation();

            // Test cases
            int result1 = calculation.PerformCalculation(1, 5, 3); // Add(5, 3) = 8
            int result2 = calculation.PerformCalculation(2, 10, 4); // Subtract(10, 4) = 6
            int result3 = calculation.PerformCalculation(3, 6, 7); // Multiply(6, 7) = 42
            int result4 = calculation.PerformCalculation(4, 8, 2); // Default, Add(8, 2) = 10

            Console.WriteLine("Result1: " + result1);
            Console.WriteLine("Result2: " + result2);
            Console.WriteLine("Result3: " + result3);
            Console.WriteLine("Result4: " + result4);
        }
    }
}
