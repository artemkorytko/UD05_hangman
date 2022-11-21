using System;
using System.IO;
using System.Text;

namespace UD05_hangman
{
    internal class Program
    {
        private static string path = @"C:\Users\vanec\Documents\UD05_hangman\word_rus.txt";
        private const int MaxErrors = 10;

        public static void Main(string[] args)
        {
            HangmanWord word = new HangmanWord(path);
            
            Console.WriteLine("Let's play!");
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);
            
            Random random = new Random();

            while (true)
            {
                word.GenerateWord();
                Console.WriteLine(word.StringWord);

                //создаем счетчик
                int errors = MaxErrors;

                
                Console.WriteLine($"Загадано слово из {word.StringWord.Length} букв");
                
                while (errors > 0 && !word.IsSolved)
                {
                    // просим ввести букву и считываем строки
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //делаем проверку, || - или, && - и
                    
                    if (inputString.Length == 0 || !char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите только буквы");
                        return;
                    }
                    //проверяем есть ли такая буква в слове
                    char letter = inputString[0];
                    

                    Console.Clear();
                    if (word.CheckLetter(letter))
                    {
                        Console.WriteLine("Красавчик!!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"такой буквы нет! Осталось попыток:{errors}");
                    }

                    Console.WriteLine(word.ViewWord);
                }

                Console.Clear();
                if (errors == 0)
                {
                    Console.WriteLine($"Продул! Это было слово - {word}");
                }
                else
                {
                    Console.WriteLine("Ты выиграл!!");
                }

                Console.WriteLine("Чтобы продолжить нажмите Enter");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}