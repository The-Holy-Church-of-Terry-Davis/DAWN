using System.Text;

namespace Dawn;

public static class Builder
{
    public static byte[] BuildHtmlResponse(string? filename)
    {
        byte[] ret = Encoding.UTF8.GetBytes(File.ReadAllText(filename ?? "index.html"));
        return ret;
    }
}