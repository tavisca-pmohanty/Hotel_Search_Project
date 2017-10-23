using System;
using System.Collections.Generic;
using System.Text;
using TripEngineServices;
using Xunit;

namespace HotelEngineTest
{
    
    class CompleteBookingTest
    {
        [Fact]
        public void Test1()
        {
            TripEngineRequestParser parser = new TripEngineRequestParser();
            CompleteBookingRQ req = parser.GetTripPricing();
            parser.GetResponse();
        }
    }
}
