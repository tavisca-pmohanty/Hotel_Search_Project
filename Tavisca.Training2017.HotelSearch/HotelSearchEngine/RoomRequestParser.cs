using HotelEngienSearch;
using HotelSearchEngine.SessionLog;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Json;
using Newtonsoft.Json;
using System.Collections;

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
            //var stream = File.OpenText(@"D:\Hotel_Search_Project\Tavisca.Training2017.HotelSearch\HotelSearchEngine\SessionLog\HotelSearchCriterion_Json.txt");
            //string data = stream.ReadToEnd();
            //var sessionDataList = JsonConvert.DeserializeObject<SessionData>(data);
            roomRequest.ResultRequested = ResponseType.Complete;
            roomRequest.SessionId = request.SessionId;
            roomRequest.Itinerary = request.Itinerary;
            //foreach (var sessionData in sessionDataList)
            //{
            //    if (sessionData.SessionId.Equals(request.SessionId))
            //    {
            //        roomRequest.HotelSearchCriterion = sessionData.HotelSearchCriterionData;
            //        break;
            //    }
            //}
            roomRequest.HotelSearchCriterion = request.HotelCriterion;
            return roomRequest;
        }
    }
}
