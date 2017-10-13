
using System;
using System.Collections.Generic;
using System.Text;
using TripEngine.Models;
using TripEngineServices;

namespace TripEngine
{
    class HotelRoomPriceResponseParser
    {
        HotelRoomPriceResponse response;
        public HotelRoomPriceResponseParser()
        {
            response = new HotelRoomPriceResponse();
        }
        public HotelRoomPriceResponse Parser(TripProductPriceRS roomPriceRS)
        {
            response.TripDetails = roomPriceRS.TripProduct;
            response.SessionId = roomPriceRS.SessionId;
            return response;
        }
    }
}
