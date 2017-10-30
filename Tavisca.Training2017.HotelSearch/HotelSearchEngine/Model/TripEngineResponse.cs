using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class TripEngineResponse:IResponse
    {
        public string SessionId { get; set; }
    }
}
