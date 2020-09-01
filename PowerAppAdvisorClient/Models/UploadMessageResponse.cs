namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;

    public class UploadMessageResponse : PowerAppsAdvisorResponse
    {
        public UploadMessageResponse(string[] sasUriList, string tenantId, Guid corrId) : base(tenantId, corrId)
        {
            this.SasUriList = sasUriList;
        }

        public string[] SasUriList { get; }
    }
}
