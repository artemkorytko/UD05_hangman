using System;
using System.IO;

namespace hangmann
{
    public class HangmanWord
    {
        private string _stringWord;
        private char[] _viewWord;
        private char[] _charWord;
        
        
        private string _path;
        private string[] _words;

        private Random _random = new Random();

        private int _oppenedLetters = 0;
        

        public HangmanWord(string path)
        {
            _path = path;
            _words = File.ReadAllLines(_path);
        }

        public string StringWord => _stringWord;
        public string ViewWord => new string(_viewWord);
        public bool IsSolved => _oppenedLetters == _charWord.Length;

        public void GenerateWord()
        {
            _stringWord = _words[_random.Next(0, _words.Length)];
            _charWord = _stringWord.ToCharArray();
            _viewWord = new char [_charWord.Length];

            for (int i = 0; i < _viewWord.Length; i++)
            {
                _viewWord[i] = '*';
            }

            _oppenedLetters = 0;
        }

        public bool CheckLetter(char letter)
        {
            bool isLetterExist = false;
            for (int i = 0; i < _charWord.Length; i++)
            {
                if (_charWord[i] == letter)
                {
                    _oppenedLetters++;
                    _viewWord[i] = _charWord[i];
                    _charWord[i] = '-';
                    isLetterExist = true;
                }
            }

            return isLetterExist;
        }
    }
}