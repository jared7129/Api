using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Api.Entities.Common;
using Api.Entities.Common.Enums;
using Api.Entities.Common.Enums.Extensions;
using Api.Entities.Common.Extensions;
using Api.Entities.Places.Common.Enums;
using Api.Entities.Places.Search.Common.Enums;

namespace Api.Entities.Places.Search.Text.Request
{

    public class PlacesTextSearchRequest : BasePlacesRequest
    {

        protected internal override string BaseUrl => base.BaseUrl + "textsearch/json";

        public virtual string Query { get; set; }


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
                if (string.IsNullOrWhiteSpace(this.Query))
                    throw new ArgumentException("Query is required");

                if (this.Location != null && this.Radius == null)
                    throw new ArgumentException("Radius is required when Location is specified");

                if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
                    throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000");

                parameters.Add("query", this.Query);
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