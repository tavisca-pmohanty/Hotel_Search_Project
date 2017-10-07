using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelSearchEngine;
using Newtonsoft.Json;
using ServiceProvider;
using Microsoft.AspNetCore.Http;
using HotelSearchRequest;

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("index/hotelListing/search")]
    public class HotelSearchController : Controller
    { 
        [Route("GetHotels")]
        [HttpPost]
        public async Task GetHotelListing([FromBody]HotelSearchRq requestData)
        {
            var request = JsonConvert.SerializeObject(requestData);
            ServiceRepository repository = new ServiceRepository();
            var service=repository.GetService("HotelListing");
            string hotelListing = await service.GetData(request);
            await HttpContext.Response.WriteAsync(hotelListing);
        }
    }
}
