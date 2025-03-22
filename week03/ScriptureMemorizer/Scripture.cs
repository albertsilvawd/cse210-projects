using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Manages a scripture's text and reference, including word-hiding logic.
/// </summary>
public class Scripture
{
    [JsonPropertyName("Reference")]
    private Reference _reference;

    [JsonPropertyName("Text")]
    private string _text;

    private List<Word> _words = new List<Word>(); // Ensure it's initialized

    /// <summary>
    /// Parameterless constructor for deserialization.
    /// </summary>
    public Scripture() { }

    /// <summary>
    /// Constructor initializes the scripture with a reference and text.
    /// </summary>
    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference));
        _text = text ?? throw new ArgumentNullException(nameof(text));

        _words = new List<Word>();
        foreach (string part in text.Split(' '))
        {
            _words.Add(new Word(part));
        }
    }

    /// <summary>
    /// Hides a specified number of random words.
    /// </summary>
    public void HideRandomWords(int numberToHide)
    {
        if (_words == null || _words.Count == 0) return; // Prevents NullReferenceException

        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
                _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        if (_reference == null) return "Invalid Scripture"; // Prevents errors

        string display = _reference.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }
        return display.Trim();
    }

    public bool IsCompletelyHidden()
    {
        if (_words == null) return false; // Prevents NullReferenceException

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }

    public List<Word> GetWords()
    {
        return _words ?? new List<Word>(); // Prevents NullReferenceException
    }
}
