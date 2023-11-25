using System;

public class Cat
{
    private string _furColor;
    private string _name;

    public Cat(string name, string furColor)
    {
        _furColor = furColor;
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetFurColor()
    {
        return _furColor;
    }
}

class Program
{
    static void Main()
    {
        Cat myCat = new Cat("Whiskers", "Orange");

        string catName = myCat.GetName();
        string catFurColor = myCat.GetFurColor();

        Console.WriteLine($"Cat Name: {catName}");
        Console.WriteLine($"Fur Color: {catFurColor}");
    }
}
