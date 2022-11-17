using System;
using System.IO;
using System.Net;

// в этом файле логика / модель

namespace UD05_hangman
{
    public class HangmanWord //конструктор 
    {
        //------------------- переменные для работы ---------------------
        private string _stringWord; //_так принято писать локалдьные внутри класса
        private char[] _charWord; //считывает слова
        private char[] _starsWord; 

        private string _path;
        private string[] _words;
        
        //--------------------- хрен пойми что ---------------------------
        public string StringWord => _stringWord; //=> называется в с# лямбда
        //для этой строки выбрали "encapsulate field"

        public string ViewWord => new string(_starsWord); //это все проперти или свойства
        //вся дата приватная наружи только методы - read oonly - снаружи только можно прочитать

        public bool IsSolved => _opennedLetters == _charWord.Length;
        

        private Random _random = new Random(); //инициализация, что по умолчанию
        //присвоили по умолчанию новый экземплят этого типа

        private int _opennedLetters = 0; //хоть 10
        
        
        
        
        //-------------------------- методы -------------------------------------
        //создание экз-ра класса
        public HangmanWord(string path) //экземпляр себя
        {
            _path = path;
            _words = File.ReadAllLines(_path);
            
        }

        
       
        //метод пишем вывода звездочек
        public void GeneratorWord() 
        {
            _stringWord = _words[_random.Next(0, _words.Length)];
            _charWord = _stringWord.ToCharArray();
            _starsWord = new char[_charWord.Length];

            for (int i = 0; i < _starsWord.Length; i++)
            {
                _starsWord[i] = '*';
            }

            _opennedLetters = 0; //по умолчанию, можно более
        }

        
        
        //метод проверяет входящую букву возвращает бул входящий - 
        public bool CheckLetter(char letter) 
        {
            bool isLetterExist = false;
            for (int i=0; i< _charWord.Length; i++)
            {
                if (_charWord[i] == letter)
                {
                    _opennedLetters++;
                    _starsWord[i] = _charWord[i];
                    _charWord = '-';
                    isLetterExist = true;

                }
            }

            return isLetterExist;
        }
    }
}