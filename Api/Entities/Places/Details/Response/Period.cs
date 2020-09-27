using Newtonsoft.Json;

namespace Api.Entities.Places.Details.Response
{
    public class Period
    {

        [JsonProperty("open")]
        public virtual DayTime Open { get; set; }

        [JsonProperty("close")]
        public virtual DayTime Close { get; set; }
    }
}