namespace Malaker.PowerAppsTools.PowerAppAdvisorClient.Models
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using Malaker.PowerAppsTools.Common.Interfaces;

    public abstract class PowerAppAdivsorMessage : PowerAppMessage
    {
        protected string _tenantId;
        protected Guid _correlationId;

        public PowerAppAdivsorMessage(string tenantId, Guid correlationId)
        {
            this._tenantId = tenantId;
            this._correlationId = correlationId;
            this.Headers.Add("x-ms-tenant-id", tenantId);
            this.Headers.Add("x-ms-correlation-id", _correlationId.ToString());
        }

        public override HttpRequestMessage GetHttpMessageRequest()
        {
            var req = new HttpRequestMessage(this.Method, this.RequestUri);
            if (req.Method == HttpMethod.Post)
            {
                var content = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                req.Content = stringContent;
            }
            if (this.Headers.Any())
            {
                foreach (var header in this.Headers)
                {
                    req.Headers.Add(header.Key, header.Value);
                }
            }
            return req;
        }
    }
}
