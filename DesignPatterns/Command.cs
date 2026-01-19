namespace Patterns.DesignPatterns;

public enum LightType
{
    Bedroom,
    Kitchen,
    Basement,
    Porch,
    Desk
}

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light(LightType type)
{
    private LightType _type = type;
    
    public void TurnOn() => Console.WriteLine($"{_type} light is ON");
    public void TurnOff() => Console.WriteLine($"{_type} light is OFF");
}

public class LightOnCommand(Light light) : ICommand
{
    private readonly Light _light = light;
    
    public void Execute() => _light.TurnOn();
    public void Undo() => _light.TurnOff();
}

public class LightOffCommand(Light light) : ICommand
{
    private readonly Light _light = light;

    public void Execute() => _light.TurnOff();
    public void Undo() => _light.TurnOn();
}

public class RemoteControl  
{
    private readonly Stack<ICommand> _commandHistory = [];

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand command = _commandHistory.Pop();
            command.Undo();
        }
    }
}