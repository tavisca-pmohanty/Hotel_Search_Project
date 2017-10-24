using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;

namespace TripEngine.Models
{
    public class CompleteBookingResponse
    {
        public string TransactionId { get; set; }
        public HotelItinerary Itinerary { get; set; }
    }
}
