using System;

// represents a single journal entry.
public class Entry
{
    // attributes
    public string _date;
    public string _promptText;
    public string _entryText;

    // display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("----------------------------------------");
    }

    // format the entry for saving to a file.
    // using a '|' as a separator as required in simplifications.
    public string ToFileString()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
}