using HotelEngienSearch;
using HotelSearchEngine.Model;
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
        public async Task<HotelRoomAvailResponse> GetRoomDetails(HotelListingResponse request)
        {
            HotelEngineClient client = new HotelEngineClient();
            HotelRoomAvailRQ roomAvailRequest = new RoomRequestParser().Parser(request);
            HotelRoomAvailRS response=await client.HotelRoomAvailAsync(roomAvailRequest);
            roomList.Itinerary = response.Itinerary;
            roomList.SessionId = response.SessionId;
            return roomList;
        }

    }
}
