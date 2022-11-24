using System;
using System.IO;
using System.Runtime.InteropServices;

namespace HangMan
{
    internal class Program
    {
        private static string path = @"/Users/Александра/Desktop/word_rus.txt";
        private const int MaxErrors = 10; //макс кол-во ошибок

        public static void Main(string[] args)
        {
            hangmanWord word = new hangmanWord(path);
            Console.WriteLine("Привет! Давай сыграем в игру!");
            Random random = new Random();

            while (true)
            {
                word.GenerateWord();
                Console.WriteLine(word.StringWord);//debug
                    
                //создаем счетчик
                int errors = MaxErrors;
                

                Console.WriteLine($"Загадано слово из {word.StringWord.Length} бкукв");
 
                while (errors > 0 && !word.isSolved)
                {
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //не даем ввести что-то кроме буквы
                    if (inputString.Length == 0 || !char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Это не буква");
                        return;
                    }

                    //проверяем есть ли эта буква в слове
                    char letter = inputString[0];
                    
                    Console.Clear();
                    if (word.CheckLetter(letter))
                    {
                        Console.WriteLine("Верно, эта буква есть!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Неверно, такой буквы нет! Осталось {errors} попыток");
                    }

                    Console.WriteLine(word.ViewWord);
                }

                Console.Clear();
                if (errors == 0)
                {
                    Console.WriteLine($"Вы проиграли! Слово было - {word}");
                }
                else
                {
                    Console.WriteLine("Вы Выиграли!");
                }

                Console.WriteLine("Что бы продолжить нажмите  Enter ");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}