using HotelEngienSearch;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class RoomPrice
    {
        HotelRoomPriceResponse response;
        public RoomPrice()
        {
            response = new HotelRoomPriceResponse();
        }
        public async Task<HotelRoomPriceResponse>GetRoomPrice(RoomPricingRequest request)
        {
            HotelEngineClient client = new HotelEngineClient();
            HotelRoomPriceRQ roomPriceRequset = new RoomPricingRequestParser().Parser(request);
            HotelRoomPriceRS roomPriceRS = await client.HotelRoomPriceAsync(roomPriceRequset);
            response = new HotelRoomPriceResponseParser().Parser(roomPriceRS);
            return response;
        }
    }
}
