using System;
using System.ComponentModel.Design.Serialization;
using System.IO;

namespace UD05_hangman // пространство имен, все что относится к этому проекту
{
    internal class Program
    {
        // путь к файлу со словами
        private static string path = @"/Users/ascha/Unity_Projects/UD05_hangman/UD05_hangman/word_rus.txt";

        private const int MaxErrors = 10;
        private const int noLongerSym = 6;

        // --------------- рисуем сложного человечка -----------

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

            Console.WriteLine($"##### {user_error_count} из {MaxErrors} ######"); //верх рамочки

            for (int i = 0; i < 11; i++) //рисует чела в зависимости от количества ошибочек
            {
                if (i <= user_error_count)
                    Console.WriteLine(coolerVisual[i]);
                else Console.WriteLine(coolerVisual[11]);
            }

            Console.WriteLine("#####################"); // низ рамочки
        }

        // ----------------------------------------------------------------------

        public static void Main(string[] args)
        {
            string[] all_words = File.ReadAllLines(path); // прочитает все строки из файла и засунет в массив

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

                    //строку символов в массив отдельных символов, его отгадываем
                    char[] guessWordArray = word.ToCharArray();

                    int opennedLetter = 0; //переменная счетчик
                    int errors = 0; //сколько допущено ошибок (по умолчанию ноль)

                    // временный массив спрятанных букв
                    // новый экземпляр массива символов char - место в памяти на символы размером
                    char[] StarsWord = new char[guessWordArray.Length];

                    // создаем массив из звездочек длиной как у загаданного слова
                    for (int i = 0; i < StarsWord.Length; i++)
                        StarsWord[i] = '*';

                    Console.WriteLine(new string(StarsWord));

                    // бакс добавляет переменнок в строку
                    Console.WriteLine($"Загадано слово из {guessWordArray.Length} букв");

                    // Символьный массив для ранее введенных букв
                    char[] dict_entered_symbols_array = null;
                    int dict_entered_symbols = 0; // и их количество

                    // ------------------- Начало цикла -------------------

                    // пока одно из условий не  false
                    while (errors < MaxErrors && opennedLetter != guessWordArray.Length)
                    {
                        Console.WriteLine("Введи букву:");

                        // что ввели пихаем в переменную и ДЕЛАЕМ МАЛЕНЬКОЙ 
                        string inputString = Console.ReadLine().ToLower();

                        // проверка что там юзер ввел
                        // две проверки || - ИЛИ НЕТ на вопрос "ты буква?"
                        if (inputString.Length != 1 || !Char.IsLetter(inputString[0]))
                        {
                            Console.Clear();
                            Console.WriteLine("Вводи только одну букву!");
                            continue; // вернуться обратно к циклу "while"
                        }

                        // введенный символ
                        char letter = inputString[0];

                        // -------------------------
                        // вводился ли символ ранее?
                        bool is_symbol_found = false;
                        for (int i = 0; i < dict_entered_symbols; i++)
                        {
                            if (letter == dict_entered_symbols_array[i])
                            {
                                is_symbol_found = true;
                                break;
                            }
                        }

                        // значит ранее этот символ не вводился... Запоминаем его в массиве
                        if (is_symbol_found)
                        {
                            Console.Clear();
                            Console.WriteLine($"Буква {letter} уже была! Ход не засчитывается.");
                            string used_letters_list = null;
                            for (int i = 0; i < dict_entered_symbols; i++)
                            {
                                used_letters_list = used_letters_list + dict_entered_symbols_array[i] + " ";
                            }

                            Console.WriteLine($"Список введенных ранее символов: {used_letters_list}");
                            continue;
                        }
                        else
                        {
                            // был введен новая буква. Запоминаем в массиве!
                            dict_entered_symbols++;
                            Array.Resize(ref dict_entered_symbols_array, dict_entered_symbols);
                            dict_entered_symbols_array[dict_entered_symbols - 1] = letter;
                        }
                        // -------------------------

                        // проверяем есть ли буква в слове
                        bool go_back_flag = false;
                        bool isLetterExist = false;
                        for (int i = 0; i < guessWordArray.Length; i++)
                        {
                            // был ли ранее введен такой же символ (! только из отгаданных)... 
                            if (StarsWord[i] == letter)
                            {
                                Console.Clear();
                                Console.WriteLine("Эту букву уже угадали!");
                                go_back_flag = true;
                                break;
                            }

                            // имеется ли ввденный символ в загаданном слове
                            if (guessWordArray[i] == letter)
                            {
                                opennedLetter++;
                                StarsWord[i] = guessWordArray[i];
                                guessWordArray[i] = '-';
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
                            else DrawCoolerHangman(errors); //вызывает вышенаписанную функцию рисования сложного чела
                        }
                        else // ...символ не угадал
                        {
                            errors++;

                            Console.WriteLine($"Такой буквы нет. Осталось попыток: {10 - errors}");
                            DrawCoolerHangman(errors); //вызывает функцию рисования сложного чела

                            
                        }

                        // отображаем слово с обновленным состоянием (с открытыми символами и звездочками)
                        Console.WriteLine(new string(StarsWord));
                    }
                    // ------------------- Конец цикла -------------------

                    // Окончательный результат
                    Console.Clear();

                    //выиграли или не выиграли...
                    if (errors == MaxErrors)
                    {
                        Console.WriteLine($"Повесился! Было загадано слово >>{word}<<");
                        DrawCoolerHangman(errors); //вызывает функцию рисования сложного чела
                    }

                    else
                    {
                        Console.WriteLine("Выиграл!!! (o˘◡˘o)");
                    }

                    Console.WriteLine("Чтобы продолжить, нажми Return...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}