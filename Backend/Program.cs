using Dawn.Types;
using Dawn.Server;
using Newtonsoft.Json;

namespace Dawn;

class Program
{
    public static async Task Main()
    {
        AppConfig? cfg = JsonConvert.DeserializeObject<AppConfig?>(File.ReadAllText("./appconfig.json"));
        WebServer srv = new WebServer(cfg ?? new(new(1), new(), "./"));
    }
}