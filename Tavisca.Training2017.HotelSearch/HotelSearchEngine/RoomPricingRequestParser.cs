using HotelEngienSearch;
using HotelSearchEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelSearchEngine
{
    class RoomPricingRequestParser
    {
        HotelRoomPriceRQ pricingRequest;
        public RoomPricingRequestParser()
        {
            pricingRequest = new HotelRoomPriceRQ();
        }
        public HotelRoomPriceRQ Parser(HotelRoomAvailResponse request)
        {
            pricingRequest.HotelSearchCriterion = request.HotelCriterionData;
            pricingRequest.Itinerary = request.Itinerary;
            pricingRequest.SessionId = request.SessionId;
            pricingRequest.ResultRequested = ResponseType.Complete;
            pricingRequest.AdditionalInfo = request.HotelCriterionData.Attributes;
            return pricingRequest;
        }
    }
}
