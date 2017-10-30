using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using HotelSearchEngine.Parser;
using Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;



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
                TwilioClient.Init("ACd295eb50aabe82232e8c765857fbbec0", "71f3852a3cc555c530aef33ec37cf926");

                MessageResource.Create(
         to: new PhoneNumber("+918249123748"),
         from: new PhoneNumber("+17149704389"),
         body: "Hi a Hotel booking is done to your name as");
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
