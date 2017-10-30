using HotelEngienSearch;
using HotelSearchEngine;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    public class RoomInfoService :IHotelService
    {

        IResponse roomItinaries;
        public async Task<string> GetRequestedDataAsync(string searchTerm)
        {
            try
            {
                RoomSearch search = new RoomSearch();
                var request = JsonConvert.DeserializeObject<RoomListingRequest>(searchTerm);
                roomItinaries = await search.GetResponseAsync(request);
                return JsonConvert.SerializeObject(roomItinaries);
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
        }
}
