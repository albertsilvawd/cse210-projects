/// <summary>
/// Represents a single word in a scripture, tracking visibility state.
/// </summary>
public class Word
{
    private string _text;      // The actual word text
    private bool _isHidden;    // Whether the word is hidden

    /// <summary>
    /// Constructor initializes the word as visible.
    /// </summary>
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Default: visible
    }

    /// <summary>
    /// Hides the word (replaced by underscores).
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Shows the word (makes it visible).
    /// </summary>
    public void Show()
    {
        _isHidden = false;
    }

    /// <summary>
    /// Checks if the word is currently hidden.
    /// </summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns the word or underscores if hidden.
    /// </summary>
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }

    /// <summary>
    /// Returns the original word text (even if hidden).
    /// </summary>
    public string GetOriginalText()
    {
        return _text; // Added for review mode
    }
}