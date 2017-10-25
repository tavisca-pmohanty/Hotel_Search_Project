using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cache.CacheData
{
    public class MultiAvailCache
    {
        Dictionary<string, HotelItinerary[]> itineraryDict;
        public MultiAvailCache()
        {
            itineraryDict = new Dictionary<string, HotelItinerary[]>();
        }
        public void Add(string sessionID,HotelItinerary[] itineraryList)
        {
            itineraryDict.Add(sessionID, itineraryList);
        }
        public bool CheckIfPresent(string sessionId)
        {
            if (itineraryDict.ContainsKey(sessionId))
            {
                return true;
            }
            return false;
        }
        public void Remove(string sessionId)
        {
            itineraryDict.Remove(sessionId);
        }
        public HotelItinerary FetchItinerary(string sessionId,string hotelName)
        {
            HotelItinerary hotelItinerary = null;
            if(itineraryDict.ContainsKey(sessionId))
            {
                HotelItinerary[] itineraryList = itineraryDict[sessionId];
                foreach(var itinerary in itineraryList)
                {
                    if(itinerary.HotelProperty.Name==hotelName)
                    {
                        hotelItinerary = itinerary;
                        break;
                    }
                }
            }
            return hotelItinerary;
        }
    }
}
