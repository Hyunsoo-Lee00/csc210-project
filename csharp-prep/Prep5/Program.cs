using System;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        Welcome();

        string name = GetName();

        int num = GetNumber ();

        int year;
        GetYear(out year);

        int square = Square(num);

        ShowResult(name, square, year);
    }

    static void Welcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string GetName()
    {
        Console.Write("Enter your name: ");
        return Console.ReadLine();
    }

    static int GetNumber()
    {
        Console.Write("Enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static void GetYear(out int birthYear)
    {
        Console.Write("Enter your birth year: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int Square(int n)
    {
        return n * n;
    }

    static void ShowResult(string name, int square, int year)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");

        int age = DateTime.Now.Year - year;
        Console.WriteLine($"{name}, you will turn {age} this year.");
    }
}