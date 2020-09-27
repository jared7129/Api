using System.Collections.Generic;
using Api.Entities.Places.Common;
using Newtonsoft.Json;

namespace Api.Entities.Places.QueryAutoComplete.Response
{

    public class PlacesQueryAutoCompleteResponse : BasePlacesResponse
    {
        [JsonProperty("predictions")]
        public virtual IEnumerable<Prediction> Predictions { get; set; }
    }
}