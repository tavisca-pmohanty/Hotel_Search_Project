using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using HotelSearchEngine.SessionLog;
using Logger;

namespace HotelSearchEngine
{
    public class HotelSearch
    {
        List<HotelListingResponse> itineraries;
        public HotelSearch()
        {
           
            itineraries = new List<HotelListingResponse>();
        }
        public async Task<List<HotelListingResponse>> GetHotelListingAsync(HotelSearchRq request)
        {
            try
            {
                HotelEngineClient client = new HotelEngineClient();
                HotelSearchRQ searchRequest = await new HotelRequestParser().ParserAsync(request);
                HotelSearchRS response = await client.HotelAvailAsync(searchRequest);
                for (int i = 0; i < response.Itineraries.Length; i++)
                {
                    HotelListingResponse listingResponse = new HotelListingResponse
                    {
                        Itinerary = response.Itineraries[i],
                        SessionId = response.SessionId,
                        HotelCriterion = searchRequest.HotelSearchCriterion
                    };
                    itineraries.Add(listingResponse);
                }
                return itineraries;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw ex;

            }
        }
    }
}
