using HotelSearchEngine;
using HotelSearchEngine.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public class RoomPricingService : IHotelService
    {
        public async Task<string> GetRequestedData(string requestData)
        {
            var request = JsonConvert.DeserializeObject<HotelRoomAvailResponse>(requestData);
            RoomPrice roomPriceService = new RoomPrice();
            HotelRoomPriceResponse response=await roomPriceService.GetRoomPrice(request);
            return JsonConvert.SerializeObject(response);
        }
    }
}
