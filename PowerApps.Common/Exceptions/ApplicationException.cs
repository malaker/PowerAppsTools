namespace Malaker.PowerAppsTools.Common.Exceptions
{
    using System;

    public class ApplicationException : Exception
    {
        public ApplicationException(string message):base(message)
        {
        }
    }
}