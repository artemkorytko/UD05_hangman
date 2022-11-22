using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading;
using UD05_hangman;


namespace UD05_hangman // пространство имен, все что относится к этому проекту
{
    //вызвали класс "программы" (логики), которая записана во ВНЕШНЕМ файле
    internal class Program
    {
        // ================================== MAIN =========================================
        public static void Main(string[] args) // args - это "аргументы?" - хранит все, что ввел юзер
        {
            // отобразить приветствие
            show_full_title();

            // ждем от поьзователя команду, внутри будет вечный цикл
            get_user_command();
        }


        // ================================ TEXT ===========================================
        // ВЫВОД ПРИВЕТСВИЯ И МЕНЮ ПРОГРАММ
        //массив для приветствий и инструкций выбора программы
        static string[] _helloMessagesArray = new string[6]
        {
            "Приветствуем, дорогой юзер!\n", //0
            "Прислушейтесь к себе внимательно: чего желает душа?\n", //1
            "1. Просто калькулятор? (Нажмите цифру \"1\")\n", //2
            "2. Калькулятор в одной строке? (Нажмите цифру \"2\")\n", //3
            "3. Поиграть в виселицу? (Нажмите цифру \"3\")\n", //4
            "4. Закрыть программу? (Нажмите цифру \"4\")\n" //5
        };

        // метод для печатания посмвольно аки у Нео
        // прикольно, что переменная whattoprint существует ТОЛЬКО В ЭТОЙ ФУНКЦИИ
        private static void PrintLikeNeo(string whattoprint)
        {
            foreach (char ch in whattoprint) //крутая штука!!! просто посимвольно печатает
            {
                Console.Write(ch); //в отличие от writeline пишет В ТОЙ ЖЕ же строке
                Thread.Sleep(5);
                //пауза - 1000 - это 1 секунда! к ней еще надо подключить using System.Threading;
            }
        }

        // выводит певое приветствие с выбором программы
        private static void show_full_title() // *
        {
            Console.Clear();

            for (int i = 0; i < _helloMessagesArray.Length; i++)
            {
                PrintLikeNeo(_helloMessagesArray[i]);
            }

            Console.WriteLine("");

            // Console.WriteLine(Environment.CurrentDirectory);
        }

        //придет сюда, когда выполнил пример в калькуляторе или hangman
        //надо вывести приветствие краткое
        private static void show_lite_title() // *
        {
            PrintLikeNeo("Чем займёмся теперь?\n");
            for (int i = 2; i < _helloMessagesArray.Length; i++) //выводит с 3 строки (0,1,2 выводит)
            {
                PrintLikeNeo(_helloMessagesArray[i]);
            }

            Console.WriteLine("");
        }

        // проверка валидности введенного числа
        private static bool isValidDigValue(string val)
        {
            if (String.IsNullOrEmpty(val)) // null - еще ничего не присваивали, empty - присвоили ""
                return false;

            for (int i = 0; i < val.Length; i++)
            {
                // CultureInfo - выдает разделитель для дробей на данной операционной системе - точка или запятая
                if (!Char.IsDigit(val[i]) &&
                    val[i] != CultureInfo.CurrentCulture.NumberFormat.PercentDecimalSeparator[0])
                    return false;
            }

            return true;
        }

        // ================================================================================

