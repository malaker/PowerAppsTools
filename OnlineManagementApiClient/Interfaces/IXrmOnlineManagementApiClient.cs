using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Interfaces
{
    using System.Threading;
    using Requests;
    using Models;
    public interface IXrmOnlineManagementApiClient
    {
        Task<IEnumerable<Instance>> GetInstances(CancellationToken cancellationToken);

        Task<IEnumerable<CurrencyResponse>> GetCurrencies(CancellationToken cancellationToken);

        Task<OperationStatus> CopyEnvironment(CopyRequest request, CancellationToken cancellationToken);

        Task<OperationStatus> GetOperationStatus(string operationId, CancellationToken cancellationToken);

        Task<OperationStatus> ResetInstance(ResetInstanceRequest request, CancellationToken cancellationToken);

        Task<OperationStatus> BackupInstance(BackupInstanceRequest request, CancellationToken cancellationToken);

        Task<OperationStatus> RestoreInstance(RestoreInstanceRequest request, CancellationToken cancellationToken);

        Task<GetInstanceBackupsResponse> GetInstanceBackups(GetInstanceBackups request, CancellationToken cancellationToken);
    }
}