using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Models;
    using Requests;

    public class ResetInstanceRequestHandler : OnlineManagementApiClientWithOperationStatusRequestHandler<ResetInstanceRequest, OperationStatus>
    {
        public ResetInstanceRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}