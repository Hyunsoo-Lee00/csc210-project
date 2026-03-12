/*
This program exceeds the core requirements in the following ways:

1. Users can enter their own scripture: book name, chapter, verse(s), and the scripture text.
   - This allows full flexibility instead of using only pre-stored scriptures.
2. Added difficulty levels: easy, medium, hard
   - Easy: hides 1-2 words at a time
   - Medium: hides 2-4 words at a time
   - Hard: hides 5-7 words at a time
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the book name:");
        string book = Console.ReadLine();

        Console.WriteLine("Enter the chapter number:");
        int chapter = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the verse number(s) (for multiple, separate by comma, e.g., 5,6):");
        string versesInput = Console.ReadLine();

        List<int> verses = new List<int>();
        foreach (string v in versesInput.Split(','))
        {
            verses.Add(int.Parse(v.Trim()));
        }

        Console.WriteLine("Enter the scripture text:");
        string text = Console.ReadLine();

        List<string> words = new List<string>(text.Split(' '));

        Scripture scripture;
        if (verses.Count == 1)
            scripture = new Scripture(book, chapter, verses[0], words);
        else
            scripture = new Scripture(book, chapter, verses, words);

        Console.WriteLine("Choose difficulty: easy / medium / hard");
        string choice = Console.ReadLine().ToLower();

        int min = 2;
        int max = 4;

        if (choice == "easy")
        {
            min = 1;
            max = 2;
        }
        else if (choice == "hard")
        {
            min = 5;
            max = 7;
        }

        Random rnd = new Random();

        while (!scripture.FullyHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress Enter to hide words or type 'quit'");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            int hideCount = rnd.Next(min, max + 1);
            scripture.HideWords(hideCount);
        }

        Console.Clear();
        Console.WriteLine("All words hidden!");
        scripture.Display();
    }
}