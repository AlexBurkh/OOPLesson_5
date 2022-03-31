using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber a = new RationalNumber(2, 3);
            RationalNumber b = new RationalNumber(-4, 7);

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(b - a);
            Console.WriteLine(a * b);
            Console.WriteLine(a / a);
            Console.WriteLine(b / a);
        }
    }
}
