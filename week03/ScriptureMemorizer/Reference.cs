/// <summary>
/// Represents a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6").
/// </summary>
public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Parameterless constructor for JSON deserialization
    public Reference() { }

    /// <summary>
    /// Constructor for a single-verse reference (e.g., "John 3:16").
    /// </summary>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = 0; // Indicates no range
    }

    /// <summary>
    /// Constructor for a verse range (e.g., "Proverbs 3:5-6").
    /// </summary>
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    /// <summary>
    /// Returns the formatted reference text (e.g., "John 3:16" or "Proverbs 3:5-6").
    /// </summary>
    public string GetDisplayText()
    {
        return _endVerse == 0 
            ? $"{_book} {_chapter}:{_startVerse}" 
            : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}