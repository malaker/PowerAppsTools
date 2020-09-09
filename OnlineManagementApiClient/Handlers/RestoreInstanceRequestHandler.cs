using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Models;
    using Requests;

    public class RestoreInstanceRequestHandler : OnlineManagementApiClientWithOperationStatusRequestHandler<RestoreInstanceRequest, OperationStatus>
    {
        public RestoreInstanceRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}