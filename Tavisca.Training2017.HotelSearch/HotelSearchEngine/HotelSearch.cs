using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logger;
using HotelContract.Model;

namespace HotelSearchEngine
{
    public class HotelSearch
    {
        HotelEngineClient client;
        public HotelSearch()
        {
            client = new HotelEngineClient();
        }
        public async Task<HotelSearchRS> GetResponseAsync(HotelSearchRQ request)
        {
            
            try
            {
                return await client.HotelAvailAsync(request);
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
