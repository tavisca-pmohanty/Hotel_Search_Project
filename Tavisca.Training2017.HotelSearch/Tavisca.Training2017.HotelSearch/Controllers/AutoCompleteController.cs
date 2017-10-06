using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tavisca.Training2017.HotelSearch.Controllers
{
    [Route("index/AutoComplete")]
    public class AutoCompleteController : Controller
    {
        // GET: api/values
        [Route("search/{searchTerm}")]
        [HttpGet]
        public  async Task GetHotelSuggestionAsync(string searchTerm)
        {
            ServiceRepository repository = new ServiceRepository();
            var service = repository.GetService("AutoComplete");
            var hotelList = await service.GetHotelSuggestion(searchTerm);
            //var json = JsonConvert.SerializeObject(hotelList);
            await HttpContext.Response.WriteAsync(hotelList);
        }
    }
}
