using System;
using System.Collections.Generic;
using System.IO; // required for file operations

// (stretch goal) manages loading scriptures from a file
public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary(string filePath)
    {
        _scriptures = new List<Scripture>();
        LoadScripturesFromFile(filePath);
    }

    // reads the file and populates the _scriptures list
    private void LoadScripturesFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // file format: book|chapter|startverse|endverse|text
                // or for single verse: book|chapter|verse|text
                string[] parts = line.Split('|');

                if (parts.Length == 4) // single verse
                {
                    string book = parts[0];
                    int chapter = int.Parse(parts[1]);
                    int verse = int.Parse(parts[2]);
                    string text = parts[3];
                    Reference reference = new Reference(book, chapter, verse);
                    _scriptures.Add(new Scripture(reference, text));
                }
                else if (parts.Length == 5) // verse range
                {
                    string book = parts[0];
                    int chapter = int.Parse(parts[1]);
                    int startVerse = int.Parse(parts[2]);
                    int endVerse = int.Parse(parts[3]);
                    string text = parts[4];
                    Reference reference = new Reference(book, chapter, startVerse, endVerse);
                    _scriptures.Add(new Scripture(reference, text));
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The scripture file was not found at '{filePath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading scriptures: {ex.Message}");
        }
    }

    // gets a random scripture from the loaded list
    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            return null; // no scriptures were loaded
        }

        Random rand = new Random();
        int index = rand.Next(_scriptures.Count);
        return _scriptures[index];
    }
}