using System;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число");
            int x = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите второе число");
            int y = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите символ");
            string symbol = Console.ReadLine();

            int result = 0;

            if (symbol == "+")
            {
                result = x + y;
            }
            else if (symbol == "-")
            {
                result = x - y;
            }
            else if (symbol == "*")
            {
                result = x * y;
            }
            else if (symbol == "/")
            {
                result = x / y;
            }
            else if (symbol == "^")
            {
                result = x ^ y;
            }
            
            Console.WriteLine("Результат=" + result);
            Console.ReadLine();
            Console.Clear();
        }

    }
}
    