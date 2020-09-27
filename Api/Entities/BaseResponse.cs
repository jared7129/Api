using System.Collections.Generic;
using Api.Entities.Common.Enums;
using Api.Entities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Api.Entities
{

    public abstract class BaseResponse : IResponse
    {

        public virtual string RawJson { get; set; }


        public virtual string RawQueryString { get; set; }


        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Status? Status { get; set; }


        [JsonProperty("error_message")]
        public virtual string ErrorMessage { get; set; }

        [JsonProperty("html_attributions")]
        public virtual IEnumerable<string> HtmlAttributions { get; set; }
    }
}