using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class RoomPricingRequest
    {
        public string SessionId { get; set; }
        public HotelItinerary Itinerary { get; set; }
        public HotelSearchCriterion HotelCriterionData { get; set; }
    }
}
