namespace Malaker.PowerAppsTools.PowerAppAdvisorClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.PowerAppAdvisorClient.Models;

    public static class ClientExtensions
    {
        public static async Task<UploadMessageResponse> UploadSolution(this Client client, byte[] managedSolution, string solution, string tenantId, Guid corrId, CancellationToken cancellationToken)
        {
            var req = new UploadMessage(managedSolution, solution, tenantId, corrId);

            var response = await client.ExecuteAsync(req, cancellationToken);

            string respnseMsg = await response.Content.ReadAsStringAsync();

            var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(respnseMsg);

            return new UploadMessageResponse(resp, tenantId, corrId);
        }

        public static async Task<InvokeAnalysisResponse> InvokeAnalysis(this Client client, UploadMessageResponse uploadMessageResponse, CancellationToken cancellationToken)
        {
            var req = new InvokeAnalysis(uploadMessageResponse.SasUriList, uploadMessageResponse.TenantId, uploadMessageResponse.CorrelationId);

            var response = await client.ExecuteAsync(req, cancellationToken);

            string respnseMsg = await response.Content.ReadAsStringAsync();

            if (response.Headers.TryGetValues("Location", out IEnumerable<string> locations))
            {
                var resp = new InvokeAnalysisResponse() { Location = locations.ToArray() };
                return resp;
            }
            else
            {
                return new InvokeAnalysisResponse();
            }
        }

        public static async Task<CheckAnalysisResponse> CheckAnalysis(this Client client, string tenantId, Guid correlationId, CancellationToken cancellationToken)
        {
            var req = new CheckAnalysisStatus(tenantId, correlationId);

            var response = await client.ExecuteAsync(req, cancellationToken);

            string respnseMsg = await response.Content.ReadAsStringAsync();

            var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<CheckAnalysisResponse>(respnseMsg);

            return resp;
        }
    }
}
