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
        Log Logger = new Log("logs", "DAWN.Program.cs.log");

        Logger.Write("Prepping DAWN", LogLevel.TASK);
        Logger.Write("Deserializing \"appconfig.json\"", LogLevel.TASK);

        AppConfig? cfg = JsonConvert.DeserializeObject<AppConfig?>(File.ReadAllText("./appconfig.json"));

        Logger.Write("Deserialized \"appconfig.json\"", LogLevel.SUCCESS);

        List<Restriction> restrictions = new();
        restrictions.Add(new Restriction(RestrictionType.FILE, fname: "./TestApp/", uri: null));
        restrictions.Add(new Restriction(RestrictionType.FILE, fname: "./TestApp/index.html", uri: null));

        WebServer srv = new WebServer(cfg ?? new(new(1), new(), "./"), new(restrictions));

        Console.Write(Constants.Logo);
        Console.Write($"{Colors.setColor(ConsoleColor.Blue)}{Constants.DAWN}");

        string rd = cfg?.RootDir ?? AppConfig.GetDefaultAppConfig("./").RootDir;
        string nameline = Builder.BuildNameLine(Constants.boxLen, rd, "║       - Root Directory : ");

        Console.WriteLine($"{Colors.setColor(ConsoleColor.DarkMagenta)}{Constants.table + "\n" + nameline + Constants.second}\nLogs:");
        Colors.setColor(ConsoleColor.White);
    }
}