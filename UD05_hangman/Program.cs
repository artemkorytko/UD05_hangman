using System;
using System.IO;

namespace UD05_hangman
{
    internal class Program
    {
        private static string path = @"F:\Unity\rider\hangman\word_rus.txt";
        private const int MaxErrors = 10;

        public static void Main(string[] args)

        {
            //считываем словарь 
            String[] words = File.ReadAllLines(path);

            Console.WriteLine("Привет! Давай играть!");
            Random random = new Random();

            while (true)
            {

                //загадываем слово
                int randomIndex = random.Next(0, words.Length);
                string word = words[randomIndex];
                Console.WriteLine(word);
                char[] charWord = word.ToCharArray();
                Console.WriteLine(charWord.Length);

                //cоздаем счетчик
                int opennedLetters = 0;
                int errors = MaxErrors;

                //сформирует строки для отображенния процесса
                char[] viewWord = new char[charWord.Length];
                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }

                Console.WriteLine(new string(viewWord));

                Console.WriteLine($"Загадано слово из {charWord.Length} букв");

                while (errors > 0 && opennedLetters != charWord.Length)
                {

                    //просим ввести букву и считываем строки
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //проверяем введеную строку
                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите только буквы");
                        return;
                    }

                    //проверяем есть ли такая буква в слове
                    char letter = inputString[0];
                    bool isLetterExist = false;
                    for (int i = 0; i < charWord.Length; i++)
                    {
                        if (charWord[i] == letter)
                        {
                            opennedLetters++;
                            viewWord[i] = charWord[i];
                            charWord[i] = '-';
                            isLetterExist = true;
                        }
                    }

                    Console.Clear();
                    if (isLetterExist)
                    {
                        Console.WriteLine("Угадал! Есть такая буква!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось попыток:{errors}");
                    }

                    Console.WriteLine(new string(viewWord));

                }

                Console.Clear();
                if (errors == 0)
                {
                    Console.WriteLine($"Проиграл!! Это было слово - {word}");
                }
                else
                {
                    Console.WriteLine("Победа!!! Вы выиграли!!!");
                }

                Console.WriteLine("Что бы продолжить нажмите Enter");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
