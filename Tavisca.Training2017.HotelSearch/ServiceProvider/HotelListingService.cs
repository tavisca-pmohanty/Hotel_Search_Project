using HotelEngienSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelSearchEngine;
using Logger;

namespace ServiceProvider
{
    class HotelListingService:IHotelService
    {
        List<HotelListingResponse> itineraries;
        public HotelListingService()
        {
            itineraries = new List<HotelListingResponse>();
        
        }

        public async Task<string> GetRequestedDataAsync(string request)
        { 
            try
            {
                HotelSearch search = new HotelSearch();
                var hotelRequest = JsonConvert.DeserializeObject<HotelSearchRq>(request);
                itineraries = await search.GetHotelListingAsync(hotelRequest);
                return JsonConvert.SerializeObject(itineraries);
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }

    }
}
