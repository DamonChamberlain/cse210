using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold all the Video objects
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video video1 = new Video("C# Abstraction Explained", "CodeWithSmith", 720);
        video1.AddComment("Alice", "This really helped me understand the concept!");
        video1.AddComment("Bob", "Great video, thanks!");
        video1.AddComment("Charlie", "A bit fast, but very informative.");
        videos.Add(video1);

        // --- Video 2 ---
        Video video2 = new Video("The Ultimate Guide to Baking Bread", "KitchenQueen", 1850);
        video2.AddComment("David", "My loaf came out perfect!");
        video2.AddComment("Eve", "What kind of yeast did you use?");
        video2.AddComment("Frank", "I burned mine... but I'll try again.");
        video2.AddComment("Grace", "Love this recipe!");
        videos.Add(video2);

        // --- Video 3 ---
        Video video3 = new Video("Beginner's Workout at Home", "FitLife", 1200);
        video3.AddComment("Hannah", "Feeling the burn!");
        video3.AddComment("Ian", "Can you do a video on stretches?");
        video3.AddComment("Judy", "Perfect for starting my fitness journey.");
        videos.Add(video3);

        // --- Video 4 ---
        Video video4 = new Video("Analyzing 'Dune: Part Two'", "CinemaCritique", 2100);
        video4.AddComment("Kyle", "Spot-on analysis of the themes.");
        video4.AddComment("Liam", "I disagreed with your take on Paul.");
        video4.AddComment("Mia", "Best movie of the year!");
        videos.Add(video4);


        // --- Iterate and Display ---
        Console.WriteLine("Displaying All Video Details:");
        Console.WriteLine("=============================\n");

        // Loop through the list of videos and call the display method for each one
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
