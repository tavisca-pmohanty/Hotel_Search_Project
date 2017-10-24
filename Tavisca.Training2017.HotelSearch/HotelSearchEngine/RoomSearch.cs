using HotelEngienSearch;
using HotelSearchEngine.Model;
using Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class RoomSearch
    {
        HotelRoomAvailResponse roomList;
        HotelEngineClient client ;
        public RoomSearch()
        {
            roomList = new HotelRoomAvailResponse();
            client = new HotelEngineClient();
        }
        public async Task<HotelRoomAvailResponse> GetRoomDetailsAsync(RoomListingRequest request)
        {
          
            try
            {
                
                HotelRoomAvailRQ roomAvailRequest = await new RoomRequestParser().ParserAsync(request);
                HotelRoomAvailRS response = await client.HotelRoomAvailAsync(roomAvailRequest);
               
                HotelSearchCriterion hotelSearchCriterion = new HotelSearchCriterion();
                
                roomList.Itinerary = response.Itinerary;
                roomList.SessionId = response.SessionId;
                roomList.HotelCriterionData = request.HotelCriterion;
                return roomList;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
            finally
            {
                await client.CloseAsync();
            }
            
        }

    }
}
