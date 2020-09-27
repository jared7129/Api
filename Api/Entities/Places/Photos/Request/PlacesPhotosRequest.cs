using System;
using System.Collections.Generic;
using System.Globalization;
using Api.Entities.Common.Extensions;

namespace Api.Entities.Places.Photos.Request
{

    public class PlacesPhotosRequest : BasePlacesRequest
    {

        protected internal override string BaseUrl => base.BaseUrl + "photo";


        public virtual int? MaxWidth { get; set; }

        public virtual int? MaxHeight { get; set; }

        public virtual string PhotoReference { get; set; }

        /// <summary>
        /// See <see cref="BasePlacesRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.PhotoReference))
                throw new ArgumentException("PhotoReference is required");

            if (!this.MaxHeight.HasValue && !this.MaxWidth.HasValue)
                throw new ArgumentException("MaxHeight or MaxWidth is required");

            if (this.MaxHeight.HasValue && (this.MaxHeight > 1600 || this.MaxHeight < 1))
                throw new ArgumentException("MaxHeight must be greater than or equal to 1 and less than or equal to 1.600");

            if (this.MaxWidth.HasValue && (this.MaxWidth > 1600 || this.MaxWidth < 1))
                throw new ArgumentException("MaxWidth must be greater than or equal to 1 and less than or equal to 1.600");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("photoreference", this.PhotoReference);

            if (this.MaxHeight.HasValue)
                parameters.Add("maxheight", this.MaxHeight.Value.ToString(CultureInfo.InvariantCulture));

            if (this.MaxWidth.HasValue)
                parameters.Add("maxwidth", this.MaxWidth.Value.ToString(CultureInfo.InvariantCulture));

            return parameters;
        }
    }
}