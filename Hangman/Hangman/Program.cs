using System;
using System.IO;

namespace Hangman
{
    internal class Program
    {
        private static string path = @" E:\Unity\TeachMeSkills\UD05_hangman/word_rus.txt ";
        private const int MaxErrors = 10;

        public static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(path);
            Console.WriteLine("Привет! Давай поираем в виселицу!");
            Random random = new Random();

            while (true)
            {
                //загадываем слово
                string word = words[random.Next(0, words.Length)];
                Console.WriteLine(word);
                char[] charWord = word.ToCharArray();
                Console.WriteLine(charWord.Length);

                //создаем счетчик
                int openedLetters = 0;
                int errors = MaxErrors;

                char[] viewWord = new char[charWord.Length];
                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }

                Console.WriteLine(new string(viewWord));

                Console.WriteLine($"Загадано слово из {charWord.Length} букв");

                while (errors > 0 && openedLetters != charWord.Length)
                {
                    Console.WriteLine("Введи букву");
                    string inputString = Console.ReadLine();

                    // проверяем введеную строку
                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Введите только буквы!");
                        return;
                    }

                    //проверяем есть ли буква в слове
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
                        Console.WriteLine("Угадал!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {errors}");
                    }

                    Console.WriteLine(new string(viewWord));
                }

                Console.Clear();
                if (errors == 0)
                {
                    Console.WriteLine($"Проиграл! Это было слово - {word}");
                }
                else
                {
                    Console.WriteLine("Победа! Молодец!");
                }

                Console.WriteLine("Чтобы продолжить нажми Enter");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}