namespace Malaker.PowerAppsTools.Common
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.Common.Interfaces;
    using Microsoft.Identity.Client;

    public class OAuthMessageHandler : DelegatingHandler
    {
        IConfidentialClientApplicationWrapper _app;
        IEnumerable<string> _scopes;
        AuthenticationResult _authResult = null;

        public OAuthMessageHandler(IConfidentialClientApplicationWrapper app, IEnumerable<string> scopes)
        {
            this._app = app;
            this._scopes = scopes;
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_authResult == null)
            {
                var token = _app.AcquireTokenForClient(_scopes);

                _authResult = await token.ExecuteAsync().ConfigureAwait(false);
            }

            if (_authResult.ExpiresOn < DateTimeOffset.UtcNow)
            {
                var token = _app.AcquireTokenForClient(_scopes);
                
                _authResult = await token.ExecuteAsync().ConfigureAwait(false);
            }
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authResult.AccessToken);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
