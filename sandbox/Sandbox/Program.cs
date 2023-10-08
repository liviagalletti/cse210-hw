using System;

class Person
{
    public string? Name { get; set; } // Use ? to indicate it's nullable
    public int Age { get; set; }

    public void SayHello()
    {
        Console.WriteLine($"Hello, I'm {Name}, and I'm {Age} years old.");
    }
    
    static void Main()
    {
        Person person1 = new Person { Name = "Alice", Age = 30 };
        person1.SayHello();
    }
}