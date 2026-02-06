using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6, 7);

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        f1.SetTop(3);
        f1.SetBottom(4);

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Random rand = new Random();
        Fraction randomFraction = new Fraction();

        for (int i = 1; i <= 20; i++)
        {
            int top = rand.Next(1, 11);
            int bottom = rand.Next(1, 11);
            randomFraction.SetTop(top);
            randomFraction.SetBottom(bottom);

            Console.WriteLine($"Fraction {i}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetDecimalValue()}");
        }
    }
}