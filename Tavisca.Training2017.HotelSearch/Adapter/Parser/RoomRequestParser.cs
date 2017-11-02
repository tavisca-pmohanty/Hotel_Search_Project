using HotelEngienSearch;
using System.Threading.Tasks;
using Cache.CacheData;

namespace Adapter.Parser
{
    public class RoomRequestParser
    {
        HotelRoomAvailRQ roomRequest;
        public RoomRequestParser()
        {
            roomRequest = new HotelRoomAvailRQ();
         
        }
        public async Task<HotelRoomAvailRQ> ParserAsync(RoomListingRequest request)
        {
            HotelItinerary hotelItinerary = GetCachedItinerary(request.SessionId, request.HotelName);
            HotelSearchCriterion hotelSearchCriterion = GetCachedCriterion(request.SessionId);
            roomRequest.ResultRequested = ResponseType.Complete;
            roomRequest.SessionId = request.SessionId;
            roomRequest.Itinerary = hotelItinerary;
            roomRequest.HotelSearchCriterion = hotelSearchCriterion;
            return roomRequest;
        }
        public HotelItinerary GetCachedItinerary(string sessionId,string hotelName)
        {
            MultiAvailCache multiAvailCache = new MultiAvailCache();
            HotelItinerary hotelItinerary = new HotelItinerary();
            if(multiAvailCache.CheckIfPresent(sessionId))
            {
                hotelItinerary= multiAvailCache.FetchItinerary(sessionId, hotelName);
            }
            return hotelItinerary;
        }
        public HotelSearchCriterion GetCachedCriterion(string sessionId)
        {
            HotelSearchCriterionCache hotelSearchCriterionCache = new HotelSearchCriterionCache();
            HotelSearchCriterion hotelSearchCriterion = new HotelSearchCriterion();
            if(hotelSearchCriterionCache.CheckIfPresent(sessionId))
            {
                hotelSearchCriterion = hotelSearchCriterionCache.FetchCriterion(sessionId);
            }
            return hotelSearchCriterion;
        }
    }
}
