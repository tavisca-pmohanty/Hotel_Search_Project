using HotelContract.Contracts;
using System.Collections.Generic;

namespace HotelContract.Model
{
    public class HotelRoomAvailResponse
    {
        public List<HotelRoomAvailData> HotelRoomList { get; set; }
        public HotelRoomAvailResponse()
        {
            HotelRoomList = new List<HotelRoomAvailData>();
        }
    }
}
