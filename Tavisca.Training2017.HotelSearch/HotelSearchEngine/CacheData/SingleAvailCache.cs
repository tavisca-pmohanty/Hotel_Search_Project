using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cache.CacheData
{
    class SingleAvailCache
    {
        Dictionary<string, HotelItinerary> itineraryDict;
        public SingleAvailCache()
        {
            itineraryDict = new Dictionary<string, HotelItinerary>();
        }
        public void Add(string sessionId,HotelItinerary hotelItinerary)
        {
            itineraryDict.Add(sessionId, hotelItinerary);
        }
        public bool CheckIfPresent(string sessionId)
        {
           if(itineraryDict.ContainsKey(sessionId))
            {
                return true;
            }
            return false;
        }
        public void Remove(string sessionId)
        {
            itineraryDict.Remove(sessionId);
        }
        public HotelItinerary FetchItinerary(string sessionId)
        {
            return itineraryDict[sessionId];
        }
    }
}
