using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> number = new List<int>();
        int newNumber;

        do {
            Console.WriteLine("Enter number:");
            newNumber = int.Parse(Console.ReadLine());
            number.Add(newNumber);

        } while (newNumber != 0 );

        foreach (int num in number){

            Console.WriteLine(num + " ");
        }
    }
}