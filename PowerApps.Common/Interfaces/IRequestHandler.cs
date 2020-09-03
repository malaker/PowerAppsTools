using System.Threading;
using System.Threading.Tasks;

namespace Malaker.PowerAppsTools.Common.Interfaces
{
    public interface IRequestHandler<TRequest,TResponse> where TRequest : PowerAppRequest<TResponse>
    {
        Task<TResponse> SendAsync(TRequest request, CancellationToken cancellationToken);
    }


}
