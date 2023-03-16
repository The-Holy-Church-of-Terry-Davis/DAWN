using CSL.Encryption;

namespace Dawn.Authentication;

/*
    This classes funcitonality
    is not yet implemented!
*/

internal static class KeyGenerators
{   
    internal static byte[] GenerateAuthBearerKey()
    {
        return System.Text.Encoding.UTF8.GetBytes(RandomVars.String(200));
    }
}