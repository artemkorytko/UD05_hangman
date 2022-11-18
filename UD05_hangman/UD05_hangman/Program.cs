using System;
using System.IO;


namespace UD05_hangman
{
    internal class Program
    {
        private static string path = @"D:\TeachMeSkill\word_rus.txt";
        private const int MaxErrors = 10;

        public static void Main(string[] args)
        {
            HangmanWord word = new HangmanWord(path);
            Console.WriteLine("Я хочу с тобой сыграть в одну игру!");
            
            word.GenerateWord();
            Console.WriteLine(word.StringWord);

            int errors = MaxErrors;
            
            Console.WriteLine(
                $"Тебе нужно отгадать слово, состоящее из {word.StringWord.Length} букв, если не отгадаешь, то я тебя найду и накажу. У тебя есть {errors} попыток");

            
            while (errors > 0 && !word.IsSolved)
            {
                Console.WriteLine("Введи букву");
                string inputString = Console.ReadLine();

                if (inputString.Length == 0 || !Char.IsLetter(inputString[0]))
                {
                    Console.Clear();
                    Console.WriteLine("Ты хочешь меня обмануть? НЕ ВЫЙДЕТ! Вводи ТОЛЬКО буквы");
                    return;
                }

                char letter = inputString[0];
                Console.Clear();
                if (word.CheckLetter(letter))
                {
                    Console.WriteLine("Хорошо, такая буква есть! давай продолжим:");
                }
                else
                {
                    errors--;
                    Console.WriteLine($"Ахаха, такой буквы нет! у тебя осталось {errors} попыток");
                }

                Console.WriteLine(word.ViewWord);
            }

            Console.Clear();

            if (errors == 0)
            {
                Console.WriteLine($"Ты проиграл, это было {word}, жди меня, я скоро тебя найду!!");
            }
            else
            {
                Console.WriteLine("Поздравляю, ты победил!");
            }

            Console.WriteLine("Чтобы продолжить нажмите Enter");
            Console.ReadLine();
            Console.Clear();
        }
    }
}