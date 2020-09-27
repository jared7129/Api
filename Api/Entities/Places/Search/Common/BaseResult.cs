using System.Collections.Generic;
using Api.Entities.Common;
using Api.Entities.Common.Converters;
using Api.Entities.Common.Enums;
using Api.Entities.Places.Common;
using Api.Entities.Places.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Entities.Places.Search.Common
{

    public abstract class BaseResult
    {        

        [JsonProperty("icon")]
        public virtual string IconUrl { get; set; }


        [JsonProperty("geometry")]
        public virtual Geometry Geometry { get; set; }


        [JsonProperty("name")]
        public virtual string Name { get; set; }


        [JsonProperty("opening_hours")]
        public virtual OpeningHours OpeningHours { get; set; }


        [JsonProperty("photos")]
        public virtual IEnumerable<Photo> Photos { get; set; }


        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }


        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Scope? Scope { get; set; } = Places.Common.Enums.Scope.Google;


        [JsonProperty("alt_ids")]
        public virtual IEnumerable<AlternativePlace> AlternativePlaceIds { get; set; }


        [JsonProperty("price_level")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PriceLevel? PriceLevel { get; set; }
        

        [JsonProperty("business_status")]
        public virtual BusinessStatus BusinessStatus { get; set; }


        [JsonProperty("rating")]
        public virtual double Rating { get; set; }


        [JsonProperty("user_ratings_total")]
        public virtual int UserRatingsTotal { get; set; }


        [JsonProperty("types", ItemConverterType = typeof(StringEnumOrDefaultConverter<PlaceLocationType>))]
        public virtual IEnumerable<PlaceLocationType?> Types { get; set; }
    }
}