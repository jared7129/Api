using System.Collections.Generic;
using Api.Entities.Common.Converters;
using Api.Entities.Common.Enums;
using Newtonsoft.Json;

namespace Api.Entities.Places.Common
{
    public class Prediction
    {
        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        [JsonProperty("description")]
        public virtual string Description { get; set; }


        [JsonProperty("structured_formatting")]
        public virtual StructuredFormatting StructuredFormatting { get; set; }

        [JsonProperty("terms")]
        public virtual IEnumerable<Term> Terms { get; set; }
     
        [JsonProperty("types", ItemConverterType = typeof(StringEnumOrDefaultConverter<PlaceLocationType>))]
        public virtual IEnumerable<PlaceLocationType> Types { get; set; }

        [JsonProperty("matched_substrings")]
        public virtual IEnumerable<MatchedSubstring> MatchedSubstrings { get; set; }
    }
}