using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient
{
    using Common.Interfaces;
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
            HttpResponseMessage response = await this.ExecuteAsync(request, cancellationToken);
            return _jsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}