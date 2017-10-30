using Cache.CacheData;
using HotelEngienSearch;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSearchEngine.Parser
{
    class RoomResponseParser
    {
        HotelRoomAvailResponse roomList;
        public RoomResponseParser()
        {
            roomList = new HotelRoomAvailResponse();
        }
        public async Task<IResponse> ParserAsync(string sessionId,HotelItinerary hotelItinerary)
        {
            
            foreach(var room in hotelItinerary.Rooms)
            {
                HotelRoomAvailData hotelRoomAvailResponse = new HotelRoomAvailData();
                hotelRoomAvailResponse.SessionId = sessionId;
                hotelRoomAvailResponse.CurrencyType = room.DisplayRoomRate.TotalFare.Currency;
                hotelRoomAvailResponse.Description = room.RoomDescription;
                hotelRoomAvailResponse.Price = room.DisplayRoomRate.TotalFare.Amount;
                hotelRoomAvailResponse.SupplierName = room.HotelFareSource.Name;
                hotelRoomAvailResponse.RoomName = room.RoomName;
                for (int i = 0; i < hotelItinerary.HotelProperty.MediaContent.Length; i++)
                {
                    if (hotelItinerary.HotelProperty.MediaContent[i].Url != String.Empty)
                    {
                       hotelRoomAvailResponse.ImageUrl = hotelItinerary.HotelProperty.MediaContent[i].Url;
                        break;
                    }
                }
                hotelRoomAvailResponse.HotelName = hotelItinerary.HotelProperty.Name;
                HotelEngienSearch.HotelSearchCriterion hotelSearchCriterion = GetCachedCriterion(sessionId);
                hotelRoomAvailResponse.NumOfRooms = hotelSearchCriterion.NoOfRooms;
                hotelRoomAvailResponse.Latitude = hotelSearchCriterion.Location.GeoCode.Latitude;
                hotelRoomAvailResponse.Longitude = hotelSearchCriterion.Location.GeoCode.Longitude;
                roomList.HotelRoomList.Add(hotelRoomAvailResponse);
            }
            return roomList;
        }

        public HotelSearchCriterion GetCachedCriterion(string sessionId)
        {
            HotelSearchCriterionCache hotelSearchCriterionCache = new HotelSearchCriterionCache();
            HotelEngienSearch.HotelSearchCriterion hotelSearchCriterion = new HotelSearchCriterion();
            if(hotelSearchCriterionCache.CheckIfPresent(sessionId))
            {
                hotelSearchCriterion = hotelSearchCriterionCache.FetchCriterion(sessionId);
            }
            return hotelSearchCriterion;
        }
    }
}
