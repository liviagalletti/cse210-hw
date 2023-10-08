using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        journal.Run();
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        Console.WriteLine("Saving to file...");
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Answer}");
            }
        }
        Console.WriteLine("File saved successfully.");
    }

    public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        DateTime dateOfFile = DateTime.Parse(parts[0]);
                        string promptOfFile = parts[1];
                        string contentOfFile = parts[2];
                        Entry loadedEntry = new Entry(dateOfFile, promptOfFile, contentOfFile);

                      
                        Console.WriteLine("Loaded Entry:");
                        loadedEntry.Display();

                        
                        AddEntry(loadedEntry);
                    }
                }
            
            }
            else
            {
                Console.WriteLine("The journal file does not exist.");
            }
        }


    public void Run()
    {
        while (true)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry newEntry = Entry.CreateEntryWithRandomPrompt();
                    Console.WriteLine($"Prompt: {newEntry.Prompt}");
                    Console.Write("Answer: ");
                    string answer = Console.ReadLine();
                    newEntry.Answer = answer;
                    AddEntry(newEntry);
                    break;

                case "2":
                    Console.WriteLine("Displaying Entries:");
                    DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter the filename to save: ");
                    string saveFileName = Console.ReadLine();
                    SaveToFile(saveFileName);
                    break;

                case "4":
                    Console.Write("Enter the filename to load: ");
                    string loadFileName = Console.ReadLine();
                    LoadFromFile(loadFileName);
                    break;

                case "5":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                    break;
            }
        }
    }
}

class Entry
{
    public DateTime Date { get; private set; }
    public string Prompt { get; private set; }
    public string Answer { get; set; }

    public Entry(DateTime date, string prompt, string answer)
    {
        Date = date;
        Prompt = prompt;
        Answer = answer;
    }

    public static Entry CreateEntryWithRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(0, prompts.Length);

        return new Entry(DateTime.Now, prompts[index], "");
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()} - Prompt: {Prompt}");
        Console.WriteLine($"Answer: {Answer}");
    }
}