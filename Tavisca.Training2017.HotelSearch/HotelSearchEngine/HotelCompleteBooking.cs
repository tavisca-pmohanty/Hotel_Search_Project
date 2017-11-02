using APITripEngine;
using HotelContract.Model;
using Logger;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;



namespace HotelSearchEngine
{
    public class HotelCompleteBooking
    {
        TripsEngineClient tripsEngineClient;
  
        public HotelCompleteBooking()
        {
            tripsEngineClient =new TripsEngineClient();
        }
        public async Task<CompleteBookingRS> GetResponseAsync(CompleteBookingRQ completeBookingRQ)
        {

            try
            {

                return  await tripsEngineClient.CompleteBookingAsync(completeBookingRQ);
                
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
            finally
            {

                await tripsEngineClient.CloseAsync();
            }
        }
       

    }
}
