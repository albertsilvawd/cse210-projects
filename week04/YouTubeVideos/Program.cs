using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create 3 videos with new titles
        Video video1 = new Video("The Wonders of Plants", "John Doe", 600);
        Video video2 = new Video("Understanding Mental Health", "Jane Smith", 500);
        Video video3 = new Video("The Importance of Fasting", "Mike Johnson", 350);

        // Create 3-4 comments for each video
        Comment comment1 = new Comment("Alice", "This video really opened my eyes to the beauty of plants!");
        Comment comment2 = new Comment("Bob", "I learned so much about plant care, thank you for sharing.");
        Comment comment3 = new Comment("Charlie", "Wonderful video, but it could use more information on plant diseases.");

        Comment comment4 = new Comment("David", "This video helped me understand mental health better, thanks!");
        Comment comment5 = new Comment("Emily", "Such a great resource, I will share it with my friends!");

        Comment comment6 = new Comment("Sophia", "I didn't know fasting had so many benefits, this video was insightful.");
        Comment comment7 = new Comment("Lucas", "The video explained everything clearly, I’ll definitely try fasting.");

        // Add comments to the videos
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);

        video2.AddComment(comment4);
        video2.AddComment(comment5);

        video3.AddComment(comment6);
        video3.AddComment(comment7);

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the videos and display their details and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Blank line between videos
        }
    }
}
