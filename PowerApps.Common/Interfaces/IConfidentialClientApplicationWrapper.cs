namespace Malaker.PowerAppsTools.Common.Interfaces
{
    using System;
    using System.Collections.Generic;


    public interface IConfidentialClientApplicationWrapper
    {
        ITokenBuilder AcquireTokenForClient(IEnumerable<string> scopes);
    }
}
