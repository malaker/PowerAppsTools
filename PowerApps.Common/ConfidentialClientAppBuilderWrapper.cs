namespace Malaker.PowerAppsTools.Common
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using Malaker.PowerAppsTools.Common.Interfaces;
    using Microsoft.Identity.Client;

    public class ConfidentialClientAppBuilderWrapper : IConfidentialClientAppBuilderWrapper
    {
        public ConfidentialClientAppBuilderWrapper(ITokenBuilder tokenBuilder)
        {
            this._tokenBuilder = tokenBuilder;
        }
        private ConfidentialClientApplicationBuilder _builder;
        private ITokenBuilder _tokenBuilder;

        public IConfidentialClientApplicationWrapper Build()
        {
            if (this._builder == null)
            {
                throw new ArgumentNullException("ConfidentialClientApplicationBuilder not initialized use Create method in the first place");
            }
            return new ConfidentialClientApplicationWrapper(this._builder.Build(), this._tokenBuilder);
        }

        public IConfidentialClientAppBuilderWrapper Create(string clientId)
        {
            this._builder = ConfidentialClientApplicationBuilder.Create(clientId);
            return this;
        }

        public IConfidentialClientAppBuilderWrapper WithCertificate(X509Certificate2 certificate)
        {
            this._builder?.WithCertificate(certificate);
            return this;
        }

        public IConfidentialClientAppBuilderWrapper WithClientSecret(string clientSecret)
        {
            this._builder?.WithClientSecret(clientSecret);
            return this;
        }

        public IConfidentialClientAppBuilderWrapper WithRedirectUri(string redirectUri)
        {
            this._builder?.WithRedirectUri(redirectUri);
            return this;
        }

        public IConfidentialClientAppBuilderWrapper WithTenantId(string tenantId)
        {
            this._builder?.WithTenantId(tenantId);
            return this;
        }
    }
}
