using System;
using System.Collections;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient
{
    using Interfaces;
    using Common;
    using Common.Interfaces;
    using Handlers;
    using System.Collections.Generic;

    public class DefaultOnlineManagementApiClientFactory
    {
        public static DefaultOnlineManagementApiClientFactory Instance = new DefaultOnlineManagementApiClientFactory(new ConfidentialClientAppBuilderWrapper(new TokenBuilder()));
        private IConfidentialClientAppBuilderWrapper _builder;

        protected DefaultOnlineManagementApiClientFactory(IConfidentialClientAppBuilderWrapper builder)
        {
            this._builder = builder;
        }

        public IXrmOnlineManagementApiClient Create(XrmClientSettings clientSettings)
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
            httpClient.BaseAddress = new Uri($"{clientSettings.BaseAddress}/api/v{clientSettings.ApiVersion}/");

            return new XrmOnlineManagementApiClient(new List<IPowerAppRequestHandler>()
            {
                new GetInstancesRequestHandler(httpClient, new DefaultJsonSerializer())
            });
        }
    }
}