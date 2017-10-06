using ServiceProvider.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProvider
{
   public class HotelSuggestionRS:IHotelSuggestionRS
    {
        public string ID { get; }

        public string HotelName { get; }

        public string CityName { get; }

        public string StateCode { get; }

        public string CountryCode { get; }

        public string Latitude { get; }

        public string Longitude { get; }

        public string SearchType { get; }

        public string CulteredText { get; }

        public HotelSuggestionRS(string id, string hotelName, string cityName, string stateCode, string countryCode, string latitude, string longitude, string searchType,string culteredText)
        {
            ID = id;
            HotelName = hotelName;
            CityName = cityName;
            StateCode = stateCode;
            CountryCode = countryCode;
            Latitude = latitude;
            Longitude = longitude;
            SearchType = searchType;
            CulteredText = culteredText;
        }
    }
}
