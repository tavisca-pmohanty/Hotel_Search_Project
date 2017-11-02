using Cache.CacheData;
using HotelContract.Model;
using HotelEngienSearch;
using System;
using System.Threading.Tasks;

namespace Adapter.Parser
{
    public class RoomResponseParser
    { 
        HotelRoomAvailResponse roomList;
        public RoomResponseParser()
        {
            roomList = new HotelRoomAvailResponse();
        }
        public async Task<HotelRoomAvailResponse> ParserAsync(HotelRoomAvailRS hotelRoomAvailRS)
        {
            HotelItinerary hotelItinerary = hotelRoomAvailRS.Itinerary;
            foreach(var room in hotelItinerary.Rooms)
            {
                HotelRoomAvailData hotelRoomAvailResponse = new HotelRoomAvailData();
                hotelRoomAvailResponse.SessionId = hotelRoomAvailRS.SessionId;
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
                HotelEngienSearch.HotelSearchCriterion hotelSearchCriterion = GetCachedCriterion(hotelRoomAvailRS.SessionId);
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
