using Newtonsoft.Json;

namespace Dawn.Types;

public class AppConfig
{
    public List<string> Prefixes = new List<string>();
    public string RootDir { get; set; }
    public List<Mapping> Mappings { get; set; }

    public AppConfig(List<string> prefixes, List<Mapping> maps, string rootdir)
    {
        Prefixes = prefixes;
        RootDir = rootdir;
        Mappings = maps;
    }
}