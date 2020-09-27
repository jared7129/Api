using System.Collections.Generic;
using Api.Entities.Places.Details.Response;
using Newtonsoft.Json;

namespace Api.Entities.Places.Common
{
    public class OpeningHours
    {
        [JsonProperty("open_now")]
        public virtual bool OpenNow { get; set; }

        [JsonProperty("periods")]
        public virtual IEnumerable<Period> Periods { get; set; }

        [JsonProperty("weekday_text")]
        public virtual IEnumerable<string> WeekdayTexts { get; set; }
    }
}