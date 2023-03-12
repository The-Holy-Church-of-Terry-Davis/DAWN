namespace Dawn.Logger;

public class Logger 
{
    public string FileName { get; set; }

    public Logger(string fname)
    {
        FileName = fname;
    }

    public void LogToFile(string message)
    {
        DateTime now = DateTime.UtcNow;
        File.WriteAllText(FileName, $"[{now.ToString()}] : {message}");
    }
}