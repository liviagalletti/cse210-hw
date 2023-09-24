using System;
using System.Globalization;
using System.Xml.Schema;

using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squareNumber = SquareNumber(userNumber);
        DisplayResult(userName, squareNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name:");
        return Console.ReadLine(); 
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        return int.Parse(Console.ReadLine()); 
    }

    static int SquareNumber(int number)
    {
        return number * number; 
    }

    static void DisplayResult(string userName, int squareNumber)
    {
        Console.WriteLine($"{userName}, the square of the number is {squareNumber}");
    }
}
