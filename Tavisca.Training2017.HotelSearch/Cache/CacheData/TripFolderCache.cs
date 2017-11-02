using APITripEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.CacheData
{
    public class TripFolderCache
    {
        static Dictionary<string, TripFolderBookRS>tripFolderResponseDictionary = new Dictionary<string, TripFolderBookRS>();
        public void Add(string sessionID, TripFolderBookRS tripFolderBookRS)
        {
            tripFolderResponseDictionary.Add(sessionID, tripFolderBookRS);
        }
        public bool CheckIfPresent(string sessionId)
        {
            if (tripFolderResponseDictionary.ContainsKey(sessionId))
            {
                return true;
            }
            return false;
        }
        public void Remove(string sessionId)
        {
            tripFolderResponseDictionary.Remove(sessionId);
        }
        public TripFolderBookRS FetchTripFolder(string sessionId)
        {
            TripFolderBookRS tripFolderBookRS = null;
            if (tripFolderResponseDictionary.ContainsKey(sessionId))
            {
               tripFolderBookRS = tripFolderResponseDictionary[sessionId];
            }
            return tripFolderBookRS;
        }
    }
}
