using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient
{
    using Interfaces;
    using Common.Interfaces;
    using Requests;
    using Models;
    using System.Threading;

    public class XrmOnlineManagementApiClient : IXrmOnlineManagementApiClient
    {
        private IEnumerable<IPowerAppRequestHandler> _handlers;

        public XrmOnlineManagementApiClient(IEnumerable<IPowerAppRequestHandler> handlers)
        {
            this._handlers = handlers;
        }

        public async Task<OperationStatus> BackupInstance(BackupInstanceRequest request, CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<BackupInstanceRequest, OperationStatus>>().FirstOrDefault().SendAsync(request, cancellationToken);
            return response;
        }

        public async Task<OperationStatus> CopyEnvironment(CopyRequest request, CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<CopyRequest, OperationStatus>>().FirstOrDefault().SendAsync(request, cancellationToken);
            return response;
        }

        public async Task<List<CurrencyResponse>> GetCurrencies(CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<GetCurrencies, List<CurrencyResponse>>>().FirstOrDefault().SendAsync(new GetCurrencies(), cancellationToken);
            return response;
        }

        public async Task<GetInstanceBackupsResponse> GetInstanceBackups(GetInstanceBackups request, CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<GetInstanceBackups, GetInstanceBackupsResponse>>().FirstOrDefault().SendAsync(request, cancellationToken);
            return response;
        }

        public async Task<IEnumerable<Instance>> GetInstances(CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<GetInstances, List<Instance>>>().FirstOrDefault().SendAsync(new GetInstances(), cancellationToken);
            return response;
        }

        public async Task<OperationStatus> GetOperationStatus(string operationId, CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<GetOperationStatus, OperationStatus>>().FirstOrDefault().SendAsync(new GetOperationStatus(operationId), cancellationToken);
            return response;
        }

        public async Task<OperationStatus> ResetInstance(ResetInstanceRequest request, CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<ResetInstanceRequest, OperationStatus>>().FirstOrDefault().SendAsync(request, cancellationToken);
            return response;
        }

        public async Task<OperationStatus> RestoreInstance(RestoreInstanceRequest request, CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<RestoreInstanceRequest, OperationStatus>>().FirstOrDefault().SendAsync(request, cancellationToken);
            return response;
        }
    }
}