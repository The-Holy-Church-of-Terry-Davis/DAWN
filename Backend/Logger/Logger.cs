namespace Dawn.Logger;

public class Logger {

    public static void LogToFile(string message) {
        using (StreamWriter w = File.AppendText("DAWN.log"))
        {
            string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            w.WriteLine($"{time} {message}");
        }
    }
}