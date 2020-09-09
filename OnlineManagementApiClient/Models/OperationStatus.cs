using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Malaker.PowerAppsTools.OnlineManagementApiClient.Models
{
    public class OperationContext
    {
        [JsonProperty("items")]
        public Dictionary<string, object> Items { get; set; }
    }

    public class ItemDescription
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string Subject { get; set; }
    }

    public class OperationStatus
    {
        [JsonProperty("operationId")]
        public Guid OperationId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public string ResourceLocation { get; set; }

        public string OperationLocation { get; set; }

        [JsonProperty("information")]
        public List<ItemDescription> Information { get; set; }

        [JsonProperty("errors")]
        public List<ItemDescription> Errors { get; set; }
    }
}