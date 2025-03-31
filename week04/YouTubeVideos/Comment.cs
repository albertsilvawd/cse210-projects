public class Comment
{
    // Private attributes
    private string _name;
    private string _text;

    // Constructor to initialize a comment
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Getters for private attributes
    public string Name => _name;
    public string Text => _text;
}
