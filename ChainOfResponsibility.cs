namespace Patterns;

public abstract class SupportHandler
{
    protected SupportHandler? _nextHandler;

    public void SetNext(SupportHandler handler)
    {
        _nextHandler = handler;
    }

    public abstract void HandleRequest(string issue, int priority);
}

public class ChatBot : SupportHandler
{
    public override void HandleRequest(string issue, int priority)
    {
        if (priority == 1)
        {
            Console.WriteLine($"{nameof(ChatBot)}: Handling {issue}");
        }
        else
        {
            _nextHandler?.HandleRequest(issue, priority);
        }
    }
}

public class JuniorAgent : SupportHandler
{
    public override void HandleRequest(string issue, int priority)
    {
        if (priority == 2)
        {
            Console.WriteLine($"{nameof(JuniorAgent)}: Handling {issue}");
        }
        else
        {
            _nextHandler?.HandleRequest(issue, priority);
        }
    }
}

public class Manager : SupportHandler
{
    public override void HandleRequest(string issue, int priority)
    {
        Console.WriteLine($"{nameof(Manager)}: Handling {issue}");
    }
}