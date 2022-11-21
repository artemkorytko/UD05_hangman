using System;

namespace Calculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a;
            int b;
            char op;
            Console.WriteLine("ведите а ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите b");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите оператор, используйте только +, -, /, *");
            op = Convert.ToChar(Console.ReadLine());

            double result = 0.0;
            switch (op)
            {
                case '/' :
                    if (b!=0)
                    {
                        result = a / b;
                        Console.WriteLine( $"ответ {result}");
                    }
                    else
                    {
                        Console.WriteLine("на ноль делить нельзя!");
                        return;
                    }
                    break;
                    
                case '*':
                    result = a * b;
                    Console.WriteLine($"ответ {result}");
                    break;
                
                case '-':
                    result = a - b;
                    Console.WriteLine($"ответ {result}");
                    break;
                    
                case '+':
                    result = a + b;
                    Console.WriteLine($"ответ {result}");
                    break;
                
                default:
                    Console.WriteLine("ошибка, проверьте введенные данные");
                    break;
                
            }
            
            
            
        }
    }
}