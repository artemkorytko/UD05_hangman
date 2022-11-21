using System;
using System.Runtime.InteropServices;

namespace UD05_hangman
{
    internal class Calculator
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                double x, y;
                string deistvie;

                try
                {
                    x = Double.Parse(Console.ReadLine());
                    y = Double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число!");
                    Console.ReadLine();
                    continue;
                }

               

                Console.WriteLine("Выберите действие: '+' '-' '/' '*' ");
                deistvie = Console.ReadLine();

                switch (deistvie)
                {
                    case "+":
                        Console.WriteLine(x + y);
                        break;
                    case "-":
                        Console.WriteLine(x - y);
                        break;
                    case "*":
                        Console.WriteLine(x * y);
                        break;
                    case "/":
                        if (y == 0)
                            Console.WriteLine(0);
                        else
                        {
                            Console.WriteLine(x / y);
                        }

                        break;
                    default:
                        Console.WriteLine("Введите верное действие");
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
