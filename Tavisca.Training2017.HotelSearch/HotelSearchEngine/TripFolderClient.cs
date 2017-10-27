using APITripEngine;
using HotelSearchEngine.CacheData;
using HotelSearchEngine.Model;
using HotelSearchEngine.Models;
using HotelSearchEngine.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace HotelSearchEngine
{
    public class TripFolderClient
    {
        TripsEngineClient tripsEngineClient;
        public TripFolderClient()
        {
             tripsEngineClient = new TripsEngineClient();
        }
        public async Task<BookTripFolderResponse> GetTripFolderAsync(HotelSearchBookingRequest request)
        {
            try
            {
                tripsEngineClient = new TripsEngineClient();
                TripFolderBookRQ tripFolderBookRQ = await new TripFolderBookRQparser().ParserAsync(request);
                TripFolderBookRS response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
                CacheTripFolderResponse(response);
                BookTripFolderResponse bookTripFolderResponse = await new BookTripFolderResponseParser().ParserAsync(response);
                return bookTripFolderResponse;
            }
            catch(Exception ex)
            {
                
                Logger.Log.LogError(ex);
                throw ex;
            }
            finally
            {
                await tripsEngineClient.CloseAsync();
            }
            
        }

        private void CacheTripFolderResponse(TripFolderBookRS response)
        {
            TripFolderCache tripFolderCache = new TripFolderCache();
            if(tripFolderCache.CheckIfPresent(response.SessionId))
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
