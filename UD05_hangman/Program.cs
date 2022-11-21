using System;
using System.IO;
using System.Text;

namespace UD05_hangman
{
    internal class Program
    {
        private static string path = @"/Applications/Unity/Hangman/word_rus.txt";
        private const int MaxErrors = 10;

        public static void Main(string[] args)
        {
            HangmanWord word = new HangmanWord(path);
            

            Console.WriteLine("Привет! Давай сыграем в игру!");
            

            while (true)
            {
               word.GenerateWord();
               Console.WriteLine(word.StringWord);

                //создаём счётчик
                
                int errors = MaxErrors;
                

                Console.WriteLine($"Загадано слово из {word.StringWord.Length} букв");

                while (errors > 0 && !word.IsSolved)
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
                    

                    Console.Clear();
                    if (word.CheckLetter(letter))
                    {
                        Console.WriteLine("Угадал!!! Есть такая буква!!");
                    }
                    else
                    {
                        errors--;
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {errors}");
                    }

                    Console.WriteLine(word.ViewWord);
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