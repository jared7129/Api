using Api.Entities.Places.Search.Common;
using Newtonsoft.Json;

namespace Api.Entities.Places.Search.Text.Response
{

    public class TextResult : BaseResult
    {

        [JsonProperty("formatted_address")]
        public virtual string FormattedAddress { get; set; }
    }
}