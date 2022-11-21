using System;
using System.IO;

namespace UD05_hangman
{
    public class HangmanWord
    {
        private string _stringWord;
        private char[] _charWord;
        private char[] _viewWord;

        private string _path;
        private string[] _words;

        private Random _random = new Random();

        private int _opennedLetters = 0;
        
        //свойства. разрешаем прочитать,но не разрешаем менять снаружи
        public string StringWord => _stringWord;
        public string ViewWord => new string(_viewWord);
        public bool IsSolved => _opennedLetters == _charWord.Length;

        public HangmanWord(string path)
        {
            _path = path;
            _words = File.ReadAllLines(_path);
        }
        

        public void GenerateWord() // метод
        {
            _stringWord = _words[_random.Next(0, _words.Length)];
            _charWord = _stringWord.ToCharArray();
            _viewWord = new char[_charWord.Length];

            for (int i = 0; i < _viewWord.Length; i++)
            {
                _viewWord[i] = '*';
            }

            _opennedLetters = 0;
        }

        public bool CheckLetter(char letter) // метод
        {
            bool isLetterExist = false;
            for (int i = 0; i < _charWord.Length; i++)
            {
                if (_charWord[i] == letter)
                {
                    _opennedLetters++;
                    _viewWord[i] = _charWord[i];
                    _charWord[i] = '-';
                    isLetterExist = true;
                }
            }

            return isLetterExist;
        }
    }
}