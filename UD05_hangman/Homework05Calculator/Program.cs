using System;
using System.Runtime.InteropServices;

namespace HomeworkCalculatorV1
{
    internal class Program
    {
        
        private static char[] chars = {'+', '-', '*', '/', '^'};
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Тебя приветствует калькулятор.(версия 1.0)");
           
            while (true)
            {
                Console.WriteLine("Имей ввиду, что я умею выполнять операции над двумя числами: +, -, *, /, ^");
                Console.Write("Введи полное выражение: ");
                string inputData = Console.ReadLine();
                
                if (!String.IsNullOrWhiteSpace(inputData) && CheckInputData(inputData))
                {
                    string[] str = inputData.Split(chars, 2);
                    int x = CheckParse(str[0]);
                    int y = CheckParse(str[1]);
                    
                    CalculationProcess process = new CalculationProcess(x,y,SignSearch(inputData));
                    Console.WriteLine(process.WriteResult());
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("моя твоя не понимать!");
                }
            }
        }

        private static char SignSearch(string str)
        {
            
            int index = -1;
            for (int i = 0; i < chars.Length; i++)
            {
                if (index == -1)
                    index = str.IndexOf(chars[i]);
            }

            return str[index];
        }

        private static bool CheckInputData(string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (Char.IsLetter(data[i]))
                    return false;
            }
            return true;
        }

        private static int CheckParse(string str)
        {
            int number;
            bool isCheck = int.TryParse(str, out number);
            
            if (isCheck)
                return Int32.Parse(str);

            Console.WriteLine("Ошибка конвертации, return 0");
            return 0;
        }
    }
}