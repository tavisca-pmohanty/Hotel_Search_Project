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
            services.Add("Autocomplete", new HotelSuggestionService());
            services.Add("HotelListing", new HotelListingService());
            services.Add("HotelRooms", new RoomInfoService());
        }
        public IHotelService GetService(string serviceType)
        {
            IHotelService service=null;
           
            return service=services[serviceType];
        }
    }
}
