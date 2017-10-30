using APITripEngine;
using Cache.CacheData;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using HotelSearchEngine.Parser;
using Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class DynamicRoomPricing
    {
        IResponse hotelRoomPriceResponse;
        TripsEngineClient client;

        public DynamicRoomPricing()
        {
            hotelRoomPriceResponse = new HotelRoomPriceResponse();
            client = new TripsEngineClient();
        }
        public async Task<IResponse> GetDynamicPricingAsync(RoomPricingRequest request)
        {
            try
            {
                TripProductPriceRQ tripProductPriceRQ = await new TripProductPriceRequestParser().ParserAsync(request);
                TripProductPriceRS response = await client.PriceTripProductAsync(tripProductPriceRQ);
                hotelRoomPriceResponse = await new HotelRoomPriceResponseParser().ParserAsync(response);
                HotelTripProduct hotelTripProduct = (HotelTripProduct)response.TripProduct;
                HotelItinerary hotelItinerary = hotelTripProduct.HotelItinerary;
                CachingItinerary(response.SessionId, hotelItinerary);
                return hotelRoomPriceResponse;
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

        private void CachingItinerary(string sessionId, HotelItinerary hotelItinerary)
        {
            SingleAvailCache singleAvailCache = new SingleAvailCache();
            if(singleAvailCache.CheckIfPresent(sessionId))
            {
                singleAvailCache.Remove(sessionId);
                string jsonItinerary = JsonConvert.SerializeObject(hotelItinerary);
                singleAvailCache.Add(sessionId, JsonConvert.DeserializeObject<HotelEngienSearch.HotelItinerary>(jsonItinerary));
            }
            else
            {
                string jsonItinerary = JsonConvert.SerializeObject(hotelItinerary);
                singleAvailCache.Add(sessionId, JsonConvert.DeserializeObject<HotelEngienSearch.HotelItinerary>(jsonItinerary));
            }
        }
    }
}
