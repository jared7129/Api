using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api.Entities.Places.Common
{
    public class StructuredFormatting
    {

        [JsonProperty("main_text")]
        public virtual string MainText { get; set; }

        [JsonProperty("main_text_matched_substrings")]
        public virtual IEnumerable<MatchedSubstring> MainTextMatchedSubstrings { get; set; }

        [JsonProperty("secondary_text")]
        public virtual string SecondaryText { get; set; }

        [JsonProperty("secondary_text_matched_substrings")]
        public virtual IEnumerable<MatchedSubstring> SecondaryTextMatchedSubstrings { get; set; }
    }
}