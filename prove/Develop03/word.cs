using System;

class Word
{
    private string _word;
    private string _hiddenWord;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _hiddenWord = new string('_', word.Length);
        _isHidden = false;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public string Display()
    {
        if (_isHidden)
            return _hiddenWord;
        else
            return _word;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetOriginal()
    {
        return _word;
    }
}