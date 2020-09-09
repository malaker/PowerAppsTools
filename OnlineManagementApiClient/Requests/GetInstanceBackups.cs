using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{
    using System.Net.Http;
    using Models;

    public class GetInstanceBackups : OnlineManagementApiRequest<GetInstanceBackupsResponse>
    {
        public GetInstanceBackups(string targetInstance)
        {
            this.TargetInstance = targetInstance;
        }
        public string TargetInstance { get; }
        public override HttpMethod Method => HttpMethod.Get;

        public override string RequestUri => $"Instances/{TargetInstance}/Backups";
    }
}