        private static void get_user_command() // *
        {
            while (true)
            {
                // ждет и слушет что введут
                string inputChoice = Console.ReadLine();

                // если ввели не цифру или ничего - предлагает повтор ввода
                if (!isValidDigValue(inputChoice))
                {
                    Console.WriteLine("Вы ввели неверное значение! Повторите ввод.");
                    continue;
                }

                // действует в зависимости от того, что ввели на выборе программы
                switch (inputChoice[0])
                {
                    case '1':
                        Calculation(); // набрали 1 - запускаем калькулятор
                        break;

                    case '2':
                        InLineCalculation(); // набрали 2 - запускаем строчный калькулятор NEW!
                        break;

                    case '3':
                        StartHangman(); // набрали 3 - запускаем hangman
                        break;

                    case '4':
                        Environment.Exit(0); // 4 - выйти из программы, закрыть ее
                        break;

                    default:
                        Console.WriteLine("Вы не то ввели! Введите цифру 1, 2 или 3.");
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("Чтобы продолжить, нажми Return...");
                Console.ReadLine();
                Console.Clear();

                show_lite_title(); //вызывает краткое меню на 2 итерации
            } // конец вечного цикла
        }

        // ==============================================================================
        // =============================== КАЛЬКУЛЯТОР ==================================
        // ==============================================================================

        // ввод переменных калькулятора
        private static void Calculation()
        {
            Console.Clear();

            string inputA, inputB, inputC;

            // вводим первое число
            while (true)
            {
                Console.WriteLine("Введите первое число:");
                inputA = Console.ReadLine();

                if (!isValidDigValue(inputA))
                    continue;

                break;
            }

            // вводим второе число
            while (true)
            {
                Console.WriteLine("Введите второе число:");
                inputB = Console.ReadLine();

                if (!isValidDigValue(inputB))
                    continue;

                break;
            }

            // выбираем тип операции
            while (true)
            {
                Console.WriteLine("Введите требуемую операцию (+ - * / % ^):");
                inputC = Console.ReadLine();

                if (inputC == null)
                    continue;

                if (inputC == "+" || inputC == "-" || inputC == "*" || inputC == "/" || inputC == "%" ||
                    inputC == "^")
                    break;
            }

            // ============================= ВЫЧИСЛИТЕЛЬ ================================
            // вычисление и отображение результата
            StartCalculations(inputA, inputB, inputC[0]);
            // ==========================================================================
        }


        // ==============================================================================
        // =============================== HANGMAN ======================================
        // ==============================================================================

        // параметры для Hangmana
        private static HangmanWord word; // внимание! объявили переменную

        // относительный путь к текстовому файлу со словами (вверх-вверх)
        private static string path = @"../../word_rus.txt"; // !!!!!!!!

        private const int MaxErrors = 10;
        private const int NoLongerSym = 6; //какую мы хотим максимальную длину слова, остальные в игру не берем

        private static int userErrorCount = 0; // сколько пользователь допустил ошибок (по умолчанию ноль)

        private static void StartHangman()
        {
            // создало экземпляр класса word из второго файла hangmanword с path на входе!!!!
            word = new HangmanWord(path, NoLongerSym);

            Console.Clear();
            Console.WriteLine("Давай поиграем в виселицу!"); // выведет приветствие
            Console.WriteLine("==========================");
            Console.WriteLine($"Загружено {word.countShortWords} коротких слов до {NoLongerSym} букв.");
            Console.WriteLine("");

            word.GeneratorWord(); // экземпляру word класса HangmanWord запускаем метод генерации слова 

            // отобразим длину загаданного слова и для отладки выведен и само слово в открытом виде
            Console.WriteLine(
                $"Загадано слово из {word.StringGuessingWord.Length} букв: (DEBUG: {word.StringGuessingWord})");
            // отобразить скрытое слово в виде звёздочек *****
            Console.WriteLine(word.StarsWordString);
            Console.WriteLine();

            let_user_guess(); // запускаем интеракцию с юзером по получению от него букв
        }

        // -----------------------------------------

        private static void let_user_guess()
        {
            // крутим цикл WHILE ока одно из условий не false - пока не выиграем или не проиграем
            // пока ошибок меньше допустимого ИИ экземпляр ворда  
            // НЕ обладает флагом что переменная количества Угаданных букв сравнялась с длиной массива ЗАгаданных букв
            while (userErrorCount < MaxErrors && !word.IsSolved)
            {
                Console.WriteLine("Введи букву:");

                // что ввели пихаем в переменную и ДЕЛАЕМ МАЛЕНЬКОЙ 
                string inputString = Console.ReadLine().ToLower();

                // ---------------------- проверки... ---------------------

                if (String.IsNullOrEmpty(inputString)) // если ничего не ввели и там пусто
                    continue; // вверх к циклу while 

                if (inputString.Length > 1)
                {
                    Console.Clear();
                    Console.WriteLine("Вводи только одну букву!");
                    continue; // вернуться обратно к циклу "while"
                }

                // проверка что там юзер ввел
                // две проверки || - ИЛИ НЕТ на вопрос "ты буква?"
                if (!Char.IsLetter(inputString[0]))
                {
                    Console.Clear();
                    Console.WriteLine("Вводи только букву!");
                    continue; // вернуться обратно к циклу "while"
                }

                // введенный символ суется в переменную letter типа CHAR
                char letter = inputString[0];

                // проверяем наличие кириллического символа (анти-латинка)
                if (!((letter >= 'а' && letter <= 'я') || letter == 'ё'))
                {
                    Console.Clear();
                    Console.WriteLine("Переключи на русский язык!");
                    continue; // вернуться обратно к циклу "while"
                }

                // вводил ли юзер эту же букву ранее
                if (word.WasLetterAlreadyEntered(letter)) // ПОДРАЗУМЕВАЕТСЯ ЧТО ФЛАГ ТРУ = если тру
                {
                    Console.Clear();
                    Console.WriteLine($"Такая буква {letter} уже была! Попытка не засчитывается.");
                    Console.WriteLine($"Список ранее введенных букв: {word.GetAlreadyEnteretSymbolList()}");
                    continue; //возвращаемся на введи букву
                }

                // -------------------------- угадал ли букву... -----------------------

                Console.Clear();
                // обращается к экз класса ворд, передает туда letter
                // проверяем в секретном слове, есть ли там введенная буква
                if (word.LetterExistsInGuessingWord(letter))
                {
                    Console.WriteLine($"Буква {letter} есть в слове!");
                    // вызывает метод звездочек от экз класса word > hangmanword
                    Console.WriteLine(word.StarsWordString);
                }
                else // в секретном слове такой буквы нет
                {
                    userErrorCount++; // плюсуем количество ошибок

                    Console.WriteLine("Этой буквы нет в слове!");

                    // создает экземпляр класса рисования чела
                    DrawHangman almostkilled = new DrawHangman(userErrorCount, MaxErrors);
                    almostkilled.StartDrawing(userErrorCount, MaxErrors);

                    Console.WriteLine(word.StarsWordString); //заново выведет массив звездочек
                    //вызвала переменную хранящую строку, сделанную из массива звездочк у экземпляра класса word
                }

                // -------------------- проверяем не завершена ли игра... --------------------

                // если ошибок стало 10. Значит проигрыш
                if (userErrorCount == MaxErrors)
                {
                    Console.Clear();
                    Console.WriteLine($"Повесился! Было загадано слово >> {word.StringGuessingWord} <<");

                    //вызывает экз класса DrawHangman и передает туда сколько ошибок наделано
                    DrawHangman killed = new DrawHangman(userErrorCount, MaxErrors);
                    killed.StartDrawing(userErrorCount, MaxErrors); //берет из класс метод рисования чела
                    break;
                }

                // победа!
                if (word.IsSolved)
                {
                    Console.Clear();
                    //должно рисовать победителя с ОТГАДАННЫМ СЛОВОМ В РАМОЧКЕ
                    string drawWinnerWord = word.StringGuessingWord;
                    //создает экземпляр класса рисования чела
                    DrawHangman winner = new DrawHangman(userErrorCount, MaxErrors);
                    winner.DrawWinner(drawWinnerWord);
                    break;
                }
            } // закрыли проверку что ошибок меньше 10 и слово не отгадано
        }

        // ==============================================================================
        // ======================= КАЛЬКУЛЯТОР В ОДНОЙ СТРОКЕ ===========================
        // ==============================================================================

        // ввод переменных калькулятора
        private static void InLineCalculation()
        {
            string wholeLineInput = null;

            string[] bunchOfExamples = new string[6]
                { "2 + 5", "100 / 3", "100 % 45", "1000 - 500", "88 * 6", "300 ^ 60" };
            Random _randomexample = new Random();

            Console.Clear();

            // просим юзера ввести пример
            while (true) // вечный цикл
            {
                //рандомно выбирает и показывает какой пример из массива можно напечатать
                Console.WriteLine(
                    $"Введите выражение с двумя переменными (например, {bunchOfExamples[_randomexample.Next(0, bunchOfExamples.Length)]}):\n");

                // ввод данных
                wholeLineInput = Console.ReadLine();

                string dig_a = null;
                string dig_b = null;
                char operate_sym; // переменная из одного символа

                // проверка введенных данных и получение числа А, В и символа операции
                if (isValidLineInput(wholeLineInput, out dig_a, out dig_b, out operate_sym))
                {
                    // вычисление и вывод результата
                    StartCalculations(dig_a, dig_b, operate_sym);
                    break;
                }
                else Console.WriteLine("Введи корректные данные!");
            }

            // возвращаемся к паузе "Нажми return..." и затем к лайт меню
        }

        // -----------------------------------------------------------------------------------
        //Проверка, получает сатроку юзера, проверяет есть ли математический знак, потом делит на субы,
        //

        private static bool isValidLineInput(string calc_inline, out string dig_a, out string dig_b,
            out char operate_sym)
        {
            string[] subs = calc_inline.Split('+', '-', '/', '*', '%', '^');

            // по умолчанию чисел и математической операции нет
            dig_a = "";
            dig_b = "";
            operate_sym = '_';

            if (calc_inline.IndexOf('+') > 0) //знак существует и он не первый по счету в строке
                operate_sym = '+';
            else if (calc_inline.IndexOf('-') > 0)
                operate_sym = '-';
            else if (calc_inline.IndexOf('/') > 0)
                operate_sym = '/';
            else if (calc_inline.IndexOf('*') > 0)
                operate_sym = '*';
            else if (calc_inline.IndexOf('%') > 0)
                operate_sym = '%';
            else if (calc_inline.IndexOf('^') > 0)
                operate_sym = '^';

            // значит не найдена математическая операция - осталось значение, какое и задали
            if (operate_sym == '_')
                return false;

            // получить А и В
            if (subs[0] != null)
                dig_a = subs[0].Trim(); // пихает первый sub в переменную, если там не пусто
            // trim отсекает пробелы слева справа, и другие технические символы

            if (subs[1] != null)
                dig_b = subs[1].Trim(); //пихает второй sub в переменную, если там не пусто

            // дополнительно проверяет переменные, true если ЦИФРА (можно с точкой), не равно нулю или empty
            return ( isValidDigValue(dig_a) && isValidDigValue(dig_b) );
        }

        // ====================================================================================

        private static void StartCalculations(string dig_a, string dig_b, char operate_sym)
        {
            Calc calcnow = new Calc(dig_a, dig_b); // вызывает calc c названием calcnow

            PrintLikeNeo("===============================\n");
            // вызов методов калькулятора на каждое действие - НЕ ПОЛУЧАЕТСЯ
            switch (operate_sym)
            {
                case '+': //вызываем складывание
                    PrintLikeNeo("Результат сложения: " + calcnow.Addition());
                    break;


                case '-':
                    PrintLikeNeo("Результат вычитания: " + calcnow.Substraction());
                    break;


                case '*':
                    PrintLikeNeo("Результат умножения: " + calcnow.Multiplication());
                    break;


                // -----деление с проверкой на ноль---
                case '/':
                    Single d = 0;
                    if (!calcnow.Division(out d))
                        PrintLikeNeo("Нельзя делить на ноль!");
                    else PrintLikeNeo("Результат деления: " + d);
                    break;


                case '%':
                    int dv = 0;
                    if (!calcnow.IntDiv(out dv))
                    {
                        PrintLikeNeo("Деление на ноль!");
                        break;
                    }

                    PrintLikeNeo("Результат операции MOD: " + dv + ":" + calcnow.Mod());
                    break;


                case '^':
                    PrintLikeNeo("Результат операции XOR: " + calcnow.Xor());
                    break;


                default:
                    Console.WriteLine("Введите нормальный тип операции: + - * / % ^");
                    break;
            } // конец свича на действия

            PrintLikeNeo("\n===============================\n");
        }
    }
}