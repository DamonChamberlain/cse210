using System.Collections.Generic;
using System.IO;
using System;

// manages a list of Entry objects and handles file operations.
public class Journal
{
    // attribute
    public List<Entry> _entries = new List<Entry>();

    // add a new entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // display all entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n*** The journal is empty. Write an entry or load a file. ***\n");
            return;
        }

        Console.WriteLine("\n*** Journal Entries ***");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("*** End of Journal ***\n");
    }

    // save the journal to a file
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    // Writes the entry to the file in the format: date|prompt|entryText
                    outputFile.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine($"\nJournal successfully saved to {filename}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while saving: {ex.Message}\n");
        }
    }

    // load the journal from a file
    public void LoadFromFile(string filename)
    {
        try
        {
            // clear current entries before loading new ones
            _entries.Clear(); 
            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                // The separator must match what was used in SaveToFile (pipe '|')
                string[] parts = line.Split('|');

                // Basic check to ensure the line has all three required parts
                if (parts.Length == 3) 
                {
                    Entry newEntry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2]
                    };
                    _entries.Add(newEntry);
                }
            }
            Console.WriteLine($"\nJournal successfully loaded from {filename}. Total entries: {_entries.Count}\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"\nError: File '{filename}' not found.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while loading: {ex.Message}\n");
        }
    }
}