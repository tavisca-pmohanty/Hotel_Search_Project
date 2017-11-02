using HotelContract.Model;
using HotelSearchEngine;
using Logger;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Adapter.Parser;
using APITripEngine;
using HotelContract.Contracts;
using Cache.CacheData;

namespace ServiceProvider
{
    public class RoomPricingService:IHotelService
    {
        public async Task<string> GetRequestedDataAsync(string requestData)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<RoomPricingRequest>(requestData);
                DynamicRoomPricing roomPriceService = new DynamicRoomPricing();
                TripProductPriceRQ tripProductPriceRQ = await new TripProductPriceRequestParser().ParserAsync(request); 
                var response = await roomPriceService.GetResponseAsync(tripProductPriceRQ);
                HotelRoomPriceResponse hotelRoomPriceResponse = await new HotelRoomPriceResponseParser().ParserAsync(response);
                HotelTripProduct hotelTripProduct = (HotelTripProduct)response.TripProduct;
                CachingItinerary(response.SessionId, hotelTripProduct.HotelItinerary);
                var result = JsonConvert.SerializeObject(hotelRoomPriceResponse);
                return result;
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }

        }
        public void CachingItinerary(string sessionId, HotelItinerary hotelItinerary)
        {
            SingleAvailCache singleAvailCache = new SingleAvailCache();
            if (singleAvailCache.CheckIfPresent(sessionId))
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
