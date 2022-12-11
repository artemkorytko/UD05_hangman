using System;
using System.IO;
using System.Text;

namespace Calculator_3types_changed
{
    internal class Program
    {
        private class Calculator
        {
            
            private double x;
            

            public double Calculation(double number1, double number2, char sign)
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


                    

                    Calculator Calculator = new Calculator();//создаем экземпляр класса, прописанного выше, где уже прописано что ему должно прийти 3 значения(2 числа и один знак)
                    Console.WriteLine("Write the first number");
                    double x = Convert.ToDouble(Console.ReadLine());
                    
                    Console.WriteLine("Write the second number");
                    double y = Convert.ToDouble(Console.ReadLine());
                    
                    Console.WriteLine("Write the symbol of operation (choose +; -; *; /; ^)");
                    char sign = Convert.ToChar(Console.ReadLine());

                   double result =  Calculator.Calculation(x, y, sign); //в calculation 3 значения передаем, которые прописали выше в функции calculation в классе calculator
                   Console.WriteLine(result);




                }

            }

            
        }

    }

