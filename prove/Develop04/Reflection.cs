using System;
using System.Collections.Generic;

public class Reflection : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private Random _random = new Random();

    public Reflection()
        : base("Reflection Activity",
               "This activity will help you reflect on times you showed strength.")
    {
        _prompts.Add("Think of a time you stood up for someone.");
        _prompts.Add("Think of a time you did something difficult.");
        _prompts.Add("Think of a time you helped someone.");
        _prompts.Add("Think of a time you were brave.");

        _questions.Add("Why was this meaningful?");
        _questions.Add("How did you feel?");
        _questions.Add("What did you learn?");
        _questions.Add("Would you do it again?");
    }

    public void Run()
    {
        StartActivity();

        int promptIndex = _random.Next(_prompts.Count);
        Console.WriteLine($"\n--- {_prompts[promptIndex]} ---");
        Pause();

        while (DateTime.Now < GetEndTime())
        {
            int qIndex = _random.Next(_questions.Count);
            Console.WriteLine("\n" + _questions[qIndex]);
            Pause();
        }

        EndActivity();
    }
}