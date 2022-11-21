using System;
using System.IO;

namespace UD05_hangman
{
    public class HangmanWord
    {
        private string _stringWord;
        private char[] _viewWord;
        private char[] _charWord;

        private string _path;
        private string[] _words;

        private Random _random = new Random(); //по умолчанию присваиваем новое значение класса

        private int _openedLetters = 0; //по умолчанию открыто 0 букв

        
        //ниже создаем методы (создаем экземпляры класса HangmanWord С помощью конструктора)
        public HangmanWord(string path)
        {
            _path = path;
            _words = File.ReadAllLines(_path);

        }

        public string StringWord => _stringWord; //=> лямбда

        public string ViewWord => new string(_viewWord);

        public bool IsSolved => _openedLetters == _charWord.Length; //сравнение текущих открытых букв с загаданным, возвращает булевское значение 

        public void GenerateWord() //функция для генерации слова
        {
            _stringWord = _words[_random.Next(0, _words.Length)];
            _charWord = _stringWord.ToCharArray();
            _viewWord = new char[_charWord.Length];

            for (int i = 0; 9 < _viewWord.Length; i++)
            {
                _viewWord[i] = '*';
            }

            _openedLetters = 0;

        }

        public bool CheckLetter(char letter) //временный флаг возвращает тру или фолс
        {
            bool isLetterExist = false;
            for (int i = 0; i < _charWord.Length; i++)
            {
                if (_charWord[i] == letter)
                {
                    _openedLetters++;
                    _viewWord[i] = _charWord[i]; //заменяем звездочку на букву
                    _charWord[i] = '-'; //флаг заменяем на прочерк
                    isLetterExist = true;
                }
            }

            return isLetterExist;
        }
    }
}