using System.Collections.Generic;
using Api.Entities.Common;
using Api.Entities.Common.Enums;
using Api.Entities.Places.Common;
using Api.Entities.Places.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Entities.Places.Search.Find.Response
{

    public class Candidate
    {

        [JsonProperty("name")]
        public virtual string Name { get; set; }


        [JsonProperty("icon")]
        public virtual string Icon { get; set; }


        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        [JsonProperty("formatted_address")]
        public virtual string FormattedAddress { get; set; }


        [JsonProperty("geometry")]
        public virtual Geometry Geometry { get; set; }


        [JsonProperty("opening_hours")]
        public virtual OpeningHours OpeningHours { get; set; }


        [JsonProperty("plus_code")]
        public virtual PlusCode PlusCode { get; set; }


        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Scope Scope { get; set; }


        [JsonProperty("business_status")]
        public virtual BusinessStatus BusinessStatus { get; set; }


        [JsonProperty("rating")]
        public virtual double Rating { get; set; }


        [JsonProperty("user_ratings_total")]
        public virtual int UserRatingsTotal { get; set; }


        [JsonProperty("photos")]
        public virtual IEnumerable<Photo> Photos { get; set; }
    }
}