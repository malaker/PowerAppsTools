namespace Malaker.PowerAppsTools.Common.Exceptions
{
    public class ApiCallFailedException : ApplicationException
    {
        public ApiCallFailedException(string message):base(message)
        {
        }
    }
}