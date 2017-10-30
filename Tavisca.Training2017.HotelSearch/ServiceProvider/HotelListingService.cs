using HotelEngienSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelSearchEngine;
using Logger;
using HotelSearchEngine.Contracts;

namespace ServiceProvider
{
    class HotelListingService:IHotelService
    {
        IResponse itineraries;
        public async Task<string> GetRequestedDataAsync(string request)
        { 
            try
            {
                HotelSearch search = new HotelSearch();
                var hotelRequest = JsonConvert.DeserializeObject<HotelSearchRq>(request);
                itineraries = await search.GetResponseAsync(hotelRequest);
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
