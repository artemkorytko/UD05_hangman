using System;
using System.IO;
using System.Text;


namespace UD05_calculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);


            Calculator calculator = new Calculator();
            string actualText = Console.ReadLine();
            int answer = calculator.Calculate(actualText);

            Console.WriteLine($"Ответ: {answer}");
        }
    }
}