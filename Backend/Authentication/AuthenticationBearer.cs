using CSL.Encryption;

namespace Dawn.Authentication;

/*
    This classes funcitonality
    is not yet implemented!
*/

public interface IAuthenticationBearer
{
    public byte[]? Key { get; set; }
    public string IP { get; set; }
}

public class AuthenticationBearer : IAuthenticationBearer
{
    public byte[]? Key { get; set; }
    public string IP { get; set; }
    public bool IsAuthenticated { get; set; } //We need authenticated clients to be represented by an actual object instead of an interface

    internal AuthenticationBearer(byte[] k, string ip)
    {
        Key = k;
        IP = ip;
    }

    public static AuthenticationBearer FromIAuthenticationBearer(IAuthenticationBearer ifce)
    {
        if(ifce.Key is not null)
        {
            AuthenticationBearer ret = new(ifce.Key, ifce.IP);
            return ret;
        }

        throw new Exception("Key is null!");
    }
}