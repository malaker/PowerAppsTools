using System.Net.Http;
using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{
    using Models;

    public class GetCurrencies : OnlineManagementApiRequest<IEnumerable<CurrencyResponse>>
    {
        public override HttpMethod Method => HttpMethod.Get;

        public override string RequestUri => $"Currencies";
    }
}