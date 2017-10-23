﻿using System;
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
            try
            {
                TripsEngineClient client = new TripsEngineClient();
                TripProductPriceRQ tripProductPriceRQ = await new TripProductPriceRequestParser().ParserAsync(request);
                TripProductPriceRS response = await client.PriceTripProductAsync(tripProductPriceRQ);
                hotelRoomPriceResponse = await new HotelRoomPriceResponseParser().ParserAsync(response);
                return hotelRoomPriceResponse;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
