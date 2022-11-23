using System;
using System.IO;
using System.Text;

namespace UD05_calculator
{
    public class Calculator
    {
        private int x;
        private int y;
        private char oper;
        private int result = 0;

        public int Calculate(string actualText)
        {
            string[] formattedText = actualText.Split(' ');
            bool bIsValid = isValid(formattedText);
            if (!bIsValid)
            {
                Console.WriteLine("Error");
                return -1;
            }

            x = int.Parse(formattedText[0]);
            oper = Convert.ToChar(formattedText[1]);
            y = int.Parse(formattedText[2]);

            return Calculation();
        }

        private bool isValid(string[] text)
        {
            for (int i = 0; i < 2; i += 2)
            {
                foreach (char ch in text[i])
                {
                    if (!char.IsDigit(ch)) return false;
                }
            }

            return true;
        }

        private int Calculation()
        {
            if (oper == '+')
            {
                return x + y;
            }

            if (oper == '-')
            {
                return x - y;
            }

            if (oper == '*')
            {
                return x * y;
            }

            if (oper == '/')
            {
                return x / y;
            }

            if (oper == '^')
            {
                return Convert.ToInt32(Math.Pow(x, y));
            }

            Console.WriteLine("Что-то не так :c Проверьте правильность ввода данных.");
            return -1;
        }
    }
}