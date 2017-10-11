using System;
using Xunit;
using HotelSearchEngine;
<<<<<<< HEAD
using HotelEngienSearch;
=======
using TripEngineServices;
>>>>>>> Updated Layout with Trip Engine parsing

namespace HotelEngineTest
{
    public class RoomRequsetParserTest
    {
        [Fact]
        public void Test1()
        {
            RoomListingRequest res = new RoomListingRequest();
            RoomRequestParser parser = new RoomRequestParser();
            parser.Parser(res);
        }
    }
}
