using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{
    using Models;
    using Common.Interfaces;
    using System.Net.Http;

    public class GetInstances : OnlineManagementApiRequest<List<Instance>>
    {
        public override HttpMethod Method => HttpMethod.Get;

        public override string RequestUri => $"Instances";
    }
}