namespace Dawn.Types;

public class AppConfig
{
    public List<string> Prefixes = new List<string>();
    public string RootDir { get; set; }
    public AppConfig(string[] prefixes, string rootdir = "./")
    {
        Prefixes.AddRange(prefixes);
        RootDir = rootdir;
    }
}