using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _entryText;
    public int _satisfaction;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine($"Satisfaction (1-10): {_satisfaction}");
        Console.WriteLine();
    }
}