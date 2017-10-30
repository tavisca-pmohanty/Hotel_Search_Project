using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class HotelRoomAvailResponse:IResponse
    {
        public List<HotelRoomAvailData> HotelRoomList { get; set; }
        public HotelRoomAvailResponse()
        {
            HotelRoomList = new List<HotelRoomAvailData>();
        }
    }
}
