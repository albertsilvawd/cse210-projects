using System;
using System.Collections.Generic;

public class Video
{
    // Attributes
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    // Constructor to initialize a video
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>(); // Initialize the list of comments
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
}
