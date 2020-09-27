using System.Globalization;

namespace Api.Entities.Places.Search.NearBy.Request
{

    public class Location
    {
        public double Latitude { get; set; }


        public double Longitude { get; set; }

        public Location()
        {

        }

        /// <summary>
        /// Contructor intializing a location using <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Location(double latitude, double longitude)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public override string ToString()
        {
            return this.Latitude.ToString(CultureInfo.InvariantCulture) + "," + this.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}