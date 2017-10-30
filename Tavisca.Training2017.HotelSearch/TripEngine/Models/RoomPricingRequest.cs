
using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;

namespace TripEngine
{
    public class RoomPricingRequest
    {
        public string SessionId { get; set; }
        public HotelSearchCriterion HotelCriterionData { get; set; }
        public string RoomName { get; set; }
    }
}
