using System;


//? в этом файле все про View и юзера 


namespace UD05_hangman // пространство имен, все что относится к этому проекту
{
    //вызвали класс "программы" (логики), которая записана во ВНЕШНЕМ файле
    internal class Program
    {
        //местные переменные
        // путь к файлу со словами
        private static string path = @"/Users/ascha/Unity_Projects/UD05_hangman/UD05_hangman/word_rus.txt";
        
        private const int MaxErrors = 10;
        private const int NoLongerSym = 6; //какую мы хотим максимальную длину слова, остальные в игру не берем

        public static void Main(string[] args) //args - это "аргументы?" - хранит все, что ввел юзер
        {
            
            // экземпляр класса назвали word
            // !!!создало экземпляр класса из второго файла с path на входе!!!!
            HangmanWord word = new HangmanWord(path, NoLongerSym); 
            
            Console.Clear();
            Console.WriteLine($"Добавлено {word.countShortWords} коротких слов до {NoLongerSym} букв.");
            Console.WriteLine(); 
            Console.WriteLine("Давай поиграем!"); // выведет приветствие
            Console.WriteLine("===============");
            
            while (true)//вечный цикл
            {
                {
                    word.GeneratorWord(); //экземпляру  цщкв класса HangmanWord запускаем метод генерации слова 
                    Console.WriteLine();
                    ////через переменную лезет в класс HangmanWord и берет оттуда масив загаданного слова

                    //убрала после ООП//int opennedLetter = 0; //переменная счетчик
                    int userErrorCount = 0; //сколько допущено ошибок (по умолчанию ноль)

                    // бакс добавляет переменную в строку
                    Console.WriteLine($"Загадано слово из {word.StringGuessingWord.Length} букв: (DEBUG: {word.StringGuessingWord})");
                    
                    // отобразить скрытое слово в виде звёздочек *****
                    Console.WriteLine(word.StarsWordString);
                    Console.WriteLine();
                    
                    // ------------------- Начало цикла - ловит буквы------------------------------------------------------------

                    // пока одно из условий не false - пока не выиграем или не проиграем
                    // пока ошибок меньше допустимого ИИ экземпляр ворда  
                    // НЕ обладает флагом что переменная количества Угаданных букв сравнялась с длиной массива ЗАгаданных букв
                    while (userErrorCount < MaxErrors && !word.IsSolved)
                    {
                        Console.WriteLine("Введи букву:");

                        // что ввели пихаем в переменную и ДЕЛАЕМ МАЛЕНЬКОЙ 
                        string inputString = Console.ReadLine();

                        if (inputString == null)//если ничего не ввели и там пусто
                            continue; // вверх к циклу while 

                        // проверка что там юзер ввел
                        // две проверки || - ИЛИ НЕТ на вопрос "ты буква?"
                        if (inputString.Length != 1 || !Char.IsLetter(inputString[0]))
                        {
                            Console.Clear();
                            Console.WriteLine("Вводи только букву и только одну!");
                            continue; // вернуться обратно к циклу "while"
                        }

                        inputString = inputString.ToLower(); //в него же и вернули

                        // введенный символ суется в переменную letter
                        char letter = inputString[0];

                        if (!((letter >= 'а' && letter <= 'я') || letter == 'ё'))
                        {
                            Console.Clear();
                            Console.WriteLine("Переключи на русский язык!");
                            continue; // вернуться обратно к циклу "while"
                        }

                        // -----------------------------------------------
                        // вводил ли юзер эту же букву ранее
                        if (word.WasLetterAlreadyEntered(letter)) //ПОДРАЗУМЕВАЕТСЯ ЧТО ФЛАГ ТРУ = если тру
                        {
                            Console.Clear();
                            Console.WriteLine($"Такая буква {letter} уже была! Попытка не засчитывается.");
                            Console.WriteLine($"Список ранее введенных букв: {word.GetAlreadyEnteretSymbolList()}");
                            continue; //возвращаемся на введи букву
                        }

                        // -------------------------------------------------

                        Console.Clear();
                        // обращается к экз класса ворд, передает туда letter
                        // проверяем в секретном слове, есть ли там введенная буква
                        if (word.LetterExistsInGuessingWord(letter))
                        {
                            Console.WriteLine($"Буква {letter} есть в слове!");
                            //вызывает метод звездочек от экз класса word > hangmanword
                            Console.WriteLine(word.StarsWordString);
                        }
                        else //в секретном слове такой буквы нету
                        {
                            userErrorCount++; //плюсуем количество ошибок
                            
                            Console.WriteLine("Этой буквы нет в слове!");

                            //создает экземпляр класса рисования чела
                            DrawHangman almostkilled = new DrawHangman(userErrorCount, MaxErrors); 
                            almostkilled.StartDrawing(userErrorCount, MaxErrors);

                            Console.WriteLine(word.StarsWordString); //заново выведет массив звездочек
                            //вызвала переменную хранящую строку, сделанную из массива звездочк у экземпляра класса word
                        }

                        // ---------------------------------------------------
                        
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
                    }
                }
                            
                Console.WriteLine("Чтобы продолжить, нажми Return...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}