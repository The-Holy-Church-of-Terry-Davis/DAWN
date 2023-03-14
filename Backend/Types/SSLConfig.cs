using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

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

    public static X509Certificate2 CreateSelfSigned()
    {
        ECDsa ecdsa = ECDsa.Create(); // generate asymmetric key pair
        CertificateRequest req = new CertificateRequest("cn=foobar", ecdsa, HashAlgorithmName.SHA256);
        X509Certificate2 cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));

        return cert;
    }
}