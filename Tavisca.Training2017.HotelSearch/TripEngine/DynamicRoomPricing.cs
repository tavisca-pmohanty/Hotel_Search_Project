using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngine.Models;
using TripEngineServices;
namespace TripEngine
{
   public class DynamicRoomPricing
    {
        HotelRoomPriceResponse hotelRoomPriceResponse;
        public DynamicRoomPricing()
        {
            hotelRoomPriceResponse = new HotelRoomPriceResponse();
        }
        public async Task<HotelRoomPriceResponse> GetDynamicPricingAsync(RoomPricingRequest request)
        {
            TripsEngineClient client = new TripsEngineClient();
            TripProductPriceRQ tripProductPriceRQ = new TripProductPriceRequestParser().Parser(request);
            TripProductPriceRS response = await client.PriceTripProductAsync(tripProductPriceRQ);
            hotelRoomPriceResponse = new HotelRoomPriceResponseParser().Parser(response);
            return hotelRoomPriceResponse;
        }
    }
}
