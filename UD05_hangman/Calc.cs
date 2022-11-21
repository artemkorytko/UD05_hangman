using System;

namespace UD05_hangman
{
    public class Calc
    {
        // private int А => inputA; //ваще не понимаю => почему работает а они серенькие
        // private int B => inputB;
        
        private Single _а;
        private Single _b;

        public Calc(string inputA, string inputB) // вызов экземпляра себя
        {
            _а = Convert.ToSingle(inputA);
            _b = Convert.ToSingle(inputB);
        }

        //------------действия----------------
        public Single Addition() // сложение
        {
            return (_а + _b);
        }


        public Single Substraction() // вычитаение
        {
            return (_а - _b);
        }


        public Single Multiplication() //умножение
        {
            return (_а * _b);
        }


        public long Mod() // действие про остаточек ^mod
        {
            return (Convert.ToInt64(_а) % Convert.ToInt64(_b));
        }

        public long Xor() // действие XOR - инвертирует биты числа O_o
        {
            return (Convert.ToInt64(_а) ^ Convert.ToInt64(_b));
        }

        // bool - передает что true (деление успешное) и тогда передаст как "out" в "div_result"
        // false - если "_b" равно нулю и делить запрещено
        // !! "out" указаить здесь и в используемой функции
        public bool Division(out Single div_result) // деление
        {
            div_result = 0;

            // деление на ноль недопустимо!
            if (_b == 0)
            {
                return false;
            } else
            {
                div_result = _а / _b;
                return true;
            }
        }
        
        public bool IntDiv(out int div_result) // деление
        {
            div_result = 0;

            // деление на ноль недопустимо!
            if (_b == 0)
            {
                return false;
            } else
            {
                div_result = (int)(_а / _b);  //операция div - деление возвращает только целое число
                return true;
            }
        }
    } 
    
}