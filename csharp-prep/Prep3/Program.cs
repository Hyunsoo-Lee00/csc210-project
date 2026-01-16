using System;

class Program
{
    static void Main(string[] args)
    {
<<<<<<< HEAD
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
=======
        Random randomN = new Random();
        int magicNumber = randomN.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
>>>>>>> 0c40c488e4e763230492b1c0c95707b4f85afff5
            {
                Console.WriteLine("Lower");
            }
            else
            {
<<<<<<< HEAD
                Console.WriteLine("You gueesed it!");
=======
                Console.WriteLine("You guessed it!");
>>>>>>> 0c40c488e4e763230492b1c0c95707b4f85afff5
            }
        }
    }
}