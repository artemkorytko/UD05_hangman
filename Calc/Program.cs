using System;
using System.Linq;

namespace Calc
{
    internal class Program
    {
        static char[] value1 = new[] { '+', '-', '*', '/', '^' };

        public static void Main(string[] args)
        {
            FirstStep();
            TwoStep();
        }

        public static void FirstStep()
        {
            int x;
            int y;

            x = int.Parse(Console.ReadLine());
            char Sing = Console.ReadLine().ToCharArray()[0];
            y = int.Parse(Console.ReadLine());
            bool cont = false;
            for (int i = 0; i < value1.Length; i++)
            {
                if (value1[i] == Sing)
                {
                    cont = true;
                    break;
                }
            }

            if (cont)
            {
                switch (Sing)
                {
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
                        Console.WriteLine(x / y);
                        break;

                    case '^':
                        Console.WriteLine(x ^ y);
                        break;
                }
            }

        }

        public static void TwoStep()
        {
            string input = Console.ReadLine();

            string[] inputs = input.Split(' ');

            int x;
            char sign;
            int y;

            bool isX = int.TryParse(inputs[0], out x);
            bool isSign = char.TryParse(inputs[1], out sign);
            bool isY = int.TryParse(inputs[2], out y);


            {
                switch (sign)
                {
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
                        Console.WriteLine(x / y);
                        break;
                    case '^':
                        Console.WriteLine(x ^ y);
                        break;
                }
            }
        }

    }
}