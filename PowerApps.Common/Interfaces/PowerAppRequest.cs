using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Malaker.PowerAppsTools.Common.Interfaces
{
    public abstract class PowerAppRequest
    {
        [JsonIgnore()]
        public abstract HttpMethod Method { get; }
        [JsonIgnore()]
        public abstract string RequestUri { get; }
        [JsonIgnore()]
        public Dictionary<string, string> Headers = new Dictionary<string, string>();


    }
    
    public abstract class PowerAppRequest<TResponse> : PowerAppRequest
    {
    }
}
