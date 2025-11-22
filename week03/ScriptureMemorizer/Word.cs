using System;

// represents a single word in the scripture
public class Word
{
    private string _text;
    private bool _isHidden;

    // constructor initializes the word and sets it to be visible
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    // shows the word (not used in core requirements, but good for encapsulation)
    public void Show()
    {
        _isHidden = false;
    }

    // checks if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // gets the display text for the word (either the word itself or underscores)
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // returns a string of underscores matching the word's length
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}