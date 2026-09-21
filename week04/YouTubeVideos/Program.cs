using System;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        
        Video video1 = new Video("C# Tutorial for Beginners", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "This video helped me a lot!"));
        video1.AddComment(new Comment("Bob", "Clear and concise explanation. Thanks."));
        video1.AddComment(new Comment("Charlie", "Subscribed! Looking forward to more."));
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programming in C#", "TechGuy", 1200);
        video2.AddComment(new Comment("David", "Encapsulation makes so much sense now."));
        video2.AddComment(new Comment("Eva", "Great examples used throughout."));
        video2.AddComment(new Comment("Frank", "Could you make a part 2 on polymorphism?"));
        videos.Add(video2);

        Video video3 = new Video("Top 10 VS Code Shortcuts", "DevTips", 450);
        video3.AddComment(new Comment("Grace", "Shortcut #4 is a game changer!"));
        video3.AddComment(new Comment("Heidi", "Very useful, thank you."));
        video3.AddComment(new Comment("Ivan", "Short and straight to the point. Awesome."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}