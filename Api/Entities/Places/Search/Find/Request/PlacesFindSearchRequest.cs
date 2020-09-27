using System;
using System.Collections.Generic;
using System.Linq;
using Api.Entities.Common;
using Api.Entities.Common.Enums;
using Api.Entities.Common.Enums.Extensions;
using Api.Entities.Common.Extensions;
using Api.Entities.Places.Search.Find.Request.Enums;

namespace Api.Entities.Places.Search.Find.Request
{

    public class PlacesFindSearchRequest : BasePlacesRequest
    {

        protected internal override string BaseUrl => base.BaseUrl + "findplacefromtext/json";


        public virtual string Input { get; set; }


        public virtual InputType Type { get; set; } = InputType.TextQuery;


        public virtual FieldTypes Fields { get; set; } = FieldTypes.Place_Id;

  
        public virtual Language Language { get; set; } = Language.English;


        public virtual int? Radius { get; set; }


        public virtual ViewPort Bounds { get; set; }


        public virtual Location Location { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (string.IsNullOrWhiteSpace(this.Input))
                throw new ArgumentException("Input is required");

            parameters.Add("input", this.Input);
            parameters.Add("inputtype", this.Type.ToString().ToLower());

            var fields = Enum.GetValues(typeof(FieldTypes))
                .Cast<FieldTypes>()
                .Where(x => this.Fields.HasFlag(x) && x != FieldTypes.Basic && x != FieldTypes.Contact && x != FieldTypes.Atmosphere)
                .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLowerInvariant()},");

            parameters.Add("fields", fields.EndsWith(",") ? fields.Substring(0, fields.Length - 1) : fields);
            parameters.Add("language", this.Language.ToCode());

            if (this.Location != null)
            {
                parameters.Add("locationbias", this.Radius.HasValue ? $"circle:{this.Radius}@{this.Location}" : $"point:{this.Location}");
            }
            else if (this.Bounds != null)
            {
                parameters.Add("locationbias", $"rectangle:{this.Bounds.SouthWest}|{this.Bounds.NorthEast}");
            }
            else
            {
                parameters.Add("locationbias", "ipbias");
            }

            return parameters;
        }
    }
}
