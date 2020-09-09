using System;

namespace Malaker.PowerAppsTools.Common.Interfaces
{
    public abstract class JsonSerializer
    {
        public abstract string Serialize(object content);
        public abstract object Deserialize(string content);

        public virtual T Deserialize<T>(string content)
        {
            return (T)Deserialize(content);
        }
    }
}