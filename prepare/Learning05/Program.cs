// Base class for all types of goals
public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PointValue { get; set; }
    public bool IsComplete { get; protected set; }

    // Constructor
    protected Goal(string name, string description, int pointValue)
    {
        Name = name;
        Description = description;
        PointValue = pointValue;
        IsComplete = false;
    }

    // Method to mark the goal as complete
    public virtual void MarkComplete()
    {
        IsComplete = true;
    }

    // Method to get points, can be overridden in derived classes
    public virtual int GetPoints()
    {
        return IsComplete ? PointValue : 0;
    }
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int pointValue)
        : base(name, description, pointValue)
    {
    }

    public override void MarkComplete()
    {
        base.MarkComplete(); // Call the base implementation
        // Additional logic for simple goals
    }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int pointValue)
        : base(name, description, pointValue)
    {
    }

    public override int GetPoints()
    {
        // Eternal goals always return points, regardless of completion
        return PointValue;
    }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    public int CompletionCount { get; set; }
    public int RequiredCompletions { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int pointValue, int requiredCompletions, int bonusPoints)
        : base(name, description, pointValue)
    {
        RequiredCompletions = requiredCompletions;
        BonusPoints = bonusPoints;
        CompletionCount = 0;
    }

    public override void MarkComplete()
    {
        CompletionCount++;
        if (CompletionCount >= RequiredCompletions)
        {
            IsComplete = true;
        }
    }

    public override int GetPoints()
    {
        int bonus = IsComplete ? BonusPoints : 0;
        return (CompletionCount * PointValue) + bonus;
    }
}

// Example usage
public class Program
{
    public static void Main(string[] args)
    {
        // Creating goals
        SimpleGoal runMarathon = new SimpleGoal("Marathon", "Run a full marathon", 1000);
        EternalGoal readScriptures = new EternalGoal("Scriptures", "Read scriptures daily", 100);
        ChecklistGoal attendTemple = new ChecklistGoal("Temple", "Attend the temple 10 times", 50, 10, 500);

        // Simulating goal completion
        readScriptures.MarkComplete();
        for (int i = 0; i < 10; i++)
        {
            attendTemple.MarkComplete();
        }
        
        // Output the points earned
        Console.WriteLine($"Points for reading scriptures: {readScriptures.GetPoints()}");
        Console.WriteLine($"Points for attending temple: {attendTemple.GetPoints()}");
    }
}
