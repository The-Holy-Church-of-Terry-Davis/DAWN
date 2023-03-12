using Dawn.Types;
using Dawn.Server;
using Dawn.Decorators;
using Newtonsoft.Json;

namespace Dawn;

class Program
{
    private static string whitespaceCounter(int len, string str) {
        try {
            int whitespace = 44 - len;
            string toReturn = $"{str}" + String.Concat(Enumerable.Repeat(" ", whitespace));
            return toReturn;
        } catch (ArgumentOutOfRangeException) {
            try {
                string toReturn = $"{String.Concat(Enumerable.Repeat(' ', 44))}║\n║          {str}{String.Concat(Enumerable.Repeat(' ', 60 - len))}";
                return toReturn;
            } catch (ArgumentOutOfRangeException) {
                string toReturn = $"{String.Concat(Enumerable.Repeat(' ', 44))}║\n║          --unavailable, project name too long!{String.Concat(Enumerable.Repeat(' ', 23))}";
                return toReturn;
            }
        }
    }
    public static void Main()
    {
        Console.WriteLine($"{Colors.setColor(ConsoleColor.Cyan)}[-] Prepping DAWN");
        Console.WriteLine($"{Colors.setColor(ConsoleColor.Cyan)}[-] Deserializing \"appconfig.json\"");

        AppConfig? cfg = JsonConvert.DeserializeObject<AppConfig?>(File.ReadAllText("./appconfig.json"));

        Console.WriteLine($"{Colors.setColor(ConsoleColor.Green)}[{Constants.tick}] Deserialized \"appconfig.json\"");

        WebServer srv = new WebServer(cfg ?? new(new(1), new(), "./"));

        Console.Write(Constants.Logo);
        Console.Write($"{Colors.setColor(ConsoleColor.Blue)}{Constants.DAWN}");

        string rd = cfg?.RootDir ?? AppConfig.GetDefaultAppConfig("./").RootDir;
        string nameline = Builder.BuildNameLine(Constants.boxLen, rd, "║       - Root Directory : ");

        Console.WriteLine($"{Colors.setColor(ConsoleColor.DarkMagenta)}{Constants.table + "\n" + nameline + Constants.second}\nLogs:");
        Colors.setColor(ConsoleColor.White);
    }
}