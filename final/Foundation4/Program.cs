using System;

abstract class Activity
{
    public DateTime Date { get; private set; }
    public int DurationInMinutes { get; private set; }

    protected Activity(DateTime date, int duration)
    {
        Date = date;
        DurationInMinutes = duration;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return GetDistance() / (DurationInMinutes / 60.0);
    }

    public virtual double GetPace()
    {
        return DurationInMinutes / GetDistance();
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} ({GetType().Name} - {DurationInMinutes} min) - Distance: {GetDistance()} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
class Running : Activity
{
    public double Distance { get; private set; } // in kilometers

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }
}
class Cycling : Activity
{
    public double Speed { get; private set; } 

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        return Speed * (DurationInMinutes / 60.0);
    }
}
class Swimming : Activity
{
    public int Laps { get; private set; }
    private const double LapLength = 0.05; 
    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * LapLength;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 03), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 04), 45, 20),
            new Swimming(new DateTime(2022, 11, 05), 60, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
