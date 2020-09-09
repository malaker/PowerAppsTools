using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Models;
    using Requests;

    public class GetOperationStatusRequestHandler : OnlineManagementApiClientWithOperationStatusRequestHandler<CopyRequest, OperationStatus>
    {
        public GetOperationStatusRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}