using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine
{
    class HotelRoomPriceResponseParser
    {
        HotelRoomPriceResponse response;
        public HotelRoomPriceResponseParser()
        {
            response = new HotelRoomPriceResponse();
        }
        public HotelRoomPriceResponse Parser(HotelRoomPriceRS roomPriceRS)
        {
            response.Itinerary = roomPriceRS.Itinerary;
            response.Occupancy = roomPriceRS.RoomOccupancyTypes;
            response.SessionId = roomPriceRS.SessionId;
            return response;
        }
    }
}
