using APITripEngine;
using HotelContract.Contracts;
using HotelContract.Models;
using HotelSearchEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Adapter.Parser;
using System;
using HotelSearchEngine.CacheData;

namespace ServiceProvider
{
    public class BookTripService :IHotelService
    {
        
        public async Task<string> GetRequestedDataAsync(string requestData)
        {
            TripFolderClient tripFolder = new TripFolderClient();
            var request = JsonConvert.DeserializeObject<HotelSearchBookingRequest>(requestData);
            TripFolderBookRQ tripFolderBookRQ = await new TripFolderBookRQParser().ParserAsync(request);
            var response = await tripFolder.GetResponseAsync(tripFolderBookRQ);
            var bookTripResponse = await new BookTripFolderResponseParser().ParserAsync(response);
            CacheTripFolderResponse(response);
            var responseData = JsonConvert.SerializeObject(bookTripResponse);
            return responseData;              
        }
        private void CacheTripFolderResponse(TripFolderBookRS response)
        {
            TripFolderCache tripFolderCache = new TripFolderCache();
            if (tripFolderCache.CheckIfPresent(response.SessionId))
            {
                tripFolderCache.Remove(response.SessionId);
                tripFolderCache.Add(response.SessionId, response);
            }
            else
            {
                tripFolderCache.Add(response.SessionId, response);
            }
        }

    }
}
