using HotelEngienSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelSearchEngine;
using HotelSearchRequest;


namespace ServiceProvider
{
    class HotelListingService:IHotelService
    {
        List<HotelItinerary> itineraries;
        public HotelListingService()
        {
            itineraries = new List<HotelItinerary>();
        }

        public async Task<string> GetData(string request)
        {
            HotelSearch search = new HotelSearch();
            var hotelRequest = JsonConvert.DeserializeObject<HotelSearchRq>(request);
            itineraries = await search.GetHotelListing(hotelRequest);
            List<Hotel> parsedlist = new List<Hotel>();
            //Add a parser over here to your own custom object
            foreach(var hotelItinerary in itineraries)
            {
                Hotel hotel = new Hotel();
                hotel.Name = hotelItinerary.HotelProperty.Name;
                hotel.Address = hotelItinerary.HotelProperty.Address.CompleteAddress;
                hotel.HotelId = hotelItinerary.HotelProperty.Id;
                hotel.Price = hotelItinerary.Fare.BaseFare.Amount;
                parsedlist.Add(hotel);
            }

            return JsonConvert.SerializeObject(parsedlist);
           
        }
    }
}
