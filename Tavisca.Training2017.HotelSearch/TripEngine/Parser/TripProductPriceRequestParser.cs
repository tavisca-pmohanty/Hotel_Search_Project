using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripEngineServices;

namespace TripEngine
{
    class TripProductPriceRequestParser
    {
        TripProductPriceRQ pricingRequest;
        public TripProductPriceRequestParser()
        {
            pricingRequest = new TripProductPriceRQ();
        }
        public async Task<TripProductPriceRQ> ParserAsync(RoomPricingRequest request)
        {
            HotelItinerary itinerary = new HotelItinerary();
            Room roomDetails = new Room();
            for (int i = 0; i < request.Itinerary.Rooms.Length; i++)
            {
                if (request.RoomName.Equals(request.Itinerary.Rooms[i].RoomName))
                {

                    roomDetails = request.Itinerary.Rooms[i];
                    break;
                }
            }
            itinerary = request.Itinerary;
            itinerary.Rooms = new Room[1];
            itinerary.Rooms[0] = new Room();
            itinerary.Rooms[0] = roomDetails;
            HotelTripProduct product = new HotelTripProduct();
            product.HotelItinerary = itinerary;
            product.HotelSearchCriterion = request.HotelCriterionData;
            pricingRequest.TripProduct = product;
            pricingRequest.SessionId = request.SessionId;
            pricingRequest.ResultRequested = ResponseType.Unknown;
            pricingRequest.AdditionalInfo = request.HotelCriterionData.Attributes;
            return pricingRequest;
        }
    }
}
