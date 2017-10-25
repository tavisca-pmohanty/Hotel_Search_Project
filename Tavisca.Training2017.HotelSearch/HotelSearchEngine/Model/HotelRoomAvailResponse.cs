using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class HotelRoomAvailResponse
    {
        public string SessionId { get; set; }
        public string ImageUrl { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public string CurrencyType { get; set; }
        public decimal Price { get; set; }
        public string SupplierName { get; set; }
        public string HotelName { get; set; }
    }
}
