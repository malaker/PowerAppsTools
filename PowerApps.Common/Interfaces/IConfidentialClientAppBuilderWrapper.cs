namespace Malaker.PowerAppsTools.Common.Interfaces
{
    using System.Security.Cryptography.X509Certificates;

    public interface IConfidentialClientAppBuilderWrapper
    {
        IConfidentialClientAppBuilderWrapper Create(string clientId);
        IConfidentialClientAppBuilderWrapper WithClientSecret(string clientSecret);
        IConfidentialClientAppBuilderWrapper WithCertificate(X509Certificate2 certificate);
        IConfidentialClientAppBuilderWrapper WithRedirectUri(string redirectUri);
        IConfidentialClientAppBuilderWrapper WithTenantId(string tenantId);
        IConfidentialClientApplicationWrapper Build();
    }
}
