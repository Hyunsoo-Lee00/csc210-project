using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine($"Level: {GetLevel()} - {GetTitle()}");
            Console.WriteLine();

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Select: ");
            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") SaveGoals();
            else if (choice == "5") LoadGoals();
            else if (choice == "6") break;
        }
    }

    public int GetLevel()
    {
        if (_score >= 10000) return 5;
        if (_score >= 6000) return 4;
        if (_score >= 3000) return 3;
        if (_score >= 1000) return 2;
        return 1;
    }

    public string GetTitle()
    {
        int level = GetLevel();

        if (level == 5) return "Eternal Champion";
        if (level == 4) return "Master";
        if (level == 3) return "Disciple";
        if (level == 2) return "Follower";

        return "Beginner";
    }

    public void CreateGoal()
    {
        Console.WriteLine("1 Simple Goal");
        Console.WriteLine("2 Eternal Goal");
        Console.WriteLine("3 Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void ListGoals()
    {
        Console.WriteLine();

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int oldLevel = GetLevel();

        int points = _goals[index].RecordEvent();

        _score += points;

        Console.WriteLine($"You earned {points} points!");

        int newLevel = GetLevel();

        if (newLevel > oldLevel)
        {
            Console.WriteLine("🎉 LEVEL UP!");
            Console.WriteLine($"You reached Level {newLevel}!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        if (!filename.EndsWith(".txt"))
            filename += ".txt";

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!filename.EndsWith(".txt"))
            filename += ".txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");

            string type = parts[0];
            string[] data = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            }

            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }

            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2]),
                    int.Parse(data[3]),
                    int.Parse(data[4]),
                    int.Parse(data[5])));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}