using System;
using System.IO;

namespace UD05Hangman
{
    public class HangmanWord
    {
        private string _stringWord;
        private char[] _charWord;
        private char[] _viewWord;
        
        private string _path;
        private string[] _words;
        
        private Random _random = new Random();
        
        private int _openedLetters = 0;
        
        public string StringWord => _stringWord;

        public string ViewWord => new string(_viewWord);

        public bool IsSolved => _openedLetters == _charWord.Length;

        public HangmanWord(string path)
        {
            _path = path;
            _words = File.ReadAllLines(_path);
        }
        
        public void GenerateWord()
        {
            _stringWord = _words[_random.Next(0, _words.Length)];
            _charWord = _stringWord.ToCharArray();
            _viewWord = new char[ViewWord.Length];

            for (int i = 0; i < _viewWord.Length; i++)
            {
                _viewWord[i] = '*';
            }

            _openedLetters = 0;
        }

        public bool CheckLetter(char letter)
        {
            bool isLetterExist = false;
            for (int i = 0; i < _charWord.Length; i++)
            {
                if (_charWord[i] == letter)
                {
                    _openedLetters++;
                    _viewWord[i] = _charWord[i];
                    _charWord[i] = '-';
                    isLetterExist = true;
                }
            }

            return isLetterExist;
        }

    }
}