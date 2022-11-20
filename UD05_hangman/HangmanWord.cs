using System;
using System.CodeDom;
using System.IO;
using System.Net;

// в этом файле логика / модель

namespace UD05_hangman
{
    public class HangmanWord //конструктор 
    {
        //------------------- переменные для работы ---------------------
        private string _stringGuessingWord; //строка загаданного слова - _так принято писать локальные переменные внутри класса - 
        private char[] _ZagadannoeWordArray; //массив, куда запихано загаданное рандомное слово
        private char[] _starsWord; //массив для отгаданного - звездочек или буковок

        private string _path;
        private string[] _ShortWordsArray;
        private int _countShortWords;

        // Символьный массив для ранее введенных букв
        private char[] _dict_entered_symbols_array = null;
        private int _dictEnteredSymbolsCount = 0; // и их количество
        
        //--------------------- доступы к приватным полям ---------------------------
        public string StringGuessingWord => _stringGuessingWord; //=> называется в с# лямбда
        //для этой строки выбрали "encapsulate field" => ? - метод доступа к приватному полю чтобы поле осталось скрытым
        //тут: массиву загаданного слова дали пеперменную StringWord, чтобы через нее заходить в класс

        //public string StarsWord => _starsWord[];
        public string StarsWordString => new string(_starsWord); //это все проперти или свойства
        //вся дата приватная cнаружи только методы - read oonly - снаружи только можно прочитать
        

        public bool IsSolved => (_opennedLetters == _ZagadannoeWordArray.Length);
        //???? внешней переменной присваивается результат (флаг) что все буквы уже угаданы 
        //== это сравнение, переменная количества угаданных букв сравнялась с длиной массива ЗАгаданных букв
   
        // public int countShortWords => _countShortWords;  // количечтво коротких слов
        public int countShortWords => _ShortWordsArray.Length;
        
        private Random _random = new Random(); //инициализация, что по умолчанию
        //присвоили по умолчанию новый экземплят этого типа

        private int _opennedLetters = 0;  // хоть 10
        
        
        //-------------------------- методы -------------------------------------
        //создание экз-ра класса
        public HangmanWord(string path, int noLongerSym) //экземпляр себя??? - метод вызывается когда обращаюсь new
        {
            _path = path;//местная переменная пути получит параметр path - это инкапсуляция??
            string[] all_words = File.ReadAllLines(_path);//считали все 30000 слов во временный массив
            
            // Новый массив только коротких слов
            // string[] short_words = null;
            // выудить короткие слова и поместить в массив short_words[]
            int short_count = 0;//переменная для подсчета коротких слов
            for (int i = 0; i < all_words.Length; i++)
            {
                if (all_words[i].Length <= noLongerSym)
                {
                    short_count++;
                    Array.Resize(ref _ShortWordsArray, short_count);
                    _ShortWordsArray[short_count - 1] = all_words[i];
                }
            }
            
        }
        
        // -------------------------------------------------------------------------
        
        //метод генерации слова и вывода звездочек
        public void GeneratorWord() 
        {
            // сброс массива введенных ранее букв
            _dictEnteredSymbolsCount = 0;
            _dict_entered_symbols_array = null;
            
            _stringGuessingWord = _ShortWordsArray[_random.Next(0, _ShortWordsArray.Length)];
            _ZagadannoeWordArray = _stringGuessingWord.ToCharArray();
            _starsWord = new char[_ZagadannoeWordArray.Length];

            for (int i = 0; i < _starsWord.Length; i++)
            {
                _starsWord[i] = '*';
            }

            _opennedLetters = 0; //по умолчанию, можно более
        }

        // -------------------------------------------------------------------------
        
        // метод проверяет входящую букву возвращает bool letterExistsinGuessingWord  
        public bool LetterExistsInGuessingWord(char letter) //объявили функцию с флагом - есть ли буква в загаданном: true/false
        {
            bool letterIsInGuessingWord = false;
            
            for (int i=0; i< _ZagadannoeWordArray.Length; i++)
            {
                // Если найдена буква в слове...
                if (_ZagadannoeWordArray[i] == letter) //побуквенно сравнивает с загаданным словом
                {
                    _opennedLetters++;
                    _starsWord[i] = _ZagadannoeWordArray[i];
                    _ZagadannoeWordArray[i] = '-';
                    letterIsInGuessingWord = true;
                    // Console.WriteLine(_ZagadannoeWordArray);// выводит масиив оставшихся букв __ZagadannoeWordArray типо ---ёл 
                }
            }

            return letterIsInGuessingWord;
        }
        
        // --------------------проверяем была ли буква введена ранее-----------------------------------------------------

        public bool WasLetterAlreadyEntered(char letter)
        {
            for (int i = 0; i < _dictEnteredSymbolsCount; i++)//цикл сравнивает введенную букву с массивом введенных ранее
            {
                if (letter == _dict_entered_symbols_array[i]) //если совпало 
                    return true; //букву нашел, послал true и НИЖЕ УЖЕ НЕ ДЕЛАЕТ
            }
 
            //если все буквы прошерстил, в массиве введенных её не нашел - загоняет её в массив введенных
            _dictEnteredSymbolsCount++;
            Array.Resize(ref _dict_entered_symbols_array, _dictEnteredSymbolsCount); //массив ресайзится с учетом что стало больше букв
            _dict_entered_symbols_array[_dictEnteredSymbolsCount - 1] = letter; //в массив всех введенных добавляем введенную букву
            
            return false;//вернет на выход значение что НЕТ не была введена
        }

        //----------------------чисто дает строку из массива ранее введенных--------------------------------
        public string GetAlreadyEnteretSymbolList()
        {
            string st = null; //временная переменная хранит строку
            for (int i = 0; i < _dictEnteredSymbolsCount; i++) 
                st = st + _dict_entered_symbols_array[i] + " ";
            return st; //после цикла вернет ст
        }

    }
}
