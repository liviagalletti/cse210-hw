using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public override string ToString()
    {
        return $"{book} {chapter}:{startVerse}-{endVerse}";
    }
}
public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public string Text
    {
        get { return text; }
    }

    public bool IsHidden
    {
        get { return isHidden; }
        set { isHidden = value; }
    }

    public override string ToString()
    {
        return isHidden ? "____" : text;
    }
}
public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            this.words.Add(new Word(word));
        }
    }

    public Reference Reference
    {
        get { return reference; }
    }

    public List<Word> Words
    {
        get { return new List<Word>(words); }
    }

    public void HideRandomWord()
    {
        Random rand = new Random();
        int index = rand.Next(words.Count);
        words[index].IsHidden = true;
    }

    public bool AreAllWordsHidden()
    {
        foreach (var word in words)
        {
            if (!word.IsHidden) return false;
        }
        return true;
    }

    public void Display()
    {
        Console.WriteLine(reference.ToString());
        foreach (var word in words)
        {
            Console.Write(word.ToString() + " ");
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AreAllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Goodbye!");
                break;
            }

            Console.WriteLine("\nPress enter to hide a word, or type 'quit' to exit: ");
            string userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            scripture.HideRandomWord();
        }
    }
}