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
            //считываем соварь
            string[] words = File.ReadAllLines(path);

            Console.WriteLine("Let's play!");
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);
            
            Random random = new Random();

            while (true)
            {
                //загадываем сово

                string word = words[random.Next(0, words.Length)];
                Console.WriteLine(word);
                char[] charWord = word.ToCharArray();
                Console.WriteLine(charWord.Length);

                //создаем счетчик
                int opennedLetters = 0;
                int errors = MaxErrors;

                //сформирует строки для отображения процесса
                char[] viewWord = new char[charWord.Length];
                for (int i = 0; i < viewWord.Length; i++)
                {
                    viewWord[i] = '*';
                }

                Console.WriteLine(new string(viewWord));

                Console.WriteLine($"Загадано слово из {charWord.Length} букв");
                while (errors > 0 && opennedLetters != charWord.Length)
                {
                    // просим ввести букву и считываем строки
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    //делаем проверку, || - или, && - и
                    
                    if (inputString.Length == 0 || !char.IsLetter(inputString[0]))
                    {
                        //  Console.Clear();
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
                        Console.WriteLine("Красавчик!!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"такой буквы нет! Осталось попыток:{errors}");
                    }

                    Console.WriteLine(new string(viewWord));
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