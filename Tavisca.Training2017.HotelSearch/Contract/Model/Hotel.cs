namespace HotelContract.Model
{
    public class Hotel
    {
        public string SessionId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public string ImageUrl { get; set; }
        public string CurrencyType { get; set; }
        public decimal Price { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
    }
}
