
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchRequest
{
   public class HotelSuggestionRS
    {
        public string ID { get; set; }

        public string HotelName { get; set; }

        public string CityName { get; set; }

        public string StateCode { get; set; }

        public string CountryCode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string SearchType { get; set; }

        public string CulteredText { get; set; }
        public HotelSuggestionRS()
        {

        }
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
