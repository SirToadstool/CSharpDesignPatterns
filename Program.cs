using Patterns.Utility;

namespace Patterns;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Creating Builder...");
        Functions.CreateBuilder();
        Console.WriteLine();
        
        Console.WriteLine("Creating Chain of Responsibility...");
        Functions.CreateChainOfResponsibility();
        Console.WriteLine();
        
        Console.WriteLine("Creating Command...");
        Functions.CreateCommand();
        Console.WriteLine();

        Console.WriteLine("Creating Factory...");
        Functions.CreateFactory();
        Console.WriteLine();
        
        Console.WriteLine("Creating Observer...");
        Functions.CreateObserver();
        Console.WriteLine();
        
        Console.WriteLine("Creating Singleton...");
        Functions.CreateSingleton();
        Console.WriteLine();
        
        Console.WriteLine("Creating Strategy...");
        Functions.CreateStrategy();
    }
}
