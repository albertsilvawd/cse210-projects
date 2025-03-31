public class Comment
{
    // Attributes
    public string Name { get; set; }
    public string Text { get; set; }

    // Constructor to initialize a comment
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
