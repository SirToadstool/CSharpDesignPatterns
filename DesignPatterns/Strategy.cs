namespace Patterns.DesignPatterns;

public interface IStrategy
{
    string Convert(string input);
}

public interface IConverter
{
    void SetStrategy(IStrategy strategy);
    string ExecuteStrategy(string input);
}

public class JsonConverter :  IStrategy
{
    public string Convert(string input)
    {
        return $"{{ \"data\": \"{input}\" }}";
    }
}

public class CsvConverter: IStrategy
{
    public string Convert(string input)
    {
        return $"data,{input}";
    }
}

public class XmlConverter : IStrategy
{
    public string Convert(string input)
    {
        return $"<data>{input}</data>";
    }
}

public class Converter(IStrategy strategy) : IConverter
{
    private IStrategy _strategy = strategy;
    
    public void SetStrategy(IStrategy strategy) => _strategy = strategy;

    public string ExecuteStrategy(string input)
    {
        return _strategy?.Convert(input) ?? string.Empty;
    }
}