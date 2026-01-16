using System;

class Program
{
    static void Main(string[] args)
    {
        Random RandomN = new Random();
        int magicnumber = RandomN.Next(1, 101);

        int guess = -1;

        while (guess != magicnumber)
        {
            Console.Write("What is your guess?");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicnumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicnumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You gueesed it!");
            }
        }
    }
}