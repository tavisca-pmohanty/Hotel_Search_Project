using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;

namespace TripEngine.Models
{
    public class HotelRoomPriceResponse
    {
        public TripProduct TripDetails { get; set; }
        public string SessionId { get; set; }
    }
}
