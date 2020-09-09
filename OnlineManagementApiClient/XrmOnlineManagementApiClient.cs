using System.Net.Http;
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

        public async Task<IEnumerable<Instance>> GetInstances(CancellationToken cancellationToken)
        {
            var response = await this._handlers.OfType<IRequestHandler<GetInstances, List<Instance>>>().FirstOrDefault().SendAsync(new GetInstances(), cancellationToken);
            return response;
        }
    }
}