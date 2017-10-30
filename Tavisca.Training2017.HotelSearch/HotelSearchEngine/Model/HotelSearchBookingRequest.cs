using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace HotelSearchEngine.Models
{
    public  class HotelSearchBookingRequest:IRequest
    {
        public string SessionId { get; set; }
        public GuestName Name { get; set; }
        public long CountryCode { get; set; }
        public string MobileNum { get; set; }
        public string Email_Id { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvv { get; set; }
    }
}
