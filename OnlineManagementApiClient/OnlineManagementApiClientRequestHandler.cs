using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient
{
    using Common.Interfaces;
    using Malaker.PowerAppsTools.Common.Exceptions;
    using Requests;

    public abstract class OnlineManagementApiClientRequestHandler<TRequest, TResponse>
    : Client, IRequestHandler<TRequest, TResponse>
    where TRequest : OnlineManagementApiRequest<TResponse>
    {
        public OnlineManagementApiClientRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }

        public async virtual Task<TResponse> SendAsync(TRequest request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await this.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
            return _jsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }

    public abstract class OnlineManagementApiClientWithOperationStatusRequestHandler<TRequest, OperationStatus>
    : OnlineManagementApiClientRequestHandler<TRequest, OperationStatus>
    where TRequest : OnlineManagementApiRequest<OperationStatus>
    {
        public OnlineManagementApiClientWithOperationStatusRequestHandler(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {
        }

        public override async Task<OperationStatus> SendAsync(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (ApiCallFailedException ex)
            {
                string content = await ex.HttpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return this._jsonSerializer.Deserialize<OperationStatus>(content);
            }
        }
    }
}