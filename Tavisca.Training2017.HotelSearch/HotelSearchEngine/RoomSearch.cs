using Cache.CacheData;
using HotelEngienSearch;
using HotelSearchEngine.Model;
using HotelSearchEngine.Parser;
using Logger;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class RoomSearch
    {
        List<HotelRoomAvailResponse> roomList;
        HotelEngineClient client ;
        public RoomSearch()
        {
            roomList = new List<HotelRoomAvailResponse>();
            client = new HotelEngineClient();
        }
        public async Task<List<HotelRoomAvailResponse>> GetRoomDetailsAsync(RoomListingRequest request)
        {
          
            try
            {
                
                HotelRoomAvailRQ roomAvailRequest = await new RoomRequestParser().ParserAsync(request);
                HotelRoomAvailRS response = await client.HotelRoomAvailAsync(roomAvailRequest);
                CachingItinerary(response.SessionId, response.Itinerary);
                roomList = await new RoomResponseParser().ParserAsync(response.SessionId,roomAvailRequest.Itinerary);
                return roomList;
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
        public void CachingItinerary(string sessionId, HotelItinerary hotelItinerary)
        {
            SingleAvailCache singleAvailCache = new SingleAvailCache();
            if(singleAvailCache.CheckIfPresent(sessionId))
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
