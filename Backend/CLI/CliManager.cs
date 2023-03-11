using Dawn.Types;
using Newtonsoft.Json;
using System.Net;

namespace Dawn.CLI;

public class CliManger
{
    public string[]? args { get; set; }

    public CliManger(string[]? arguments)
    {
        args = arguments;
    }

    public async Task ProcessArgs()
    {
        for(int i = 0; i < args?.Length; i++)
        {
            switch(args[i])
            {
                case "create":
                {
                    switch(args[i + 1])
                    {
                        default:
                        {
                            DirectoryInfo inf = Directory.CreateDirectory(args[i + 1]);
                            Directory.SetCurrentDirectory(inf.FullName);

                            File.Create("./appconfig.json").Close();
                            await Task.Delay(1);
                            File.WriteAllText("./appconfig.json", JsonConvert.SerializeObject(AppConfig.GetDefaultAppConfig(args[i + 1])));

                            HttpClient cli = new HttpClient();
                            byte[] buf = await cli.GetByteArrayAsync("https://github.com/The-Holy-Church-of-Terry-Davis/DAWN/releases/tag/2023-3-11.2/DAWN.exe");

                            FileStream fs = File.Create("DAWN.exe");
                            await fs.WriteAsync(buf, 0, buf.Length);
                            fs.Close();

                            i++;
                            break;
                        }
                    }

                    break;
                }
            }
        }
    }
}