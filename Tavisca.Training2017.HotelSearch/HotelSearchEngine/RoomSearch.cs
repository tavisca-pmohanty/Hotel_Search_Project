using HotelEngienSearch;
using Logger;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSearchEngine
{
    public class RoomSearch
    {
        HotelEngineClient client ;
        public RoomSearch()
        {
            client = new HotelEngineClient();
        }
        public async Task<HotelRoomAvailRS> GetResponseAsync(HotelRoomAvailRQ hotelRoomAvailRQ)
        {
          
            try
            { 
               return await client.HotelRoomAvailAsync(hotelRoomAvailRQ);
                
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
