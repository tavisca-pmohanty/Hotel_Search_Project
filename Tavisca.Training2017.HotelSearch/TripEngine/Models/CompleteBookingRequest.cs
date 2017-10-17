using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;

namespace TripEngine.Models
{
    public class CompleteBookingRequest
    {
        public TripProduct TripDetails { get; set; }
        public string SessionId { get; set; }
        public HotelSearchCriterion HotelCriterionData { get; set; }
    }
}
