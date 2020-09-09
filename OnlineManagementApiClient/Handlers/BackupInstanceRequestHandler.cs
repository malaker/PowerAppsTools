using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Models;
    using Requests;

    public class BackupInstanceRequestHandler : OnlineManagementApiClientWithOperationStatusRequestHandler<BackupInstanceRequest, OperationStatus>
    {
        public BackupInstanceRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}