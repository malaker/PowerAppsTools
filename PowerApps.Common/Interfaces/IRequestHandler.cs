using System.Threading;
using System.Threading.Tasks;

namespace Malaker.PowerAppsTools.Common.Interfaces
{
    public interface IPowerAppRequestHandler {
    }

    public interface IRequestHandler<TRequest,TResponse> : IPowerAppRequestHandler
    where TRequest : PowerAppRequest<TResponse>
    {
        Task<TResponse> SendAsync(TRequest request, CancellationToken cancellationToken);
    }
}
