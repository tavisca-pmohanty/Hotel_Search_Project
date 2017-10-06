﻿using System;
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
        }
        public IHotelService GetService(string serviceType)
        {
            IHotelService service=null;
            switch(serviceType)
            {
                case "AutoComplete":
                    service= new HotelSuggestionService();
                    break;                    
            }
            return service;
        }
    }
}
