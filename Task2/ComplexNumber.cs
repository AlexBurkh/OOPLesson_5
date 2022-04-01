using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task1;

namespace Task2
{
    internal class ComplexNumber
    {
        #region Конструкторы
        public ComplexNumber(RationalNumber a, RationalNumber b)
        {
            _real = a;
            _complex = b;
        }
        #endregion

        #region Поля
        RationalNumber _real;
        RationalNumber _complex;
        #endregion
        #region Свойства
        public RationalNumber Real { get { return _real; } }
        public RationalNumber Complex { get { return _complex; } }
        #endregion

        #region Методы
        #region Override
        public override string ToString()
        {
            return $"{_real} + {_complex}*i";
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ComplexNumber);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_real.GetHashCode(), _complex.GetHashCode());
        }
        public bool Equals(ComplexNumber other)
        {
            if ((other is not null) && (other._real == _real) && (other._complex == _complex))
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Операторы
        #region Бинарные
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            // z = (a1 + a2) + (b1 + b2) i.
            return new ComplexNumber(a._real + b._real, a._complex + b._complex);
        }
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            // z = (a1 - a2) + (b1 - b2) i.
            return new ComplexNumber(a._real - b._real, a._complex - b._complex);
        }
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            // z = (a1a2 – b1b2) + (a1b2 + a2b1) i.
            return new ComplexNumber(a._real * b._real - a._complex * b._complex, a._real * b._complex + b._real * a._complex);
        }
        #endregion
        #region Сравнения
        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !a.Equals(b);
        }
        #endregion
        #endregion
        #endregion
    }
}
