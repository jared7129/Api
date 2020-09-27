using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Entities.Places.Search.NearBy.Response
{

    public class PlacesNearbySearchResponse : BasePlacesResponse
    {

        [JsonProperty("results")]
        public virtual IEnumerable<NearByResult> Results { get; set; }

        [JsonProperty("next_page_token")]
        public virtual string NextPageToken { get; set; }
    }
}