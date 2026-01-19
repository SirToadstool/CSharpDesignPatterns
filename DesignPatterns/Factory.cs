namespace Patterns.DesignPatterns;

public enum AnimalType
{
    Dog,
    Cat,
    Bird,
    Snake
}

public interface IAnimal
{
    string Speak();
}

public interface IAnimalFactory
{
    IAnimal Get(AnimalType animalType);
}

public class Dog : IAnimal
{
    public string Speak() { return "Woof"; }
}

public class Cat : IAnimal
{
    public string Speak() { return "Meow"; }
}

public class Bird : IAnimal
{
    public string Speak() { return "Tweet"; }
}

public class Snake : IAnimal
{
    public string Speak() { return "Hiss"; }
}

public class AnimalFactory : IAnimalFactory
{
    public IAnimal Get(AnimalType animalType)
    {
        return animalType switch
        {
            AnimalType.Dog => new Dog(),
            AnimalType.Cat => new Cat(),
            AnimalType.Bird => new Bird(),
            AnimalType.Snake => new Snake(),
            _ => throw new Exception("Unknown animal type")
        };
    }
}