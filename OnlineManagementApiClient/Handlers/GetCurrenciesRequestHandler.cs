using System.Net.Http;
using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Requests;
    using Models;

    public class GetCurrenciesRequestHandler : OnlineManagementApiClientRequestHandler<GetCurrencies, List<CurrencyResponse>>
    {
        public GetCurrenciesRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}