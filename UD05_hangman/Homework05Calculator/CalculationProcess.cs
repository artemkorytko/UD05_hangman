using System;

namespace HomeworkCalculatorV1
{
    public class CalculationProcess
    {
        private int _x;
        private int _y;
        private char _operation;
        public CalculationProcess(int x, int y, char operation)
        {
            _x = x;
            _y = y;
            _operation = operation;
        }
        
        public double WriteResult()
        {
            double result = 0.0;
            switch (_operation)
            {
                case '+':
                    result = _x + _y;
                    break;
                
                case '-':
                    result = _x - _y;
                    break;
                
                case '*':
                    result = _x * _y;
                    break;
                
                case '/':
                    result = Convert.ToDouble(_x / _y);
                    break;
                
                case '%':
                    result = _x % _y;
                    break;
                
                case '^':
                    result = Math.Pow(_x, _y);
                    break;
                
                default:
                    Console.WriteLine("я не въехал.. что ты от меня хочешь? Я простой калькулятор!");
                    break;
            }
            
            return result;
        }

    }
}