using Dawn.CLI;
using Dawn.Types;
using Dawn.Server;
using Newtonsoft.Json;

namespace Dawn;

class Program
{
    public static async Task Main(params string[] args)
    {
        if(args.Length > 0)
        {
            CliManger cli = new CliManger(args);
            await cli.ProcessArgs();
        } else {
            AppConfig? cfg = JsonConvert.DeserializeObject<AppConfig?>(File.ReadAllText("./appconfig.json"));
            WebServer srv = new WebServer(cfg ?? new(new(1), new(), "./"));
        }
    }
}