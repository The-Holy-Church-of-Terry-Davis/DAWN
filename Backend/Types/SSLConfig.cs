using System.Security.Cryptography.X509Certificates;

namespace Dawn.Types;

public class SSLConfig
{
    public string filename { get; set; }

    public SSLConfig(string fname)
    {
        filename = fname;
    }

    public X509Certificate2 ResolveCert()
    {
        X509Certificate2 cert = new X509Certificate2(filename);
        return cert;
    }
}