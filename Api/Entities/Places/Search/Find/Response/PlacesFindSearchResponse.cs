using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Entities.Places.Search.Find.Response
{

    public class PlacesFindSearchResponse : BasePlacesResponse
    {

        [JsonProperty("candidates")]
        public virtual IEnumerable<Candidate> Candidates { get; set; }
    }
}