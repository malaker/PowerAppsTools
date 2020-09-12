using System.Collections.Generic;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Models;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers;
using Malaker.PowerAppsTools.OnlineManagementApiClient.Requests;

namespace Tests.RequestHandlers
{
    public class GetCurrenciesRequestHandlerTests : RequestHandlerTests<GetCurrenciesRequestHandler, GetCurrencies, IEnumerable<CurrencyResponse>>
    {

    }
}