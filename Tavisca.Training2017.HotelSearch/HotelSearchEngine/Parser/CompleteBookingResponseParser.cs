using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;



namespace HotelSearchEngine.Parser
{
    public class CompleteBookingResponseParser:IParser
    {
       CompleteBookingResponse completeBookingResponse;
        public CompleteBookingResponseParser()
        {
            completeBookingResponse = new CompleteBookingResponse();
        }
        public async Task<IResponse> ParserAsync(IRequest request)
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
