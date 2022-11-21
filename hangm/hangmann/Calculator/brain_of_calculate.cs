using System;

namespace Calculator
{
    public class brain_of_calculate
    {
        int _a;
        int _b;
        char _oper;
        public brain_of_calculate(int a, int b, char oper)
        { 
            _a = a; 
            _b = b; 
            _oper = oper; 
        }

        public string WriteResult()
        {

            double result = 0.0;
            switch (_oper)
            {
                case '/':
                    if (_b != 0)
                    {
                        result = _a / _b;
                        
                    }
                    else
                    {
                        Console.WriteLine("на ноль делить нельзя!");
                    }

                    break;

                case '*':
                    result = _a * _b;
                    
                    break;

                case '-':
                    result = _a - _b;
                    
                    break;

                case '+':
                    result = _a + _b;
                    
                    break;

                default:
                    Console.WriteLine("ошибка, проверьте введенные данные");
                    break;

            }

            return result.ToString();
        }

    }
}