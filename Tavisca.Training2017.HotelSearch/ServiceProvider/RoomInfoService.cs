using Adapter.Parser;
using Cache.CacheData;
using HotelContract.Contracts;
using HotelContract.Model;
using HotelEngienSearch;
using HotelSearchEngine;
using Logger;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public class RoomInfoService :IHotelService
    {
        public async Task<string> GetRequestedDataAsync(string searchTerm)
        {
            try
            {
                RoomSearch search = new RoomSearch();
                var request = JsonConvert.DeserializeObject<RoomListingRequest>(searchTerm);
                HotelRoomAvailRQ hotelRoomAvailRQ = await new RoomRequestParser().ParserAsync(request);
                HotelRoomAvailRS hotelRoomAvailRS = await search.GetResponseAsync(hotelRoomAvailRQ);
                HotelRoomAvailResponse hotelRoomAvailResponse = await new RoomResponseParser().ParserAsync(hotelRoomAvailRS);
                CachingItinerary(hotelRoomAvailRS.SessionId, hotelRoomAvailRS.Itinerary);
                return JsonConvert.SerializeObject(hotelRoomAvailResponse);
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
        public void CachingItinerary(string sessionId, HotelItinerary hotelItinerary)
        {
            SingleAvailCache singleAvailCache = new SingleAvailCache();
            if (singleAvailCache.CheckIfPresent(sessionId))
            {
                singleAvailCache.Remove(sessionId);
                singleAvailCache.Add(sessionId, hotelItinerary);
            }
            else
            {
                singleAvailCache.Add(sessionId, hotelItinerary);
            }
        }
    }
}
