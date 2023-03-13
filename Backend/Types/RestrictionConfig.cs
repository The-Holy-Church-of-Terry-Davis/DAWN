namespace Dawn.Types;

public class RestrictionConfig
{
    public List<Restriction> restrictions { get; set; }

    public Restriction this[int index]
    {
        get => restrictions[index];
        set => restrictions[index] = value;
    }
    
    public RestrictionConfig(List<Restriction> res)
    {
        restrictions = res;
    }

    public bool CanAccess(string filename)
    {
        foreach(Restriction res in restrictions)
        {
            FileInfo inf1 = new(res.filename!);
            FileInfo inf2 = new(filename);

            if(inf1.FullName == inf2.FullName)
            {
                return true;
            } else 
            {
                continue;
            }
        }

        return false;
    }
}

public class Restriction
{
    public RestrictionType type { get; set; }
    public string? endpoint { get; set; }
    public string? filename { get; set; }
    public string? subrequri { get; set; }

    public Restriction(RestrictionType tp, string? endp = null, string? fname = null, string? uri = null)
    {
        type = tp;
        endpoint = endp;
        filename = fname;
        subrequri = uri;
    }
}

public enum RestrictionType
{
    FILE,
    ENDPOINT
}
