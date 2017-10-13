﻿using HotelEngienSearch;
using HotelSearchEngine.SessionLog;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Json;
using Newtonsoft.Json;
using System.Collections;
using HotelSearchEngine.Model;

namespace HotelSearchEngine
{
    public class RoomRequestParser
    {
        HotelRoomAvailRQ roomRequest;
        public RoomRequestParser()
        {
            roomRequest = new HotelRoomAvailRQ();
         
        }
        public HotelRoomAvailRQ Parser(RoomListingRequest request)
        {
            roomRequest.ResultRequested = ResponseType.Complete;
            roomRequest.SessionId = request.SessionId;
            roomRequest.Itinerary = request.Itinerary;
            roomRequest.HotelSearchCriterion = request.HotelCriterion;
            return roomRequest;
        }
    }
}
