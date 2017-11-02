using HotelContract.Contracts;
using System.Collections.Generic;

namespace HotelContract.Model
{
    public class HotelListingResponse
    {
        public List<Hotel> HotelListingList { get; set; }
        public HotelListingResponse()
        {
            HotelListingList = new List<Hotel>();
        }
    }
}
