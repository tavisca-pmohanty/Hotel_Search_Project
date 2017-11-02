using APITripEngine;
using HotelContract.Contracts;
using HotelContract.Model;
using Logger;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class DynamicRoomPricing
    {
        TripsEngineClient client;

        public DynamicRoomPricing()
        {
            client = new TripsEngineClient();
        }
        public async Task<TripProductPriceRS> GetResponseAsync(TripProductPriceRQ tripProductPriceRQ)
        {
            try
            {
               return await client.PriceTripProductAsync(tripProductPriceRQ);
                
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
      
    }
}
