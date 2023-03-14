using Dawn.Decorators;

namespace Dawn.Logger;

public class Log
{
    public string DirName { get; set; }
    public string FileName { get; set; }
    public string PathName { get; set; }

    public Log(string dname, string fname, bool overwrite = true)
    {
        DirName = dname;
        FileName = fname;
        PathName = $"{DirName}/{FileName}";

        Directory.CreateDirectory("./" + dname);
        File.Create("./" + Path.Join(dname, fname)).Close();

        if(overwrite) 
        {
            File.WriteAllText(PathName, $"[{DateTime.UtcNow} UTC] : [?] START OF LOG FOR {FileName}\n");
        }
    }

    public void Write(string message, LogLevel logLevel)
    {
        switch (logLevel) {
            case LogLevel.INFO:
                message = $"[?] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Blue)}{message}");
                break;
            case LogLevel.TASK:
                message = $"[-] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Cyan)}{message}");
                break;
            case LogLevel.WARN:
                message = $"[!] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Yellow)}{message}");
                break;
            case LogLevel.ERROR:
                message = $"[X] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Red)}{message}");
                break;
            case LogLevel.SUCCESS:
                message = $"[{Constants.tick}] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Green)}{message}");
                break;
            default:
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Magenta)}{message}");
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;
        DateTime now = DateTime.UtcNow;
        File.AppendAllText(PathName, $"[{now.ToString()} UTC] : {message}\n");
    }
}

public enum LogLevel
{
    INFO,
    TASK,
    WARN,
    ERROR,
    SUCCESS
}