using System;

class Program
{
    static void Main(string[] args)
    {
        //Start off with a clean console window
        Console.Clear();

        List<Video> videos = new();

        Video video1 = new("Digging a SECRET Garage Part 6 THE COVER UP!", "colinfurze", 2266);
        video1.AddComment("colinfurze", "Hope you enjoy this update, I’ll be a bit slow on reply’s for a bit as I’m A&E right now with a Thorne in my eye. Let me know any questions for the next 2nd channel update were I discuss the next steps.");
        video1.AddComment("rsdotscot", "Colin just so you're aware there are now AI tools which can descramble mosaic tile censorship in video, so if you want to keep your number plate hidden (you missed a bit at 35:45, by the way) you should just put a solid rectangle over what you want to obscure.");
        video1.AddComment("TheHorzabora", "37:35 I dunno about the rest of you, but I’m here for a volumetric kinda man. 😂❤");

        videos.Add(video1);

        Video video2 = new("Is Our Model of Dark Energy WRONG? | New 4.2σ Results", "pbsspacetime", 1301);
        video2.AddComment("TechnIx12", "4.2σ blaze it");
        video2.AddComment("dyne313", "I'm still waiting for the Black Hole Sun to come and wash away the rain.");
        video2.AddComment("AdvantestInc", "The idea that dark energy might not be a constant is a reminder of how science works, each new observation opens the door to better models, not final answers. This video does a great job translating that evolving process.");

        videos.Add(video2);

        Video video3 = new("Linus made a good investment", "LMGClips", 402);
        video3.AddComment("armaan_bhangoo", "It's 6am and I understand nothing.  But Linus seems happy and excited so this is cool.");
        video3.AddComment("R520", "once again the stupid secretlab overlay getting in the way of the content");
        video3.AddComment("WileeC", "I have no understanding of anything that was discussed in this clip, yet I watched the entire thing just because of his excitement about it.  Congratulations?!");

        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine(video.Display());
        }
    }
}