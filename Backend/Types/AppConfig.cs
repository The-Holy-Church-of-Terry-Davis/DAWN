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

    public static AppConfig GetDefaultAppConfig(string rootdir)
    {
        if(!rootdir.EndsWith('/')) rootdir = rootdir + '/';

        List<string> ps = new();
        ps.Add("http://localhost:8080/");

        List<Mapping> maps = new();
        maps.Add(new Mapping("/index", rootdir + "index2.html"));
        maps.Add(new Mapping("/", rootdir + "index2.html"));
        maps.Add(new Mapping("", rootdir + "index2.html"));
        maps.Add(new Mapping("/home", rootdir + "index2.html"));
        maps.Add(new Mapping("/index2", rootdir + "index2.html"));

        AppConfig cfg = new AppConfig(ps, maps, rootdir);

        return cfg;
    }
}