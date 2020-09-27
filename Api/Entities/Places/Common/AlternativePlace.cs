using Api.Entities.Places.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Entities.Places.Common
{

    public class AlternativePlace
    {
        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Scope Scope { get; set; }
    }
}