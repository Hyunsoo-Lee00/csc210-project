using System;
using System.Collections.Generic;

public class Listing : Activity
{
    private List<string> _prompts = new List<string>();
    private Random _random = new Random();

    public Listing()
        : base("Listing Activity",
               "This activity will help you focus on positive things in your life.")
    {
        _prompts.Add("Who do you appreciate?");
        _prompts.Add("What are your strengths?");
        _prompts.Add("Who have you helped recently?");
        _prompts.Add("What makes you happy?");
    }

    public void Run()
    {
        StartActivity();

        int index = _random.Next(_prompts.Count);
        Console.WriteLine("\n--- " + _prompts[index] + " ---");
        DisplayCountdown();

        int count = 0;

        while (DateTime.Now < GetEndTime())
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");

        EndActivity();
    }
}