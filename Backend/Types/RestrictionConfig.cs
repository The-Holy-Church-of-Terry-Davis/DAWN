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
}

public class Restriction
{
    public RestrictionType type { get; set; }
    public string? endpoint { get; set; }
    public string? filename { get; set; }
    public string? subrequri { get; set; }
    public RestrictionCondition condition { get; set; }

    public Restriction(RestrictionType tp, RestrictionCondition c, string? endp = null, string? fname = null, string? uri = null)
    {
        type = tp;
        endpoint = endp;
        filename = fname;
        subrequri = uri;
        condition = c;
    }
}

public enum RestrictionType
{
    FILE,
    ENDPOINT
}

public enum RestrictionCondition
{
    SUBREQUEST
}