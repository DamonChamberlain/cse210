using System;

// Defines the Comment class
public class Comment
{
    // Properties to store the commenter's name and the comment text
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Constructor to initialize the properties when a new comment is created
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    // A simple method to display the comment's details
    public void Display()
    {
        Console.WriteLine($"  - {CommenterName}: \"{CommentText}\"");
    }
}