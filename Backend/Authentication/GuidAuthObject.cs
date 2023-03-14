using CSL.Encryption;

namespace Dawn.Authentication;

public class GuidAuthObject
{
    public string[] guids { get; set; }
    
    public GuidAuthObject(string[] g)
    {
        guids = g;
    }

    public static GuidAuthObject New()
    {
        List<string> strs = new();

        for(int i = 0; i <=7; i++)
        {
            strs.Add(RandomVars.Guid().ToString());
        }

        return new(strs.ToArray());
    }
}