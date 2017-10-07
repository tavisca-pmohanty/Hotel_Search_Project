using HotelEngienSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelSearchEngine;
using HotelSearchRequest;

namespace ServiceProvider
{
    class HotelListingService:IHotelService
    {
        List<HotelItinerary> itinerary;
        public HotelListingService()
        {
            itinerary = new List<HotelItinerary>();
        }

        public async Task<string> GetData(string request)
        {
            HotelSearch search = new HotelSearch();
            var hotelRequest = JsonConvert.DeserializeObject<HotelSearchRq>(request);
            itinerary = await search.GetHotelListing(hotelRequest);
            //Add a parser over here to your own custom object
            var hotelItenaries = JsonConvert.SerializeObject(itinerary);
            return hotelItenaries;
        }
    }
}
