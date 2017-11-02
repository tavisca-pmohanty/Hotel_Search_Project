using APITripEngine;
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
    class CompleteBookingService : Notifier
    {
        public async Task<string> GetRequestedDataAsync(string requestData)
        {
            try
            {
                var request = JsonConvert.DeserializeObject<CompleteBookingRequest>(requestData);
                HotelCompleteBooking hotelCompleteBooking = new HotelCompleteBooking();
                var response = await hotelCompleteBooking.GetResponseAsync(request);
                return JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
    }
}
