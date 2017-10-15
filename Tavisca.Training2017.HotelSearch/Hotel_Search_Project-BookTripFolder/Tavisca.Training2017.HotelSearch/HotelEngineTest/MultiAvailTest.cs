using System;
using Xunit;
using HotelSearchEngine;
using HotelEngienSearch;
using System.Collections.Generic;

namespace HotelEngineTest
{
    public class MultiAvailTest
    {
        [Fact]
        public async void Sending_Request_To_Hotel_Engine_To_Get_Hotel_List()
        {
            HotelSearchRq request = new HotelSearchRq();
            request.Adults = "2";
            request.Children = "0";
            request.InDate = new DateTime(2017, 10, 8);
            request.OutDate = new DateTime(2017, 10, 10);
            request.Rooms = "1";
            request.SelectedHotel = new HotelSuggestionRS();
            request.SelectedHotel.HotelName = "Catania S. Giovanni LA Pu";
            request.SelectedHotel.ID = "15773";
            request.SelectedHotel.CityName = "Catania S. Giovanni LA Pu";
            request.SelectedHotel.CountryCode = "IT";
            request.SelectedHotel.CulteredText = "Catania S. Giovanni LA Pu, Italy";
            request.SelectedHotel.Latitude = "37.5106032046717";
            request.SelectedHotel.Longitude = "15.0681298468366";
            request.SelectedHotel.SearchType = "City";
            request.SelectedHotel.StateCode = "";
            HotelSearch search = new HotelSearch();
            List<HotelListingResponse> hotelItinerary=await search.GetHotelListing(request);
            bool itemsInList = false;
            if(hotelItinerary.Count>0)
            {
                itemsInList = true;
            }
            Assert.True(itemsInList);
        }
    }
}
