namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;

    public class PowerAppsAdvisorResponse
    {
        public PowerAppsAdvisorResponse(string tenantId, Guid correlationId)
        {
            this.TenantId = tenantId;
            this.CorrelationId = correlationId;
        }

        public string TenantId { get; }

        public Guid CorrelationId { get; }
    }
}
