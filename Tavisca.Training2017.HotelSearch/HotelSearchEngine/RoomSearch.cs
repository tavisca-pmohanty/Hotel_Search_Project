using Cache.CacheData;
using HotelEngienSearch;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using HotelSearchEngine.Parser;
using Logger;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class RoomSearch:IResponseService
    {
        IResponse roomList;
        HotelEngineClient client ;
        public RoomSearch()
        {
            client = new HotelEngineClient();
        }
        public async Task<IResponse> GetResponseAsync(IRequest request)
        {
          
            try
            {
                RoomListingRequest roomListingRequest = (RoomListingRequest)request;
                HotelRoomAvailRQ roomAvailRequest = await new RoomRequestParser().ParserAsync(roomListingRequest);
                HotelRoomAvailRS response = await client.HotelRoomAvailAsync(roomAvailRequest);
                CachingItinerary(response.SessionId, response.Itinerary);
                roomList = await new RoomResponseParser().ParserAsync(response.SessionId,response.Itinerary);
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
