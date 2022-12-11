using System;
using System.IO;
using System.Text;

namespace UD05_hangman
{
    internal class Program
    {
        private static string path = @"/Applications/Unity/Hangman/word_rus.txt";//указываем путь к файлу
        private const int MaxErrors = 10;//указываем максимальное количество ошибок - 10

        public static void Main(string[] args)
        {
            HangmanWord word = new HangmanWord(path); // создаем экземлпяра класса HANGMANWORD, передаем переменную path, которая понадобится для реализации функции HangmanWord класса HangmanWord (передаем путь (экзмепляр класса связан с путем файла))
            

            Console.WriteLine("Привет! Давай сыграем в игру!");
            

            while (true)
            {
               word.GenerateWord(); // GenerateWord - прописано в HANGMANWORD, word - прописан выше, является экземпляром класса HangmanWOrd
               Console.WriteLine(word.StringWord);// StringWord - прописано в HANGMANWORD, word - прописан выше, является экземпляром класса HangmanWOrd

                //создаём счётчик
                
                int errors = MaxErrors; //изначально оставшееся кол-во возможно допустимых ошибок - 10
                

                Console.WriteLine($"Загадано слово из {word.StringWord.Length} букв"); // stringWord - прописан в HangmanWord

                while (errors > 0 && !word.IsSolved) //пока количетсво возможно допустимых ошибок еще > 0 И слово не разгадано
                {
                    //просим ввести букву и считываем строку
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine(); //считали введенную букву

                    //проверяем введенную строку
                    if (inputString.Length == 0 || !Char.IsLetter(inputString[0])) //если длина введенной строки(т е буквы) равно 0 ИЛИ 0-ой элемент массива введенной строки не соответсвует никакой букве по коду из ЮНИКОДА(!Char.IsLetter)
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите только буквы");
                        return;
                    }

                    //проверяем есть ли такая буква в слове
                    char letter = inputString[0];//присваиваем в переменную letter введенную букву
                    

                    Console.Clear();
                    if (word.CheckLetter(letter)) //передаем введенную букву в функнцию checkLetter в экземпляр word класса HangmanWord
                    {
                        Console.WriteLine("Угадал!!! Есть такая буква!!");
                    }
                    else
                    {
                        errors--; //кл-во ошибок уменьшается на 1
                        Console.WriteLine($"Такой буквы нет! Осталось попыток: {errors}");
                    }

                    Console.WriteLine(word.ViewWord); //выводит результат функции(метода) viewWord из экземпляра word класса HangmanWord
                }

                Console.Clear();
                if (errors == 0) //когда кол-во ошибок остается 0
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