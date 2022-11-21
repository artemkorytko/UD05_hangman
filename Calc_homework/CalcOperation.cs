using System;

namespace Calc_homework
{
    public class CalcOperation
    {
        private int _x;
        private int _y;
        private char _sing;

        public CalcOperation(int x, int y, char sing)
        {
            _x = x;
            _y = y;
            _sing = sing;
        }

        public string WriteResult()
        {
            double result = 0.0;
            switch (_sing)
            {
                case '+':
                    result = _x + _y;
                    break;

                case '-':
                    result = _x - _y;
                    break;

                case '/':
                    if (_y != 0)
                        result = Convert.ToDouble(_x / _y);
                    else
                        return "Деление на ноль невозможно!";
                    break;

                case '*':
                    result = _x * _y;
                    break;

                case '^':
                    result = Math.Pow(_x, _y);
                    break;

                default:
                    Console.WriteLine("test");
                    break;
            }

            return result.ToString();
        }
    }
}