namespace Dawn.Types;

public class Mapping
{
    public string request_path { get; set; }
    public string filename { get; set; }

    public Mapping(string r, string f)
    {
        request_path = r;
        filename = f;
    }
}