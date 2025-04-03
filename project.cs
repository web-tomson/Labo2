using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>
        {
            new Video("C# Basics", "John Joe", 300),
            new Video("OOP in C#", "Jane Smith", 450),
            new Video("LINQ Tutorial", "Henry Brown", 600)
        };

        videos[0].AddComment(new Comment("Alice", "Great explanation!"));
        videos[0].AddComment(new Comment("Bob", "Very helpful, thanks!"));
        videos[0].AddComment(new Comment("Charlie", "Loved the examples."));

        videos[1].AddComment(new Comment("Dave", "OOP concepts are well covered."));
        videos[1].AddComment(new Comment("Eve", "I finally understand inheritance!"));
        videos[1].AddComment(new Comment("Frank", "This was exactly what I needed."));

        videos[2].AddComment(new Comment("Grace", "LINQ makes queries so much easier."));
        videos[2].AddComment(new Comment("Hank", "This tutorial is a lifesaver!"));
        videos[2].AddComment(new Comment("Ivy", "I learned a lot from this."));

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
