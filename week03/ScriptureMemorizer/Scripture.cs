using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Manages a scripture's text and reference, including word-hiding logic.
/// </summary>
public class Scripture
{
    [JsonPropertyName("Reference")] // Maps to JSON "Reference" object
    private Reference _reference = new Reference(); // Initialize to avoid null

    [JsonPropertyName("Text")] // Maps to JSON "Text" field
    private string _text;

    private List<Word> _words = new List<Word>();

    /// <summary>
    /// Parameterless constructor for deserialization.
    /// </summary>
    public Scripture()
    {
        _words = new List<Word>(); // Initialize to avoid null
    }

    /// <summary>
    /// Constructor initializes the scripture with a reference and text.
    /// </summary>
    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference));
        _text = text ?? throw new ArgumentNullException(nameof(text));

        InitializeWords(); // Initialize words during construction
    }

    /// <summary>
    /// Initializes the list of words after deserialization.
    /// Ensures words are split into Word objects based on _text.
    /// </summary>
    public void InitializeWords()
    {
        if (!string.IsNullOrEmpty(_text))
        {
            _words = new List<Word>();
            foreach (string part in _text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                _words.Add(new Word(part));
            }
        }
        else
        {
            Console.WriteLine("Warning: Scripture text is null or empty."); // Added for debugging
        }
    }

    /// <summary>
    /// Hides a specified number of random words.
    /// </summary>
    public void HideRandomWords(int numberToHide)
    {
        if (_words == null || _words.Count == 0) return;

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
        if (_reference == null || _words == null)
        {
            return "Invalid Scripture"; // Prevents NullReferenceException
        }

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
        if (_words == null) return false;

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
        return _words ?? new List<Word>();
    }
}