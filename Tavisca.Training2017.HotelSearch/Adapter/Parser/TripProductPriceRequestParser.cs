﻿using APITripEngine;
using Cache.CacheData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelEngienSearch;
using HotelContract.Contracts;
using HotelContract.Model;

namespace Adapter.Parser
{
    public class TripProductPriceRequestParser
    {
        TripProductPriceRQ pricingRequest;
        public TripProductPriceRequestParser()
        {
            pricingRequest = new TripProductPriceRQ();
        }
        public async Task<TripProductPriceRQ> ParserAsync(RoomPricingRequest request)
        {
            HotelEngienSearch.HotelItinerary itinerary = GetCachedItinerary(request.SessionId);
            HotelEngienSearch.Room roomDetails = new HotelEngienSearch.Room();
            for (int i = 0; i < itinerary.Rooms.Length; i++)
            {
                if (request.RoomName.Equals(itinerary.Rooms[i].RoomName))
                {
                    roomDetails = itinerary.Rooms[i];
                    break;
                }
            }
            itinerary.Rooms = new HotelEngienSearch.Room[1];
            itinerary.Rooms[0] = new HotelEngienSearch.Room();
            itinerary.Rooms[0] = roomDetails;
            HotelTripProduct product = new HotelTripProduct();
            string jsonItinerary = JsonConvert.SerializeObject(itinerary);
            product.HotelItinerary = JsonConvert.DeserializeObject<APITripEngine.HotelItinerary>(jsonItinerary);
            HotelEngienSearch.HotelSearchCriterion hotelSearchCriterion = GetCachedCriterion(request.SessionId);
            string jsonCriterion = JsonConvert.SerializeObject(hotelSearchCriterion);
            product.HotelSearchCriterion = JsonConvert.DeserializeObject<APITripEngine.HotelSearchCriterion>(jsonCriterion);
            pricingRequest.TripProduct = product;
            pricingRequest.SessionId = request.SessionId;
            pricingRequest.ResultRequested = APITripEngine.ResponseType.Unknown;
            pricingRequest.AdditionalInfo = product.HotelSearchCriterion.Attributes;
            return pricingRequest;
        }

        public HotelEngienSearch.HotelSearchCriterion GetCachedCriterion(string sessionId)
        {
            HotelSearchCriterionCache hotelSearchCriterionCache = new HotelSearchCriterionCache();
            HotelEngienSearch.HotelSearchCriterion hotelSearchCriterion = new HotelEngienSearch.HotelSearchCriterion();
            if (hotelSearchCriterionCache.CheckIfPresent(sessionId))
            {
                hotelSearchCriterion = hotelSearchCriterionCache.FetchCriterion(sessionId);
            }
            return hotelSearchCriterion;
        }

        public HotelEngienSearch.HotelItinerary GetCachedItinerary(string sessionId)
        {
            HotelEngienSearch.HotelItinerary hotelItinerary = new HotelEngienSearch.HotelItinerary();
            SingleAvailCache singleAvailCache = new SingleAvailCache();
            if (singleAvailCache.CheckIfPresent(sessionId))
            {
                hotelItinerary = singleAvailCache.FetchItinerary(sessionId);
            }
            return hotelItinerary;
        }
    }
}
