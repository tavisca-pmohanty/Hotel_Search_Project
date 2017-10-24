﻿using Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngine.Models;
using TripEngine.Parser;
using TripEngineServices;

namespace TripEngine
{
    public class HotelCompleteBooking
    {
        TripsEngineClient tripsEngineClient;
        public HotelCompleteBooking()
        {
            tripsEngineClient =new TripsEngineClient();
        }
        public async Task<CompleteBookingResponse> CompleteHotelBooking(TripFolderBookRS request)
        {

            try
            {
              
                CompleteBookingRQ completeBookingRQ = await new CompleteBookingRequestParser().ParserAsync(request);
                CompleteBookingRS completeBookingRS = await tripsEngineClient.CompleteBookingAsync(completeBookingRQ);
                CompleteBookingResponse completeBookingResponse = await new CompleteBookingResponseParser().ResponseParserAsync(completeBookingRS);
                return completeBookingResponse;
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
