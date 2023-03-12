using System.Text;

namespace Dawn;

public static class Builder
{
    public static byte[] RetrieveFileResponse(string? filename, int encoding)
    {
        try
        {
            switch(encoding)
            {
                case 0:
                {
                    return File.ReadAllBytes(filename ?? throw new Exception("Could not find file!"));
                }

                case 1:
                {
                    byte[] ascii = Encoding.ASCII.GetBytes(File.ReadAllText(filename ?? throw new Exception("Could not find file!")));
                    return ascii;
                }

                case 2:
                {
                    return Encoding.UTF8.GetBytes(File.ReadAllText(filename ?? throw new Exception("Could not find file!")));
                }
            }
        } catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new byte[5];
    }

    public static string BuildNameLine(int boxlen, string name, string firststr)
    {
        string combined = firststr + name;
        if(combined.Length >= boxlen)
        {
            combined = combined.Remove(boxlen - 5);
            combined = combined + "...";
        }

        int whitespace = boxlen - combined.Length;
        
        for(int i = 0; i < whitespace - 1; i++)
        {
            combined = combined + " ";
        }

        return combined + "║"; 
    }
}