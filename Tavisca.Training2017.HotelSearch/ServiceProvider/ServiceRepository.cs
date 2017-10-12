using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProvider
{
    public class ServiceRepository
    {
        Dictionary<string, IHotelService> services;
        public ServiceRepository()
        {
            services = new Dictionary<string, IHotelService>();
            services.Add("AutoComplete", new HotelSuggestionService());
            services.Add("HotelListing", new HotelListingService());
            services.Add("HotelRooms", new RoomInfoService());
            services.Add("RoomPricing", new RoomPricingService());
           // services.Add("BookTripFolder", new BookTripService());
        }
        public IHotelService GetService(string serviceType)
        {
            return services[serviceType];
        }
    }
}
