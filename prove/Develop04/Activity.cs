using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private DateTime _endTime;

    private int _moodStart;
    private int _moodEnd;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---\n");

        _moodStart = GetMoodInput("How are you feeling right now (1-5)? ");

        Console.WriteLine("\n" + _description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        _endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("\nPrepare to begin...");
        Pause();
    }

    public void EndActivity()
    {
        Console.WriteLine("\nWell done!!");
        Pause();

        _moodEnd = GetMoodInput("\nHow are you feeling now (1-5)? ");

        int difference = _moodEnd - _moodStart;

        if (difference > 0)
            Console.WriteLine($"Your mood improved by {difference} point(s)!");
        else if (difference < 0)
            Console.WriteLine($"Your mood decreased by {Math.Abs(difference)} point(s).");
        else
            Console.WriteLine("Your mood stayed the same.");

        Console.WriteLine($"\nYou completed the activity for {_duration} seconds.");
        Pause();
    }

    private int GetMoodInput(string message)
    {
        int mood;

        while (true)
        {
            Console.Write(message);
            bool valid = int.TryParse(Console.ReadLine(), out mood);

            if (valid && mood >= 1 && mood <= 5)
                return mood;

            Console.WriteLine("Please enter a number between 1 and 5.");
        }
    }

    public DateTime GetEndTime()
    {
        return _endTime;
    }

    public void Pause()
    {
        string[] spinner = { "|", "/", "-", "\\" };

        DateTime futureTime = DateTime.Now.AddSeconds(3);
        int i = 0;

        while (DateTime.Now < futureTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    public void DisplayCountdown()
    {
        for (int i = 4; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}