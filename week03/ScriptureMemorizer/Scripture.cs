using System;
using System.Collections.Generic;

/// <summary>
/// Manages a scripture's text and reference, including word-hiding logic.
/// </summary>
public class Scripture
{
    private Reference _reference; // Scripture reference
    private List<Word> _words;    // List of Word objects

    /// <summary>
    /// Constructor initializes the scripture with a reference and text.
    /// Splits the text into individual Word objects.
    /// </summary>
    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference)); // Prevent null reference
        _words = new List<Word>();
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    /// <summary>
    /// Hides a specified number of random words.
    /// </summary>
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
                _words[index].Hide();
        }
    }

    /// <summary>
    /// Returns the formatted scripture text with hidden words as underscores.
    /// </summary>
    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }

    /// <summary>
    /// Checks if all words in the scripture are hidden.
    /// </summary>
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }

    /// <summary>
    /// Returns the list of Word objects (for review mode).
    /// </summary>
    public List<Word> GetWords()
    {
        return _words; // Added to resolve CS1061 error
    }
}