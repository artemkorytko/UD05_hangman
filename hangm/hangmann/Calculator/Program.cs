using System;

namespace Calculator
{
    internal class Program

    {
        private static char[] chars = { '-', '+', '*', '/' };
        private static char oper = 'x';
        
       
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в калькулятор");
            Console.WriteLine("В калькуляторе используются такие операторы, как '/', '*', '-', '+',");

            while (true)
            {
               
                Console.WriteLine("Введите выражение:");

                string imputData = Console.ReadLine();

                string[] str = imputData.Split(chars, 2);
                int a = Int32.Parse(str[0]);
                int b = Int32.Parse(str[1]);
                
                int index = -1;
                for (int i = 0; i < chars.Length; i++)
                {
                    if (index == -1)
                        index = imputData.IndexOf(chars[i]);
                }

                oper = imputData[index];
                    

                brain_of_calculate brain = new brain_of_calculate(a, b, oper);
                Console.WriteLine(brain.WriteResult());


            }

        }
    }
}