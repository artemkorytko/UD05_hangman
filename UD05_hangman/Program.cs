using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введите выражение(пример: \"2 + 3 * 5\"): ");
        var expression = Console.ReadLine();
        Console.WriteLine("{0} = {1}", expression, Calc(expression));
        Console.ReadLine();
    }

    /// <summary>
    /// Калькулятор выражения
    /// </summary>
    /// <param name="mathExpression">Математическое выражение</param>
    /// <returns></returns>
    static double Calc(string mathExpression)
    {
        var parts = mathExpression.Split(' '); //разбиваем выражение на части

        var operands = new List<double>();
        var operations = new List<string>();
        //в цикле разделяем операнды и операции
        for (var i = 0; i < parts.Length; i += 2)
        {
            operands.Add(Convert.ToDouble(parts[i]));
            if (i + 1 < parts.Length)
            {
                operations.Add(parts[i + 1]);
            }
        }

        //передаем в метод операции с одинаковым приоритетом и функции для их вычисления
        Calculate(operands, operations, "*", (a, b) => a * b, "/", (a, b) => a / b);
        Calculate(operands, operations, "+", (a, b) => a + b, "-", (a, b) => a - b);

        return operands[0]; //результат
    }

    /// <summary>
    /// Калькулятор для операций с одинаковым приоритетом
    /// </summary>
    /// <param name="operands">Список операндов</param>
    /// <param name="operations">Список операций</param>
    /// <param name="currentOperation1">Текущая операция 1</param>
    /// <param name="function1">Функция для операции 1</param>
    /// <param name="currentOperation2">Текущая операция 2</param>
    /// <param name="function2">Функция для операции 2</param>
    static void Calculate(List<double> operands, List<string> operations, 
        string currentOperation1, Func<double, double, double> function1, 
        string currentOperation2, Func<double, double, double> function2)
    {
        while (true)
        {
            //ищем индексы текущих операций
            var i1 = operations.IndexOf(currentOperation1);
            var i2 = operations.IndexOf(currentOperation2);

            int index; //индекс операции которую будем вычислять
            if (i1 >= 0 && i2 >= 0)
            {
                index = Math.Min(i1, i2);
            }
            else
            {
                index = Math.Max(i1, i2);
            }

            //если операции нет в списке - выходим из цикла
            if (index < 0)
            {
                break;
            }

            //вычисление текущей операции
            if (index == i1)
            {
                operands[index] = function1(operands[index], operands[index + 1]);
            }
            else
            {
                operands[index] = function2(operands[index], operands[index + 1]);
            }
            //удаление операции
            operations.RemoveAt(index);
            //удаление операнда
            operands.RemoveAt(index + 1);
        }
    }
}