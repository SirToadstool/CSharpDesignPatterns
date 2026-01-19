namespace Patterns.DesignPatterns;

public class Singleton
{
    private Singleton() { }
    private static Singleton? _instance;
    public int Number { get; set; }

    public static Singleton Create()
    {
        _instance ??= new Singleton();
        return _instance;
    }
}