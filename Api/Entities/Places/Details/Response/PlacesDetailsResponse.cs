using Newtonsoft.Json;

namespace Api.Entities.Places.Details.Response
{

    public class PlacesDetailsResponse : BasePlacesResponse
    {

        [JsonProperty("result")]
        public virtual DetailsResult Result { get; set; }
    }
}