class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create videos and add comments
        Video video1 = new Video("C# Tutorial for Beginners", "Tech With Tim", 10800);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot."));
        videos.Add(video1);

        Video video2 = new Video("ASP.NET Core Web API Best Practices", "Nick Chapsas", 3600);
        video2.AddComment(new Comment("Dave", "Excellent content."));
        video2.AddComment(new Comment("Eve", "Love your videos!"));
        video2.AddComment(new Comment("Frank", "Keep up the good work."));
        videos.Add(video2);

        Video video3 = new Video("Introduction to Machine Learning", "Andrew Ng", 7200);
        video3.AddComment(new Comment("Grace", "Amazing explanation."));
        video3.AddComment(new Comment("Heidi", "Very clear and concise."));
        video3.AddComment(new Comment("Ivan", "Highly recommended."));
        video3.AddComment(new Comment("Travis", "Bazinga."));
        videos.Add(video3);

        // Display video information
        Console.WriteLine();
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }
    }
}