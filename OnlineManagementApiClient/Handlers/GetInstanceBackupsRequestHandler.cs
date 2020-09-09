using System.Net.Http;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Handlers
{
    using Common.Interfaces;
    using Requests;
    using Models;

    public class GetInstanceBackupsRequestHandler : OnlineManagementApiClientRequestHandler<GetInstanceBackups, GetInstanceBackupsResponse>
    {
        public GetInstanceBackupsRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }
    }
}