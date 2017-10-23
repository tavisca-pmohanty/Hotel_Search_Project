using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;

namespace HotelSearchEngine
{
    public class HotelSearchR
    {
        public HotelTripProduct TripDetails { get; set; }
        public string SessionId { get; set; }
        public string GuestName { get; set; }
        public long CountryCode { get; set; }
        public string MobileNum { get; set; }
        public string EmailId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvv { get; set; }
        public HotelSearchR()
        {
            TripDetails = new HotelTripProduct();
        }

    }
}
