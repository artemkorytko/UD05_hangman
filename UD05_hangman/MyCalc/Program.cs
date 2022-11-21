using System;

namespace MyCalc
{
    internal class Program
    {
        private static string someString;
        private static int x;
        private static int y;
        private static char sign;
        private static string error;

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                //Просим ввести выражение для решения и считываем его
                Console.WriteLine(
                    "Введите выражение для решения и нажмите Enter. Каждая переменная и знак должны быть разделены пробелами!\nИспользуйте только целые числа! Например: 2421 + 4537");
                someString = Console.ReadLine();

                //переводим выражение в массив строк, преобразуем тип и выполняем проверки валидности данных
                error = null;
                string[] splitString = someString.Split(' ');
                if (splitString.Length == 3)
                {
                    bool result1 = int.TryParse(splitString[0], out x);
                    if (result1 == true)
                    {
                        //Console.WriteLine($"Успех! Первое число {x}"); //Debug message
                        bool result2 = int.TryParse(splitString[2], out y);
                        if (result2 == true)
                        {
                            //Console.WriteLine($"Успех! Второе число {y}"); //Debug message
                            bool result3 = char.TryParse(splitString[1], out sign);
                            if (result3 == true && sign == '+' || sign == '-' || sign == '*' || sign == '/' ||
                                sign == '^')
                            {
                                //Console.WriteLine($"Успех! Знак {sign}"); //Debug message
                            }
                            else
                            {
                                error = "Неверный формат введённого выражения. Не введён знак арифметической операции!";
                            }
                        }
                        else
                        {
                            error =
                                "Неверный формат введённого выражения. В качестве второй переменной введены неверные данные!";
                        }
                    }
                    else
                    {
                        error = "Неверный формат введённого выражения. В качестве первой переменной введены неверные данные!";
                    }
                }
                else
                {
                    error =
                        "Неверный формат введённого выражения. Каждая переменная и знак должны быть разделены пробелами!";
                }

                //Инициализируем экземпляр класса и выполняем проверку деления на 0
                CalcLogic Calc = new CalcLogic(x, y, sign);
                if (error == null)
                {
                    error = Calc.CheckDivNull();
                }

                //выводим ответ, либо сообщение об ошибке
                if (error == null)
                {
                    Console.WriteLine($"{someString} = {Calc.Calculation()}");
                }
                else
                {
                    Console.WriteLine(error);
                }
                Console.WriteLine();
                Console.WriteLine("Для решения следующего выражения нажмите Enter");
                Console.ReadLine();
            }
        }
    }
}