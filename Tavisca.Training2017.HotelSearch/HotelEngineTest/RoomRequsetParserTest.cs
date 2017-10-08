using System;
using Xunit;
using HotelSearchEngine;

namespace HotelEngineTest
{
    public class RoomRequsetParserTest
    {
        [Fact]
        public void Test1()
        {
            HotelListingResponse res = new HotelListingResponse();
            RoomRequestParser parser = new RoomRequestParser();
            parser.Parser(res);
        }
    }
}
