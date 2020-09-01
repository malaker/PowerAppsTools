namespace Malaker.PowerAppsTools.Common
{
    using System;
    using System.Net.Http;
    using Common.Interfaces;

    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClientFactory()
        {
        }

        public HttpClient Create(DelegatingHandler handler)
        {
            return new HttpClient(handler);
        }
    }
}
