using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngineServices;

namespace TripEngine
{
    public class TripFolderClient
    {
        public async Task<TripFolderBookRS> GetTripFolderAsync(HotelSearchRequestBooking request)
        {
            try
            {
                TripsEngineClient tripsEngineClient = new TripsEngineClient();
                TripFolderBookRQ tripFolderBookRQ = await new TripFolderBookRQparser().Get(request);
                TripFolderBookRS tripFolderBookRS = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
                return tripFolderBookRS;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
