using System;

using Task1;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(new RationalNumber(5, 2), new RationalNumber(-3, 4));
            ComplexNumber b = new ComplexNumber(new RationalNumber(3, 2), new RationalNumber(-1, 4));

            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"a + b: {a + b}");
            Console.WriteLine($"a - b: {a - b}");
            Console.WriteLine($"b - a: {b - a}");
            Console.WriteLine($"a * b: {a * b}");
            Console.WriteLine();
            Console.WriteLine($"a == b: {a == b}");
            Console.WriteLine($"a != b: {a != b}");
        }
    }
}
