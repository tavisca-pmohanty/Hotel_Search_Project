using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using HotelSearchEngine.Parser;
using Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;



namespace HotelSearchEngine
{
    public class HotelCompleteBooking:IResponseService
    {
        TripsEngineClient tripsEngineClient;
        IResponse completeBookingResponse;
        private string _filePath = "D:\\Hotel_Search_Project\\Tavisca.Training2017.HotelSearch\\HotelSearchEngine\\BookingData\\BookingInfo.txt";
        public HotelCompleteBooking()
        {
            completeBookingResponse = new CompleteBookingResponse();
            tripsEngineClient =new TripsEngineClient();
        }
        public async Task<IResponse>GetResponseAsync(IRequest request)
        {

            try
            {
                CompleteBookingRQ completeBookingRQ = (CompleteBookingRQ)await new CompleteBookingRequestParser().ParserAsync(request);
                CompleteBookingRS completeBookingRS = await tripsEngineClient.CompleteBookingAsync(completeBookingRQ);
                completeBookingResponse = await new CompleteBookingResponseParser().ParserAsync(completeBookingRS);
                CompleteBookingResponse response = (CompleteBookingResponse)completeBookingResponse;
                if (response.Status == "Success")
                {
                    StoreBookingStatus(response);
                }
                return completeBookingResponse;
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
            finally
            {

                await tripsEngineClient.CloseAsync();
            }
        }
        private void StoreBookingStatus(CompleteBookingResponse completeBookingResponse)
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
