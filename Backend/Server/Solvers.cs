namespace Dawn.Server;

public static class Solvers
{
    public static string ContentTypeSolver(string? extension)
    {
        switch(extension)
        {
            case "json":
            {
                return "application/json";
            }

            case "js":
            {
                return "text/javascript";
            }

            case "css":
            {
                return "text/css";
            }

            default:
            {
                return "text/html";
            }
        }
    }
}