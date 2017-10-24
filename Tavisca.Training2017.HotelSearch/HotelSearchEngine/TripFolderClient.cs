﻿using APITripEngine;
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
        public async Task<TripFolderBookRS> GetTripFolderAsync(HotelSearchBookingRequest request)
        {
            try
            {
                tripsEngineClient = new TripsEngineClient();
                TripFolderBookRQ tripFolderBookRQ = await new TripFolderBookRQparser().ParserAsync(request);
                TripFolderBookRS response = await tripsEngineClient.BookTripFolderAsync(tripFolderBookRQ);
                return response;
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
    }
}