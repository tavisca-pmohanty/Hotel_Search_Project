using HotelEngienSearch;
using HotelSearchEngine;
using HotelSearchEngine.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ServiceProvider
{
    public class BookTripService : IHotelService
    {



        public async Task<string> GetRequestedDataAsync(string requestData)
        {
            TripFolderClient tripFolder = new TripFolderClient();
            var request = JsonConvert.DeserializeObject<HotelSearchBookingRequest>(requestData);
            var response = await tripFolder.GetTripFolderAsync(request);
            var responseData = JsonConvert.SerializeObject(response);
            return responseData;              
        }
    }
}
