namespace Malaker.PowerAppsTools.Common.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.Identity.Client;

    public interface ITokenBuilder
    {
        Task<AuthenticationResult> ExecuteAsync();
        void Set(AbstractConfidentialClientAcquireTokenParameterBuilder<AcquireTokenForClientParameterBuilder> acquireTokenForClientParameterBuilder);
    }
}
