using System;

namespace MyCalc
{
    public class CalcLogic
    {
        private int _x;
        private int _y;
        private char _sign;
        public int _result;
        public string _error;

        //создаём конструктор
        public CalcLogic(int x, int y, char sign)
        {
            _x = x;
            _y = y;
            _sign = sign;
        }

        //Метод проверки деления на ноль
        public string CheckDivNull()
        {
            if (_sign == '/' && _y == 0)
            {
                _error = "На ноль делить нельзя!";
            }

            return _error;
        }

        //Метод вычисления
        public int Calculation()
        {
            switch (_sign)
            {
                case '+':
                    _result = _x + _y;
                    break;
                case '-':
                    _result = _x - _y;
                    break;
                case '*':
                    _result = _x * _y;
                    break;
                case '/':
                    _result = _x / _y;
                    break;
                case '^':
                    _result = Convert.ToInt32(Math.Pow(_x, _y));
                    break;
            }

            return _result;
        }
    }
}