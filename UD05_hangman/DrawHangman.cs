using System;
using System.Security.Cryptography.X509Certificates;

namespace UD05_hangman
{
    public class DrawHangman
    {

        private int _user_error_count;
        private int _MaxErrors;
        private string _DrawWinnerWord;

        public int user_error_count  => _user_error_count; //вот тут серое и не работает ??? попросить пояснить
        public int MaxErrors => _MaxErrors;
        public string DrawWinnerWord => _DrawWinnerWord;
        

        public DrawHangman(int user_error_count, int MaxErrors)//создание экземпляра себя, берет эти параметры извне
        {
            //что сюда запихать???
         //   _user_error_count = user_error_count;
         //   _MaxErrors = MaxErrors;
        }

        // ---------------метод рисует виселицу  ------
        //функция вывода рисунка (было еще static void но я убрала)
        public void StartDrawing(int _user_error_count, int _MaxErrors)
        {
            

            string[] coolerVisual = new string[12]
            {
                "#     +-------+     #", //0
                "#    || /     |     #", //1
                "#    ||/      |     #", //2
                "#    ||    (xx)     #", //3
                "#    ||      |      #", //4
                "#    ||    +-|-+    #", //5
                "#    ||   /  | |    #", //6
                "#    ||     /|      #", //7
                "#    ||    / |      #", //8
                "#    ||   .  .      #", //9
                "#    ||_____________#", //10
                "#    ||             #"  //11 - empty
            };

            
            Console.WriteLine($"##### {_user_error_count} из {_MaxErrors} ######"); //верх рамочки

            for (int i = 0; i < 11; i++) //рисует чела из массива в зависимости от количества ошибочек
            {
                if (i < _user_error_count)
                    Console.WriteLine(coolerVisual[i]);
                else Console.WriteLine(coolerVisual[11]);
            }

            Console.WriteLine("#####################"); // низ рамочки}
        }

        
        //метод рисования выигравшегшо победителя
        public void DrawWinner(string _DrawWinnerWord) //получает параметр со словом из файла программ
        {
            
            //готовит массив для рисования победителя, пепеменную получает извне и переводит в местную стоку
            string[] WinnerDrawArray = new string[8] //почему 8 не розовое?????
            {
                "Выиграл!!! (o˘◡˘o)", //0
                "           ---|---", //1
                $"      ____/   |   |____[{_DrawWinnerWord}]", //2 - чел держит загаданное слово в рамочке!!
                "              |", //3 
                "              |", //4
                "             /|", //5
                "            / | ", //6
                "###########/##|###################" //7
            };

            
            Console.Clear(); //важно что написали после массива, тут очищает!
            
            for (int i = 0; i < WinnerDrawArray.Length; i++) //просто построчно циклом выводит победившего чела
            {
                Console.WriteLine(WinnerDrawArray[i]);
            }
            
            
        }

    }
}
        