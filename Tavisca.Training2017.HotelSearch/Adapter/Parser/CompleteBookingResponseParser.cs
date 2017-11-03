using APITripEngine;
using HotelContract.Model;
using System.Threading.Tasks;



namespace Adapter.Parser
{
    public class CompleteBookingResponseParser
    {
       CompleteBookingResponse completeBookingResponse;
        public CompleteBookingResponseParser()
        {
            completeBookingResponse = new CompleteBookingResponse();
        }
        public async Task<CompleteBookingResponse> ParserAsync(CompleteBookingRS request)
        {
            CompleteBookingRS completeBookingRS = (CompleteBookingRS)request;
            completeBookingResponse.TransactionId = completeBookingRS.SessionId;
            HotelTripProduct product = (HotelTripProduct)completeBookingRS.TripFolder.Products[0];
            completeBookingResponse.HotelName = product.HotelItinerary.HotelProperty.Name;
            completeBookingResponse.RoomName = product.HotelItinerary.Rooms[0].RoomName;
            completeBookingResponse.CheckInDate = product.HotelItinerary.StayPeriod.Start;
            completeBookingResponse.CheckOutDate = product.HotelItinerary.StayPeriod.End;
            completeBookingResponse.NumOfNights = product.HotelItinerary.StayPeriod.Duration;
            completeBookingResponse.Status = completeBookingRS.ServiceStatus.Status.ToString();
            completeBookingResponse.BookingId = completeBookingRS.TripFolder.ConfirmationNumber.ToString();
            return completeBookingResponse;
        }
    }
}
