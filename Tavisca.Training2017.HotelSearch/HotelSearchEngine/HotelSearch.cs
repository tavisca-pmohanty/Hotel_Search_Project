using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using HotelSearchEngine.SessionLog;
using Logger;
using HotelSearchEngine.Parser;
using HotelSearchEngine.Cache;

namespace HotelSearchEngine
{
    public class HotelSearch
    {
        List<HotelListingResponse> itineraryList;
        HotelEngineClient client;
        public HotelSearch()
        {
           
            itineraryList = new List<HotelListingResponse>();
            client = new HotelEngineClient();
        }
        public async Task<List<HotelListingResponse>> GetHotelListingAsync(HotelSearchRq request)
        {
            
            try
            {
                HotelSearchRQ searchRequest = await new HotelRequestParser().ParserAsync(request);
                HotelSearchRS response = await client.HotelAvailAsync(searchRequest);
                CachingHotelSearchCriterion(searchRequest.SessionId, searchRequest.HotelSearchCriterion);
                itineraryList = await new HotelListingResponseParser().ParserAsync(response);
                CachingHotelItineraries(searchRequest.SessionId, response.Itineraries);
                return itineraryList;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
            finally
            {
                await client.CloseAsync();
            }
        }
        public void CachingHotelSearchCriterion(string sessionId,HotelSearchCriterion hotelSearchCriterion)
        {
            HotelSearchCriterionCache hotelSearchCriterionCache = new HotelSearchCriterionCache();
            if(hotelSearchCriterionCache.CheckIfPresent(sessionId))
            {
                hotelSearchCriterionCache.Remove(sessionId);
                hotelSearchCriterionCache.Add(sessionId, hotelSearchCriterion);
            }
            else
            {
                hotelSearchCriterionCache.Add(sessionId, hotelSearchCriterion);
            }
        }
        public void CachingHotelItineraries(string sessionId,HotelItinerary[] itineraries)
        {
            MultiAvailCache multiAvailCache = new MultiAvailCache();
            if(multiAvailCache.CheckIfPresent(sessionId))
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
