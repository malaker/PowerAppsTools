using System.Net.Http;

namespace Malaker.PowerAppsTools.Common.Exceptions
{
    public class ApiCallFailedException : ApplicationException
    {
        public HttpResponseMessage HttpResponseMessage { get; }
        public ApiCallFailedException(string message, HttpResponseMessage httpResponseMessage) : base(message)
        {
            this.HttpResponseMessage = httpResponseMessage;
        }
    }
}