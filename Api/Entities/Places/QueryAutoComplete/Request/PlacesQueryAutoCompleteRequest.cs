using System;
using System.Collections.Generic;
using System.Globalization;
using Api.Entities.Common;
using Api.Entities.Common.Enums;
using Api.Entities.Common.Enums.Extensions;
using Api.Entities.Common.Extensions;

namespace Api.Entities.Places.QueryAutoComplete.Request
{

    public class PlacesQueryAutoCompleteRequest : BasePlacesRequest
    {

        protected internal override string BaseUrl => base.BaseUrl + "queryautocomplete/json";


        public virtual string Input { get; set; }

        public virtual string Offset { get; set; }

        public virtual Location Location { get; set; }

        public virtual double? Radius { get; set; }

        public virtual Language Language { get; set; } = Language.English;

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>A <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrEmpty(this.Input))
                throw new ArgumentException("Input is required");

            if (this.Radius.HasValue && (this.Radius > 50000 || this.Radius < 1))
                throw new ArgumentException("Radius must be greater than or equal to 1 and less than or equal to 50.000");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("input", this.Input);
            parameters.Add("language", this.Language.ToCode());

            if (!string.IsNullOrEmpty(this.Offset))
                parameters.Add("offset", this.Offset);

            if (this.Location != null)
                parameters.Add("location", this.Location.ToString());

            if (this.Radius.HasValue)
                parameters.Add("radius", this.Radius.Value.ToString(CultureInfo.InvariantCulture));

            return parameters;
        }
    }
}