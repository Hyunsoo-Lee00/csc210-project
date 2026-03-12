using System;
using System.Collections.Generic;

class Reference
{
    private string _book;
    private int _chapter;
    private List<int> _verses;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verses = new List<int>();
        _verses.Add(verse);
    }

    public Reference(string book, int chapter, List<int> verses)
    {
        _book = book;
        _chapter = chapter;
        _verses = verses;
    }

    public void Display()
    {
        if (_verses.Count == 1)
        {
            Console.WriteLine(_book + " " + _chapter + ":" + _verses[0]);
        }
        else
        {
            Console.WriteLine(_book + " " + _chapter + ":" + _verses[0] + "-" + _verses[_verses.Count - 1]);
        }
    }
}