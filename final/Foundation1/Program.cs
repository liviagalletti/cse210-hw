using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video()
    {
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int NumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

       
        Video video1 = new Video { Title = "Unboxing the XYZ Phone", Author = "TechReviewDaily", LengthInSeconds = 300 };
        video1.AddComment(new Comment { CommenterName = "Alice", Text = "Great review!" });
        video1.AddComment(new Comment { CommenterName = "Bob", Text = "Can't wait to try this phone." });
        videos.Add(video1);

        Video video2 = new Video { Title = "Best Laptops 2023", Author = "GadgetGuru", LengthInSeconds = 600 };
        video2.AddComment(new Comment { CommenterName = "Charlie", Text = "Very informative!" });
        video2.AddComment(new Comment { CommenterName = "Dave", Text = "I disagree with your top pick." });
        videos.Add(video2);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.NumberOfComments()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(); 
        }
    }
}
