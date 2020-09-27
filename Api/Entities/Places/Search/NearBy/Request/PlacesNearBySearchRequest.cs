using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Api.Entities.Common.Enums;
using Api.Entities.Common.Enums.Extensions;
using Api.Entities.Places.Search.NearBy.Request.Enums;
using Api.Entities.Common.Extensions;
using Api.Entities.Places.Common.Enums;
using Api.Entities.Places.Search.Common.Enums;

namespace Api.Entities.Places.Search.NearBy.Request
{

    public class PlacesNearBySearchRequest : BasePlacesRequest
    {

        protected internal override string BaseUrl => base.BaseUrl + "nearbysearch/json";


        public virtual string Name { get; set; }


        public virtual string Keyword { get; set; }


        public virtual Ranking Rankby { get; set; } = Ranking.Prominence;


        public virtual bool OpenNow { get; set; }


        public virtual Language Language { get; set; } = Language.English;


        public virtual PriceLevel? Minprice { get; set; }

        public virtual PriceLevel? Maxprice { get; set; }


        public virtual SearchPlaceType? Type { get; set; }


        public virtual Location Location { get; set; }


        public virtual double? Radius { get; set; }


        public virtual string PageToken { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (!string.IsNullOrEmpty(this.PageToken))
            {
                parameters.Add("pagetoken", this.PageToken);
            }
            else
            {
                if (this.Location == null)
                    throw new ArgumentException("Location is required");

                if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
                    throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000");

                if (this.Rankby == Ranking.Distance)
                {
                    if (this.Radius.HasValue)
                        throw new ArgumentException("Radius cannot be specified, when using RankBy distance");

                    if (string.IsNullOrWhiteSpace(this.Name) && string.IsNullOrWhiteSpace(this.Keyword) && !this.Type.HasValue)
                        throw new ArgumentException("Keyword, Name or Type is required, If rank by distance");
                }
                else
                {
                    if (!this.Radius.HasValue)
                        throw new ArgumentException("Radius is required, when RankBy is not Distance");
                }

                if (!string.IsNullOrWhiteSpace(this.Name))
                    parameters.Add("name", this.Name);

                if (!string.IsNullOrWhiteSpace(this.Keyword))
                    parameters.Add("keyword", this.Keyword);

                parameters.Add("rankby", this.Rankby.ToString().ToLower());
                parameters.Add("language", Language.ToCode());

                if (this.Location != null)
                    parameters.Add("location", this.Location.ToString());

                if (this.Radius != null)
                    parameters.Add("radius", this.Radius.Value.ToString(CultureInfo.InvariantCulture));

                if (this.Type.HasValue)
                {
                    var type = this.Type.GetType().GetTypeInfo();
                    var attribute = type.DeclaredMembers.FirstOrDefault(x => x.Name == this.Type.ToString())?.GetCustomAttribute<EnumMemberAttribute>();

                    if (attribute != null)
                        parameters.Add("type", attribute.Value.ToLower());
                }

                if (this.OpenNow)
                    parameters.Add("opennow");

                if (this.Minprice.HasValue)
                    parameters.Add("minprice", ((int)this.Minprice.Value).ToString());

                if (this.Maxprice.HasValue)
                    parameters.Add("maxprice", ((int)this.Maxprice.Value).ToString());
            }
            
            return parameters;
        }
    }
}