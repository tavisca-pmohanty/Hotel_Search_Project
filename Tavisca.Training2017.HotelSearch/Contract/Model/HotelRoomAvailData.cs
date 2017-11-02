﻿namespace HotelContract.Model
{
    public class HotelRoomAvailData
    {
        public string SessionId { get; set; }
        public string ImageUrl { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public string CurrencyType { get; set; }
        public decimal Price { get; set; }
        public string SupplierName { get; set; }
        public int NumOfRooms { get; set; }
        public string HotelName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}