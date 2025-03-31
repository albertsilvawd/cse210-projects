using System;
using System.Collections.Generic;

public class Video
{
    // Private attributes
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    // Constructor to initialize the video
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>(); // Initialize the list of comments
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Getters for private attributes
    public string Title => _title;
    public string Author => _author;
    public int LengthInSeconds => _lengthInSeconds;
    public List<Comment> Comments => _comments;
}
