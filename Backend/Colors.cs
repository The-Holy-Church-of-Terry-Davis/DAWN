namespace Dawn.Colors;

public class Colors
{
    public static ConsoleColor? setColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        return null;
    }
}