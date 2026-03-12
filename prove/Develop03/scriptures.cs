using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _scripture;
    private List<int> _hiddenWords;

    public Scripture(string book, int chapter, int verse, List<string> words)
    {
        _reference = new Reference(book, chapter, verse);
        _scripture = new List<Word>();

        for (int i = 0; i < words.Count; i++)
        {
            _scripture.Add(new Word(words[i]));
        }

        _hiddenWords = new List<int>();
    }

    public Scripture(string book, int chapter, List<int> verses, List<string> words)
    {
        _reference = new Reference(book, chapter, verses);
        _scripture = new List<Word>();

        for (int i = 0; i < words.Count; i++)
        {
            _scripture.Add(new Word(words[i]));
        }

        _hiddenWords = new List<int>();
    }

    public void Display()
    {
        _reference.Display();

        for (int i = 0; i < _scripture.Count; i++)
        {
            Console.Write(_scripture[i].Display() + " ");
        }

        Console.WriteLine();
    }

    public void HideWords(int count)
    {
        List<int> visibleIndexes = new List<int>();

        for (int i = 0; i < _scripture.Count; i++)
        {
            if (_scripture[i].IsHidden() == false)
            {
                visibleIndexes.Add(i);
            }
        }

        Random rnd = new Random();

        for (int i = 0; i < count && visibleIndexes.Count > 0; i++)
        {
            int randomIndex = rnd.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[randomIndex];

            _scripture[wordIndex].HideWord();
            visibleIndexes.RemoveAt(randomIndex);
            _hiddenWords.Add(wordIndex);
        }
    }

    public bool FullyHidden()
    {
        for (int i = 0; i < _scripture.Count; i++)
        {
            if (_scripture[i].IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }
}