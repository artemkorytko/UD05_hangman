using System;
using System.IO;
using System.Text;

namespace Calculator_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Write the expression which you want to evalute through a space (for example: 3 + 4)");
            string expression = Convert.ToString(Console.ReadLine());
            char[] separator = {' '};
            string[] divided = expression.Split(separator);
            

            string checksign = Convert.ToString(divided[1]);
            string checknumber1 = Convert.ToString(divided[0]);
            string checknumber2 = Convert.ToString(divided[2]);
            if (checksign.Length != 1 || checknumber1.Length == 0 || checknumber2.Length == 0)
            {
                Console.WriteLine("you have errors in inputted data");
            }

            else 
            {
                double number1 = Convert.ToDouble(divided[0]);
                char sign = Convert.ToChar(divided[1]);
                double number2 = Convert.ToDouble(divided[2]);
                
                if (sign != '+' && sign != '-' && sign != '*' && sign != '/' && sign != '^')
                {
                    Console.WriteLine("you have errors in inputted sign");
                }
                
                if (sign == '+')
                {
                    double x = number1 + number2;
                    Console.WriteLine($"{number1} + {number2} = {x}");
                }
                if (sign == '-')
                {
                    double x = number1 - number2;
                    Console.WriteLine($"{number1} - {number2} = {x}");
                }
                if (sign == '*')
                {

                    double x = number1 * number2;
                    Console.WriteLine($"{number1} * {number2} = {x}");
                }
                if (sign == '/')
                {

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
                
                    double x = Math.Pow(number1, number2);
                    Console.WriteLine($"{number1}^{number2} = {x}");
                }
                
                
            }


        }
    }
 
    internal class divided
    {
    }
}