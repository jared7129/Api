using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Entities.Interfaces;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Api.Entities.Common.Extensions;

namespace Api.Entities
{

    public abstract class BaseRequest : IRequest
    {

        protected internal abstract string BaseUrl { get; }


        protected internal virtual string KeyName { get; set; } = "key";


        [JsonIgnore]
        public virtual string Key { get; set; }


        [JsonIgnore]
        public virtual string ClientId { get; set; }


        [JsonIgnore]
        public virtual bool IsSsl { get; set; } = true;

        /// <summary>
        /// See <see cref="IRequest.GetUri()"/>.
        /// </summary>
        /// <returns>The <see cref="Uri"/>.</returns>
        public virtual Uri GetUri()
        {
            var scheme = this.IsSsl ? "https://" : "http://";
            var queryString = string.Join("&", this.GetQueryStringParameters().Select(x => 
                x.Value == null
                    ? Uri.EscapeDataString(x.Key)
                    : Uri.EscapeDataString(x.Key) + "=" + Uri.EscapeDataString(x.Value)));
            var uri = new Uri(scheme + this.BaseUrl + "?" + queryString);

            if (this.ClientId == null)
                return uri;

            var url = uri.LocalPath + uri.Query + "&client=" + this.ClientId;
            var bytes = Encoding.UTF8.GetBytes(url);
            var privateKey = Convert.FromBase64String(this.Key.Replace("-", "+").Replace("_", "/"));

            var hmac = new HMac(new Sha1Digest());
            hmac.Init(new KeyParameter(privateKey));
            
            var signature = new byte[hmac.GetMacSize()];
            hmac.BlockUpdate(bytes, 0, bytes.Length);
            hmac.DoFinal(signature, 0);
            
            var base64Signature = Convert.ToBase64String(signature).Replace("+", "-").Replace("/", "_");

            return new Uri(uri.Scheme + "://" + uri.Host + url + "&signature=" + base64Signature);
        }

        /// <summary>
        /// See <see cref="IRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public virtual IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = new List<KeyValuePair<string, string>>();

            if (this.ClientId == null)
            {
                if (!string.IsNullOrWhiteSpace(this.Key))
                    parameters.Add(this.KeyName, this.Key);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.Key))
                    throw new ArgumentException("Key is required");

                if (!this.ClientId.StartsWith("gme-"))
                    throw new ArgumentException("ClientId must begin with 'gme-'");
            }

            return parameters;
        }
    }
}