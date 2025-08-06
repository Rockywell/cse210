using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.\n");

        Video video1 = new Video("The Secrets of Space", "AstroMax", 620, [
            new Comment("Alice", "This is so fascinating!"),
            new Comment("Bob", "Loved the visuals."),
            new Comment("Clara", "Very informative, thanks!")
        ]);

        Video video2 = new Video("How to Cook Pasta", "Chef Luigi", 540, [
            new Comment("Derek", "Tried it, turned out amazing!"),
            new Comment("Ella", "Simple and delicious."),
            new Comment("Frank", "I added garlic and it was great!")
        ]);

        Video video3 = new Video("Learn C# in 10 Minutes", "CodeMaster", 600, [
            new Comment("Grace", "Super helpful for beginners."),
            new Comment("Hank", "I wish it was a bit slower."),
            new Comment("Ivy", "Clear and concise. Thanks!")
        ]);

        Video video4 = new Video("Relaxing Nature Sounds", "ZenVibes", 1800, [
            new Comment("Jake", "Perfect for studying."),
            new Comment("Luna", "I listen to this every night."),
            new Comment("Mia", "So calming!")
        ]);
        video4.AddComment(new Comment("Trololol", "Way too annoying, this video sucks."));


        List<Video> videos = [video1, video2, video3, video4];

        foreach (Video video in videos)
        {
            Console.WriteLine($"{video.GetInfo()}\n\nComments:\n{video.GetComments()}\n");
        }
    }
}