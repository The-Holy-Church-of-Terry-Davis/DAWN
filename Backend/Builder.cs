using System.Text;

namespace Dawn;

public static class Builder
{
    public static byte[] BuildHtmlResponse(string? filename)
    {
        try
        {
            byte[] ret = Encoding.UTF8.GetBytes(File.ReadAllText(filename ?? "index.html"));
            return ret;
        } catch(Exception ex)
        {
            Console.WriteLine(ex);
            return new byte[5];
        }
    }
}