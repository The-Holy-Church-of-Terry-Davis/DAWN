using CSL.Encryption;

namespace Dawn.Authentication;

internal static class KeyGenerators
{   
    private static string StringKey()
    {
        return RandomVars.String(100);
    }

    internal static byte[] GenerateAuthBearerKey()
    {
        byte[] ret = RandomVars.ByteArray(200);
        string gen = StringKey();

        for(int i = 0; i < 200; i++)
        {
            if(i % 2 == 0)
            {
                ret[i] = (byte)gen[i];
            }
        }

        return ret;
    }
}