using System;
using System.IO;
using System.Text;

namespace Calculator_3
{
    internal class Program
    {
        public class Calculator
        {
            public static double number1;
            public static double number2;
            public static char sign;
            public static double x;

            public double Calculating()
            {
                if (Calculator.sign == '+')
                {
                    Calculator.x = Calculator.number1 + Calculator.number2;
                    
                }
                if (sign == '-')
                {
                    x = Calculator.number1 - Calculator.number2;
                }
                if (Calculator.sign == '*')
                {
                    x = Calculator.number1*Calculator.number2;
                }
                if (Calculator.sign == '/')
                {
                    if (Calculator.number2 == 0)
                    {
                        Console.WriteLine("can not be divided by 0");
                    }
                    else
                    {
                        x = Calculator.number1 / Calculator.number2;
                    }
                }

                if (Calculator.sign == '^')
                {
                    x = Math.Pow(Calculator.number1, Calculator.number2);
                }

                return x;
                Console.WriteLine($"{x}");
            }



            public static void Main(string[] args)
            {
                Console.WriteLine("Write the symbol of operation (choose +; -; *; /; ^)");
                Calculator.sign = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Write the first number");
                Calculator.number1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Write the second number");
                Calculator.number2 = Convert.ToDouble(Console.ReadLine());


            }

        }
    }
}