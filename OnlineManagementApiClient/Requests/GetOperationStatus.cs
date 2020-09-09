using System.Net.Http;
namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Requests
{

    using Models;

    public class GetOperationStatus : OnlineManagementApiRequest<OperationStatus>
    {
        public GetOperationStatus(string operationId)
        {
            this.OperationId = operationId;
        }

        public string OperationId { get; }
        public override HttpMethod Method => HttpMethod.Get;

        public override string RequestUri => $"Operation/{this.OperationId}";
    }
}