using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProvider.Contracts
{
   public  interface IHotelSuggestionRS
    {
        string ID { get; }
        string HotelName { get; }
        string CityName { get; }
        string StateCode { get; }
        string CountryCode { get; }
        string Latitude { get; }
        string Longitude { get; }
        string SearchType { get; }
    }
}
