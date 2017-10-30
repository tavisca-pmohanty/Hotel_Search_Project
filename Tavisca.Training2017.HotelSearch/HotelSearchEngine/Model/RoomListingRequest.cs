using HotelEngienSearch;
using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEngienSearch
{ 
    public class RoomListingRequest
    {
        public string SessionId { get; set; }
        public string HotelName { get; set; }
    }
}
