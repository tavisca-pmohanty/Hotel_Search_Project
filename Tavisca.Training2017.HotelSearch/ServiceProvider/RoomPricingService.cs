using HotelSearchEngine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngine;
using TripEngine.Models;

namespace ServiceProvider
{
    public class RoomPricingService:IHotelService
    {
        public async Task<string> GetRequestedDataAsync(string requestData)
        {
            var request = JsonConvert.DeserializeObject<RoomPricingRequest>(requestData);
            DynamicRoomPricing roomPriceService = new DynamicRoomPricing();
            HotelRoomPriceResponse response =await roomPriceService.GetDynamicPricingAsync(request);
            var result = JsonConvert.SerializeObject(response);
            return result;
        }
    }
}
