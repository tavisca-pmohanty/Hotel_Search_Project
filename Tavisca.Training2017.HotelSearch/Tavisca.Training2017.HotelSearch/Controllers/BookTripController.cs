using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelSearchEngine;
using ServiceProvider;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    public class BookTripController : Controller
    {
        [Route("GetBookController")]
        [HttpGet]
        public async Task GetBookController([FromBody] string requestData)
        {
            ServiceRepository repository = new ServiceRepository();
            var service = repository.GetService("BookTripFolder");
            string roomPricingData = await service.GetRequestedData(requestData);
            await HttpContext.Response.WriteAsync(roomPricingData);
        }

    }
}
