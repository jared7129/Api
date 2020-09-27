using System.Collections.Generic;
using Api.Entities.Places.Common;
using Newtonsoft.Json;

namespace Api.Entities.Places.AutoComplete.Response
{

    public class PlacesAutoCompleteResponse : BasePlacesResponse
    {
        [JsonProperty("predictions")]
        public virtual IEnumerable<Prediction> Predictions { get; set; }
    }
}