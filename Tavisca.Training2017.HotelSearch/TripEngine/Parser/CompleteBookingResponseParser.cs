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
            completeBookingResponse.HotelName = product.HotelItinerary.HotelProperty.Name;
            completeBookingResponse.RoomName = product.HotelItinerary.Rooms[0].RoomName;
            completeBookingResponse.CheckInDate = product.HotelItinerary.StayPeriod.Start;
            completeBookingResponse.CheckOutDate = product.HotelItinerary.StayPeriod.End;
            completeBookingResponse.NumOfNights = product.HotelItinerary.StayPeriod.Duration;
            return completeBookingResponse;
        }
    }
}
