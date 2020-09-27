using System.Collections.Generic;
using Api.Entities.Common;
using Api.Entities.Common.Converters;
using Api.Entities.Common.Enums;
using Api.Entities.Places.Common;
using Api.Entities.Places.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Entities.Places.Details.Response
{

    public class DetailsResult
    {
        [JsonProperty("address_components")]
        public virtual IEnumerable<AddressComponent> AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        public virtual string FormattedAddress { get; set; }

        [JsonProperty("formatted_phone_number")]
        public virtual string FormattedPhoneNumber { get; set; }

        [JsonProperty("adr_address")]
        public virtual string AdrAddress { get; set; }

        [JsonProperty("geometry")]
        public virtual Geometry Geometry { get; set; }

        [JsonProperty("icon")]
        public virtual string Icon { get; set; }

        [JsonProperty("international_phone_number")]
        public virtual string InternationalPhoneNumber { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }


        [JsonProperty("opening_hours")]
        public virtual OpeningHours OpeningHours { get; set; }


        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        [JsonProperty("photos")]
        public virtual IEnumerable<Photo> Photos { get; set; }


        [JsonProperty("price_level")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual PriceLevel PriceLevel { get; set; }


        [JsonProperty("business_status")]
        public virtual BusinessStatus BusinessStatus { get; set; }


        [JsonProperty("rating")]
        public virtual double Rating { get; set; }


        [JsonProperty("user_ratings_total")]
        public virtual int UserRatingsTotal { get; set; }

        [JsonProperty("reviews")]
        public virtual IEnumerable<Review> Review { get; set; }

        [JsonProperty("types", ItemConverterType = typeof(StringEnumOrDefaultConverter<PlaceLocationType>))]
        public virtual IEnumerable<PlaceLocationType> Types { get; set; }

        [JsonProperty("url")]
        public virtual string Url { get; set; }

        [JsonProperty("vicinity")]
        public virtual string Vicinity { get; set; }

        [JsonProperty("utc_offset")]
        public virtual int UtcOffset { get; set; }

        [JsonProperty("website")]
        public virtual string Website { get; set; }
    }
}