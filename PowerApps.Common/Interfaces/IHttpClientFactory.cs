namespace Malaker.PowerAppsTools.Common.Interfaces
{
    using System;
    using System.Net.Http;

    public interface IHttpClientFactory
    {
        HttpClient Create(DelegatingHandler handler);
    }
}
