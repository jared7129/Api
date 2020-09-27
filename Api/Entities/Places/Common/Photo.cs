using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Entities.Places.Common
{

    public class Photo
    {
        [JsonProperty("photo_reference")]
        public virtual string PhotoReference { get; set; }


        [JsonProperty("height")]
        public virtual int Height { get; set; }

        [JsonProperty("width")]
        public virtual int Width { get; set; }
        
        [JsonProperty("html_attributions")]
        public virtual IEnumerable<string> HtmlAttributions { get; set; }
    }
}