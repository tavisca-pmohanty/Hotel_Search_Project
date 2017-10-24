using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngine.Models;
using TripEngineServices;

namespace TripEngine.Parser
{
    public class CompleteBookingResponseParser
    {
        CompleteBookingResponse completeBookingResponse;
        public CompleteBookingResponseParser()
        {
            completeBookingResponse = new CompleteBookingResponse();
        }
        public async Task<CompleteBookingResponse> ResponseParserAsync(CompleteBookingRS completeBookingRS)
        {
            completeBookingResponse.TransactionId = completeBookingRS.TripFolder.ConfirmationNumber;
            HotelTripProduct product = (HotelTripProduct)completeBookingRS.TripFolder.Products[0];
            completeBookingResponse.Itinerary = product.HotelItinerary;
            return completeBookingResponse;
        }
    }
}
