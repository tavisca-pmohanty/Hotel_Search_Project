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
           
           for(int i=0;i<hotelSearchRS.Itineraries.Length;i++)
            {
                HotelListingResponse hotelListingResponse = new HotelListingResponse();
                hotelListingResponse.Address = hotelSearchRS.Itineraries[i].HotelProperty.Address.City.Name;
                hotelListingResponse.SessionId = hotelSearchRS.SessionId;
                hotelListingResponse.HotelName = hotelSearchRS.Itineraries[i].HotelProperty.Name;
                hotelListingResponse.Price = hotelSearchRS.Itineraries[i].Fare.TotalFare.BaseEquivAmount;
                hotelListingResponse.Rating = hotelSearchRS.Itineraries[i].HotelProperty.HotelRating.Rating;
                hotelListingResponse.CurrencyType = hotelSearchRS.Itineraries[i].Fare.TotalFare.Currency;
                for(int j=0;j< hotelSearchRS.Itineraries[i].HotelProperty.MediaContent.Length;j++)
                {
                    if(hotelSearchRS.Itineraries[i].HotelProperty.MediaContent[j].Url!=String.Empty)
                    {
                        hotelListingResponse.ImageUrl = hotelSearchRS.Itineraries[i].HotelProperty.MediaContent[j].Url;
                        break;
                    }
                }
                hotelListingResponse.SupplierName = hotelSearchRS.Itineraries[i].HotelFareSource.Name;
                hotelListingResponseList.Add(hotelListingResponse);
            }
            return hotelListingResponseList;
        }
    }
}
