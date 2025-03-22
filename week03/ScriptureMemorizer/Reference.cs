/// <summary>
/// Represents a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6").
/// </summary>
public class Reference
{
    private string _book;      // Book name (e.g., "John")
    private int _chapter;      // Chapter number
    private int _startVerse;   // Starting verse
    private int _endVerse;     // Ending verse (0 if single verse)

    /// <summary>
    /// Constructor for a single-verse reference (e.g., "John 3:16").
    /// </summary>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = 0; // 0 indicates no range
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
        if (_endVerse == 0)
            return $"{_book} {_chapter}:{_startVerse}";
        else
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}