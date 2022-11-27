using System;
using System.IO;
using System.Text;

namespace Calculator_3
{
    internal class Program
    {
        private class Calculator
        {
            public double number1;
            public double number2;
            private double x;
            public char sign;
            


            public double Calculation(double number1, double number2, char sign, double x)
            {
                


                switch (sign)
                {
                    case '+':
                        
                        x = Sum(number1, number2);
                        break;


                    case '-':
                        x = Minus(number1, number2);
                        break;


                    case '*':
                        x = Multi(number1, number2);
                        break;



                    case '/':
                        if (number2 == 0)
                        {
                            Console.WriteLine("can not be divided by 0");
                        }
                        else
                        {
                            x = Devision(number1, number2);
                        }

                        break;


                    case '^':

                        x = Pow(number1, number2);
                        break;

                }


                return x;

                void Result()
                {
                    Console.WriteLine(5);
                }
                

            }


                double Sum(double number1, double number2)
                {
                    return (number1 + number2);
                }

                double Minus(double number1, double number2)
                {
                    return (number1 - number2);
                }

                double Multi(double number1, double number2)
                {
                    return (number1 * number2);
                }

                double Devision(double number1, double number2)
                {
                    return (number1 / number2);
                }

                double Pow(double number1, double number2)
                {
                    return (Math.Pow(number1, number2));
                }
                
                

            }





            public class InputtedData

            {


                public static void Main(string[] args)
                {


                    

                    Calculator num1 = new Calculator();
                    Console.WriteLine("Write the first number");
                    num1.Number1 = Convert.ToDouble(Console.ReadLine());
                    Calculator num2 = new Calculator();
                    Console.WriteLine("Write the second number");
                    num2.Number2 = Convert.ToDouble(Console.ReadLine());
                    Calculator signNew = new Calculator();
                    Console.WriteLine("Write the symbol of operation (choose +; -; *; /; ^)");
                    signNew.sign = Convert.ToChar(Console.ReadLine());




                }

            }

            
        }

    }
