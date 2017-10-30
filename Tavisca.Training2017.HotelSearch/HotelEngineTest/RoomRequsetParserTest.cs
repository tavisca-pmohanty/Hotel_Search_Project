using System;
using Xunit;
using HotelSearchEngine;
using HotelEngienSearch;
namespace HotelEngineTest
{
    public class RoomRequsetParserTest
    {
        [Fact]
        public void Test1()
        {
            RoomListingRequest res = new RoomListingRequest();
            RoomRequestParser parser = new RoomRequestParser();
            parser.ParserAsync(res);
        }
    }
}
