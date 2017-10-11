using HotelEngienSearch;
using HotelSearchEngine;
using HotelSearchEngine.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public class RoomInfoService :IHotelService
    {

        HotelRoomAvailResponse roomItinaries;
        public RoomInfoService()
        {
            roomItinaries = new HotelRoomAvailResponse();
        }

        public async Task<string> GetRequestedData(string searchTerm)
        {
            RoomSearch search = new RoomSearch();
            var request = JsonConvert.DeserializeObject<RoomListingRequest>(searchTerm);
            roomItinaries=await search.GetRoomDetails(request);
            return JsonConvert.SerializeObject(roomItinaries);
        }
        }
}
