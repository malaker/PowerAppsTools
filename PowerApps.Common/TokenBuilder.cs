namespace Malaker.PowerAppsTools.Common
{
    using System;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.Common.Interfaces;
    using Microsoft.Identity.Client;

    public class TokenBuilder : ITokenBuilder
    {
        private AbstractConfidentialClientAcquireTokenParameterBuilder<AcquireTokenForClientParameterBuilder> _builder;

        public Task<AuthenticationResult> ExecuteAsync()
        {
            return this._builder.ExecuteAsync();
        }

        public void Set(AbstractConfidentialClientAcquireTokenParameterBuilder<AcquireTokenForClientParameterBuilder> acquireTokenForClientParameterBuilder)
        {
            this._builder = acquireTokenForClientParameterBuilder;
        }
    }
}
