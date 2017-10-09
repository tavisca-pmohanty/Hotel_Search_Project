using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelSearchRequest;
using Newtonsoft.Json;
using System.IO;
using HotelSearchEngine.SessionLog;

namespace HotelSearchEngine
{
    public class HotelSearch
    {
        List<HotelListingResponse> itineraries;
        public HotelSearch()
        {
           
            itineraries = new List<HotelListingResponse>();
        }
        public async Task<List<HotelListingResponse>> GetHotelListing(HotelSearchRq request)
        {
            HotelEngineClient client = new HotelEngineClient();
            HotelSearchRQ searchRequest = new HotelRequsetParser().Parser(request);
            HotelSearchRS response = await client.HotelAvailAsync(searchRequest);
            for(int i=0;i<response.Itineraries.Length;i++)
            {
                HotelListingResponse listingResponse = new HotelListingResponse();
                listingResponse.Itinerary = response.Itineraries[i];
                listingResponse.SessionId = response.SessionId;
                itineraries.Add(listingResponse);
            }
            PreservingSessionData(searchRequest);
            return itineraries;
        }
        public void PreservingSessionData(HotelSearchRQ searchRequest)
        {
            SessionData sessionData = new SessionData();
            sessionData.SessionId = searchRequest.SessionId;
            sessionData.HotelSearchCriterionData = searchRequest.HotelSearchCriterion;
          File.WriteAllText(@"D:\Hotel_Search_Project\Tavisca.Training2017.HotelSearch\HotelSearchEngine\SessionLog\HotelSearchCriterion_Json.txt",JsonConvert.SerializeObject(sessionData));   
        }
    }
}
