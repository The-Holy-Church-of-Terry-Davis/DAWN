using CSL.Encryption;

namespace Dawn.Authentication;

internal static class KeyGenerators
{   
    internal static byte[] GenerateAuthBearerKey()
    {
        return System.Text.Encoding.UTF8.GetBytes(RandomVars.String(200));
    }
}