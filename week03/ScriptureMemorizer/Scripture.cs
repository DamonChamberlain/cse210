using System;
using System.Collections.Generic;
using System.Linq; // used for .all() and .where()

// represents a single scripture, including its reference and text
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // constructor to initialize the scripture
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // split the text into words and create word objects
        string[] textWords = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordStr in textWords)
        {
            _words.Add(new Word(wordStr));
        }
    }

    // hides a specified number of random, currently visible words
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();

        // find all words that are not already hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide; i++)
        {
            // if there are no more visible words, stop trying to hide
            if (visibleWords.Count == 0)
            {
                break;
            }

            // pick a random index from the list of visible words
            int randomIndex = rand.Next(visibleWords.Count);
            
            // hide the word
            visibleWords[randomIndex].Hide();
            
            // remove it from our temporary list so we don't pick it again this turn
            visibleWords.RemoveAt(randomIndex);
        }
    }

    // gets the display text for the entire scripture
    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + " ";
        
        // build the scripture text from individual words
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        
        return text.Trim(); // remove any trailing space
    }

    // checks if all words in the scripture are hidden
    public bool IsCompletelyHidden()
    {
        // returns true if every word in the _words list is hidden
        return _words.All(w => w.IsHidden());
    }
}