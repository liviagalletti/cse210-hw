using System;
using System.Threading;

class Activity
{
    protected string description;
    protected int duration;

    public Activity(string description)
    {
        this.description = description;
    }

    public void DisplayDescription()
    {
        Console.WriteLine(description);
    }

    public virtual void Start(int duration)
    {
        this.duration = duration;
        Console.WriteLine($"Prepare to begin {GetType().Name} activity...");
        
    }

    public virtual void Finish()
    {
        Console.WriteLine($"You have completed the {GetType().Name} activity.");
        Console.WriteLine($"Duration: {duration} seconds");

    }

}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("This activity will help you relax by guiding you through deep breathing.") { }

    public override void Start(int duration)
    {
        base.Start(duration);
        for (int seconds = 0; seconds < duration; seconds++)
        {
            Console.WriteLine(seconds % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(5000);
        }
        Finish();
    }
}

class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("This activity will help you reflect on past experiences.") { }

    public override void Start(int duration)
    {
        base.Start(duration);
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need."
        };

        Random random = new Random();

        for (int seconds = 0; seconds < duration;)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine($"Prompt: {prompt}");

            string[] reflectionQuestions = {
                "What have been the most significant challenges you've faced in the past, and how did you overcome them?",
                "What lessons have you learned from mistakes,",
                "What does success mean to you?",
                "What are the qualities or characteristics you admire in others?",
                "What legacy or impact do you want to leave behind in the world?",
                "How do you express gratitude and appreciation in your daily life? "
            };

            foreach (var question in reflectionQuestions)
            {
                Console.WriteLine($"Reflection Question: {question}");
                Thread.Sleep(6000); 
                seconds += 2;
            }
        }
        Finish();
    }
}

class ListingActivity : Activity
{
    public ListingActivity() : base("This activity will help you list positive things in your life.") { }

    public override void Start(int duration)
    {
        base.Start(duration);
        string[] prompts = {
            "List personal strengths of yours.",
            "List people you appreciate.",
            "List people you have helped recently."
        };

        Random random = new Random();
        int itemCount = 0;

        for (int seconds = 0; seconds < duration; seconds++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine($"Prompt: {prompt}");

            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"You listed {itemCount} items.");
        Finish();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Mindfulness App Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Select an option (1-4): ");
            int choice;

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        RunActivity(new BreathingActivity());
                        break;
                    case 2:
                        RunActivity(new ReflectionActivity());
                        break;
                    case 3:
                        RunActivity(new ListingActivity());
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number (1-4).");
            }
        }
    }

    static void RunActivity(Activity activity)
    {
        activity.DisplayDescription();
        int duration = GetDurationFromUser();
        activity.Start(duration);
    }

    static int GetDurationFromUser()
    {
        int duration;
        while (true)
        {
            Console.Write("Enter the duration in seconds: ");
            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
            {
                return duration;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }
    }
}
