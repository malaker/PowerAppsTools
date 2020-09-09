namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;
    using System.IO;
    using System.Net.Http;

    public class UploadMessage : PowerAppAdivsorRequest
    {
        public UploadMessage(byte[] managedSolution, string solutionName, string tenantId, Guid correlationId) : base(tenantId, correlationId)
        {
            MultipartFormDataContent = new MultipartFormDataContent();
            MultipartFormDataContent.Add(new ByteArrayContent(managedSolution, 0, managedSolution.Length), $"{solutionName}", $"{solutionName}.zip");
        }

        public override HttpMethod Method => HttpMethod.Post;

        public override string RequestUri => "api/upload";

        public MultipartFormDataContent MultipartFormDataContent { get; set; }
    }
}
