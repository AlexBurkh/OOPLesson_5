﻿using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber a = new RationalNumber(2, 5);
            Single b = 0.1f;

            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"a + b: {a + b}");
            Console.WriteLine($"a - b: {a - b}");
            Console.WriteLine($"b - a: {b - a}");
            Console.WriteLine($"a * b: {a * b}");
            Console.WriteLine($"a / b: {a / b}");
            Console.WriteLine($"b / a: {b / a}");
            Console.WriteLine();
            Console.WriteLine($"a < b: {a < b}");
            Console.WriteLine($"a > b: {a > b}");
            Console.WriteLine($"a <= b: {a <= b}");
            Console.WriteLine($"a >= b: {a >= b}");
        }
    }
}
