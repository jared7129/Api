using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Entities.Places.Search.Text.Response
{

    public class PlacesTextSearchResponse : BasePlacesResponse
    {

        [JsonProperty("results")]
        public virtual IEnumerable<TextResult> Results { get; set; }


        [JsonProperty("next_page_token")]
        public virtual string NextPageToken { get; set; }
    }
}