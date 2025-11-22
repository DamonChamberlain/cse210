using System;

// represents the reference for a scripture (e.g., "john 3:16" or "proverbs 3:5-6")
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse; // will be 0 if it's a single verse

    // constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; // use 0 or -1 to indicate no end verse
    }

    // constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // gets the formatted display text for the reference
    public string GetDisplayText()
    {
        if (_endVerse == 0) // it's a single verse
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else // it's a verse range
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}