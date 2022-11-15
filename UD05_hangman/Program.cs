using System;
using System.IO;
using System.Text;

namespace UD05_hangman
{
    internal class Program
    {
        private static string path = @"/Users/a.korytko/TMS/Lessons_p1/Материалы для занятий/Hangman/hangman/word_rus.txt";
        private const int MaxErrors = 10;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //считываем словарь
            string[] words = File.ReadAllLines(path);

            Console.WriteLine("Привет! Давай сыграем в игру!");
            Random random = new Random();

            while (true)
            {
                //загадываем слово
                int randomIndex = random.Next(0, words.Length); // 0, 34010 
                string word = words[randomIndex];
                Console.WriteLine(word);
                char[] charWord = word.ToCharArray();
                Console.WriteLine(charWord.Length);

                //создаём счётчик
                int opennedLetters = 0;
                int errors = MaxErrors;

                //сформирует строку для отображенния процесса
                char[] viewWord = new char[charWord.Length];
                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }

                Console.WriteLine(new string(viewWord));

                Console.WriteLine($"Загадано слово из {charWord.Length} букв");

                while (errors > 0 && opennedLetters != charWord.Length)
                {
                    //просим ввести букву и считываем строку
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //проверяем введенную строку
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
                        Console.WriteLine("Угадал!!! Есть такая буква!!");
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
                    Console.WriteLine($"Проиграл!! Это было слово - {word}");
                }
                else
                {
                    Console.WriteLine("Победа!!! Вы выиграли!!!!!");
                }

                Console.WriteLine("Чтобы продолжить нажмите Enter");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}