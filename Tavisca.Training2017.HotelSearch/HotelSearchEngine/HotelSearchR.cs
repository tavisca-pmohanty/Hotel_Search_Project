using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine
{
    public class HotelSearchR
    {

        public string SessionId { get; set; }
        public string guestName { get; set; }
    
        public long countryCode { get; set; }
        public string mobileNum { get; set; }
        public string emailId { get; set; }
        public string cardHolderName { get; set; }
        public long cardNumber { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
        public string cvv { get; set; }


    }
}
