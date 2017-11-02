using Adapter.Parser;
using APITripEngine;
using HotelContract.Contracts;
using HotelContract.Model;
using HotelSearchEngine;
using Logger;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ServiceProvider
{
    class CompleteBookingService : IHotelService
    {

        private string _filePath = "D:\\Hotel_Search_Project\\Tavisca.Training2017.HotelSearch\\HotelSearchEngine\\BookingData\\BookingInfo.txt";

        public async Task<string> GetRequestedDataAsync(string requestData)
        {
     
            try
            {
                var request = JsonConvert.DeserializeObject<CompleteBookingRequest>(requestData);
                HotelCompleteBooking hotelCompleteBooking = new HotelCompleteBooking();
                CompleteBookingRQ completeBookingRequest = await new CompleteBookingRequestParser().ParserAsync(request);
                var completeBookingResponse = await hotelCompleteBooking.GetResponseAsync(completeBookingRequest);
                var response = await new CompleteBookingResponseParser().ParserAsync(completeBookingResponse);

                if (response.Status == "Success")
                {
                    StoreBookingStatus(response);
                }
                return JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }

        public void StoreBookingStatus(CompleteBookingResponse completeBookingResponse)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(completeBookingResponse);
                writer = new StreamWriter(_filePath, true);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        
    }
}
