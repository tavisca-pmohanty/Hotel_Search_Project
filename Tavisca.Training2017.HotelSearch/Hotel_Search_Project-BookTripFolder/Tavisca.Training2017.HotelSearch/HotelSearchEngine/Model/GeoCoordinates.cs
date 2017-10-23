namespace HotelSearchEngine
{
    internal class GeoCoordinates
    {
        public float Latitude { get; set; }

        public float Longitude { get; set; }
        public GeoCoordinates(float longitude,float latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}