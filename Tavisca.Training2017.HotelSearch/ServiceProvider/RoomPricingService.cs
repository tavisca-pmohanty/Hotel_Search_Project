using HotelSearchEngine;
using HotelSearchEngine.Model;
using Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                var response = await roomPriceService.GetDynamicPricingAsync(request);
                var result = JsonConvert.SerializeObject(response);
                return result;
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
    }
}
