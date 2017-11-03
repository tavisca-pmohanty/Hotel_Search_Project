using HotelEngienSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelSearchEngine;
using Logger;
using HotelContract.Contracts;
using Cache.CacheData;
using Adapter.Parser;
using HotelContract.Model;

namespace ServiceProvider
{
    class HotelListingService:IHotelService
    {
        public async Task<string> GetRequestedDataAsync(string request)
        { 
            try
            {
                HotelSearch search = new HotelSearch();
                var hotelRequest = JsonConvert.DeserializeObject<HotelSearchRq>(request);
                HotelSearchRQ hotelSearchRQ = await new HotelRequestParser().ParserAsync(hotelRequest);
                HotelSearchRS hotelSearchRS  = await search.GetResponseAsync(hotelSearchRQ);
                HotelListingResponse hotelListingResponse = await new HotelListingResponseParser().ParserAsync(hotelSearchRS);
                CachingHotelSearchCriterion(hotelSearchRS.SessionId, hotelSearchRQ.HotelSearchCriterion);
                CachingHotelItineraries(hotelSearchRS.SessionId, hotelSearchRS.Itineraries);
                return JsonConvert.SerializeObject(hotelListingResponse);
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
        public void CachingHotelSearchCriterion(string sessionId, HotelSearchCriterion hotelSearchCriterion)
        {
            HotelSearchCriterionCache hotelSearchCriterionCache = new HotelSearchCriterionCache();
            if (hotelSearchCriterionCache.CheckIfPresent(sessionId))
            {
                hotelSearchCriterionCache.Remove(sessionId);
                hotelSearchCriterionCache.Add(sessionId, hotelSearchCriterion);
            }
            else
            {
                hotelSearchCriterionCache.Add(sessionId, hotelSearchCriterion);
            }
        }
        public void CachingHotelItineraries(string sessionId, HotelItinerary[] itineraries)
        {
            MultiAvailCache multiAvailCache = new MultiAvailCache();
            if (multiAvailCache.CheckIfPresent(sessionId))
            {
                multiAvailCache.Remove(sessionId);
                multiAvailCache.Add(sessionId, itineraries);
            }
            else
            {
                multiAvailCache.Add(sessionId, itineraries);
            }
        }
    }
}
