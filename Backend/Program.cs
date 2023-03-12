using Dawn.Types;
using Dawn.Server;
using Dawn.Logger;
using Dawn.Decorators;
using Newtonsoft.Json;

namespace Dawn;

class Program
{
    public static void Main()
    {
        Log RootLogger = new Log("logs", "DAWN.log");
        Log Logger = new Log("logs", "DAWN.Program.cs.log");
        RootLogger.Write("Made logger for program.cs", "info");

        Logger.Write("Prepping DAWN", "task");
        Logger.Write("Deserializing \"appconfig.json\"", "task");

        AppConfig? cfg = JsonConvert.DeserializeObject<AppConfig?>(File.ReadAllText("./appconfig.json"));

        Logger.Write("Deserialized \"appconfig.json\"", "success");

        WebServer srv = new WebServer(cfg ?? new(new(1), new(), "./"));

        Console.Write(Constants.Logo);
        Console.Write($"{Colors.setColor(ConsoleColor.Blue)}{Constants.DAWN}");

        string rd = cfg?.RootDir ?? AppConfig.GetDefaultAppConfig("./").RootDir;
        string nameline = Builder.BuildNameLine(Constants.boxLen, rd, "║       - Root Directory : ");

        Console.WriteLine($"{Colors.setColor(ConsoleColor.DarkMagenta)}{Constants.table + "\n" + nameline + Constants.second}\nLogs:");
        Colors.setColor(ConsoleColor.White);
    }
}