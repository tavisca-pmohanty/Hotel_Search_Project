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
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            TripFolderBookRQ tripFolderBookRQ = await new TripFolderBookRQparser().Get(request);
            TripFolderBookRS tripFolderBookRS = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
            return tripFolderBookRS;
        }
    }
}
