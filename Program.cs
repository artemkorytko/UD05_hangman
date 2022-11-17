using System;
using System.IO;
using System.Text;

namespace Hangman_
{
    internal class Program
    {
        
        private static string path = @"/Applications/Unity/Hangman/word_rus.txt";
        private const int MaxErrors = 10; // максимальное количество попыток угадать буквы

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //считываем словарь
            string[] words = File.ReadAllLines(path);

            Console.WriteLine("Hello! Let's play: ");
            Random random = new Random(); //new random - создает новый экземпляр типа Random

            while (true) // цикл продолжается (т е игра будет продолжаться) всегда пока игра запущена
            {
                // загадываем слово
                int randomIndex = random.Next(0, words.Length); //words.Length - все слова от 0 до 34010
                string word = words[randomIndex]; //берем слово с этим рандомным индексом со строчки выше
                Console.WriteLine(word);
                char[] charWord = word.ToCharArray();
                Console.WriteLine(charWord.Length);

                //создаём счётчик
                int opennedLetters = 0; //счётчик открытых букв, в начале 0
                int errors = MaxErrors;


                char[] viewWord = new char[charWord.Length]; //создаём экземпляр - массив состоящий из символов

                for (int i = 0; i < viewWord.Length; i++) //чтобы считать кол-во символов в загаданном слове
                {
                    viewWord[i] = '*'; //одиночные ' т.к. работаем с одним символом
                }

                Console.WriteLine(new string(viewWord)); //выводим загаданное слово

                //начинаем разгадывать загаданное слово
                Console.WriteLine(
                    $"Загаданное слово из {charWord.Length} буквы"); //$ ; информация о длине загаданного слова{charWord.Length}

                while (errors > 0 && opennedLetters != charWord.Length) //если кол-во ошибок > 0 или ...
                {
                    //просим ввести букву и считываем строки
                    Console.WriteLine("Введите букву");
                    string inputString = Console.ReadLine();

                    if (inputString.Length == 0 ||
                        !Char.IsLetter(
                            inputString[
                                0])) //   (|| - или) если длина строки = 0  ИЛИ символ(который пришел от пользователя) не буква => попадаем внутрь нашего условия условия ; Char.IsLetter(inputString[0]; ! - отрицание (если пришло "да", то ! - преобразует в "нет". Т Е если выполнилось одно из условий)
                    {
                        Console.Clear();
                        Console.WriteLine("Вводите только буквы");
                        return; //останавливает выполнение кода
                    }

                    //проверяем выведенную строку есть ли такая буква в слова, т.к. не попали в первое условие if
                    char letter = inputString[0]; //в инпутстринг - то что ввел пользователь
                    bool isLetterExist = false;
                    for (int i = 0; i < charWord.Length; i++)
                    {
                        if (charWord[i] == letter) //если какая-то буква из слова = введенной пользователем букве
                        {
                            opennedLetters++;
                            viewWord[i] = charWord[i]; //открываем букву если такая в слове у нас есть
                            charWord[i] = '-';
                            isLetterExist = true;
                        }
                    }

                    Console.Clear();
                    if (isLetterExist)
                    {
                        Console.WriteLine("Угадал, есть такая буква!!");
                    }
                    else
                    {
                        errors--; //если не угадали букву то кол-во ошибок которые еще можно сделать уменьшится на 1
                        Console.WriteLine("Такой буквы нет");
                    }

                    Console.WriteLine(new string(viewWord));
                }

                Console.Clear();
                if (errors == 0)
                {
                    Console.WriteLine($"You loose The word was - {word}");
                }
                else
                {
                    Console.WriteLine("You win!!!");
                }
                Console.WriteLine("Tab enter for continue game!!");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}