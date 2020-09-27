using System;
using System.Collections.Generic;
using System.Linq;
using Api.Entities.Common.Enums;
using Api.Entities.Common.Enums.Extensions;
using Api.Entities.Common.Extensions;
using Api.Entities.Places.Details.Request.Enums;

namespace Api.Entities.Places.Details.Request
{

    public class PlacesDetailsRequest : BasePlacesRequest
    {
        protected internal override string BaseUrl => base.BaseUrl + "details/json";

        public virtual string PlaceId { get; set; }

        public virtual string SessionToken { get; set; }

        public virtual Language Language { get; set; } = Language.English;

        public virtual FieldTypes Fields { get; set; } = FieldTypes.Basic;

        public virtual Extensions Extensions { get; set; } = Extensions.None;

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.PlaceId))
                throw new ArgumentException("PlaceId is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("placeid", this.PlaceId);
            parameters.Add("language", this.Language.ToCode());

            var fields = Enum.GetValues(typeof(FieldTypes))
                .Cast<FieldTypes>()
                .Where(x => this.Fields.HasFlag(x) && x != FieldTypes.Basic && x != FieldTypes.Contact && x != FieldTypes.Atmosphere)
                .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLowerInvariant()},");

            parameters.Add("fields", fields.EndsWith(",") ? fields.Substring(0, fields.Length - 1) : fields);

            if (!string.IsNullOrEmpty(this.SessionToken))
                parameters.Add("sessiontoken", this.SessionToken);

            if (this.Extensions != Enums.Extensions.None)
                parameters.Add("extensions", this.Extensions.ToString().ToLower());

            return parameters;
        }
    }
}