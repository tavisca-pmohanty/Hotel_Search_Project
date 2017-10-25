using HotelEngienSearch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine.Parser
{
    class HotelListingResponseParser
    {
        List<HotelListingResponse> hotelListingResponseList;
        public HotelListingResponseParser()
        {
            hotelListingResponseList = new List<HotelListingResponse>();
        }
        public async Task<List<HotelListingResponse>> ParserAsync(HotelSearchRS hotelSearchRS)
        {
            HotelListingResponse hotelListingResponse = new HotelListingResponse();
           foreach(var itinerary in hotelSearchRS.Itineraries)
            {
                hotelListingResponse.Address = itinerary.HotelProperty.Address.City.Name;
                hotelListingResponse.SessionId = hotelSearchRS.SessionId;
                hotelListingResponse.HotelName = itinerary.HotelProperty.Name;
                hotelListingResponse.Price = itinerary.Fare.TotalFare.BaseEquivAmount;
                hotelListingResponse.Rating = itinerary.HotelProperty.HotelRating.Rating;
                hotelListingResponse.CurrencyType = itinerary.Fare.TotalFare.Currency;
                for(int i=0;i<itinerary.HotelProperty.MediaContent.Length;i++)
                {
                    if(itinerary.HotelProperty.MediaContent[i].Url!=String.Empty)
                    {
                        hotelListingResponse.ImageUrl = itinerary.HotelProperty.MediaContent[i].Url;
                        break;
                    }
                }
                hotelListingResponseList.Add(hotelListingResponse);
            }
            return hotelListingResponseList;
        }
    }
}
