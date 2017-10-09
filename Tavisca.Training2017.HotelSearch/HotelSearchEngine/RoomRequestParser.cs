using HotelEngienSearch;
using HotelSearchEngine.SessionLog;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Json;
using Newtonsoft.Json;

namespace HotelSearchEngine
{
    public class RoomRequestParser
    {
        HotelRoomAvailRQ roomRequest;
        public RoomRequestParser()
        {
            roomRequest = new HotelRoomAvailRQ();
         
        }
        public HotelRoomAvailRQ Parser(HotelListingResponse request)
        {
            var stream = File.OpenText("D:\\Hotel_Search_Project\\Tavisca.Training2017.HotelSearch\\HotelSearchEngine\\SessionLog\\HotelSearchCriterion_Json.txt");             
            string data = stream.ReadToEnd();
            var sessionData = JsonConvert.DeserializeObject<SessionData>(data);
            roomRequest.ResultRequested = ResponseType.Complete;
            roomRequest.SessionId = request.SessionId;
            roomRequest.Itinerary = request.Itinerary;
            roomRequest.HotelSearchCriterion = sessionData.HotelSearchCriterionData;
            return roomRequest;
        }
    }
}
