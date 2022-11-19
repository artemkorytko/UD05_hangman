using System;
using System.Runtime.InteropServices;

namespace HomeworkCalculatorV1
{
    internal class Program
    {
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
                    char[] chars = {'+', '-', '*', '/', '^'};
                    
                    string[] subs = inputData.Split(chars, 2);
                    int x = CheckParse(subs[0]);
                    int y = CheckParse(subs[1]);
                    
                    int index = -1;
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (index == -1)
                            index = inputData.IndexOf(chars[i]);
                    }
                    char operation = inputData[index];
                    
                    
                    CalculationProcess process = new CalculationProcess(x,y,operation);
                    Console.WriteLine(process.WriteResult());
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("моя твоя не понимать!");
                }
            }
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

        private static int CheckParse(string subs)
        {
            int number;
            bool isCheck = int.TryParse(subs, out number);
            
            if (isCheck)
                return Int32.Parse(subs);

            Console.WriteLine("Ошибка конвертации, return 0");
            return 0;
        }
    }
}