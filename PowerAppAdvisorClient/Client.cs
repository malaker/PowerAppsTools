namespace Malaker.PowerAppsTools.PowerAppAdvisorClient
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Malaker.PowerAppsTools.Common;
    using Malaker.PowerAppsTools.PowerAppAdvisorClient.Exceptions;
    using Malaker.PowerAppsTools.PowerAppAdvisorClient.Models;
    using Microsoft.Identity.Client;

    public class Client
    {
        
        HttpClient _httpCLient;

        protected Client()
        {
        }
        /// <summary>
        /// httpClient has to implement oauth
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="httpCLient"></param>
        public Client(HttpClient httpCLient)
        {
            _httpCLient = httpCLient;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(PowerAppAdivsorMessage message, CancellationToken cancellationToken)
        {
            var response = await this._httpCLient.SendAsync(message.GetHttpMessageRequest(), cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                string content = await response?.Content.ReadAsStringAsync() ?? string.Empty;

                throw new ApiCallFailedException($"{(int)response.StatusCode}-{response.StatusCode.ToString()} - content - {content}");
            }
            
            return response;
        }
    }
}
