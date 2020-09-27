using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Entities.Places.Details.Response
{

    public class Aspect
    {

        [JsonProperty("aspects")]
        public virtual IEnumerable<AspectRating> AspectRatings { get; set; }
    }
}