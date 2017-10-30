using HotelEngienSearch;
using HotelSearchEngine.Contracts;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelSearchEngine.Parser
{
    class HotelListingResponseParser
    {
        HotelListingResponse hotelListingResponseList;
        public HotelListingResponseParser()
        {
            hotelListingResponseList = new HotelListingResponse();
        }
        public async Task<IResponse> ParserAsync(HotelSearchRS hotelSearchRS)
        {
           
           for(int i=0;i<hotelSearchRS.Itineraries.Length;i++)
            {
                HotelListingData hotelListingResponse = new HotelListingData();
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
                for (int k = 0; k < hotelSearchRS.Itineraries[i].HotelProperty.Descriptions.Length; k++)
                {
                    if (hotelSearchRS.Itineraries[i].HotelProperty.Descriptions[k].Description != null)
                    {
                        hotelListingResponse.Description = hotelSearchRS.Itineraries[i].HotelProperty.Descriptions[0].Description;
                        break;
                    }
                }
                hotelListingResponseList.HotelListingList.Add(hotelListingResponse);
            }
            return hotelListingResponseList;
        }
    }
}
