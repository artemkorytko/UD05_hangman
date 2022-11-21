using System;

namespace hangmann
{
    internal class Program
    {
        private static string path = @"D:\dasha2\hangman\word_rus.txt";
        private const int MaxErrors = 10;
        
        public static void Main(string[] args)
        {
            HangmanWord word = new HangmanWord(path);
            Console.WriteLine("Привет! Давай сыграем в игру!");
            

           while (true) 
           {
               
               word.GenerateWord();
               Console.WriteLine(word.StringWord);//debug

               //создаем счетчик 
               int errors = MaxErrors;

               Console.WriteLine($"Загадано слово из {word.StringWord.Length} букв");

               while (errors > 0 && !word.IsSolved) 
               {

                   //просим ввести буквуи считываем строки
                   Console.WriteLine("Введите букву");
                   string imputString = Console.ReadLine();

                   //проверяем введенную стооку 
                   if (imputString.Length == 0 || !char.IsLetter(imputString[0]))
                   {
                       Console.Clear();
                       Console.WriteLine("Вводите только буквы");
                       return;
                   }

                   // проверяем есть ли такая буква в слове 
                   char letter = imputString[0];
                   

                   Console.Clear();
                   if (word.CheckLetter(letter))
                   {
                       Console.WriteLine("Угадал! Есть такая буква!");
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
                   Console.WriteLine($"Ты проиграл! Это было слово - {word}");
               }
               else
               {
                   Console.WriteLine("Победа! Вы выйграли!");
               }

               Console.WriteLine("Чтобы продолжить нажмите Enter");
               Console.ReadLine();
               Console.Clear();
           }

        }
    }
}
