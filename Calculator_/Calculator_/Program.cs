using System;
using System.IO;
using System.Text;

namespace Calculator_
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Write the symbol of operation (choose +; -; *; /; ^)");
            char sign = Convert.ToChar(Console.ReadLine());
            

            if (sign == '+')
            {
                Console.WriteLine("Write the first number for operation");
                double number1 = Convert.ToDouble(Console.ReadLine());
            
                Console.WriteLine("Write the first number for operation");
                double number2 = Convert.ToDouble(Console.ReadLine());
                
                double x = number1 + number2;
                Console.WriteLine($"{number1} + {number2} = {x}");
            }
            if (sign == '-')
            {
                Console.WriteLine("Write the first number for operation");
                double number1 = Convert.ToDouble(Console.ReadLine());
            
                Console.WriteLine("Write the first number for operation");
                double number2 = Convert.ToDouble(Console.ReadLine());
                
                double x = number1 - number2;
                Console.WriteLine($"{number1} - {number2} = {x}");
            }
            if (sign == '*')
            {
                Console.WriteLine("Write the first number for operation");
                double number1 = Convert.ToDouble(Console.ReadLine());
            
                Console.WriteLine("Write the first number for operation");
                double number2 = Convert.ToDouble(Console.ReadLine());
                
                double x = number1 * number2;
                Console.WriteLine($"{number1} * {number2} = {x}");
            }
            if (sign == '/')
            {
                Console.WriteLine("Write the first number for operation");
                double number1 = Convert.ToDouble(Console.ReadLine());
            
                Console.WriteLine("Write the first number for operation");
                double number2 = Convert.ToDouble(Console.ReadLine());
                
                if (number2 == 0)
                {
                    Console.WriteLine("can not be divided by 0");
                }
                else
                {
                    double x = number1 / number2;
                    Console.WriteLine($"{number1} / {number2} = {x}");
                }
            }

            if (sign == '^')
            { 
                Console.WriteLine("Write the number");
                double number1 = Convert.ToDouble(Console.ReadLine());
            
                Console.WriteLine("Write the number of degree");
                double number2 = Convert.ToDouble(Console.ReadLine());
                double x = Math.Pow(number1, number2);
                Console.WriteLine($"{number1}^{number2} = {x}");
            }
            if (sign != '+' && sign != '-' && sign != '*' && sign != '/' && sign != '^')
            {
                Console.WriteLine("You have errors in inputted data");
            }
        }
    }
}