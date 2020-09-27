using Newtonsoft.Json;

namespace Api.Entities.Places.Details.Response
{
    public class DayTime
    {
        [JsonProperty("day")]
        public virtual int Day { get; set; }

        [JsonProperty("time")]
        public virtual string Time { get; set; }
    }
}