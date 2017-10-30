using HotelSearchEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine.Model
{
    public class CompleteBookingRequest:IRequest
    {
        public string SessionId { get; set; }
    }
}
