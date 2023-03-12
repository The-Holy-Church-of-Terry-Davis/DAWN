using Dawn.Decorators;
using Dawn.Logger;

namespace Dawn.Logger;

public class Log {

    public static void Task(string message) {
        Logger.LogToFile($"[-] {message}");
        Console.WriteLine($"{Colors.setColor(ConsoleColor.Cyan)}[-] {message}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Success(string message) {
        Logger.LogToFile($"[{Constants.tick}] {message}");
        Console.WriteLine($"{Colors.setColor(ConsoleColor.Green)}[{Constants.tick}] {message}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Warn(string message) {
        Logger.LogToFile($"[!] {message}");
        Console.WriteLine($"{Colors.setColor(ConsoleColor.Yellow)}[!] {message}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Error(string message) {
        Logger.LogToFile($"[X] {message}");
        Console.WriteLine($"{Colors.setColor(ConsoleColor.Red)}[X] {message}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Info(string message) {
        Logger.LogToFile($"[?] {message}");
        Console.WriteLine($"{Colors.setColor(ConsoleColor.Blue)}[?] {message}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}