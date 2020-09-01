namespace Malaker.PowerAppsTools.Common
{
    using System.Collections.Generic;
    using Malaker.PowerAppsTools.Common.Interfaces;
    using Microsoft.Identity.Client;

    public class ConfidentialClientApplicationWrapper : IConfidentialClientApplicationWrapper
    {
        IConfidentialClientApplication _app;
        ITokenBuilder _builder;
        public ConfidentialClientApplicationWrapper(IConfidentialClientApplication app, ITokenBuilder builder)
        {
            this._app = app;
            this._builder = builder;
        }

        public ITokenBuilder AcquireTokenForClient(IEnumerable<string> scopes)
        {
            _builder.Set(_app.AcquireTokenForClient(scopes));
            return _builder;
        }
    }
}
