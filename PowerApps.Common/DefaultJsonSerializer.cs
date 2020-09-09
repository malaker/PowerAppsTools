namespace Malaker.PowerAppsTools.Common
{
    using Interfaces;
    public class DefaultJsonSerializer : JsonSerializer
    {
        public override object Deserialize(string content)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(content);
        }

        public override T Deserialize<T>(string content)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }

        public override string Serialize(object @object)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(@object);
        }
    }
}