using Api.Entities.Places.Search.Common;
using Newtonsoft.Json;

namespace Api.Entities.Places.Search.NearBy.Response
{

    public class NearByResult : BaseResult
    {

        [JsonProperty("vicinity")]
        public virtual string Vicinity { get; set; }
    }
}