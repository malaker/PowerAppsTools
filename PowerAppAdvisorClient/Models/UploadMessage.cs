namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;
    using System.IO;
    using System.Net.Http;

    public class UploadMessage : PowerAppAdivsorMessage
    {
        public UploadMessage(byte[] managedSolution, string solutionName, string tenantId, Guid correlationId) : base(tenantId, correlationId)
        {
            _form = new MultipartFormDataContent();
            _form.Add(new ByteArrayContent(managedSolution, 0, managedSolution.Length), $"{solutionName}", $"{solutionName}.zip");
        }

        public override HttpRequestMessage GetHttpMessageRequest()
        {
            var req = base.GetHttpMessageRequest();
            req.Content = _form;
            return req;
        }

        public override HttpMethod Method => HttpMethod.Post;

        public override string RequestUri => "api/upload";

        MultipartFormDataContent _form;
    }
}
