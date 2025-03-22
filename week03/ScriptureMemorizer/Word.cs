/// <summary>
/// Represents a single word in a scripture, tracking visibility state.
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;

    // Parameterless constructor for JSON deserialization
    public Word() { }

    /// <summary>
    /// Constructor initializes the word as visible.
    /// </summary>
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>
    /// Hides the word (replaces it with underscores).
    /// </summary>
    public void Hide() => _isHidden = true;

    /// <summary>
    /// Shows the word (makes it visible).
    /// </summary>
    public void Show() => _isHidden = false;

    /// <summary>
    /// Checks if the word is currently hidden.
    /// </summary>
    public bool IsHidden() => _isHidden;

    /// <summary>
    /// Returns the word or underscores if hidden.
    /// </summary>
    public string GetDisplayText() => _isHidden ? new string('_', _text.Length) : _text;

    /// <summary>
    /// Returns the original word text (even if hidden).
    /// </summary>
    public string GetOriginalText() => _text; // Added for review mode
}