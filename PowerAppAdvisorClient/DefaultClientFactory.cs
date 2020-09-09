namespace Malaker.PowerAppsTools.PowerAppAdvisorClient
{
    using System;
    using Malaker.PowerAppsTools.Common;
    using Malaker.PowerAppsTools.Common.Interfaces;

    public class DefaultClientFactory
    {
        public static DefaultClientFactory Instance = new DefaultClientFactory(new ConfidentialClientAppBuilderWrapper(new TokenBuilder()));
        private IConfidentialClientAppBuilderWrapper _builder;

        protected DefaultClientFactory(IConfidentialClientAppBuilderWrapper builder)
        {
            this._builder = builder;
        }

        public IPowerAppAdvisorClient Create(ClientSettings clientSettings)
        {
            _builder.Create(clientSettings.ClientId);

            if (!string.IsNullOrEmpty(clientSettings.Secret) && clientSettings.Certificate == null)
            {
                _builder.WithClientSecret(clientSettings.Secret);

            }
            else if (string.IsNullOrEmpty(clientSettings.Secret) && clientSettings.Certificate != null)
            {
                _builder.WithCertificate(clientSettings.Certificate);
            }

            _builder.WithRedirectUri(clientSettings.RedirectUri).WithTenantId(clientSettings.TenantId);
            var app = _builder.Build();
            var httpClient = new HttpClientFactory().Create(new OAuthMessageHandler(app, clientSettings.Scopes));
            httpClient.BaseAddress = new Uri(clientSettings.BaseAddress);

            return new AdvisorClient(httpClient, new DefaultJsonSerializer());
        }
    }
}
