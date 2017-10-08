using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class HotelRoomAvailResponse
    {
        public string SessionId { get; set; }
        public HotelItinerary Itinerary { get; set; }
    }
}
