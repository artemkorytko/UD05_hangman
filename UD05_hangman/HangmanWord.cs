using System;
using System.IO;

namespace UD05_hangman
{
    public class HangmanWord
    {
        private string _stringWord; // объвляем строку 
        private char[] _viewWord; //объявляем массив состоящий из букв
        private char[] _charWord; //объявляем массив состоящий из букв

        private string _path; // 
        private string[] _words; //объявляем массив 

        private Random _random = new Random(); // вызываем функцию Random из класса Random созданием экземпляра (по умолчанию присваиваем новое значение класса)

        private int _openedLetters = 0; //по умолчанию открыто 0 букв

        
        //ниже создаем методы (создаем экземпляры класса HangmanWord С помощью конструктора)
        public HangmanWord(string path) // создаем функцию HangmanWord, объявляем локальную переменную path, в классе HangmanWord
        {
            _path = path;
            _words = File.ReadAllLines(_path); // массив из слов из всего файла прочитанного по пути

        }

        public string StringWord => _stringWord; // (=> лямбда) создаем функцию(метод) StringWord в который передадим _stringWord

        public string ViewWord => new string(_viewWord); // ??? создаем функцию(метод) ViewWord в который передаем экземпляр (new) _viewWord'a 

        public bool IsSolved => _openedLetters == _charWord.Length; //создаем фнукицю(метод) где сравнивается кол-во текущих открытых букв с длинной массива загаданного слова, возвращает булевское значение 

        public void GenerateWord() //функция для генерации слова
        {
            _stringWord = _words[_random.Next(0, _words.Length)]; //генерирует рандомом слово из всего файла
            _charWord = _stringWord.ToCharArray(); //делит выбранное рандомное слово на символы 
            _viewWord = new char[_charWord.Length]; //создаем экземпляр массива из char размер которого = _charWord.Length, т.е. размер = кол-ву символов

            for (int i = 0; i < _viewWord.Length; i++) 
            {
                _viewWord[i] = '*'; // каждый символ в массиве(который = длине слова) делаем звездочкой*;
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