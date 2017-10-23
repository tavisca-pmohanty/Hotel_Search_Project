using HotelEngienSearch;
using HotelSearchEngine.Model;
using Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class RoomSearch
    {
        HotelRoomAvailResponse roomList;
        public RoomSearch()
        {
            roomList = new HotelRoomAvailResponse();
        }
        public async Task<HotelRoomAvailResponse> GetRoomDetailsAsync(RoomListingRequest request)
        {
            try
            {
                HotelEngineClient client = new HotelEngineClient();
                HotelRoomAvailRQ roomAvailRequest = await new RoomRequestParser().ParserAsync(request);
                HotelRoomAvailRS response = await client.HotelRoomAvailAsync(roomAvailRequest);
                roomList.Itinerary = response.Itinerary;
                roomList.SessionId = response.SessionId;
                roomList.HotelCriterionData = request.HotelCriterion;
                return roomList;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }

    }
}
