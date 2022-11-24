using System;

namespace Calculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char sign;
            double x = 0, y = 0;
            Console.WriteLine("-КАЛЬКУЛЯТОР-");
            try
            {
                Console.WriteLine("Введите число");
                x = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите второе число");
                y = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR");
            }


            Console.WriteLine("Введите один из знаков  +  -  *   / ");
            sign = Convert.ToChar(Console.ReadLine());

            switch (sign)
            {
                default:
                    Console.WriteLine("ERROR");
                    break;
                case '+':
                    Console.WriteLine(x + y);
                    break;
                case '-':
                    Console.WriteLine(x - y);
                    break;
                case '*':
                    Console.WriteLine(x * y);
                    break;
                case '/':
                    if (y == 0)
                        Console.WriteLine("ERROR");
                    else
                        Console.WriteLine(x / y);
                    break;
            }
        }
    }
}