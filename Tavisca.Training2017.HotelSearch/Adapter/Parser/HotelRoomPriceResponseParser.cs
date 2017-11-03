﻿
using APITripEngine;
using System.Threading.Tasks;
using HotelContract.Model;

namespace Adapter.Parser
{
    public class HotelRoomPriceResponseParser
    {
        HotelRoomPriceResponse response;
        public HotelRoomPriceResponseParser()
        {
            response = new HotelRoomPriceResponse();
        }
        public async Task<HotelRoomPriceResponse> ParserAsync(TripProductPriceRS roomPriceRS)
        {
            HotelTripProduct hotelTripProduct = (HotelTripProduct)roomPriceRS.TripProduct;
            HotelItinerary hotelItinerary = hotelTripProduct.HotelItinerary;
            response.CheckInDate = hotelItinerary.StayPeriod.Start;
            response.CheckOutDate = hotelItinerary.StayPeriod.End;
            response.Duration = hotelItinerary.StayPeriod.Duration;
            response.HotelName = hotelItinerary.HotelProperty.Name;
            response.Price = hotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Amount;
            response.RoomName = hotelItinerary.Rooms[0].RoomName;
            response.SessionId = roomPriceRS.SessionId;
            response.CurrencyType = hotelItinerary.Rooms[0].DisplayRoomRate.TotalFare.Currency;
            response.NumOfRooms = hotelTripProduct.HotelSearchCriterion.NoOfRooms;
            return response;
        }
    }
}
