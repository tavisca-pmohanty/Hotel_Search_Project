using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;

namespace TripEngine
{
    public class HotelSearchRequestBooking
    {
        public HotelTripProduct TripDetails { get; set; }
        public string SessionId { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
        public GuestName Name { get; set; }
        public long CountryCode { get; set; }
        public string MobileNum { get; set; }
        public string Email_Id { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvv { get; set; }
        public HotelSearchRequestBooking()
        {
            TripDetails = new HotelTripProduct();
        }

    }
}
