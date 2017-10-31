
using APITripEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace HotelSearchEngine.Parser
{
    class HotelRoomPriceResponseParser:IParser
    {
        HotelRoomPriceResponse response;
        public HotelRoomPriceResponseParser()
        {
            response = new HotelRoomPriceResponse();
        }
        public async Task<IResponse> ParserAsync(IRequest request)
        {
            TripProductPriceRS roomPriceRS = (TripProductPriceRS)request;
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
