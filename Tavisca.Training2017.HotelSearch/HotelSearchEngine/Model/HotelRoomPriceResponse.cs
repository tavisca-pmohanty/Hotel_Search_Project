using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine
{
    public class HotelRoomPriceResponse
    {
        public HotelItinerary Itinerary { get; set; }
        public RoomOccupancyType []Occupancy { get; set; }
        public string SessionId { get; set; }
    }
}
