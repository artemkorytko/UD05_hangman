using System; 
using System.IO;

namespace UD05_hangman
{
    internal class Program
    {
        private static string path = @"/Users/ascha/Unity_Projects/UD05_hangman/UD05_hangman/word_rus.txt";
        public static void Main(string[] args)
        {
           string[] words = File.readAllLines(path); //прочитает все строки из файла и засунет в массив
           Console.WriteLine(words.Length);


           //Console.WriteLine(" Hello World ");
           //Console.ReadLine();
        }
    }
}