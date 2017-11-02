using HotelContract.Contracts;
using System;

namespace HotelContract.Model
{
    public class CompleteBookingResponse
    {
        public string TransactionId { get; set; }
        public string  HotelName { get; set; }
        public string RoomName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumOfNights { get; set; }
        public string Status { get; set; }
        public string BookingId { get; set; }
    }
}
