using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelSearchRequest;

namespace HotelSearchEngine
{
    public class HotelSearch
    {
        List<HotelItinerary> itineraries;
        public HotelSearch()
        {
            itineraries = new List<HotelItinerary>();
        }
        public async Task<List<HotelItinerary>> GetHotelListing(HotelSearchRq request)
        {
            HotelEngineClient client = new HotelEngineClient();
            HotelSearchRQ searchRequest = new HotelRequsetParser().Parser(request);
            HotelSearchRS response = await client.HotelAvailAsync(searchRequest);
            for(int i=0;i<response.Itineraries.Length;i++)
            {
                itineraries.Add(response.Itineraries[i]);
            }
            return itineraries;
        }
    }
}
