using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;
using System.Timers; //подключили какой-то непонятный но нужный функционал

namespace UD05_hangman //пространство имен, все что относится к этому проекту
{
    internal class Program
    {
        private static string path = @"/Users/ascha/Unity_Projects/UD05_hangman/UD05_hangman/word_rus.txt";

        private const int MaxErrors = 10;
        private const int noLongerSym = 6;

        //---------------рисуем сложного человечка-----------

        //функция вывода рисунка
        private static void DrawCoolerHangman(int user_error_count)
        {
            string[] coolerVisual = new string[12]
            {
                "#     +------+      #", //0
                "#    ||       |     #", //1
                "#    ||       |     #", //2
                "#    ||    (xx)     #", //3
                "#    ||      |      #", //4
                "#    ||    +-|-+    #", //5
                "#    ||   /  | |    #", //6
                "#    ||     /|      #", //7
                "#    ||    / |      #", //8
                "#    ||   .  .      #", //9
                "#    ||_____________#", //10
                "#    ||             #" //11 - empty
            };
            
            Console.WriteLine($"##### {user_error_count} из {MaxErrors} ######");   //верх рамочки
            
            for (int i = 0; i < 11; i++)  //рисует чела в зависимости от количества ошибочек
            {
                if (i <= user_error_count)
                    Console.WriteLine(coolerVisual[i]);
                else Console.WriteLine(coolerVisual[11]);
            }
            
            Console.WriteLine("#####################");    //низ рамочки
        }


        public static void Main(string[] args)
        {
            string[] all_words = File.ReadAllLines(path); //прочитает все строки из файла и засунет в массив
            
            // Новый массив только коротких слов
            string[] short_words = null;

            // выудить короткие слова и поместить в массив short_words[]
            // ----------------------------------------------------------
            int short_count = 0;
            for (int i = 0; i < all_words.Length; i++)
            {
                if (all_words[i].Length <= noLongerSym)
                {
                    short_count++;
                    Array.Resize(ref short_words, short_count);
                    short_words[short_count - 1] = all_words[i];
                }
            }

            Console.Clear();
            Console.WriteLine($"Добавлено {short_words.Length} коротких слов до {noLongerSym} букв.");


            // ----------------------------------------------------------

            Console.WriteLine("Давай поиграем!"); // выведет приветствие
            //string word = words[0]; // 1-е слово

            Random my_random = new Random(); //экземпляр типа переменной

            while (true)
            {
                {
                    string word = short_words[my_random.Next(0, short_words.Length)]; //загадали слово

                    // Для отладки: показать загаданное слово
                    Console.WriteLine(word);

                    char[] charWord = word.ToCharArray(); //строку символов в массив отдельных символов, его отгадываем

                    int opennedLetter = 0; //переменная счетчик
                    int errors = 0; //сколько допущено ошибок (по умолчанию ноль)

                    //временный массив спрятанных букв
                    char[]
                        viewWord = new char[charWord
                            .Length]; //новый экземпляр массива символов char - место в памяти на символы размером
                    for (int i = 0; i < viewWord.Length; i++) //массив из звездочек
                    {
                        viewWord[i] = '*';
                    }

                    Console.WriteLine(new string(viewWord));

                    Console.WriteLine($"Загадано слово из {charWord.Length} букв"); //бакс добавляет переменнок в строку

                    // ------------------- Начало цикла -------------------
                    while (errors < MaxErrors && opennedLetter != charWord.Length) //пока одно из условий не  false
                    {
                        Console.WriteLine("Введи букву:");

                        string inputString = Console.ReadLine().ToLower(); // что ввели пихаем в переменную

                        //проверка что там юзер ввел
                        if (inputString.Length != 1 ||
                            !Char.IsLetter(inputString[0])) // две проверки || - ИЛИ НЕТ на вопрос "ты буква?"
                        {
                            Console.Clear();
                            Console.WriteLine("Вводи только одну букву!");
                            continue; // вернуться обратно к циклу "while"
                        }

                        //проверяем есть ли буква в слове
                        char letter = inputString[0];
                        bool isLetterExist = false;
                        
                        bool go_back_flag = false;
                        
                        for (int i = 0; i < charWord.Length; i++)
                        {
                            // был ли ранее введен такой же символ...
                            if (viewWord[i] == letter)
                            {
                                Console.Clear();
                                Console.WriteLine("Такой символ уже был введен! Не засчитан.");
                                go_back_flag = true;
                                break;
                            }
                            // имеется ли ввденный символ в загаданном слове
                            if (charWord[i] == letter)
                            {
                                opennedLetter++;
                                viewWord[i] = charWord[i];
                                charWord[i] = '-';
                                isLetterExist = true;
                            }
                        }

                        // если флаг повтора символа установлен, вернуться обратно к циклу "while"
                        if (go_back_flag)
                            continue; // вернуться обратно к циклу "while"
                        
                        // чистим консоль и отображаем результат отгадывания буквы
                        Console.Clear();

                        // если символ угадал...
                        if (isLetterExist)
                        {
                            Console.WriteLine("Угадал букву!");
                            // Отобразить текущее состояние трупа
                            if (errors == 0)
                                Console.WriteLine(" ･ᴗ･");
                            else DrawCoolerHangman(errors);             //вызывает вышенаписанную функцию рисования сложного чела
                            
                        }
                        else // ...символ не угадал
                        {
                            errors++;
                            Console.WriteLine($"Такой буквы нет. Осталось попыток: {10 - errors}");
                            DrawCoolerHangman(errors);                    //вызывает функцию рисования сложного чела
                        }

                        // отображаем слово с обновленным состоянием (с открытыми символами и звездочками)
                        Console.WriteLine(new string(viewWord));
                    }
                    // ------------------- Конец цикла -------------------

                    // Окончательный результат
                    Console.Clear();

                    //выиграли или не выиграли...
                    if (errors == MaxErrors)
                    {
                        Console.WriteLine($"Проиграл, слово было - {word}");
                        Console.WriteLine("Повесился...");
                        DrawCoolerHangman(errors); //вызывает функцию рисования сложного чела
                    }
                    
                    else
                    {
                        Console.WriteLine("Выиграл!!! (o˘◡˘o)");
                    }

                    Console.WriteLine("Чтобы продолжить, жми Return...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}