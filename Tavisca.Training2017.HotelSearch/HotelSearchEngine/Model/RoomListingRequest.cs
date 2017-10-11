﻿using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class RoomListingRequest
    {
        public HotelItinerary Itinerary { get; set; }
        public HotelSearchCriterion HotelCriterion { get; set; }
        public string SessionId { get; set; }
    }
}
