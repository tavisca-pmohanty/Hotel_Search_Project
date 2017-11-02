using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceProvider
{
    public class ServiceRepository
    {
        Dictionary<string, Notifier> services;
        public ServiceRepository()
        {
            services = new Dictionary<string, Notifier>();
            services.Add("AutoComplete", new HotelSuggestionService());
            services.Add("HotelListing", new HotelListingService());
            services.Add("HotelRooms", new RoomInfoService());
            services.Add("RoomPricing", new RoomPricingService());
            services.Add("BookTrip", new BookTripService());
            services.Add("CompleteBooking", new CompleteBookingService());
            //services.Add("Notification", new NotificationService());
            services.Add("SmsAlert", new MessageService());
        }
        public Notifier GetService(string serviceType)
        {
            return services[serviceType];
        }
    }
}

