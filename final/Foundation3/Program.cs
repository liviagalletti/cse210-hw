using System;

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}
class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime EventDate { get; private set; }
    public Address EventAddress { get; private set; }

    public Event(string title, string description, DateTime eventDate, Address address)
    {
        Title = title;
        Description = description;
        EventDate = eventDate;
        EventAddress = address;
    }

    public string GetStandardDetails()
    {
        return $"{Title} on {EventDate}: {Description} at {EventAddress}.";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"{GetType().Name} - {Title} on {EventDate.ToShortDateString()}";
    }
}
class Lecture : Event
{
    public string Speaker { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, DateTime eventDate, Address address, string speaker, int capacity)
        : base(title, description, eventDate, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()} Speaker: {Speaker}, Capacity: {Capacity}";
    }
}
class Reception : Event
{
    public string RSVP_Email { get; private set; }

    public Reception(string title, string description, DateTime eventDate, Address address, string rsvpEmail)
        : base(title, description, eventDate, address)
    {
        RSVP_Email = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()} RSVP at: {RSVP_Email}";
    }
}
class OutdoorGathering : Event
{
    public string WeatherForecast { get; private set; }

    public OutdoorGathering(string title, string description, DateTime eventDate, Address address, string weatherForecast)
        : base(title, description, eventDate, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()} Weather Forecast: {WeatherForecast}";
    }
}
class Program
{
    static void Main(string[] args)
    {
       
        Event lecture = new Lecture("Space Exploration Talk", "A talk on the latest in space technology.", new DateTime(2023, 12, 15), new Address("123 Galaxy Rd", "Houston", "TX", "USA"), "Dr. Jane Smith", 100);
        Event reception = new Reception("Tech Conference 2023", "Annual technology networking event.", new DateTime(2023, 11, 20), new Address("456 Innovation Ave", "San Francisco", "CA", "USA"), "rsvp@techconf.com");
        Event outdoorGathering = new OutdoorGathering("Summer Music Festival", "Enjoy music in the park.", new DateTime(2023, 6, 5), new Address("789 Park Blvd", "New York", "NY", "USA"), "Sunny with a chance of rain");

        
        DisplayEventDetails(lecture);
        DisplayEventDetails(reception);
        DisplayEventDetails(outdoorGathering);
    }

    static void DisplayEventDetails(Event eventItem)
    {
        Console.WriteLine("Standard Details:");
        Console.WriteLine(eventItem.GetStandardDetails());
        Console.WriteLine("Full Details:");
        Console.WriteLine(eventItem.GetFullDetails());
        Console.WriteLine("Short Description:");
        Console.WriteLine(eventItem.GetShortDescription());
        Console.WriteLine();
    }
}
