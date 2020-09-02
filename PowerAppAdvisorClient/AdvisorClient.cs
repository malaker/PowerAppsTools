namespace Malaker.PowerAppsTools.PowerAppAdvisorClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.Common.Interfaces;
    using Malaker.PowerAppsTools.PowerAppAdvisorClient.Models;

    public class AdvisorClient : Client, IPowerAppAdvisorClient
    {
        public AdvisorClient(HttpClient httpCLient) : base(httpCLient)
        {
        }

        public async Task<CheckAnalysisResponse> CheckAnalysis(string tenantId, Guid correlationId, CancellationToken cancellationToken)
        {
            var req = new CheckAnalysisStatus(tenantId, correlationId);

            var response = await this.ExecuteAsync(req, cancellationToken);

            string respnseMsg = await response.Content.ReadAsStringAsync();

            var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<CheckAnalysisResponse>(respnseMsg);

            return resp;
        }

        public async Task<InvokeAnalysisResponse> InvokeAnalysis(UploadMessageResponse uploadMessageResponse, CancellationToken cancellationToken)
        {
            var req = new InvokeAnalysis(uploadMessageResponse.SasUriList, uploadMessageResponse.TenantId, uploadMessageResponse.CorrelationId);

            var response = await this.ExecuteAsync(req, cancellationToken);

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

        public async Task<UploadMessageResponse> UploadSolution(byte[] managedSolution, string solution, string tenantId, Guid corrId, CancellationToken cancellationToken)
        {
            var req = new UploadMessage(managedSolution, solution, tenantId, corrId);

            var response = await this.ExecuteAsync(req, cancellationToken);

            string respnseMsg = await response.Content.ReadAsStringAsync();

            var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(respnseMsg);

            return new UploadMessageResponse(resp, tenantId, corrId);
        }
    }
}
