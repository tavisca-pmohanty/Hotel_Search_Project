using Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngine.Parser;
using TripEngineServices;

namespace TripEngine
{
    public class HotelCompleteBooking
    {
        public async Task<CompleteBookingRS> CompleteHotelBooking(TripFolderBookRS request)
        {
            try
            {
                TripsEngineClient tripsEngineClient = new TripsEngineClient();
                CompleteBookingRQ completeBookingRQ = await new CompleteBookingRequestParser().ParserAsync(request);
                CompleteBookingRS completeBookingRS = await tripsEngineClient.CompleteBookingAsync(completeBookingRQ);
                return completeBookingRS;
            }
            catch(Exception ex)
            {
                Log.LogError(ex);
                throw ex;
            }
        }
    }
}
