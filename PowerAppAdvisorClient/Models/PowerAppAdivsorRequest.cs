namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using Malaker.PowerAppsTools.Common.Interfaces;

    public abstract class PowerAppAdivsorRequest : PowerAppRequest
    {
        protected string _tenantId;
        protected Guid _correlationId;

        public PowerAppAdivsorRequest(string tenantId, Guid correlationId)
        {
            this._tenantId = tenantId;
            this._correlationId = correlationId;
            this.Headers.Add("x-ms-tenant-id", tenantId);
            this.Headers.Add("x-ms-correlation-id", _correlationId.ToString());
        }
    }
}
