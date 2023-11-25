using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class for goals
class Goal
{
    public string Name { get; set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get;  set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public virtual void CompleteGoal()
    {
        IsCompleted = true;
    }

    public virtual void DisplayProgress()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Name}");
    }
}

class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int requiredTimes;

    public ChecklistGoal(string name, int points, int requiredTimes) : base(name, points)
    {
        this.requiredTimes = requiredTimes;
        timesCompleted = 0;
    }

    public override void CompleteGoal()
    {
        timesCompleted++;
        if (timesCompleted >= requiredTimes)
        {
            IsCompleted = true;
            Points += 100;
        }
    }

    public override void DisplayProgress()
    {
        string status = IsCompleted ? "[X]" : $"Completed {timesCompleted}/{requiredTimes} times";
        Console.WriteLine($"{status} {Name}");
    }
}

class EternalQuestProgram
{
    private List<Goal> goals = new List<Goal>();

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        var goal = goals.FirstOrDefault(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));
        if (goal != null)
        {
            goal.CompleteGoal();
            Console.WriteLine($"You earned {goal.Points} points for completing: {goal.Name}");
        }
        else
        {
            Console.WriteLine("Goal not found. Please check the goal name.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            goal.DisplayProgress();
        }
    }

    public int CalculateTotalScore()
    {
        return goals.FindAll(goal => goal.IsCompleted).Sum(goal => goal.Points);
    }

    public void SaveGoalsToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                string goalType = goal is ChecklistGoal ? "Checklist" : "Simple";
                string goalData = $"{goalType}:{goal.Name}:{goal.Points}:{goal.IsCompleted}";
                outputFile.WriteLine(goalData);
            }
        }
        Console.WriteLine("Goals saved to file.");
    }

    public void LoadGoalsFromFile(string filename)
    {
        goals.Clear(); // Clear existing goals
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 4)
                {
                    string goalType = parts[0];
                    string goalName = parts[1];
                    int goalPoints = int.Parse(parts[2]);
                    bool goalCompleted = bool.Parse(parts[3]);

                    if (goalType.Equals("Checklist", StringComparison.OrdinalIgnoreCase))
                    {
                        int requiredTimes = 10; // Change this value as needed
                        var checklistGoal = new ChecklistGoal(goalName, goalPoints, requiredTimes);
                        checklistGoal.IsCompleted = goalCompleted;
                        goals.Add(checklistGoal);
                    }
                    else
                    {
                        var simpleGoal = new Goal(goalName, goalPoints);
                        simpleGoal.IsCompleted = goalCompleted;
                        goals.Add(simpleGoal);
                    }
                }
            }
            Console.WriteLine("Goals loaded from file.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}

class Program
{
    static void Main()
    {
        EternalQuestProgram program = new EternalQuestProgram();
        program.LoadGoalsFromFile("goals.txt");

        while (true)
        {
            Console.WriteLine("Eternal Quest Program Menu:");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Calculate Total Score");
            Console.WriteLine("5. Save Goals to File");
            Console.WriteLine("6. Load Goals from File");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();
                    Console.Write("Enter goal type (Simple/Checklist): ");
                    string goalType = Console.ReadLine();
                    Console.Write("Enter goal points: ");
                    int goalPoints = int.Parse(Console.ReadLine());

                    if (goalType.Equals("Checklist", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter required times for checklist goal: ");
                        int requiredTimes = int.Parse(Console.ReadLine());
                        var checklistGoal = new ChecklistGoal(goalName, goalPoints, requiredTimes);
                        program.AddGoal(checklistGoal);
                    }
                    else
                    {
                        var simpleGoal = new Goal(goalName, goalPoints);
                        program.AddGoal(simpleGoal);
                    }
                    break;

                case "2":
                    Console.Write("Enter the name of the goal you completed: ");
                    string completedGoalName = Console.ReadLine();
                    program.RecordEvent(completedGoalName);
                    break;

                case "3":
                    program.DisplayGoals();
                    break;

                case "4":
                    int totalScore = program.CalculateTotalScore();
                    Console.WriteLine($"Total Score: {totalScore}");
                    break;

                case "5":
                    program.SaveGoalsToFile("goals.txt");
                    break;

                case "6":
                    program.LoadGoalsFromFile("goals.txt");
                    break;

                case "7":
                program.SaveGoalsToFile("goals.txt"); // Save goals before exiting
                Environment.Exit(0);
                break;


                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
