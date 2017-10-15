using HotelEngienSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public class BookTripService : IHotelService
    {



        public Task<string> GetRequestedDataAsync(string requestData)
        {
            
            var request = JsonConvert.DeserializeObject<HotelSearchRQ>(requestData);
            return null;
        }
    }
}
