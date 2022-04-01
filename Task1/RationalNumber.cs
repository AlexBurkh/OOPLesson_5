using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class RationalNumber
    {
        #region Конструкторы
        public RationalNumber(Int32 numerator, UInt32 denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        #endregion

        #region Поля
        private Int32 _numerator;
        private UInt32 _denominator;
        #endregion

        #region Свойства
        public Int32 Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }
        public UInt32 Denominator
        {
            get
            {
                return _denominator;
            }
            set
            {
                if (value != 0) _denominator = value;
                else throw new ArgumentException();
            }
        }
        #endregion

        #region Методы
        #region Override
        public override string ToString()
        {
            if (Numerator == 0)
                return "0";
            return $"{_numerator}/{_denominator}";
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as RationalNumber);
        }
        public bool Equals(RationalNumber other)
        {
            return (other is not null) && (Numerator == other.Numerator) && (Denominator == other.Denominator);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }
        #endregion

        #region Операторы
        #region Унарные
        public static RationalNumber operator ++(RationalNumber a)
        {
            return new RationalNumber(a.Numerator + (Int32)a.Denominator, a.Denominator);
        }
        public static RationalNumber operator --(RationalNumber a)
        {
            return new RationalNumber(a.Numerator - (Int32)a.Denominator, a.Denominator);
        }
        #endregion
        #region Бинарные
        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            if (a.Denominator != b.Denominator)
            {
                BringToCommonDenominator(a, b);
            }
            var newNum = new RationalNumber(a.Numerator + b.Numerator, a.Denominator);
            ReduceRationalNumber(newNum);
            return newNum;
        }
        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            if (a.Denominator != b.Denominator)
            {
                BringToCommonDenominator(a, b);
            }
            var newNum = new RationalNumber(a.Numerator - b.Numerator, a.Denominator);
            ReduceRationalNumber(newNum);
            return newNum;
        }
        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            Int32 newNumerator = a.Numerator * b.Numerator;
            UInt32 newDenominator = a.Denominator * b.Denominator;
            var newNum = new RationalNumber(newNumerator, newDenominator);
            ReduceRationalNumber(newNum);
            return newNum;
        }
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            Int32 temp;
            Int32 newNumerator;
            UInt32 newDenominator;
            if (b.Numerator < 0)
            {
                temp = b.Numerator * -1;
                newNumerator = a.Numerator * (Int32)b.Denominator * -1;
                newDenominator = (UInt32)temp * a.Denominator;
            }
            else
            {
                newNumerator = a.Numerator * (Int32)b.Denominator;
                newDenominator = a.Denominator * (UInt32)b.Numerator;
            }
            var newNum = new RationalNumber(newNumerator, newDenominator);
            ReduceRationalNumber(newNum);
            return newNum;
        }
/*        public static RationalNumber operator %(RationalNumber a, RationalNumber b)
        {
            
        }*/
        #endregion
        #region Сравнения
        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            var first = a;
            var second = b;
            if (a.Denominator != b.Denominator)
                BringToCommonDenominator(first, second);
            return first.Numerator > second.Numerator;
        }
        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            var first = a;
            var second = b;
            if (a.Denominator != b.Denominator)
                BringToCommonDenominator(first, second);
            return first.Numerator < second.Numerator;
        }
        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            var first = a;
            var second = b;
            if (first.Denominator != second.Denominator)
                BringToCommonDenominator(first, second);
            return (first.Numerator > second.Numerator) || (first.Numerator == second.Numerator);
        }
        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            var first = a;
            var second = b;
            if (first.Denominator != second.Denominator)
                BringToCommonDenominator(first, second);
            return (first.Numerator < second.Numerator) || (first.Numerator == second.Numerator);
        }
        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !a.Equals(b);
        }
        #endregion
        #endregion

        #region Вспомогательные
        private static void BringToCommonDenominator(RationalNumber a, RationalNumber b)
        {
            UInt32 mulForA = b.Denominator;
            UInt32 mulForB = a.Denominator;

            a.Numerator *= (Int32)mulForA;
            a.Denominator *= mulForA;
            b.Numerator *= (Int32)mulForB;
            b.Denominator *= mulForB;
        }
        private static void ReduceRationalNumber(RationalNumber a)
        {
            Int32 gcd = GCD(Math.Abs(a.Numerator), Math.Abs((Int32) a.Denominator));
            a.Numerator /= gcd;
            a.Denominator /= (UInt32) gcd;
        }
        private static Int32 GCD(Int32 firstNum, Int32 secondNum)
        {
            Int32 gcd = 1;
            for (int i = 1; i < (firstNum * secondNum + 1); i++)
            {
                if ((firstNum % i == 0) && (secondNum % i == 0))
                {
                    gcd = i;
                }
            }
            return gcd;
        }
        #endregion
        #endregion
    }
}
