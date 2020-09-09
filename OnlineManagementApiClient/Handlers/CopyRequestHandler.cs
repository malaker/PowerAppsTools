using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Models;
    using Requests;


    public class CopyRequestHandler : OnlineManagementApiClientWithOperationStatusRequestHandler<CopyRequest, OperationStatus>
    {
        public CopyRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}