using System.Security.Cryptography.X509Certificates;

namespace Malaker.PowerAppsTools.Powershell.Cmdlets
{
    public class OAuthCredentials
    {
        public string Secret { get; set; }

        public X509Certificate2 Certificate { get; set; }
    }
}
