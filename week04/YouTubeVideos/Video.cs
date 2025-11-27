using System;
using System.Collections.Generic;

// Defines the Video class
public class Video
{
    // Properties for the video's details
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    // A private list to hold all Comment objects associated with this video
    // This is a key part of the class's responsibility
    private List<Comment> _comments;

    // Constructor to initialize the video properties and the comment list
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>(); // Must initialize the list!
    }

    // Public method to add a new comment
    // It abstracts away the creation of the Comment object
    public void AddComment(string commenterName, string commentText)
    {
        Comment newComment = new Comment(commenterName, commentText);
        _comments.Add(newComment);
    }

    // Method to return the number of comments, as required
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // A comprehensive display method to show all video details
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        if (GetNumberOfComments() > 0)
        {
            Console.WriteLine("Comments:");
            // Loop through the private list and tell each comment to display itself
            foreach (Comment comment in _comments)
            {
                comment.Display();
            }
        }
        else
        {
            Console.WriteLine("No comments yet.");
        }
        
        // Add a separator for readability
        Console.WriteLine(new string('-', 30)); 
    }
}