using System;
using System.IO;
using System.Text;

namespace UD05Hangman
{
    internal class Program
    {
        private static string path = @"D:\Project Hangman\UD05_hangman\word_rus.txt";
        private const int maxErrors = 10;

        public static void Main()
        {
            HangmanWord word = new HangmanWord(path);
            Console.WriteLine("Добро пожаловать в эфир капитал шоу Поле Чудес!");
            
            while (true)
            {
                word.GenerateWord();
                Console.WriteLine(word.StringWord);
                
                //создаём счётчик
                int errors = maxErrors;
                
                Console.WriteLine($"Я загадал слово из {word.StringWord.Length} букв");

                while (errors > 0 && !word.IsSolved)
                {
                    //просим ввести букву и считываем её
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //проверяем введённые данные
                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите только буквы!");
                        return;
                    }

                    //проверяем есть ли такая буква в слове
                    char letter = inputString[0];
                    
                    Console.Clear();
                    if (word.CheckLetter(letter))
                    {
                        Console.WriteLine("Верно!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось {errors} попыток");
                    }
                    
                    Console.WriteLine(word.ViewWord);
                }
                
                Console.Clear();
                
                if (errors == 0)
                {
                    Console.WriteLine($"Попытки закончились! Ты проиграл! Искомое слово - {word}");
                }
                else
                {
                    Console.WriteLine("Все буквы угаданы верно! Победа!");
                }

                Console.WriteLine("Для продолжения нажми Enter");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}