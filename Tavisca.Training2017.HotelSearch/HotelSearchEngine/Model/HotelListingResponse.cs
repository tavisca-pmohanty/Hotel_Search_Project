using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class HotelListingResponse:IResponse
    {
        public List<HotelListingData> HotelListingList { get; set; }
        public HotelListingResponse()
        {
            HotelListingList = new List<HotelListingData>();
        }
    }
}
