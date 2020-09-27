using System;
using System.Collections.Generic;
using Api.Entities.Interfaces;

namespace Api.Entities.Places
{

    public abstract class BasePlacesRequest : BaseRequest, IRequestQueryString
    {

        protected internal override string BaseUrl => "maps.Apis.com/maps/api/place/";


        public override bool IsSsl
        {
            get => true;
            set => throw new NotSupportedException("This operation is not supported, Request must use SSL");
        }

        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Key is required");

            var parameters = base.GetQueryStringParameters();

            return parameters;
        }
    }
}