﻿using APITripEngine;
using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace HotelSearchEngine.Model
{
    public class HotelRoomPriceResponse:IResponse
    {
        public string HotelName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal Duration { get; set; }
        public decimal Price { get; set; }
        public string CurrencyType { get; set; }
        public string RoomName { get; set; }
        public int NumOfRooms { get; set; }
        public string SessionId { get; set; }
    }
}
