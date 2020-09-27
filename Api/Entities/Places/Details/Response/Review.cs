using System;
using Api.Entities.Common.Extensions;
using Newtonsoft.Json;

namespace Api.Entities.Places.Details.Response
{

    public class Review
    {

        [JsonProperty("aspect")]
        public virtual Aspect Aspect { get; set; }


        [JsonProperty("author_name")]
        public virtual string AuthorName { get; set; }


        [JsonProperty("author_url")]
        public virtual string AuthorUrl { get; set; }


        [JsonProperty("language")]
        public virtual string Language { get; set; }


        [JsonProperty("rating")]
        public virtual double Rating { get; set; }


        [JsonProperty("text")]
        public virtual string Text { get; set; }


        [JsonProperty("profile_photo_url")]
        public virtual string ProfilePhotoUrl { get; set; }


        [JsonProperty("relative_time_description")]
        public virtual string RelativeTime { get; set; }

        public virtual DateTime DateTime { get; set; }

        [JsonProperty("time")]
        internal int TimeInt
        {
            get => this.DateTime.DateTimeToUnixTimestamp();
            set => this.DateTime = DateTimeExtension.epoch.AddSeconds(value);
        }
    }
}