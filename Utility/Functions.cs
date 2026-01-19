using Patterns.DesignPatterns;

namespace Patterns.Utility;

public static class Functions
{
    public static void CreateChainOfResponsibility()
    {
        ChatBot chatBot = new();
        JuniorAgent juniorAgent = new();
        Manager manager = new();

        chatBot.SetNext(juniorAgent);
        juniorAgent.SetNext(manager);

        chatBot.HandleRequest("issue1", 1);
        chatBot.HandleRequest("issue2", 2);
        chatBot.HandleRequest("issue3", 3);
    }

    public static void CreateFactory()
    {
        AnimalFactory factory = new();

        IAnimal dog = factory.Get(AnimalType.Dog);
        IAnimal cat = factory.Get(AnimalType.Cat);
        IAnimal bird = factory.Get(AnimalType.Bird);
        IAnimal snake = factory.Get(AnimalType.Snake);

        Console.WriteLine($"Dog goes {dog.Speak()}");
        Console.WriteLine($"Cat goes {cat.Speak()}");
        Console.WriteLine($"Bird goes {bird.Speak()}");
        Console.WriteLine($"Snake goes {snake.Speak()}");
    }

    public static void CreateObserver()
    {
        WeatherStation station = new();

        PhoneDisplay phone1 = new("PHone 1");
        PhoneDisplay phone2 = new("Phone 2");

        station.Attach(phone1);
        station.Attach(phone2);

        station.Temperature = 33.2f;
        station.Temperature = 46.1f;

        station.Detach(phone2);
        station.Temperature = 50.9f;
    }

    public static void CreateSingleton()
    {
        Singleton singleton1 = Singleton.Create();
        Singleton singleton2 = Singleton.Create();

        singleton2.Number = 2;

        Console.WriteLine($"Singleton1 number: {singleton1.Number}");
        Console.WriteLine($"Singleton2 number: {singleton2.Number}");
    }

    public static void CreateStrategy()
    {
        Converter converter = new(new JsonConverter());
        string input = "some cool data";

        Console.WriteLine($"JSON: {converter.ExecuteStrategy(input)}");
        converter.SetStrategy(new CsvConverter());
        Console.WriteLine($"CSV: {converter.ExecuteStrategy(input)}");
        converter.SetStrategy(new XmlConverter());
        Console.WriteLine($"XML: {converter.ExecuteStrategy(input)}");
    }
}