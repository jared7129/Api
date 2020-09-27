using Newtonsoft.Json;

namespace Api.Entities.Places.Search.Common
{

    public class OpeningHours
    {
        [JsonProperty("OpenNow")]
        public virtual bool OpenNow { get; set; }
    }
}