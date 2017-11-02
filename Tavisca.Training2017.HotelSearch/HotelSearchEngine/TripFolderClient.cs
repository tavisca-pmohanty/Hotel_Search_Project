using APITripEngine;
using System;
using System.Collections.Generic;
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
        public async Task<TripFolderBookRS> GetResponseAsync(TripFolderBookRQ tripFolderBookRQ)
        {
            try
            {

                return await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
            }
            catch (Exception ex)
            {

                Logger.Log.LogError(ex);
                throw ex;
            }
            finally
            {
                await tripsEngineClient.CloseAsync();
            }
            
        }

       
    }
}
