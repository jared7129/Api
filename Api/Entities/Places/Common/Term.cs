using Newtonsoft.Json;

namespace Api.Entities.Places.Common
{
    public class Term
    {

        [JsonProperty("value")]
        public virtual string Value { get; set; }

        [JsonProperty("offset")]
        public virtual string Offset { get; set; }
    }
}