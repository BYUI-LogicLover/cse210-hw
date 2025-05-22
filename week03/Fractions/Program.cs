using System;
using Fractions;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3, 4);
        Fraction f4 = new Fraction(1, 3);

        Console.WriteLine(f1.ToString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.ToString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.ToString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.ToString());
        Console.WriteLine(f4.GetDecimalValue());
    }
}