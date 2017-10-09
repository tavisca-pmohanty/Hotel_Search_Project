using System;
using Xunit;
using HotelSearchEngine;
using HotelEngienSearch;

namespace HotelEngineTest
{
    public class RoomRequsetParserTest
    {
        [Fact]
        public void Room_Request_Parsing_Test()
        {
            HotelListingResponse res = new HotelListingResponse();
            RoomRequestParser parser = new RoomRequestParser();
            parser.Parser(res);
        }
        [Fact]
        public async void Getting_Room_Response_For_A_Request__Test()
        {
            HotelEngineClient client = new HotelEngineClient();
            HotelRoomAvailRQ request = new HotelRoomAvailRQ();
            HotelRoomAvailRS response = await client.HotelRoomAvailAsync(request);
            Assert.True(true);
        }
    }
}
