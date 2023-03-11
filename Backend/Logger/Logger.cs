namespace Dawn.Logger;

public class Logger
{
    public LoggerContext ctx { get; set; }

    public Logger(LoggerContext context)
    {
        ctx = context;
    }

    public void Append(string text)
    {
        if(ctx.SaveLogs ?? false)
        {
            File.WriteAllText(ctx.filename ?? "./log.txt", text);
        }
    }
}

public class LoggerContext
{
    public string? filename { get; set; }
    public bool? SaveLogs { get; set; }

    public LoggerContext(string fname, bool sl)
    {
        filename = fname;
        SaveLogs = sl;
    }
}