using Logger;
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
        TripsEngineClient client;

        public DynamicRoomPricing()
        {
            hotelRoomPriceResponse = new HotelRoomPriceResponse();
            client =new TripsEngineClient();
        }
        public async Task<HotelRoomPriceResponse> GetDynamicPricingAsync(RoomPricingRequest request)
        {
            try
            {
                TripProductPriceRQ tripProductPriceRQ = await new TripProductPriceRequestParser().ParserAsync(request);
                TripProductPriceRS response = await client.PriceTripProductAsync(tripProductPriceRQ);
                hotelRoomPriceResponse = await new HotelRoomPriceResponseParser().ParserAsync(response);
                return hotelRoomPriceResponse;
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
            finally
            {
                await client.CloseAsync();
            }
        }
    }
}
