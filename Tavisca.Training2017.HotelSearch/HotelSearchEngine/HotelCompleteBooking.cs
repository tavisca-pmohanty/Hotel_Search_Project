using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using HotelSearchEngine.Parser;
using Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace HotelSearchEngine
{
    public class HotelCompleteBooking
    {
        TripsEngineClient tripsEngineClient;
        IResponse completeBookingResponse;
        public HotelCompleteBooking()
        {
            completeBookingResponse = new CompleteBookingResponse();
            tripsEngineClient =new TripsEngineClient();
        }
        public async Task<IResponse> CompleteHotelBooking(CompleteBookingRequest request)
        {

            try
            {
              
                CompleteBookingRQ completeBookingRQ = await new CompleteBookingRequestParser().ParserAsync(request);
                CompleteBookingRS completeBookingRS = await tripsEngineClient.CompleteBookingAsync(completeBookingRQ);
                completeBookingResponse = await new CompleteBookingResponseParser().ResponseParserAsync(completeBookingRS);
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
       
    }
}
