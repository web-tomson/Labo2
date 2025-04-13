using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"{Name} Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration (seconds): ");
        Duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("Get ready...");
        ShowAnimation(3);
        Run();
        End();
    }

    protected abstract void Run();

    protected void End()
    {
        Console.WriteLine("Well done! You have completed the activity.");
        Console.WriteLine($"You spent {Duration} seconds in the {Name} activity.");
        ShowAnimation(3);
    }

    protected void ShowAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly.") { }

    protected override void Run()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class ReflectionActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times when you showed strength and resilience.") { }

    protected override void Run()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        ShowAnimation(3);

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(Questions[rand.Next(Questions.Count)]);
            ShowAnimation(5);
        }
    }
}

class ListingActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on positive things in your life.") { }

    protected override void Run()
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
        ShowAnimation(3);
        
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            responses.Add(Console.ReadLine() ?? "");
        }
        
        Console.WriteLine($"You listed {responses.Count} items!");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine() ?? "4";
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                _ => null
            };
            
            if (activity == null)
                break;
            
            activity.Start();
        }
    }
}
