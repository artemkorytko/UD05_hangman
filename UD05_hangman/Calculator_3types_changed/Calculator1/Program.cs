using System;
using System.IO;
using System.Text;

namespace Calculator_3types_changed
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Write the symbol of operation (choose +; -; *; /; ^)");
            char sign = Convert.ToChar(Console.ReadLine());




            Console.WriteLine("Write the first number for operation");
            string n1 = Console.ReadLine();
            double number1 = Double.Parse(n1);



            Console.WriteLine("Write the second number for operation");
            string n2 = Console.ReadLine();
            double number2 = Double.Parse(n2);
           
            double x = 0;

            if (sign != '+' && sign != '-' && sign != '*' && sign != '/' && sign != '^')
            {
                Console.WriteLine("You have errors in inputted data");
            }
            

            else
            {
                
                
                switch (sign)
                {


                    case ('+'):


                        x = number1 + number2;
                       // Console.WriteLine($"{number1} + {number2} = {x}");
                        break;


                    case ('-'):


                        x = number1 - number2;
                      // Console.WriteLine($"{number1} - {number2} = {x}");
                        break;


                    case ('*'):


                        x = number1 * number2;
                      // Console.WriteLine($"{number1} * {number2} = {x}");
                        break;


                    case ('/'):
                    {
                        if (number2 == 0)
                        {
                            Console.WriteLine("can not be divided by 0");
                        }
                        else
                        {
                            x = number1 / number2;
                           //Console.WriteLine($"{number1} / {number2} = {x}");
                        }

                        break;
                    }

                    case ('^'):
                    {

                        x = Math.Pow(number1, number2);
                       //Console.WriteLine($"{number1}^{number2} = {x}");
                        break;
                        
                    }
                            
                    
                }
                Console.WriteLine(x);
            }
        }
    }
}