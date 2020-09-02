namespace Malaker.PowerAppsTools.PowerAppAdvisorClient
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Malaker.PowerAppsTools.PowerAppAdvisorClient.Models;

    public interface IPowerAppAdvisorClient
    {
        Task<UploadMessageResponse> UploadSolution(byte[] managedSolution, string solution, string tenantId, Guid corrId, CancellationToken cancellationToken);

        Task<InvokeAnalysisResponse> InvokeAnalysis(UploadMessageResponse uploadMessageResponse, CancellationToken cancellationToken);

        Task<CheckAnalysisResponse> CheckAnalysis(string tenantId, Guid correlationId, CancellationToken cancellationToken);
    }
}
