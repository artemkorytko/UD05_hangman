using System;
using System.IO;

namespace UD05Hangman
{
    internal class Program
    {
        private static string Path = @"D:\Project Hangman\UD05_hangman\word_rus.txt";
        private const int maxErrors = 10;

        public static void Main()
        {
            //считываем словарь
            string[] words = File.ReadAllLines(Path);

            Console.WriteLine("Добро пожаловать в игру!");
            while (true)
            {
                //загадываем слово
                Random random = new Random();
                string word = words[random.Next(0, words.Length)];
                Console.WriteLine(word);
                char[] charWord = word.ToCharArray();
                Console.WriteLine(charWord.Length);

                //создаём счётчик
                int openedLetters = 0;
                int errors = maxErrors;

                //формируем строку для отображения процесса
                char[] viewWord = new char[charWord.Length];

                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }

                Console.WriteLine(new string(viewWord));

                Console.WriteLine($"Я загадал слово из {charWord.Length} букв");

                while (errors > 0 && openedLetters != charWord.Length)
                {
                    //просим ввести букву и считываем её
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //проверяем введённые данные
                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите только буквы!");
                    }

                    //проверяем есть ли такая буква в слове
                    char letter = inputString[0];
                    bool isLetterExist = false;
                    for (int i = 0; i < charWord.Length; i++)
                    {
                        if (charWord[i] == letter)
                        {
                            openedLetters++;
                            viewWord[i] = charWord[i];
                            charWord[i] = '-';
                            isLetterExist = true;
                        }
                    }

                    Console.Clear();
                    if (isLetterExist)
                    {
                        Console.WriteLine("Верно!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось {errors} попыток");
                    }
                    Console.WriteLine(new string(viewWord));
                }
                
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