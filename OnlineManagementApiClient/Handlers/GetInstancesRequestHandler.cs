using System.Net.Http;
using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Requests;
    using Models;

    public class GetInstancesRequestHandler : OnlineManagementApiClientRequestHandler<GetInstances, List<Instance>>
    {
        public GetInstancesRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}