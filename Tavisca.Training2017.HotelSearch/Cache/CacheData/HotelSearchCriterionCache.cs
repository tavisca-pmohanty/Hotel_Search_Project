using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cache.CacheData
{
    class HotelSearchCriterionCache
    {
        Dictionary<string, HotelSearchCriterion> criterionDict;
        public HotelSearchCriterionCache()
        {
            criterionDict = new Dictionary<string, HotelSearchCriterion>();
        }
        public void Add(string sessionId,HotelSearchCriterion hotelSearchCriterion)
        {
            criterionDict.Add(sessionId, hotelSearchCriterion);
        }
        public bool CheckIfPresent(string sessionId)
        {
            if (criterionDict.ContainsKey(sessionId))
            {
                return true;
            }
            return false;
        }
        public void Remove(string sessionId)
        {
            criterionDict.Remove(sessionId);
        }
        public HotelSearchCriterion FetchCriterion(string sessionId)
        {
            HotelSearchCriterion hotelSearchCriterion = null;
            if(criterionDict.ContainsKey(sessionId))
            {
                hotelSearchCriterion = criterionDict[sessionId];
            }
            return hotelSearchCriterion;
        }
    }
}
