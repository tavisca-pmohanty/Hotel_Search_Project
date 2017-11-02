using HotelContract.Contracts;
using HotelContract.Model;


namespace HotelContract.Models
{
    public  class HotelSearchBookingRequest
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
