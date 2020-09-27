using Newtonsoft.Json;

namespace Api.Entities.Places.Common
{

    public class MatchedSubstring
    {

        [JsonProperty("offset")]
        public virtual string Offset { get; set; }

        [JsonProperty("length")]
        public virtual string Length { get; set; }
    }
}