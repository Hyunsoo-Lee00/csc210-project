using System;

public class Breathing : Activity
{
    public Breathing()
        : base("Breathing Activity",
               "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    public void Run()
    {
        StartActivity();

        while (DateTime.Now < GetEndTime())
        {
            Console.Write("\nBreathe in... ");
            DisplayCountdown();

            Console.Write("\nBreathe out... ");
            DisplayCountdown();
        }

        EndActivity();
    }
}