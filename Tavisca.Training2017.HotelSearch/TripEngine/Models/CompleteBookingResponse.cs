using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;

namespace TripEngine.Models
{
    public class CompleteBookingResponse
    {
        public string TransactionId { get; set; }
        public string  HotelName { get; set; }
        public string RoomName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumOfNights { get; set; }
    }
}
