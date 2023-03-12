namespace Dawn.Decorators;

public class Colors
{
    public static ConsoleColor? setColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        return null;
    }
}