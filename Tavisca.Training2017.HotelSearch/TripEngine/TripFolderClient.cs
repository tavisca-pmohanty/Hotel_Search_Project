using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngine.Models;
using TripEngineServices;

namespace TripEngine
{
    public class TripFolderClient
    {
        public async Task<TripFolderBookRS> GetTripFolderAsync(HotelSearchBookingRequest request)
        {
            TripsEngineClient tripsEngineClient = new TripsEngineClient();
            TripFolderBookRQ tripFolderBookRQ = await new TripFolderBookRQparser().ParserAsync(request);
            TripFolderBookRS response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
            return response;
        }
    }
}
