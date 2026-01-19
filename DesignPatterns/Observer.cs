namespace Patterns.DesignPatterns;

public interface ISubject
{
    void Update(IObserver observer);
}

public interface IObserver
{
    void Attach(ISubject subject);
    void Detach(ISubject subject);
    void Notify();
}

public class WeatherStation : IObserver
{
    private readonly List<ISubject> _subjects = [];
    private float _temperature;

    public float Temperature
    {
        get { return _temperature; }
        set
        {
            _temperature = value;
            Notify();        
        }
    }

    public void Attach(ISubject subject) => _subjects.Add(subject);
    public void Detach(ISubject subject) => _subjects.Remove(subject);

    public void Notify()
    {
        foreach (ISubject subject in _subjects)
        {
            subject.Update(this);
        }
    }
}

public class PhoneDisplay(string name) : ISubject
{
    private readonly string _name = name;

    public void Update(IObserver observer)
    {
        if (observer is WeatherStation station)
        {
            Console.WriteLine($"{_name}: Temperature changed to {station.Temperature} degreees Celsius");
        }
    }
}