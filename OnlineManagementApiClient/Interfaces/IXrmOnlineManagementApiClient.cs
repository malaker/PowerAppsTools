using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Interfaces
{
    using System.Threading;
    using Models;
    public interface IXrmOnlineManagementApiClient
    {
        Task<IEnumerable<Instance>> GetInstances(CancellationToken cancellationToken);
    }
}