namespace Patterns;

public abstract class SupportHandler
{
    protected SupportHandler? _nextHandler;

    public void SetNext(SupportHandler handler)
    {
        if (handler == this)
        {
            throw new ArgumentException("Handler cannot reference itself");
        }

        if (WouldCreateCycle(handler))
        {
            throw new InvalidOperationException("Setting this handler would create a cycle");
        }

        _nextHandler = handler;
    }

    public abstract void HandleRequest(string issue, int priority);

    private bool WouldCreateCycle(SupportHandler newHandler)
    {
        SupportHandler? current = newHandler;
        HashSet<SupportHandler> visited = [];

        while (current != null)
        {
            if (current == this || !visited.Add(current))
            {
                return true;
            }

            current = current._nextHandler;
        }

        return false;
    }
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